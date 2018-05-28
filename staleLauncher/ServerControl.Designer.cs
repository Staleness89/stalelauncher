namespace staleLauncher
{
    public partial class ServerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerControl));
            this.authServer_toggleButton = new System.Windows.Forms.Button();
            this.worldServer_toggleButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openClientFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.dBErrorslogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editConfigsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worldserverconfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authserverconfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realmlistwtfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.launchClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDBErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearClientCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueauthserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redworldserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warcraft1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warcraft2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warcraft3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warcraft4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInTaskbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTrayIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launcherLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // authServer_toggleButton
            // 
            this.authServer_toggleButton.BackColor = System.Drawing.Color.SteelBlue;
            this.authServer_toggleButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.authServer_toggleButton.Image = ((System.Drawing.Image)(resources.GetObject("authServer_toggleButton.Image")));
            this.authServer_toggleButton.Location = new System.Drawing.Point(-1, 83);
            this.authServer_toggleButton.Name = "authServer_toggleButton";
            this.authServer_toggleButton.Size = new System.Drawing.Size(62, 58);
            this.authServer_toggleButton.TabIndex = 0;
            this.authServer_toggleButton.UseVisualStyleBackColor = false;
            this.authServer_toggleButton.Click += new System.EventHandler(this.ToggleAuthServer);
            // 
            // worldServer_toggleButton
            // 
            this.worldServer_toggleButton.BackColor = System.Drawing.Color.Red;
            this.worldServer_toggleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.worldServer_toggleButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.worldServer_toggleButton.Image = ((System.Drawing.Image)(resources.GetObject("worldServer_toggleButton.Image")));
            this.worldServer_toggleButton.Location = new System.Drawing.Point(-1, 28);
            this.worldServer_toggleButton.Name = "worldServer_toggleButton";
            this.worldServer_toggleButton.Size = new System.Drawing.Size(63, 58);
            this.worldServer_toggleButton.TabIndex = 1;
            this.worldServer_toggleButton.UseVisualStyleBackColor = false;
            this.worldServer_toggleButton.Click += new System.EventHandler(this.ToggleWorldServer);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.sqlToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(307, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.editConfigsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.launchClientToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.openClientFolderToolStripMenuItem,
            this.toolStripMenuItem2,
            this.dBErrorslogToolStripMenuItem,
            this.serverlogToolStripMenuItem,
            this.authlogToolStripMenuItem});
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.openFolderToolStripMenuItem.Text = "Open...";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.serverToolStripMenuItem.Text = "Server Folder";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.serverToolStripMenuItem_Click);
            // 
            // openClientFolderToolStripMenuItem
            // 
            this.openClientFolderToolStripMenuItem.Name = "openClientFolderToolStripMenuItem";
            this.openClientFolderToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.openClientFolderToolStripMenuItem.Text = "Client Folder";
            this.openClientFolderToolStripMenuItem.Click += new System.EventHandler(this.openClientFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 6);
            // 
            // dBErrorslogToolStripMenuItem
            // 
            this.dBErrorslogToolStripMenuItem.Name = "dBErrorslogToolStripMenuItem";
            this.dBErrorslogToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.dBErrorslogToolStripMenuItem.Text = "DBErrors.log";
            this.dBErrorslogToolStripMenuItem.Click += new System.EventHandler(this.dBErrorslogToolStripMenuItem_Click);
            // 
            // serverlogToolStripMenuItem
            // 
            this.serverlogToolStripMenuItem.Name = "serverlogToolStripMenuItem";
            this.serverlogToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.serverlogToolStripMenuItem.Text = "Server.log";
            this.serverlogToolStripMenuItem.Click += new System.EventHandler(this.serverlogToolStripMenuItem_Click);
            // 
            // authlogToolStripMenuItem
            // 
            this.authlogToolStripMenuItem.Name = "authlogToolStripMenuItem";
            this.authlogToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.authlogToolStripMenuItem.Text = "Auth.log";
            this.authlogToolStripMenuItem.Click += new System.EventHandler(this.authlogToolStripMenuItem_Click);
            // 
            // editConfigsToolStripMenuItem
            // 
            this.editConfigsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.worldserverconfToolStripMenuItem,
            this.authserverconfToolStripMenuItem,
            this.realmlistwtfToolStripMenuItem});
            this.editConfigsToolStripMenuItem.Name = "editConfigsToolStripMenuItem";
            this.editConfigsToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.editConfigsToolStripMenuItem.Text = "Edit...";
            // 
            // worldserverconfToolStripMenuItem
            // 
            this.worldserverconfToolStripMenuItem.Name = "worldserverconfToolStripMenuItem";
            this.worldserverconfToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.worldserverconfToolStripMenuItem.Text = "worldserver.conf";
            this.worldserverconfToolStripMenuItem.Click += new System.EventHandler(this.worldserverconfToolStripMenuItem_Click);
            // 
            // authserverconfToolStripMenuItem
            // 
            this.authserverconfToolStripMenuItem.Name = "authserverconfToolStripMenuItem";
            this.authserverconfToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.authserverconfToolStripMenuItem.Text = "authserver.conf";
            this.authserverconfToolStripMenuItem.Click += new System.EventHandler(this.authserverconfToolStripMenuItem_Click);
            // 
            // realmlistwtfToolStripMenuItem
            // 
            this.realmlistwtfToolStripMenuItem.Name = "realmlistwtfToolStripMenuItem";
            this.realmlistwtfToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.realmlistwtfToolStripMenuItem.Text = "realmlist.wtf";
            this.realmlistwtfToolStripMenuItem.Click += new System.EventHandler(this.realmlistwtfToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // launchClientToolStripMenuItem
            // 
            this.launchClientToolStripMenuItem.Name = "launchClientToolStripMenuItem";
            this.launchClientToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.launchClientToolStripMenuItem.Text = "Start client";
            this.launchClientToolStripMenuItem.Click += new System.EventHandler(this.launchClientToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem1,
            this.clientToolStripMenuItem,
            this.toolStripMenuItem3});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // serverToolStripMenuItem1
            // 
            this.serverToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideProcessesToolStripMenuItem,
            this.restartProcessesToolStripMenuItem,
            this.clearDBErrorsToolStripMenuItem});
            this.serverToolStripMenuItem1.Name = "serverToolStripMenuItem1";
            this.serverToolStripMenuItem1.Size = new System.Drawing.Size(142, 26);
            this.serverToolStripMenuItem1.Text = "Server";
            // 
            // hideProcessesToolStripMenuItem
            // 
            this.hideProcessesToolStripMenuItem.CheckOnClick = true;
            this.hideProcessesToolStripMenuItem.Name = "hideProcessesToolStripMenuItem";
            this.hideProcessesToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.hideProcessesToolStripMenuItem.Text = "Hide processes";
            this.hideProcessesToolStripMenuItem.ToolTipText = "Hides the worldserver and authserver processes";
            this.hideProcessesToolStripMenuItem.Click += new System.EventHandler(this.hideProcessesToolStripMenuItem_Click);
            // 
            // restartProcessesToolStripMenuItem
            // 
            this.restartProcessesToolStripMenuItem.CheckOnClick = true;
            this.restartProcessesToolStripMenuItem.Name = "restartProcessesToolStripMenuItem";
            this.restartProcessesToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.restartProcessesToolStripMenuItem.Text = "Restart processes";
            this.restartProcessesToolStripMenuItem.ToolTipText = "Restarts server processes on crashes or unexpected exits";
            this.restartProcessesToolStripMenuItem.Click += new System.EventHandler(this.restartProcessesToolStripMenuItem_Click);
            // 
            // clearDBErrorsToolStripMenuItem
            // 
            this.clearDBErrorsToolStripMenuItem.CheckOnClick = true;
            this.clearDBErrorsToolStripMenuItem.Name = "clearDBErrorsToolStripMenuItem";
            this.clearDBErrorsToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.clearDBErrorsToolStripMenuItem.Text = "Clear DBErrors.log";
            this.clearDBErrorsToolStripMenuItem.ToolTipText = "Deletes DBErrors.log upon worldserver startup";
            this.clearDBErrorsToolStripMenuItem.Click += new System.EventHandler(this.clearDBErrorsToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearClientCacheToolStripMenuItem});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.clientToolStripMenuItem.Text = "Client";
            // 
            // clearClientCacheToolStripMenuItem
            // 
            this.clearClientCacheToolStripMenuItem.CheckOnClick = true;
            this.clearClientCacheToolStripMenuItem.Name = "clearClientCacheToolStripMenuItem";
            this.clearClientCacheToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.clearClientCacheToolStripMenuItem.Text = "Clear cache";
            this.clearClientCacheToolStripMenuItem.ToolTipText = "Deletes the client\'s cache folder upon client startup";
            this.clearClientCacheToolStripMenuItem.Click += new System.EventHandler(this.clearClientCacheToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectIconToolStripMenuItem,
            this.showInTaskbarToolStripMenuItem,
            this.showTrayIconToolStripMenuItem,
            this.clearLogToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(142, 26);
            this.toolStripMenuItem3.Text = "Launcher";
            // 
            // selectIconToolStripMenuItem
            // 
            this.selectIconToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueauthserverToolStripMenuItem,
            this.redworldserverToolStripMenuItem,
            this.warcraft1ToolStripMenuItem,
            this.warcraft2ToolStripMenuItem,
            this.warcraft3ToolStripMenuItem,
            this.warcraft4ToolStripMenuItem});
            this.selectIconToolStripMenuItem.Name = "selectIconToolStripMenuItem";
            this.selectIconToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.selectIconToolStripMenuItem.Text = "Select icon...";
            // 
            // blueauthserverToolStripMenuItem
            // 
            this.blueauthserverToolStripMenuItem.Name = "blueauthserverToolStripMenuItem";
            this.blueauthserverToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.blueauthserverToolStripMenuItem.Text = "Blue (authserver)";
            this.blueauthserverToolStripMenuItem.Click += new System.EventHandler(this.blueauthserverToolStripMenuItem_Click);
            // 
            // redworldserverToolStripMenuItem
            // 
            this.redworldserverToolStripMenuItem.Name = "redworldserverToolStripMenuItem";
            this.redworldserverToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.redworldserverToolStripMenuItem.Text = "Red (worldserver)";
            this.redworldserverToolStripMenuItem.Click += new System.EventHandler(this.redworldserverToolStripMenuItem_Click);
            // 
            // warcraft1ToolStripMenuItem
            // 
            this.warcraft1ToolStripMenuItem.Name = "warcraft1ToolStripMenuItem";
            this.warcraft1ToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.warcraft1ToolStripMenuItem.Text = "WoW (Vanilla)";
            this.warcraft1ToolStripMenuItem.Click += new System.EventHandler(this.warcraft1ToolStripMenuItem_Click);
            // 
            // warcraft2ToolStripMenuItem
            // 
            this.warcraft2ToolStripMenuItem.Name = "warcraft2ToolStripMenuItem";
            this.warcraft2ToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.warcraft2ToolStripMenuItem.Text = "WoW (Burning Crusade)";
            this.warcraft2ToolStripMenuItem.Click += new System.EventHandler(this.warcraft2ToolStripMenuItem_Click);
            // 
            // warcraft3ToolStripMenuItem
            // 
            this.warcraft3ToolStripMenuItem.Name = "warcraft3ToolStripMenuItem";
            this.warcraft3ToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.warcraft3ToolStripMenuItem.Text = "WoW (Wrath of the Lich King)";
            this.warcraft3ToolStripMenuItem.Click += new System.EventHandler(this.warcraft3ToolStripMenuItem_Click);
            // 
            // warcraft4ToolStripMenuItem
            // 
            this.warcraft4ToolStripMenuItem.Name = "warcraft4ToolStripMenuItem";
            this.warcraft4ToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.warcraft4ToolStripMenuItem.Text = "WoW (Cataclysm)";
            this.warcraft4ToolStripMenuItem.Click += new System.EventHandler(this.warcraft4ToolStripMenuItem_Click);
            // 
            // showInTaskbarToolStripMenuItem
            // 
            this.showInTaskbarToolStripMenuItem.CheckOnClick = true;
            this.showInTaskbarToolStripMenuItem.Name = "showInTaskbarToolStripMenuItem";
            this.showInTaskbarToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.showInTaskbarToolStripMenuItem.Text = "Show in taskbar";
            this.showInTaskbarToolStripMenuItem.Click += new System.EventHandler(this.showInTaskbarToolStripMenuItem_Click);
            // 
            // showTrayIconToolStripMenuItem
            // 
            this.showTrayIconToolStripMenuItem.CheckOnClick = true;
            this.showTrayIconToolStripMenuItem.Name = "showTrayIconToolStripMenuItem";
            this.showTrayIconToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.showTrayIconToolStripMenuItem.Text = "Show tray icon";
            this.showTrayIconToolStripMenuItem.Click += new System.EventHandler(this.showTrayIconToolStripMenuItem_Click);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.clearLogToolStripMenuItem.Text = "Clear log";
            this.clearLogToolStripMenuItem.ToolTipText = "Clears the log in the launcher window.";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // sqlToolStripMenuItem
            // 
            this.sqlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountManagerToolStripMenuItem});
            this.sqlToolStripMenuItem.Name = "sqlToolStripMenuItem";
            this.sqlToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.sqlToolStripMenuItem.Text = "Sql";
            // 
            // accountManagerToolStripMenuItem
            // 
            this.accountManagerToolStripMenuItem.Name = "accountManagerToolStripMenuItem";
            this.accountManagerToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.accountManagerToolStripMenuItem.Text = "Account Manager";
            this.accountManagerToolStripMenuItem.Click += new System.EventHandler(this.accountManagerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(128, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // launcherLog
            // 
            this.launcherLog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.launcherLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.launcherLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F);
            this.launcherLog.HideSelection = false;
            this.launcherLog.Location = new System.Drawing.Point(68, 33);
            this.launcherLog.Name = "launcherLog";
            this.launcherLog.ReadOnly = true;
            this.launcherLog.Size = new System.Drawing.Size(239, 108);
            this.launcherLog.TabIndex = 6;
            this.launcherLog.Text = "";
            // 
            // ServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(307, 143);
            this.Controls.Add(this.launcherLog);
            this.Controls.Add(this.worldServer_toggleButton);
            this.Controls.Add(this.authServer_toggleButton);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(325, 190);
            this.MinimumSize = new System.Drawing.Size(325, 190);
            this.Name = "ServerControl";
            this.Text = "staleLauncher";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button authServer_toggleButton;
        private System.Windows.Forms.Button worldServer_toggleButton;
        public static System.Windows.Forms.Timer world_upTimer;
        public static System.Windows.Forms.Timer auth_upTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openClientFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dBErrorslogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editConfigsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem worldserverconfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authserverconfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDBErrorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearClientCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem showInTaskbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueauthserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redworldserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warcraft1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warcraft2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warcraft3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warcraft4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realmlistwtfToolStripMenuItem;
        public System.Windows.Forms.RichTextBox launcherLog;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem launchClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTrayIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountManagerToolStripMenuItem;
    }
}