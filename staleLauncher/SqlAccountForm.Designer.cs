namespace sqlTools
{
    partial class SqlAccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountNameEntry_box = new System.Windows.Forms.TextBox();
            this.accountPasswordEntry_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gmLevelEntry_box = new System.Windows.Forms.ComboBox();
            this.accountCreate_button = new System.Windows.Forms.Button();
            this.expansionEntry_box = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_ExitAccounts = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.setPassword_button = new System.Windows.Forms.Button();
            this.setExpansion_button = new System.Windows.Forms.Button();
            this.setGmLevel_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // accountNameEntry_box
            // 
            this.accountNameEntry_box.Location = new System.Drawing.Point(9, 33);
            this.accountNameEntry_box.Margin = new System.Windows.Forms.Padding(2);
            this.accountNameEntry_box.MaxLength = 32;
            this.accountNameEntry_box.Name = "accountNameEntry_box";
            this.accountNameEntry_box.Size = new System.Drawing.Size(90, 20);
            this.accountNameEntry_box.TabIndex = 0;
            // 
            // accountPasswordEntry_box
            // 
            this.accountPasswordEntry_box.Location = new System.Drawing.Point(102, 33);
            this.accountPasswordEntry_box.Margin = new System.Windows.Forms.Padding(2);
            this.accountPasswordEntry_box.MaxLength = 16;
            this.accountPasswordEntry_box.Name = "accountPasswordEntry_box";
            this.accountPasswordEntry_box.PasswordChar = '*';
            this.accountPasswordEntry_box.Size = new System.Drawing.Size(81, 20);
            this.accountPasswordEntry_box.TabIndex = 1;
            this.accountPasswordEntry_box.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(100, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gmLevelEntry_box
            // 
            this.gmLevelEntry_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gmLevelEntry_box.FormattingEnabled = true;
            this.gmLevelEntry_box.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.gmLevelEntry_box.Location = new System.Drawing.Point(244, 30);
            this.gmLevelEntry_box.Margin = new System.Windows.Forms.Padding(2);
            this.gmLevelEntry_box.MaxDropDownItems = 5;
            this.gmLevelEntry_box.Name = "gmLevelEntry_box";
            this.gmLevelEntry_box.Size = new System.Drawing.Size(32, 21);
            this.gmLevelEntry_box.TabIndex = 3;
            // 
            // accountCreate_button
            // 
            this.accountCreate_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountCreate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.accountCreate_button.Location = new System.Drawing.Point(298, 31);
            this.accountCreate_button.Margin = new System.Windows.Forms.Padding(2);
            this.accountCreate_button.Name = "accountCreate_button";
            this.accountCreate_button.Size = new System.Drawing.Size(59, 46);
            this.accountCreate_button.TabIndex = 4;
            this.accountCreate_button.Text = "Create";
            this.accountCreate_button.UseVisualStyleBackColor = true;
            this.accountCreate_button.Click += new System.EventHandler(this.accountCreate_button_Click);
            // 
            // expansionEntry_box
            // 
            this.expansionEntry_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expansionEntry_box.FormattingEnabled = true;
            this.expansionEntry_box.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.expansionEntry_box.Location = new System.Drawing.Point(197, 31);
            this.expansionEntry_box.Margin = new System.Windows.Forms.Padding(2);
            this.expansionEntry_box.MaxDropDownItems = 3;
            this.expansionEntry_box.Name = "expansionEntry_box";
            this.expansionEntry_box.Size = new System.Drawing.Size(36, 21);
            this.expansionEntry_box.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(182, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "expansion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(242, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "gmlevel";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 83);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 18;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(348, 143);
            this.dataGridView1.TabIndex = 10;
            // 
            // button_ExitAccounts
            // 
            this.button_ExitAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExitAccounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_ExitAccounts.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_ExitAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ExitAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.button_ExitAccounts.Location = new System.Drawing.Point(298, 7);
            this.button_ExitAccounts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_ExitAccounts.Name = "button_ExitAccounts";
            this.button_ExitAccounts.Size = new System.Drawing.Size(59, 23);
            this.button_ExitAccounts.TabIndex = 18;
            this.button_ExitAccounts.Text = "Exit";
            this.button_ExitAccounts.UseVisualStyleBackColor = true;
            this.button_ExitAccounts.Click += new System.EventHandler(this.button2_Click);
            // 
            // delete_button
            // 
            this.delete_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.delete_button.Location = new System.Drawing.Point(10, 54);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(87, 23);
            this.delete_button.TabIndex = 5;
            this.delete_button.Text = "Delete account";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // setPassword_button
            // 
            this.setPassword_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setPassword_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.setPassword_button.Location = new System.Drawing.Point(102, 54);
            this.setPassword_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.setPassword_button.Name = "setPassword_button";
            this.setPassword_button.Size = new System.Drawing.Size(80, 23);
            this.setPassword_button.TabIndex = 6;
            this.setPassword_button.Text = "Set password";
            this.setPassword_button.UseVisualStyleBackColor = true;
            this.setPassword_button.Click += new System.EventHandler(this.setPassword_button_Click);
            // 
            // setExpansion_button
            // 
            this.setExpansion_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setExpansion_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.setExpansion_button.Location = new System.Drawing.Point(197, 54);
            this.setExpansion_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.setExpansion_button.Name = "setExpansion_button";
            this.setExpansion_button.Size = new System.Drawing.Size(35, 23);
            this.setExpansion_button.TabIndex = 7;
            this.setExpansion_button.Text = "Set";
            this.setExpansion_button.UseVisualStyleBackColor = true;
            this.setExpansion_button.Click += new System.EventHandler(this.setExpansion_button_Click);
            // 
            // setGmLevel_button
            // 
            this.setGmLevel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setGmLevel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.setGmLevel_button.Location = new System.Drawing.Point(244, 54);
            this.setGmLevel_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.setGmLevel_button.Name = "setGmLevel_button";
            this.setGmLevel_button.Size = new System.Drawing.Size(34, 23);
            this.setGmLevel_button.TabIndex = 8;
            this.setGmLevel_button.Text = "Set";
            this.setGmLevel_button.UseVisualStyleBackColor = true;
            this.setGmLevel_button.Click += new System.EventHandler(this.setGmLevel_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Account Manager";
            // 
            // SqlAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.button_ExitAccounts;
            this.ClientSize = new System.Drawing.Size(366, 236);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setGmLevel_button);
            this.Controls.Add(this.setExpansion_button);
            this.Controls.Add(this.setPassword_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.button_ExitAccounts);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.expansionEntry_box);
            this.Controls.Add(this.accountCreate_button);
            this.Controls.Add(this.gmLevelEntry_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accountPasswordEntry_box);
            this.Controls.Add(this.accountNameEntry_box);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SqlAccountForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox accountNameEntry_box;
        public System.Windows.Forms.TextBox accountPasswordEntry_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox gmLevelEntry_box;
        private System.Windows.Forms.Button accountCreate_button;
        public System.Windows.Forms.ComboBox expansionEntry_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_ExitAccounts;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button setPassword_button;
        private System.Windows.Forms.Button setExpansion_button;
        private System.Windows.Forms.Button setGmLevel_button;
        private System.Windows.Forms.Label label3;
    }
}