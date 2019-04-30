using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using staleLauncher.Properties;
using sqlTools;
using System.ComponentModel;
using System.ServiceProcess;
using Microsoft.SqlServer;

namespace staleLauncher
{
    public partial class ServerControl : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1, HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static string serverPath, worldExe, authExe, bnetExe;

        public static bool intentionedStop = false;
        
        SqlConnectForm sqlConnectForm;
        public static ServiceController mySqlController = new ServiceController();
        public static string mySqlServiceName = "";
        public static string mySqlExe = "mysqld";
        public static Form sqlProcess = null;
        About aboutPage = null;

        public static ProcessStartInfo worldServerStartInfo = new ProcessStartInfo();
        public static ProcessStartInfo bnetServerStartInfo = new ProcessStartInfo();
        public static ProcessStartInfo authServerStartInfo = new ProcessStartInfo();
        private static Process worldServer = null;
        private static Process authServer = null;
        private static Process bnetServer = null;


        private BackgroundWorker worldConsoleOutputWorker = new BackgroundWorker();
        private BackgroundWorker worldConsoleOutputErrorWorker = new BackgroundWorker();
        StreamWriter worldStreamWriter;

        private bool ClearDBErrors { get { return Settings.Default.clearDBErrors; } set { Settings.Default.clearDBErrors = value; } }
        private bool DeleteClientCache { get { return Settings.Default.deleteClientCache; } set { Settings.Default.deleteClientCache = value; } }
        private bool HideProcesses { get { return Settings.Default.hideProcesses; } set { Settings.Default.hideProcesses = value; } }

        public void CommandForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public ServerControl()
        {
            InitializeComponent();

            authServerStartInfo.WorkingDirectory = worldServerStartInfo.WorkingDirectory = bnetServerStartInfo.WorkingDirectory = serverPath;
            authServerStartInfo.FileName = serverPath + "\\" + authExe + ".exe";
            worldServerStartInfo.FileName = serverPath + "\\" + worldExe + ".exe";
            bnetServerStartInfo.FileName = serverPath + "\\" + bnetExe + ".exe";
            mySqlController.ServiceName = mySqlServiceName;

            if (string.IsNullOrEmpty(StaleLauncher.clientPath) || string.IsNullOrEmpty(StaleLauncher.clientLocale) || string.IsNullOrEmpty(StaleLauncher.clientExe))
            {
                if (StaleLauncher.clientPathWarning == "true")
                    MessageBox.Show("Client configuration in StaleConfig.xml is incomplete", "Warning");
                launchClientToolStripMenuItem.Dispose();
                clientToolStripMenuItem.Dispose();
            }
                

            FormClosing += new FormClosingEventHandler(OnFormExit);
            MouseDown += new MouseEventHandler(CommandForm_MouseDown);

            worldConsoleOutputWorker.WorkerReportsProgress = worldConsoleOutputWorker.WorkerSupportsCancellation = true;
            worldConsoleOutputWorker.ProgressChanged += WorldConsoleOutputWorker_ProgressChanged;
            worldConsoleOutputWorker.DoWork += WorldConsoleOutputWorker_DoWork;

            worldConsoleOutputErrorWorker.WorkerReportsProgress = worldConsoleOutputErrorWorker.WorkerSupportsCancellation = true;
            worldConsoleOutputErrorWorker.ProgressChanged += WorldConsoleOutputErrorWorker_ProgressChanged;
            worldConsoleOutputErrorWorker.DoWork += WorldConsoleOutputErrorWorker_DoWork;


            worldServer = GetServerProcess(worldExe);
            if (worldServer != null && worldServer.StartInfo == worldServerStartInfo) { worldServer.EnableRaisingEvents = true; worldServer.Exited += (worldServer, EventArgs) =>
            { serverProcessExit(worldServer, EventArgs, worldExe); }; };
            authServer = GetServerProcess(authExe);
            if (authServer != null && authServer.StartInfo == authServerStartInfo) { authServer.EnableRaisingEvents = true; authServer.Exited += (authServer, EventArgs) =>
            { serverProcessExit(authServer, EventArgs, authExe); }; };
            bnetServer = GetServerProcess(bnetExe);
            if (bnetServer != null) { bnetServer.EnableRaisingEvents = true; bnetServer.Exited += (bnetServer, EventArgs) =>
                { serverProcessExit(bnetServer, EventArgs, bnetExe); }; };
            UpdateServerButtons();
            SyncCheckboxSettings();
        }

