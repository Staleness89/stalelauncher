using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;
using System.Diagnostics;
using staleLauncher.Properties;

namespace staleLauncher
{
    class StaleLauncherContext : ApplicationContext
    {
        public static string clientEntryPath;
        public static string clientLocale;
        public static string clientPathWarning;
        public static NotifyIcon _trayIcon;
        public static Form _serverControl;
        public static bool serverControlShowing = true;

        public StaleLauncherContext()
        {
            if (!ParseConfig("staleconfig.xml"))
            {
                MessageBox.Show("Failed to load staleconfig.xml", "Error");
                Application.Exit();
            }

            InitializeTrayIcon();

            _serverControl = new ServerControl();
            _serverControl.Show();
            _serverControl.Activate();

            if (!Properties.Settings.Default.showTrayIcon)
                _serverControl.FormClosed += new FormClosedEventHandler(Exit);
        }

        public void InitializeTrayIcon()
        {
            var menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem("Show/Hide Control", ToggleServerControl));
            if (clientEntryPath != string.Empty)
                menuItems.Add(new MenuItem("Launch Client", ClientClick));
            menuItems.Add(new MenuItem("-"));
            menuItems.Add(new MenuItem("Exit", Exit));

            _trayIcon = new NotifyIcon
            {
                ContextMenu = new ContextMenu(menuItems.ToArray()),
                Text = "staleLauncher"
            };

            if (Properties.Settings.Default.showTrayIcon)
                _trayIcon.Visible = true;
            else
                _trayIcon.Visible = false;

            _trayIcon.Icon = GetPreferredTrayIcon();
            _trayIcon.Click += new System.EventHandler(FocusServerControl);
            _trayIcon.DoubleClick += new System.EventHandler(ToggleServerControl);
        }

        public static Icon GetPreferredTrayIcon()
        {
            switch (Properties.Settings.Default.iconString)
            {
                case "red":
                    _trayIcon.Icon = Resources.worldServer;
                    return Resources.worldServer;
                case "blue":
                    _trayIcon.Icon = Resources.authServer;
                    return Resources.authServer;
                case "wow1":
                    _trayIcon.Icon = Resources.WoW;
                    return Resources.WoW;
                case "wow2":
                    _trayIcon.Icon = Resources.WoW2;
                    return Resources.WoW2;
                case "wow3":
                    _trayIcon.Icon = Resources.WoW3;
                    return Resources.WoW3;
                case "wow4":
                    _trayIcon.Icon = Resources.WoW4;
                    return Resources.WoW4;
                default:
                    return Resources.worldServer;
            }
        }

        public void ToggleServerControl(object Sender, EventArgs e)
        {
            if (serverControlShowing)
            {
                _serverControl.Hide();
                serverControlShowing = false;
            }
            else if (!serverControlShowing)
            {
                if (_serverControl.IsDisposed)
                    _serverControl = new ServerControl();

                _serverControl.Show();
                _serverControl.Activate();
                serverControlShowing = true;

                if (!Properties.Settings.Default.showTrayIcon)
                    _serverControl.FormClosed += new FormClosedEventHandler(Exit);
            }
        }

        private void FocusServerControl(object Sender, EventArgs e)
        {
            if (serverControlShowing)
                _serverControl.Activate();
        }

        private void ClientClick(object sender, EventArgs e)
        {
            LaunchClient();
        }

        private void Exit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            _trayIcon.Dispose();
            _serverControl.Dispose();
            Application.Exit();
        }

        public static void LaunchClient()
        {
            if (!File.Exists(clientEntryPath + "\\" + "Wow.exe"))
            {
                MessageBox.Show("File does not exist.", "Error");
                return;
            }

            Process process;
            ProcessStartInfo _wowClient = new ProcessStartInfo();

            Process[] processes = Process.GetProcessesByName("wow");

            _wowClient.WorkingDirectory = clientEntryPath;
            _wowClient.FileName = clientEntryPath + "\\" + "Wow.exe";

            if (processes.Length == 0)
            {
                if (Properties.Settings.Default.deleteClientCache && Directory.Exists(clientEntryPath + "\\" + "cache"))
                    Directory.Delete(clientEntryPath + "\\" + "cache", true);

                process = Process.Start(_wowClient);
            }
            else
                MessageBox.Show("Wow.exe already running.", "Error");
        }


        ///         XML CONFIG PARSER
        ///           ************

        private bool ParseConfig(string filename)
        {
            var doc = XElement.Load(filename);
            
            foreach (var c in doc.Descendants())
            {
                switch (c.Name.ToString().ToLower())
                {
                    case "server":
                        {
                            foreach (var e in c.Elements())
                            {
                                switch (e.Name.ToString().ToLower())
                                {
                                    case "settings":
                                        foreach (var attr in e.Attributes())
                                        {
                                            switch (attr.Name.ToString().ToLower())
                                            {
                                                case "root":
                                                    ServerControl.serverPath = attr.Value;
                                                    break;
                                                case "worldexe":
                                                    ServerControl.worldExe = attr.Value;
                                                    break;
                                                case "authexe":
                                                    ServerControl.authExe = attr.Value;
                                                    break;
                                                default:
                                                    return false;
                                            }
                                        }
                                        break;
                                    default:
                                        return false;
                                }
                            }

                            if (ServerControl.serverPath == string.Empty || ServerControl.worldExe == string.Empty || ServerControl.authExe == string.Empty)
                                MessageBox.Show("Your server path is empty.", "Warning");

                            break;
                        }

                    case "client":
                        {
                            foreach (var e in c.Elements())
                            {
                                switch (e.Name.ToString().ToLower())
                                {
                                    case "settings":
                                        foreach (var attr in e.Attributes())
                                        {
                                            switch (attr.Name.ToString().ToLower())
                                            {
                                                case "path":
                                                    clientEntryPath = attr.Value;
                                                    break;
                                                case "locale":
                                                    clientLocale = attr.Value;
                                                    break;
                                                case "empty_path_warning":
                                                    clientPathWarning = attr.Value;
                                                    break;
                                                default:
                                                    return false;
                                            }
                                        }
                                        break;
                                        
                                    default:
                                        return false;
                                }
                            }

                            if (clientEntryPath == string.Empty && clientPathWarning == "true")
                                MessageBox.Show("Your client path is empty. Disable this warning in staleConfig.", "Warning");

                            break;
                        }
                }

            }
            doc.RemoveAll();
            doc = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return true;
        }
    }
}
