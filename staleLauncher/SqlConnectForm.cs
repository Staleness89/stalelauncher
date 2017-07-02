using System;
using System.Windows.Forms;
using staleLauncher.Properties;
using staleLauncher;

namespace sqlTools
{
    public partial class SqlConnectForm : Form
    {
        public static Form _commandWindow = null;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void ConnectForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public SqlConnectForm()
        {
            InitializeComponent();
            
            if (Settings.Default.save_db_info)
            {
                saveConnectInfo.Checked = true;
                connectionAddressString = Settings.Default.db_address;
                connectionPortString = Settings.Default.db_port;
                connectionUserString = Settings.Default.db_user;
                connectionPasswordString = Settings.Default.db_password;
            }

            label1.MouseDown += new MouseEventHandler(ConnectForm_MouseDown);
            label2.MouseDown += new MouseEventHandler(ConnectForm_MouseDown);
            label3.MouseDown += new MouseEventHandler(ConnectForm_MouseDown);
            label4.MouseDown += new MouseEventHandler(ConnectForm_MouseDown);
            MouseDown += new MouseEventHandler(ConnectForm_MouseDown);
            portEntry_box.KeyPress += new KeyPressEventHandler(portBox_KeyHandler);
        }

        private string connectionUserString
        {
            get { return connectionUserEntry_box.Text; }
            set { connectionUserEntry_box.Text = value; }
        }

        private string connectionPasswordString
        {
            get { return connectionPasswordEntry_box.Text; }
            set { connectionPasswordEntry_box.Text = value; }
        }

        private string connectionAddressString
        {
            get { return connectionAddressEntry_box.Text; }
            set { connectionAddressEntry_box.Text = value; }
        }

        private string connectionPortString
        {
            get { return portEntry_box.Text; }
            set { portEntry_box.Text = value; }
        }

        private void portBox_KeyHandler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBConnection.Connect(connectionUserString, connectionPasswordString, connectionAddressString, connectionPortString))
            {
                if (saveConnectInfo.Checked)
                {
                    Settings.Default.db_address = connectionAddressString;
                    Settings.Default.db_port = connectionPortString;
                    Settings.Default.db_user = connectionUserString;
                    Settings.Default.db_password = connectionPasswordString;
                    Settings.Default.save_db_info = true;
                    Settings.Default.Save();
                }

                _commandWindow = new SqlAccountForm();
                _commandWindow.Activate();
                _commandWindow.Show();
                ServerControl.sqlProcess = _commandWindow;
                Dispose();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Could not connect to server", "Error");
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Dispose();
            ServerControl.sqlProcess = null;
        }
    }
}
