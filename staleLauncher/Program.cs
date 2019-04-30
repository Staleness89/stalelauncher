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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StaleLauncher());
        }
    }
}
