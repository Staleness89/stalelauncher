using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;
using System.Diagnostics;

namespace staleLauncher
{
    class StaleLauncher : ApplicationContext
    {
        public static string clientPath;
        public static string clientExe;
        public static string clientLocale;
        public static string clientPathWarning;
        private string  allowMultipleLaunchers;
        public static NotifyIcon _trayIcon;
        public static Form _serverControl;

        public StaleLauncher()
        {
            if (!ParseConfig("staleconfig.xml"))
            {
                MessageBox.Show("Failed to load staleconfig.xml", "Error");
                Application.Exit();
            }
            
            Process[] staleProcessGet = Process.GetProcessesByName(Application.ProductName);

            if (staleProcessGet.Length > 1 && allowMultipleLaunchers == "false")
            {
                MessageBox.Show("staleLauncher already running.", "Error");
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
            if (!string.IsNullOrEmpty(clientPath) || !string.IsNullOrEmpty(clientLocale) || !string.IsNullOrEmpty(clientExe))
                menuItems.Add(new MenuItem("Launch Client", ClientClick));
            menuItems.Add(new MenuItem("-"));
            menuItems.Add(new MenuItem("Exit", Exit));

            _trayIcon = new NotifyIcon {
                ContextMenu = new ContextMenu(menuItems.ToArray()),
                Text = "staleLauncher",  Visible = Properties.Settings.Default.showTrayIcon,  Icon = GetPreferredTrayIcon() };
            _trayIcon.Click += new System.EventHandler(ToggleServerControl);
        }

        public static Icon GetPreferredTrayIcon()
        {
            switch (Properties.Settings.Default.iconString)
            {
                case "worldserver":
                    return Resources.worldserver;
                case "authserver":
                    return Resources.authserver;
                case "wow1":
                    return Resources.WoW;
                case "wow2":
                    return Resources.WoW2;
                case "wow3":
                    return Resources.WoW3;
                case "wow4":
                    return Resources.WoW4;
                default:
                    return Resources.worldserver;
            }
        }

        public void ToggleServerControl(object Sender, EventArgs e)
        {
            _serverControl.Show();

            if (!Properties.Settings.Default.showTrayIcon)
                _serverControl.FormClosed += new FormClosedEventHandler(Exit);
        }

        private void ClientClick(object sender, EventArgs e)
        {
            LaunchClient();
        }

        private void Exit(object sender, EventArgs e)
        {
            _trayIcon.Dispose();
            _serverControl.Dispose();
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        public static void LaunchClient()
        {
            if (!File.Exists(clientPath + "\\" + clientExe + ".exe"))
            {
                MessageBox.Show(clientExe + ".exe does not exist in \"" + clientPath + "\"", "Error");
                return;
            }

            Process process;
            ProcessStartInfo _wowClient = new ProcessStartInfo();

            Process[] processes = Process.GetProcessesByName(clientExe);

            _wowClient.WorkingDirectory = clientPath;
            _wowClient.FileName = clientPath + "\\" + clientExe + ".exe";

            if (processes.Length == 0)
            {
                if (Properties.Settings.Default.deleteClientCache && Directory.Exists(clientPath + "\\" + "cache"))
                    Directory.Delete(clientPath + "\\" + "cache", true);

                process = Process.Start(_wowClient);
            }
            else
                MessageBox.Show(clientExe + ".exe already running.", "Error");
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
                                                case "server_path":
                                                    ServerControl.serverPath = attr.Value;
                                                    break;
                                                case "world_exe":
                                                    ServerControl.worldExe = attr.Value;
                                                    break;
                                                case "auth_exe":
                                                    ServerControl.authExe = attr.Value;
                                                    break;
                                                case "sql_service":
                                                    ServerControl.mySqlServiceName = attr.Value;
                                                    break;
                                                case "allow_multiple":
                                                    allowMultipleLaunchers = attr.Value;
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
                                MessageBox.Show("StaleConfig.xml is not configured.", "Warning");

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
                                                case "client_path":
                                                    clientPath = attr.Value;
                                                    break;
                                                case "client_exe":
                                                    clientExe = attr.Value;
                                                    break;
                                                case "client_locale":
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
