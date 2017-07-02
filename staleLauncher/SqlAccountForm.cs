using System;
using System.Windows.Forms;
using staleLauncher;

namespace sqlTools
{
    public partial class SqlAccountForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private string accountName
        {
            get { return accountNameEntry_box.Text; }
            set { accountNameEntry_box.Text = value; }
        }

        private string accountPassword
        {
            get { return accountPasswordEntry_box.Text; }
            set { accountPasswordEntry_box.Text = value; }
        }

        private string gmLevel
        {
            get { return gmLevelEntry_box.Text; }
            set { gmLevelEntry_box.Text = value; }
        }

        private string expansion
        {
            get { return expansionEntry_box.Text; }
            set { expansionEntry_box.Text = value; }
        }

        public void CommandForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void TextBox_PreventWhitespace(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        public SqlAccountForm()
        {
            InitializeComponent();
            gmLevelEntry_box.SelectedIndex = 0;
            expansionEntry_box.SelectedIndex = 0;

            accountNameEntry_box.KeyPress += new KeyPressEventHandler(TextBox_PreventWhitespace);
            accountPasswordEntry_box.KeyPress += new KeyPressEventHandler(TextBox_PreventWhitespace);
            MouseDown += new MouseEventHandler(CommandForm_MouseDown);
            label1.MouseDown += new MouseEventHandler(CommandForm_MouseDown);
            label2.MouseDown += new MouseEventHandler(CommandForm_MouseDown);
            label5.MouseDown += new MouseEventHandler(CommandForm_MouseDown);

            dataGridView1.ColumnAdded += new DataGridViewColumnEventHandler(dataGridView1_ColumnAdded);
            dataGridView1.CellEnter += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            DBConnection.GetAccountData(dataGridView1);
        }

        private void accountCreate_button_Click(object sender, EventArgs e)
        {
            if (DBConnection.CreateAccount(accountName, accountPassword, expansion, gmLevel))
                InputSuccess("Account " + accountName + " created successfully.");
            else
                InputError();

            DBConnection.GetAccountData(dataGridView1);
        }

        private void setPassword_button_Click(object sender, EventArgs e)
        {
            if (DBConnection.SetAccountPassword(accountName, accountPassword))
                InputSuccess("Password changed successfully.");
            else
                InputError();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (DBConnection.DeleteAccount(accountName))
                InputSuccess("Account deleted successfully.");
            else
                InputError();

            DBConnection.GetAccountData(dataGridView1);
        }

        private void setExpansion_button_Click(object sender, EventArgs e)
        {
            if (DBConnection.SetAccountExpansion(accountName, expansion))
                InputSuccess("Expansion changed successfully.");
            else
                InputError();

            DBConnection.GetAccountData(dataGridView1);
        }

        private void setGmLevel_button_Click(object sender, EventArgs e)
        {
            if (DBConnection.SetAccountGmLevel(accountName, gmLevel))
                InputSuccess("gmLevel changed successfully.");
            else
                InputError();

            DBConnection.GetAccountData(dataGridView1);
        }

        private void InputError()
        {
            System.Media.SystemSounds.Exclamation.Play();
            MessageBox.Show("Invalid input.", "Error");
        }

        private void InputSuccess(string message)
        {
            System.Media.SystemSounds.Beep.Play();
            MessageBox.Show(message, "Success");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
            ServerControl.sqlProcess = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            accountNameEntry_box.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "id":
                    e.Column.Width = 33;
                    break;
                case "username":
                    e.Column.Width = 128;
                    break;
                case "expansion":
                    e.Column.Width = 57;
                    break;
                case "gmlevel":
                    e.Column.Width = 47;
                    break;
                case "characters":
                    e.Column.Width = 58;
                    break;
            }
        }
    }
}
