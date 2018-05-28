using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace staleLauncher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Process[] staleProcessGet = Process.GetProcessesByName("stalelauncher");

            if (staleProcessGet.Length > 1)
            {
                MessageBox.Show("staleLauncher already running.", "Error");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StaleLauncherContext());
        }
    }
}
