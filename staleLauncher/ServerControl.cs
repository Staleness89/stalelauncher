using System;
using System.Diagnostics;
using System.Windows.Forms;
using staleLauncher.Properties;
using System.IO;

namespace staleLauncher
{
    public partial class ServerControl : Form
    {
        public static string serverPath;
        public static string worldExe;
        public static string authExe;

        public static bool intentionedStop_worldServer = false;
        public static bool intentionedStop_authServer = false;

        ProcessStartInfo _worldServer = new ProcessStartInfo();
        ProcessStartInfo _authServer = new ProcessStartInfo();

        Process worldServer = new Process();
        Process authServer = new Process();


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
            // @TODO: SIMPLIFY/CONDENSE

            if (Properties.Settings.Default.hideProcesses)
                ToggleHiddenProcesses(true);
            else
                ToggleHiddenProcesses(false);

            if (Properties.Settings.Default.restartProcesses)
                restartProcessesToolStripMenuItem.Checked = true;

            if (Properties.Settings.Default.clearDBErrors)
                clearDBErrorsToolStripMenuItem.Checked = true;

            if (Properties.Settings.Default.deleteClientCache)
                clearClientCacheToolStripMenuItem.Checked = true;

            if (Properties.Settings.Default.showInTaskbar)
            {
                showInTaskbarToolStripMenuItem.Checked = true;
                ShowInTaskbar = true;
            }
            else
                ShowInTaskbar = false;

            if (Properties.Settings.Default.showTrayIcon)
            {
                showTrayIconToolStripMenuItem.Checked = true;
                MinimizeBox = false;
            }

            switch (Properties.Settings.Default.iconString)
            {
                case "red":
                    redworldserverToolStripMenuItem.Checked = true;
                    Icon = Resources.worldServer;
                    break;
                case "blue":
                    blueauthserverToolStripMenuItem.Checked = true;
                    Icon = Resources.authServer;
                    break;
            }
        }

        private void worldProcessExit(Object sender, EventArgs e)
        {
            Process[] worldProcessGet = Process.GetProcessesByName(worldExe);

            foreach (var process in worldProcessGet)
            {
                process.Kill();
                process.Close();
            }
            
            if (worldProcessGet.Length == 0)
                worldServer_toggleButton.Image = Resources.greyscale.ToBitmap();

            if (!intentionedStop_worldServer)
            {
                if (Properties.Settings.Default.restartProcesses)
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

            foreach (var process in authProcessGet)
            {
                process.Kill();
                process.Close();
            }

            if (authProcessGet.Length == 0)
                authServer_toggleButton.Image = Resources.greyscale.ToBitmap();

            if (!intentionedStop_authServer)
            {
                if (Properties.Settings.Default.restartProcesses)
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
                if (Properties.Settings.Default.clearDBErrors == true && File.Exists(serverPath + "\\" + "DBErrors.log"))
                    File.Delete(serverPath + "\\" + "DBErrors.log");

                worldServer.StartInfo = _worldServer;
                StartServerExe(worldServer.StartInfo);

                // refresh this
                intentionedStop_worldServer = false;
            }
            else
            {
                intentionedStop_worldServer = true;

                foreach (var process in worldProcessGet)
                {
                    process.Kill();
                    process.Close();
                }
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

                foreach (var process in authProcessGet)
                {
                    process.Kill();
                    process.Close();
                }
            }
        }

        public void StartServerExe(ProcessStartInfo serverExe)
        {
            if (serverExe == _worldServer || serverExe == _authServer)
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
            if (enabled)
            {
                _worldServer.WindowStyle = ProcessWindowStyle.Hidden;
                _authServer.WindowStyle = ProcessWindowStyle.Hidden;
                Properties.Settings.Default.hideProcesses = true;
                hideProcessesToolStripMenuItem.Checked = true;
            }
            else if (!enabled)
            {
                _worldServer.WindowStyle = ProcessWindowStyle.Normal;
                _authServer.WindowStyle = ProcessWindowStyle.Normal;
                Properties.Settings.Default.hideProcesses = false;
                hideProcessesToolStripMenuItem.Checked = false;
            }
        }

        private void ToggleClearDBErrors(bool enabled)
        {
            if (enabled)
                Properties.Settings.Default.clearDBErrors = true;
            else if (!enabled)
                Properties.Settings.Default.clearDBErrors = false;
        }

        private void ToggleDeleteClientCache(bool enabled)
        {
            if (enabled)
                Properties.Settings.Default.deleteClientCache = true;
            else if (!enabled)
                Properties.Settings.Default.deleteClientCache = false;
        }

        private void ToggleShowInTaskbar(bool enabled)
        {
            if (enabled)
            {
                Properties.Settings.Default.showInTaskbar = true;
                ShowInTaskbar = true;
            }
            else if (!enabled)
            {
                ShowInTaskbar = false;
                Properties.Settings.Default.showInTaskbar = false;
            }                
        }


        private void ToggleShowTrayIcon(bool enabled)
        {
            if (enabled)
            {
                Properties.Settings.Default.showTrayIcon = true;
                StaleLauncherContext._trayIcon.Visible = true;
                StaleLauncherContext._serverControl.FormClosed -= new FormClosedEventHandler(Exit);
                MinimizeBox = false;
            }
            else if (!enabled)
            {
                Properties.Settings.Default.showTrayIcon = false;
                StaleLauncherContext._trayIcon.Visible = false;
                StaleLauncherContext._serverControl.FormClosed += new FormClosedEventHandler(Exit);
                MinimizeBox = true;
            }
        }
        //    TASKBAR CLICK EVENTS

        private void openClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(StaleLauncherContext.clientEntryPath))
                Process.Start(StaleLauncherContext.clientEntryPath);
            else
            {
                MessageBox.Show("Folder does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }
        
        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(serverPath))
                Process.Start(serverPath);
            else
            {
                MessageBox.Show("Folder does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void dBErrorslogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverPath + "\\" + "DBErrors.log"))
                Process.Start(serverPath + "\\" + "DBErrors.log");
            else
            {
                MessageBox.Show("Log does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void serverlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverPath + "\\" + "Server.log"))
                Process.Start(serverPath + "\\" + "Server.log");
            else
            {
                MessageBox.Show("Log does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void authlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverPath + "\\" + "Auth.log"))
                Process.Start(serverPath + "\\" + "Auth.log");
            else
            {
                MessageBox.Show("Log does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void worldserverconfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverPath + "\\" + "worldserver.conf"))
                Process.Start(serverPath + "\\" + "worldserver.conf");
            else
            {
                MessageBox.Show("File does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void authserverconfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverPath + "\\" + "authserver.conf"))
                Process.Start(serverPath + "\\" + "authserver.conf");
            else
            {
                MessageBox.Show("File does not exist.", "Error");
                System.Media.SystemSounds.Exclamation.Play();
            }
        }


        private void staleconfigxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("staleconfig.xml"))
                Process.Start(serverPath + "\\" + "staleconfig.xml");
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("File does not exist.");
            }

        }

        private void realmlistwtfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var realmlistPath = StaleLauncherContext.clientEntryPath + "\\Data\\" + StaleLauncherContext.clientLocale + "\\" + "realmlist.wtf";

            if (File.Exists(realmlistPath))
                Process.Start(realmlistPath);
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("File does not exist.", "Error");
            }
        }

        //    FILESTRIP "OPTIONS" TOGGLES
        //  1: Server

        private void hideProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideProcessesToolStripMenuItem.Checked)
                ToggleHiddenProcesses(true);
            else
                ToggleHiddenProcesses(false);
        }

        private void restartProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (restartProcessesToolStripMenuItem.Checked)
                Properties.Settings.Default.restartProcesses = true;
            else
                Properties.Settings.Default.restartProcesses = false;

        }

        private void clearDBErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clearDBErrorsToolStripMenuItem.Checked)
                ToggleClearDBErrors(true);
            else
                ToggleClearDBErrors(false);
        }

