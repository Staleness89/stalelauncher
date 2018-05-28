using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using staleLauncher.Properties;
using sqlTools;

namespace staleLauncher
{
    public partial class ServerControl : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static string serverPath;
        public static string worldExe;
        public static string authExe;

        public static bool intentionedStop_worldServer = false;
        public static bool intentionedStop_authServer = false;

        public static Form sqlProcess = null;

        ProcessStartInfo _worldServer = new ProcessStartInfo();
        ProcessStartInfo _authServer = new ProcessStartInfo();

        Process worldServer = new Process();
        Process authServer = new Process();

        SqlConnectForm sqlConnectForm;


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
            UpdateServerButtons();
            SyncCheckboxSettings();

            _authServer.WorkingDirectory = serverPath;
            _authServer.FileName = serverPath + "\\" + authExe + ".exe";

            _worldServer.WorkingDirectory = serverPath;
            _worldServer.FileName = serverPath + "\\" + worldExe + ".exe";

            if (StaleLauncherContext.clientEntryPath == string.Empty)
                launchClientToolStripMenuItem.Dispose();

            FormClosing += new FormClosingEventHandler(OnFormExit);
            Activated += new EventHandler(servercontrol_Focus);
            MouseDown += new MouseEventHandler(CommandForm_MouseDown);
        }

        public void UpdateServerButtons()
        {
            Process[] worldProcessGet = Process.GetProcessesByName(worldExe);
            Process[] authProcessGet = Process.GetProcessesByName(authExe);

            if (authProcessGet.Length == 0)
                authServer_toggleButton.Image = Resources.greyscale.ToBitmap();
            else
                authServer_toggleButton.Image = Resources.authServer.ToBitmap();

            if (worldProcessGet.Length == 0)
                worldServer_toggleButton.Image = Resources.greyscale.ToBitmap();
            else
                worldServer_toggleButton.Image = Resources.worldServer.ToBitmap();

            foreach (var process in worldProcessGet)
            {
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(worldProcessExit);
            }

            foreach (var process in authProcessGet)
            {
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(authProcessExit);
            }
        }

        private void SyncCheckboxSettings()
        {
            ToggleHiddenProcesses(Settings.Default.hideProcesses);
            restartProcessesToolStripMenuItem.Checked = Settings.Default.restartProcesses;
            clearDBErrorsToolStripMenuItem.Checked = Settings.Default.clearDBErrors;
            clearClientCacheToolStripMenuItem.Checked = Settings.Default.deleteClientCache;
            showInTaskbarToolStripMenuItem.Checked = Settings.Default.showInTaskbar;
            ShowInTaskbar = Settings.Default.showInTaskbar;
            showTrayIconToolStripMenuItem.Checked = Settings.Default.showTrayIcon;
            MinimizeBox = !Settings.Default.showTrayIcon;

            switch (Settings.Default.iconString)
            {
                case "red":
                    redworldserverToolStripMenuItem.Checked = true;
                    Icon = Resources.worldServer;
                    break;
                case "blue":
                    blueauthserverToolStripMenuItem.Checked = true;
                    Icon = Resources.authServer;
                    break;
                case "wow1":
                    warcraft1ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW;
                    break;
                case "wow2":
                    warcraft2ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW2;
                    break;
                case "wow3":
                    warcraft3ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW3;
                    break;
                case "wow4":
                    warcraft4ToolStripMenuItem.Checked = true;
                    Icon = Resources.WoW4;
                    break;
            }
        }

        private void worldProcessExit(Object sender, EventArgs e)
        {
            Process[] worldProcessGet = Process.GetProcessesByName(worldExe);
            
            if (worldProcessGet.Length == 0)
                worldServer_toggleButton.Image = Resources.greyscale.ToBitmap();

            if (!intentionedStop_worldServer)
            {
                if (Settings.Default.restartProcesses)
                {
                    worldServer.StartInfo = _worldServer;
                    StartServerExe(worldServer.StartInfo);
                }

                System.Media.SystemSounds.Exclamation.Play();
                launcherLogInsert("Worldserver unexpected stop");
            }
            else
                launcherLogInsert("Worldserver stopped");
        }


        private void authProcessExit(Object sender, EventArgs e)
        {
            Process[] authProcessGet = Process.GetProcessesByName(authExe);

            if (authProcessGet.Length == 0)
                authServer_toggleButton.Image = Resources.greyscale.ToBitmap();

            if (!intentionedStop_authServer)
            {
                if (Settings.Default.restartProcesses)
                {
                    authServer.StartInfo = _authServer;
                    StartServerExe(authServer.StartInfo);
                }

                System.Media.SystemSounds.Exclamation.Play();
                launcherLogInsert("Authserver unexpected stop");
            }
            else
                launcherLogInsert("Authserver stopped");
        }

        public void launcherLogInsert(string newText)
        {
            if (launcherLog.IsHandleCreated)
                launcherLog.Invoke(new Action(() => launcherLog.AppendText(System.DateTime.Now.ToLocalTime().ToLongTimeString() + ": " + newText + Environment.NewLine)));
        }

        private void ToggleWorldServer(Object sender, EventArgs e)
        {
            Process[] worldProcessGet = Process.GetProcessesByName(worldExe);

            if (worldProcessGet.Length == 0)
            {
                if (Settings.Default.clearDBErrors == true && File.Exists(serverPath + "\\" + "DBErrors.log"))
                    File.Delete(serverPath + "\\" + "DBErrors.log");

                worldServer.StartInfo = _worldServer;
                StartServerExe(worldServer.StartInfo);

                // refresh this
                intentionedStop_worldServer = false;
            }
            else
            {
                intentionedStop_worldServer = true;
                worldProcessGet[0].Kill();
                worldProcessGet[0].Dispose();
            }
        }

        private void ToggleAuthServer(Object sender, EventArgs e)
        {
            Process[] authProcessGet = Process.GetProcessesByName(authExe);

            if (authProcessGet.Length == 0)
            {
                authServer.StartInfo = _authServer;
                StartServerExe(authServer.StartInfo);

                // refresh this
                intentionedStop_authServer = false;
            }
            else
            {
                intentionedStop_authServer = true;
                authProcessGet[0].Kill();
                authProcessGet[0].Dispose();
            }
        }

        public void StartServerExe(ProcessStartInfo serverExe)
        {
            if (File.Exists(serverExe.FileName))
            {
                Process server = Process.Start(serverExe);
                server.EnableRaisingEvents = true;

                if (serverExe == _worldServer)
                {
                    server.Exited += new EventHandler(worldProcessExit);
                    worldServer_toggleButton.Image = Resources.worldServer.ToBitmap();
                    launcherLogInsert("Worldserver started");
                }
                else if (serverExe == _authServer)
                {
                    server.Exited += new EventHandler(authProcessExit);
                    authServer_toggleButton.Image = Resources.authServer.ToBitmap();
                    launcherLogInsert("Authserver started");
                }
            }
            else
                MessageBox.Show("File not found", "Error");
        }

        private void ToggleHiddenProcesses(bool enabled)
        {
            Settings.Default.hideProcesses = enabled;
            hideProcessesToolStripMenuItem.Checked = enabled;

            if (enabled)
            {
                _worldServer.WindowStyle = ProcessWindowStyle.Hidden;
                _authServer.WindowStyle = ProcessWindowStyle.Hidden;
            }
            else
            {
                _worldServer.WindowStyle = ProcessWindowStyle.Normal;
                _authServer.WindowStyle = ProcessWindowStyle.Normal;
            }
        }

        private void ToggleClearDBErrors(bool enabled)
        {
            Settings.Default.clearDBErrors = enabled;
        }

        private void ToggleDeleteClientCache(bool enabled)
        {
            Settings.Default.deleteClientCache = enabled;
        }

        private void ToggleShowInTaskbar(bool enabled)
        {
            Settings.Default.showInTaskbar = enabled;
            ShowInTaskbar = enabled;
        }
        
        private void ToggleShowTrayIcon(bool enabled)
        {
            Settings.Default.showTrayIcon = enabled;
            StaleLauncherContext._trayIcon.Visible = enabled;
            MinimizeBox = !enabled;
            if (enabled)
                StaleLauncherContext._serverControl.FormClosed -= new FormClosedEventHandler(Exit);
            else
                StaleLauncherContext._serverControl.FormClosed += new FormClosedEventHandler(Exit);
        }

        private void OpenDirectory(string path)
        {
            if (Directory.Exists(path))
                Process.Start(path);
            else
            {
                MessageBox.Show("Folder does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void OpenFile(string path)
        {
            if (File.Exists(path))
                Process.Start(path);
            else
            {
                MessageBox.Show("File does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        //    TASKBAR CLICK EVENTS
        private void openClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDirectory(StaleLauncherContext.clientEntryPath);
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDirectory(serverPath);
        }

        private void dBErrorslogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(serverPath + "\\" + "DBErrors.log");
        }

        private void serverlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(serverPath + "\\" + "Server.log");
        }

        private void authlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(serverPath + "\\" + "Auth.log");
        }

        private void worldserverconfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(serverPath + "\\" + "worldserver.conf");
        }

        private void authserverconfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(serverPath + "\\" + "authserver.conf");
        }

        private void staleconfigxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(serverPath + "\\" + "staleconfig.xml");
        }

        private void realmlistwtfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(StaleLauncherContext.clientEntryPath + "\\Data\\" + StaleLauncherContext.clientLocale + "\\" + "realmlist.wtf");
        }

        //    FILESTRIP "OPTIONS" TOGGLES
        //  1: Server
        private void hideProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleHiddenProcesses(hideProcessesToolStripMenuItem.Checked);
        }

        private void restartProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.restartProcesses = restartProcessesToolStripMenuItem.Checked;
        }

        private void clearDBErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleClearDBErrors(clearDBErrorsToolStripMenuItem.Checked);
        }

        //  2: Client
        private void clearClientCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleDeleteClientCache(clearClientCacheToolStripMenuItem.Checked);
        }

        //  3: Launcher
        private void showInTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleShowInTaskbar(showInTaskbarToolStripMenuItem.Checked);

            if (!showTrayIconToolStripMenuItem.Checked && !showInTaskbarToolStripMenuItem.Checked)
            {
                ToggleShowTrayIcon(true);
                showTrayIconToolStripMenuItem.Checked = true;
            }
        }

        private void showTrayIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleShowTrayIcon(showTrayIconToolStripMenuItem.Checked);

            if (!showInTaskbarToolStripMenuItem.Checked && !showTrayIconToolStripMenuItem.Checked)
            {
                ToggleShowInTaskbar(true);
                showInTaskbarToolStripMenuItem.Checked = true;
            }
        }

        private void blueauthserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (blueauthserverToolStripMenuItem.Checked)
                return;

            blueauthserverToolStripMenuItem.Checked = true;
            redworldserverToolStripMenuItem.Checked = false;
            warcraft1ToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.authServer;
            Icon = Resources.authServer;
            Settings.Default.iconString = "blue";
        }

        private void redworldserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redworldserverToolStripMenuItem.Checked)
                return;

            redworldserverToolStripMenuItem.Checked = true;
            blueauthserverToolStripMenuItem.Checked = false;
            warcraft1ToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.worldServer;
            Icon = Resources.worldServer;
            Settings.Default.iconString = "red";
        }

        private void warcraft1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warcraft1ToolStripMenuItem.Checked)
                return;

            warcraft1ToolStripMenuItem.Checked = true;
            warcraft2ToolStripMenuItem.Checked = false;
            warcraft3ToolStripMenuItem.Checked = false;
            warcraft4ToolStripMenuItem.Checked = false;
            blueauthserverToolStripMenuItem.Checked = false;
            redworldserverToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.WoW;
            Icon = Resources.WoW;
            Settings.Default.iconString = "wow1";
        }

        private void warcraft2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warcraft2ToolStripMenuItem.Checked)
                return;

            warcraft2ToolStripMenuItem.Checked = true;
            warcraft1ToolStripMenuItem.Checked = false;
            warcraft3ToolStripMenuItem.Checked = false;
            warcraft4ToolStripMenuItem.Checked = false;
            blueauthserverToolStripMenuItem.Checked = false;
            redworldserverToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.WoW2;
            Icon = Resources.WoW2;
            Settings.Default.iconString = "wow2";
        }

        private void warcraft3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warcraft3ToolStripMenuItem.Checked)
                return;

            warcraft3ToolStripMenuItem.Checked = true;
            warcraft1ToolStripMenuItem.Checked = false;
            warcraft2ToolStripMenuItem.Checked = false;
            warcraft4ToolStripMenuItem.Checked = false;
            blueauthserverToolStripMenuItem.Checked = false;
            redworldserverToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.WoW3;
            Icon = Resources.WoW3;
            Settings.Default.iconString = "wow3";
        }

        private void warcraft4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (warcraft4ToolStripMenuItem.Checked)
                return;

            warcraft4ToolStripMenuItem.Checked = true;
            warcraft1ToolStripMenuItem.Checked = false;
            warcraft2ToolStripMenuItem.Checked = false;
            warcraft3ToolStripMenuItem.Checked = false;
            blueauthserverToolStripMenuItem.Checked = false;
            redworldserverToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.WoW4;
            Icon = Resources.WoW4;
            Settings.Default.iconString = "wow4";

        }

        //    MISC FILESTRIP CLICK EVENTS


        private void launchClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaleLauncherContext.LaunchClient();
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launcherLog.Invoke(new Action(() => launcherLog.Text = null));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutPage = null;

            if (aboutPage == null || aboutPage.IsDisposed)
            {
                aboutPage = new About();
                aboutPage.Show();
                aboutPage.Activate();
            }
            else
                aboutPage.Dispose();
        }

        private void Exit(object sender, EventArgs e)
        {
            Settings.Default.Save();
            StaleLauncherContext._trayIcon.Dispose();
            Application.Exit();
        }

        private void OnFormExit(object sender, FormClosingEventArgs e)
        {
            if (Settings.Default.showTrayIcon)
            {
                e.Cancel = true;
                StaleLauncherContext.serverControlShowing = false;
                Hide();
            }
        }

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

        private void servercontrol_Focus(object sender, EventArgs e)
        {
            if (sqlProcess != null)
                sqlProcess.Activate();
        }
    }
}