        private void WorldConsoleOutputWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader StandardOutput = e.Argument as StreamReader;
            string data = StandardOutput.ReadLine();
            while (data != null)
            {
                worldConsoleOutputWorker.ReportProgress(100, data);
                data = StandardOutput.ReadLine();
            }
        }

        private void WorldConsoleOutputErrorWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader StandardOutput = e.Argument as StreamReader;

            string data = worldServer == null ? StandardOutput.ReadToEnd() : StandardOutput.ReadLine();
            //string data = StandardOutput.ReadLine();
            while (data != null)
            {
                worldConsoleOutputErrorWorker.ReportProgress(100, data);
                data = worldServer == null ? StandardOutput.ReadToEnd() : StandardOutput.ReadLine();
            }
        }

        private void WorldConsoleOutputWorker_Exit(object sender, DoWorkEventArgs e)
        {
            StreamReader StandardOutput = e.Argument as StreamReader;
            string data = worldServer.HasExited ? StandardOutput.ReadToEnd() : StandardOutput.ReadLine();
            while (data != null)
            {
                worldConsoleOutputErrorWorker.ReportProgress(100, data);
                data = StandardOutput.ReadToEnd();
            }
        }

        private void WorldConsoleOutputWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            worldConsoleTextBox.Invoke(new Action(() => worldConsoleTextBox.AppendText(e.UserState as string + "\r\n"))); }

        private void WorldConsoleOutputErrorWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            DBErrorsTextBox.Invoke(new Action(() => DBErrorsTextBox.AppendText(e.UserState as string + "\r\n"))); }

        public void launcherLogInsert(string newText, RichTextBox consoleWindow) {
            consoleWindow.Invoke(new Action(() => consoleWindow.AppendText(System.DateTime.Now.ToLocalTime().ToLongTimeString() + ": " + newText + Environment.NewLine))); }
                
        private void SyncCheckboxSettings()
        {
            restartProcessesToolStripMenuItem.Checked = Settings.Default.restartProcesses;
            hideProcessesToolStripMenuItem.Checked = Settings.Default.hideProcesses;
            clearDBErrorsToolStripMenuItem.Checked = Settings.Default.clearDBErrors;
            clearClientCacheToolStripMenuItem.Checked = Settings.Default.deleteClientCache;
            showInTaskbarToolStripMenuItem.Checked = Settings.Default.showInTaskbar;
            ShowInTaskbar = Settings.Default.showInTaskbar;
            showTrayIconToolStripMenuItem.Checked = Settings.Default.showTrayIcon;
            clearConsoleToolStripMenuItem.Checked = Settings.Default.clearConsoleOnStartup;

            switch (Settings.Default.iconString)
            {
                case "worldserver":
                    redworldserverToolStripMenuItem.Checked = true;
                    Icon = Resources.worldserver;
                    break;
                case "authserver":
                    blueauthserverToolStripMenuItem.Checked = true;
                    Icon = Resources.authserver;
                    break;
                case "WoW1":
                    warcraft1ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW;
                    break;
                case "WoW2":
                    warcraft2ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW2;
                    break;
                case "WoW3":
                    warcraft3ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW3;
                    break;
                case "WoW4":
                    warcraft4ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW4;
                    break;
            }
        }

        public void UpdateServerButtons()
        {
            if (authServer == null)
            {
                authServer_toggleButton.BackColor = System.Drawing.Color.LightSteelBlue;
                authServer_toggleButton.Image = Resources.greyscale.ToBitmap();
            }
            else
            {
                authServer_toggleButton.BackColor = System.Drawing.Color.DodgerBlue;
                authServer_toggleButton.Image = Resources.authserver.ToBitmap();
            }
            if (worldServer == null)
            {
                worldServer_toggleButton.BackColor = System.Drawing.Color.MistyRose;
                worldServer_toggleButton.Image = Resources.greyscale.ToBitmap();
            }   
            else
            {
                worldServer_toggleButton.Image = Resources.worldserver.ToBitmap();
                worldServer_toggleButton.BackColor = System.Drawing.Color.Red;
            }
            if (bnetServer == null)
            {
                bnetServer_toggleButton.BackColor = System.Drawing.Color.LightSteelBlue;
                bnetServer_toggleButton.Image = Resources.greyscale.ToBitmap();
            }
            else
            {
                bnetServer_toggleButton.Image = Resources.authserver.ToBitmap();
                bnetServer_toggleButton.BackColor = System.Drawing.Color.DodgerBlue;
            }
            if (GetServerProcess(mySqlExe) == null)
            {
                MySql_ToggleButton.BackColor = System.Drawing.Color.Silver;
                MySql_ToggleButton.Image = Resources.mysql_white.ToBitmap();
            }
            else
            {
                MySql_ToggleButton.Image = Resources.mysql.ToBitmap();
                MySql_ToggleButton.BackColor = System.Drawing.Color.White;
            }                
        }

        private void serverProcessExit(Object sender, EventArgs e, string processType)
        {
            if (!intentionedStop)
            {
                launcherLogInsert(processType + " unintentionally exited.", eventLogTextBox);
                System.Media.SystemSounds.Exclamation.Play();
            }
            else launcherLogInsert(processType + " stopped.", eventLogTextBox);

            if (processType == worldExe) worldServer = null;
            if (processType == authExe) authServer = null;
            if (processType == bnetExe) bnetServer = null;

            UpdateServerButtons();
        }

        private Process GetServerProcess(string processExe)
        {
            if (Process.GetProcessesByName(processExe).Length > 1)
                MessageBox.Show("There are more than one " + processExe + " processes running.", "Warning");
            if (Process.GetProcessesByName(processExe).Length > 0) // remember length is NOT 0 based
                return Process.GetProcessesByName(processExe)[0];
            else return null;
        }


        public void ToggleServerButton(Object sender, EventArgs e)
        {
            intentionedStop = true; // disable the alarm

            if (sender == worldServer_toggleButton)
            {
                if (worldServer == null)
                {
                    if (Settings.Default.clearDBErrors == true && File.Exists(serverPath + "\\" + "DBErrors.log"))
                        File.Delete(serverPath + "\\" + "DBErrors.log");
                    StartServerExe(worldServerStartInfo);
                }
                else
                    worldServer.Kill();
            }
            else if (sender == authServer_toggleButton)
            {
                if (authServer == null)
                    StartServerExe(authServerStartInfo);
                else
                    authServer.Kill();
            }
            else if (sender == bnetServer_toggleButton)
            {
                if (bnetServer == null)
                    StartServerExe(bnetServerStartInfo);
                else
                    bnetServer.Kill();
            }
            else if (sender == MySql_ToggleButton)
                ToggleSqlServer();
            UpdateServerButtons();
        }

        public void ToggleSqlServer()
        {
            try
            {
                if (GetServerProcess(mySqlExe) != null)
                {
                    mySqlController.Stop();
                    mySqlController.WaitForStatus(ServiceControllerStatus.Stopped);
                    launcherLogInsert(mySqlServiceName + " stopped.", eventLogTextBox);
                }
                else
                {
                    mySqlController.Start();
                    mySqlController.WaitForStatus(ServiceControllerStatus.Running);
                    launcherLogInsert(mySqlServiceName + " started.", eventLogTextBox);
                }
            }
            catch
            {
                MessageBox.Show("Error starting/stopping SQL service. Try running as administrator.", "Error");
            }
        }

        public void StartServerExe(ProcessStartInfo serverStartInfo)
        {
            if (File.Exists(serverStartInfo.FileName))
            {   
                if (Settings.Default.hideProcesses)
                {
                    serverStartInfo.UseShellExecute = false;
                    serverStartInfo.CreateNoWindow = true;
                }
                else
                {
                    serverStartInfo.UseShellExecute = true;
                    serverStartInfo.CreateNoWindow = false;
                }
                    

                if (serverStartInfo == worldServerStartInfo)
                {
                    if (Settings.Default.clearConsoleOnStartup)
                    {
                        DBErrorsTextBox.Text = "";
                        worldConsoleTextBox.Text = "";
                    }                        

                    if (Settings.Default.hideProcesses)
                        serverStartInfo.RedirectStandardOutput = serverStartInfo.RedirectStandardError = serverStartInfo.RedirectStandardInput = true;

                    worldServer = Process.Start(serverStartInfo);
                    worldServer.EnableRaisingEvents = true;
                    worldServer.Exited += (worldServer, EventArgs) => { serverProcessExit(worldServer, EventArgs, worldExe); };
                    launcherLogInsert(worldExe + " started.", eventLogTextBox);

                    if (Settings.Default.hideProcesses)
                    {
                        worldConsoleOutputWorker.RunWorkerAsync(worldServer.StandardOutput);
                        worldConsoleOutputErrorWorker.RunWorkerAsync(worldServer.StandardError);
                        worldStreamWriter = worldServer.StandardInput;
                    }                    
                }
                else if (serverStartInfo == authServerStartInfo)
                {
                    authServer = Process.Start(serverStartInfo);
                    launcherLogInsert(authExe + " started.", eventLogTextBox);
                    authServer.EnableRaisingEvents = true;
                    authServer.Exited += (authServer, EventArgs) => { serverProcessExit(authServer, EventArgs, authExe); };
                }
                else if (serverStartInfo == bnetServerStartInfo)
                {
                    bnetServer = Process.Start(serverStartInfo);
                    launcherLogInsert(bnetExe + " started.", eventLogTextBox);
                    bnetServer.EnableRaisingEvents = true;
                    bnetServer.Exited += (bnetServer, EventArgs) => { serverProcessExit(bnetServer, EventArgs, bnetExe); };
                }
            }
            else
                MessageBox.Show(serverStartInfo.FileName.ToString() + " not found", "Error");
            intentionedStop = false; // reset the alarm
        }

        public void ToggleTrayIcon(bool enabled)
        {
            Settings.Default.showTrayIcon = StaleLauncher._trayIcon.Visible = enabled;
            MinimizeBox = !enabled;
            if (enabled)
                StaleLauncher._serverControl.FormClosed -= new FormClosedEventHandler(Exit);
            else
                StaleLauncher._serverControl.FormClosed += new FormClosedEventHandler(Exit);
        }

        private void OpenFileOrDirectory(string path)
        {
            if (File.Exists(path))
                Process.Start(path);
            else if (Directory.Exists(path))
                Process.Start(path);
            else
            {
                MessageBox.Show("\"" + path + "\"" + " could not be found.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        //    TASKBAR CLICK EVENTS
        private void OpenFileOrFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (sender.ToString())
            {
                case "Client Folder":
                    OpenFileOrDirectory(StaleLauncher.clientPath);
                    break;
                case "Server Folder":
                    OpenFileOrDirectory(serverPath);
                    break;
                case "DBErrors.log":
                    OpenFileOrDirectory(serverPath + "\\" + "DBErrors.log");
                    break;
                case "Server.log":
                    OpenFileOrDirectory(serverPath + "\\" + "Server.log");
                    break;
                case "Auth.log":
                    OpenFileOrDirectory(serverPath + "\\" + "Auth.log");
                    break;
                case "worldserver.conf":
                    OpenFileOrDirectory(serverPath + "\\" + "worldserver.conf");
                    break;
                case "authserver.conf":
                    OpenFileOrDirectory(serverPath + "\\" + "authserver.conf");
                    break;
                case "staleconfigxmlToolStripMenuItem":
                    OpenFileOrDirectory(Application.StartupPath + "\\" + "staleconfig.xml");
                    break;
                case "realmlist.wtf":
                    OpenFileOrDirectory(StaleLauncher.clientPath + "\\Data\\" + StaleLauncher.clientLocale + "\\" + "realmlist.wtf");
                    break;
                case "Launch Client":
                    StaleLauncher.LaunchClient();
                    break;
            }
        }
       // private void clearLogToolStripMenuItem_Click(object sender, EventArgs e) {
      //      launcherLog.Invoke(new Action(() => launcherLog.Text = null)); }

        //    FILESTRIP "OPTIONS" TOGGLES
        private void restartProcessesToolStripMenuItem_Click(object sender, EventArgs e) { Settings.Default.restartProcesses = restartProcessesToolStripMenuItem.Checked; }
        private void clearDBErrorsToolStripMenuItem_Click(object sender, EventArgs e) { ClearDBErrors = clearDBErrorsToolStripMenuItem.Checked; }
        private void clearClientCacheToolStripMenuItem_Click(object sender, EventArgs e) { DeleteClientCache = clearClientCacheToolStripMenuItem.Checked; }
        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e) { Settings.Default.clearConsoleOnStartup = clearConsoleToolStripMenuItem.Checked; }
        private void hideProcessesToolStripMenuItem_Click(object sender, EventArgs e) { Settings.Default.hideProcesses = hideProcessesToolStripMenuItem.Checked; }

        //  3: Launcher @TODO can condense these somewhere?
        private void showInTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = showInTaskbarToolStripMenuItem.Checked;

            if (!showTrayIconToolStripMenuItem.Checked && !showInTaskbarToolStripMenuItem.Checked)
            {
                ToggleTrayIcon(true);
                showTrayIconToolStripMenuItem.Checked = true;
            }            
        }

        private void showTrayIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleTrayIcon(showTrayIconToolStripMenuItem.Checked);

            if (!showInTaskbarToolStripMenuItem.Checked && !showTrayIconToolStripMenuItem.Checked)
            {
                ShowInTaskbar = true;
                showInTaskbarToolStripMenuItem.Checked = true;
            }
        }

        private void changeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blueauthserverToolStripMenuItem.Checked = redworldserverToolStripMenuItem.Checked = warcraft1ToolStripMenuItem.Checked = 
            warcraft3ToolStripMenuItem.Checked = warcraft2ToolStripMenuItem.Checked = warcraft4ToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;

            Settings.Default.iconString = sender.ToString();
            Icon = StaleLauncher.GetPreferredIcon();
            StaleLauncher._trayIcon.Icon = StaleLauncher.GetPreferredIcon();
        }

        //    MISC FILESTRIP CLICK EVENTS        
        private void accountManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlProcess == null)
            {
                sqlConnectForm = new SqlConnectForm();
                sqlConnectForm.Show();
                sqlConnectForm.Activate();
                sqlProcess = sqlConnectForm;
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("A DB manager is open.", "Error");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutPage == null || aboutPage.IsDisposed)
            {
                aboutPage = new About();
                aboutPage.Activate();
            }
            else
                aboutPage.Dispose();
        }
        
        private void Exit(object sender, EventArgs e)
        {
            Settings.Default.Save();
            StaleLauncher._trayIcon.Dispose();
            Application.Exit();
        }

        private void OnFormExit(object sender, FormClosingEventArgs e)
        {
            if (Settings.Default.showTrayIcon)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void WorldConsole_InputTextBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var consoleInputText = WorldConsole_InputTextBox.Text;
                WorldConsole_InputTextBox.Text = "";

                if (!Settings.Default.hideProcesses || worldServer == null || worldServer.StartInfo.UseShellExecute)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    launcherLogInsert("Console input failed.", eventLogTextBox);
                    return;                    
                }

                worldStreamWriter.WriteLineAsync(consoleInputText);
            }
        }
    }
}