        //  2: Client

        private void clearClientCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clearClientCacheToolStripMenuItem.Checked)
                ToggleDeleteClientCache(true);
            else
                ToggleDeleteClientCache(false);
        }

        //  3: Launcher

        private void showInTaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showInTaskbarToolStripMenuItem.Checked)
                ToggleShowInTaskbar(true);
            else
            {
                if (!showTrayIconToolStripMenuItem.Checked)
                {
                    ToggleShowTrayIcon(true);
                    showTrayIconToolStripMenuItem.Checked = true;
                }

                ToggleShowInTaskbar(false);
            }
        }

        private void showTrayIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showTrayIconToolStripMenuItem.Checked)
            {
                ToggleShowTrayIcon(true);
            }
            else
            {
                if (!showInTaskbarToolStripMenuItem.Checked)
                {
                    ToggleShowInTaskbar(true);
                    showInTaskbarToolStripMenuItem.Checked = true;
                }

                ToggleShowTrayIcon(false);
            }
        }

        private void blueauthserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (blueauthserverToolStripMenuItem.Checked)
                return;

            blueauthserverToolStripMenuItem.Checked = true;
            redworldserverToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.authServer;
            Icon = Resources.authServer;
            Properties.Settings.Default.iconString = "blue";
        }

        private void redworldserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redworldserverToolStripMenuItem.Checked)
                return;

            redworldserverToolStripMenuItem.Checked = true;
            blueauthserverToolStripMenuItem.Checked = false;
            StaleLauncherContext._trayIcon.Icon = Resources.worldServer;
            Icon = Resources.worldServer;
            Properties.Settings.Default.iconString = "red";
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
            Properties.Settings.Default.Save();
            StaleLauncherContext._trayIcon.Dispose();
            Application.Exit();
        }

        private void OnFormExit(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.showTrayIcon)
            {
                e.Cancel = true;
                StaleLauncherContext.serverControlShowing = false;
                Hide();
            }
        }
    }
}
