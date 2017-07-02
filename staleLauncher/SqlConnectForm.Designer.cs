namespace sqlTools
{
    partial class SqlConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlConnectForm));
            this.connectionAddressEntry_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.connectionUserEntry_box = new System.Windows.Forms.TextBox();
            this.connectionPasswordEntry_box = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.portEntry_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.saveConnectInfo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // connectionAddressEntry_box
            // 
            this.connectionAddressEntry_box.Location = new System.Drawing.Point(12, 27);
            this.connectionAddressEntry_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectionAddressEntry_box.MaxLength = 50;
            this.connectionAddressEntry_box.Name = "connectionAddressEntry_box";
            this.connectionAddressEntry_box.Size = new System.Drawing.Size(117, 22);
            this.connectionAddressEntry_box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(119, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // connectionUserEntry_box
            // 
            this.connectionUserEntry_box.Location = new System.Drawing.Point(12, 71);
            this.connectionUserEntry_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectionUserEntry_box.MaxLength = 50;
            this.connectionUserEntry_box.Name = "connectionUserEntry_box";
            this.connectionUserEntry_box.Size = new System.Drawing.Size(92, 22);
            this.connectionUserEntry_box.TabIndex = 2;
            // 
            // connectionPasswordEntry_box
            // 
            this.connectionPasswordEntry_box.Location = new System.Drawing.Point(110, 71);
            this.connectionPasswordEntry_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectionPasswordEntry_box.MaxLength = 50;
            this.connectionPasswordEntry_box.Name = "connectionPasswordEntry_box";
            this.connectionPasswordEntry_box.PasswordChar = '*';
            this.connectionPasswordEntry_box.Size = new System.Drawing.Size(94, 22);
            this.connectionPasswordEntry_box.TabIndex = 3;
            this.connectionPasswordEntry_box.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(24, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portEntry_box
            // 
            this.portEntry_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portEntry_box.Location = new System.Drawing.Point(135, 28);
            this.portEntry_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portEntry_box.MaxLength = 6;
            this.portEntry_box.Name = "portEntry_box";
            this.portEntry_box.Size = new System.Drawing.Size(53, 22);
            this.portEntry_box.TabIndex = 1;
            this.portEntry_box.Text = "3306";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(143, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port";
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.Color.Silver;
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.cancel_button.Location = new System.Drawing.Point(110, 106);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(78, 31);
            this.cancel_button.TabIndex = 5;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // saveConnectInfo
            // 
            this.saveConnectInfo.AutoSize = true;
            this.saveConnectInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold);
            this.saveConnectInfo.Location = new System.Drawing.Point(44, 142);
            this.saveConnectInfo.Name = "saveConnectInfo";
            this.saveConnectInfo.Size = new System.Drawing.Size(125, 17);
            this.saveConnectInfo.TabIndex = 10;
            this.saveConnectInfo.Text = "Save connection";
            this.saveConnectInfo.UseVisualStyleBackColor = true;
            // 
            // SqlConnectForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(213, 167);
            this.Controls.Add(this.saveConnectInfo);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.portEntry_box);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.connectionPasswordEntry_box);
            this.Controls.Add(this.connectionUserEntry_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectionAddressEntry_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlConnectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox connectionAddressEntry_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox connectionUserEntry_box;
        public System.Windows.Forms.TextBox connectionPasswordEntry_box;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox portEntry_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.CheckBox saveConnectInfo;
    }
}