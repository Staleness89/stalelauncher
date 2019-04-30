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
            this.clearConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.eventLogTabPage = new System.Windows.Forms.TabPage();
            this.eventLogTextBox = new System.Windows.Forms.RichTextBox();
            this.worldConsoleTabPage = new System.Windows.Forms.TabPage();
            this.WorldConsole_InputTextBox = new System.Windows.Forms.TextBox();
            this.worldConsoleTextBox = new System.Windows.Forms.RichTextBox();
            this.dBErrorsTabPage = new System.Windows.Forms.TabPage();
            this.DBErrorsTextBox = new System.Windows.Forms.RichTextBox();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.MySql_ToggleButton = new System.Windows.Forms.Button();
            this.bnetServer_toggleButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.eventLogTabPage.SuspendLayout();
            this.worldConsoleTabPage.SuspendLayout();
            this.dBErrorsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // authServer_toggleButton
            // 
            this.authServer_toggleButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.authServer_toggleButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.authServer_toggleButton.Image = ((System.Drawing.Image)(resources.GetObject("authServer_toggleButton.Image")));
            this.authServer_toggleButton.Location = new System.Drawing.Point(8, 83);
            this.authServer_toggleButton.Name = "authServer_toggleButton";
            this.authServer_toggleButton.Size = new System.Drawing.Size(52, 50);
            this.authServer_toggleButton.TabIndex = 0;
            this.authServer_toggleButton.UseVisualStyleBackColor = false;
            this.authServer_toggleButton.Click += new System.EventHandler(this.ToggleServerButton);
            // 
            // worldServer_toggleButton
            // 
            this.worldServer_toggleButton.BackColor = System.Drawing.Color.MistyRose;
            this.worldServer_toggleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.worldServer_toggleButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.worldServer_toggleButton.Image = ((System.Drawing.Image)(resources.GetObject("worldServer_toggleButton.Image")));
            this.worldServer_toggleButton.Location = new System.Drawing.Point(8, 27);
            this.worldServer_toggleButton.Name = "worldServer_toggleButton";
            this.worldServer_toggleButton.Size = new System.Drawing.Size(52, 50);
            this.worldServer_toggleButton.TabIndex = 1;
            this.worldServer_toggleButton.UseVisualStyleBackColor = false;
            this.worldServer_toggleButton.Click += new System.EventHandler(this.ToggleServerButton);
            // 
            // bnetServer_toggleButton
            // 
            this.bnetServer_toggleButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bnetServer_toggleButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnetServer_toggleButton.Image = ((System.Drawing.Image)(resources.GetObject("bnetServer_toggleButton.Image")));
            this.bnetServer_toggleButton.Location = new System.Drawing.Point(8, 139);
            this.bnetServer_toggleButton.Name = "bnetServer_toggleButton";
            this.bnetServer_toggleButton.Size = new System.Drawing.Size(52, 50);
            this.bnetServer_toggleButton.TabIndex = 9;
            this.bnetServer_toggleButton.UseVisualStyleBackColor = false;
            this.bnetServer_toggleButton.Click += new System.EventHandler(this.ToggleServerButton);
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
            this.menuStrip1.Size = new System.Drawing.Size(359, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
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
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFolderToolStripMenuItem.Text = "Open...";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.serverToolStripMenuItem.Text = "Server Folder";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // openClientFolderToolStripMenuItem
            // 
            this.openClientFolderToolStripMenuItem.Name = "openClientFolderToolStripMenuItem";
            this.openClientFolderToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.openClientFolderToolStripMenuItem.Text = "Client Folder";
            this.openClientFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 6);
            // 
            // dBErrorslogToolStripMenuItem
            // 
            this.dBErrorslogToolStripMenuItem.Name = "dBErrorslogToolStripMenuItem";
            this.dBErrorslogToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.dBErrorslogToolStripMenuItem.Text = "DBErrors.log";
            this.dBErrorslogToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // serverlogToolStripMenuItem
            // 
            this.serverlogToolStripMenuItem.Name = "serverlogToolStripMenuItem";
            this.serverlogToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.serverlogToolStripMenuItem.Text = "Server.log";
            this.serverlogToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // authlogToolStripMenuItem
            // 
            this.authlogToolStripMenuItem.Name = "authlogToolStripMenuItem";
            this.authlogToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.authlogToolStripMenuItem.Text = "Auth.log";
            this.authlogToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // editConfigsToolStripMenuItem
            // 
            this.editConfigsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.worldserverconfToolStripMenuItem,
            this.authserverconfToolStripMenuItem,
            this.realmlistwtfToolStripMenuItem});
            this.editConfigsToolStripMenuItem.Name = "editConfigsToolStripMenuItem";
            this.editConfigsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.editConfigsToolStripMenuItem.Text = "Edit...";
            // 
            // worldserverconfToolStripMenuItem
            // 
            this.worldserverconfToolStripMenuItem.Name = "worldserverconfToolStripMenuItem";
            this.worldserverconfToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.worldserverconfToolStripMenuItem.Text = "worldserver.conf";
            this.worldserverconfToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // authserverconfToolStripMenuItem
            // 
            this.authserverconfToolStripMenuItem.Name = "authserverconfToolStripMenuItem";
            this.authserverconfToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.authserverconfToolStripMenuItem.Text = "authserver.conf";
            this.authserverconfToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // realmlistwtfToolStripMenuItem
            // 
            this.realmlistwtfToolStripMenuItem.Name = "realmlistwtfToolStripMenuItem";
            this.realmlistwtfToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.realmlistwtfToolStripMenuItem.Text = "realmlist.wtf";
            this.realmlistwtfToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // launchClientToolStripMenuItem
            // 
            this.launchClientToolStripMenuItem.Name = "launchClientToolStripMenuItem";
            this.launchClientToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.launchClientToolStripMenuItem.Text = "Start client";
            this.launchClientToolStripMenuItem.Click += new System.EventHandler(this.OpenFileOrFolderToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
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
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // serverToolStripMenuItem1
            // 
            this.serverToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideProcessesToolStripMenuItem,
            this.restartProcessesToolStripMenuItem,
            this.clearDBErrorsToolStripMenuItem});
            this.serverToolStripMenuItem1.Name = "serverToolStripMenuItem1";
            this.serverToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.serverToolStripMenuItem1.Text = "Server";
            // 
            // hideProcessesToolStripMenuItem
            // 
            this.hideProcessesToolStripMenuItem.CheckOnClick = true;
            this.hideProcessesToolStripMenuItem.Name = "hideProcessesToolStripMenuItem";
            this.hideProcessesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hideProcessesToolStripMenuItem.Text = "Hide processes";
            this.hideProcessesToolStripMenuItem.ToolTipText = "Hides server processes. Disables console input/output.";
            this.hideProcessesToolStripMenuItem.Click += new System.EventHandler(this.hideProcessesToolStripMenuItem_Click);
            // 
            // restartProcessesToolStripMenuItem
            // 
            this.restartProcessesToolStripMenuItem.CheckOnClick = true;
            this.restartProcessesToolStripMenuItem.Name = "restartProcessesToolStripMenuItem";
            this.restartProcessesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.restartProcessesToolStripMenuItem.Text = "Restart processes";
            this.restartProcessesToolStripMenuItem.ToolTipText = "Restarts server processes on crashes or unexpected exits";
            this.restartProcessesToolStripMenuItem.Click += new System.EventHandler(this.restartProcessesToolStripMenuItem_Click);
            // 
            // clearDBErrorsToolStripMenuItem
            // 
            this.clearDBErrorsToolStripMenuItem.CheckOnClick = true;
            this.clearDBErrorsToolStripMenuItem.Name = "clearDBErrorsToolStripMenuItem";
            this.clearDBErrorsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.clearDBErrorsToolStripMenuItem.Text = "Clear DBErrors.log";
            this.clearDBErrorsToolStripMenuItem.ToolTipText = "Deletes DBErrors.log upon worldserver startup";
            this.clearDBErrorsToolStripMenuItem.Click += new System.EventHandler(this.clearDBErrorsToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearClientCacheToolStripMenuItem});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.clientToolStripMenuItem.Text = "Client";
            // 
            // clearClientCacheToolStripMenuItem
            // 
            this.clearClientCacheToolStripMenuItem.CheckOnClick = true;
            this.clearClientCacheToolStripMenuItem.Name = "clearClientCacheToolStripMenuItem";
            this.clearClientCacheToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
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
            this.clearConsoleToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(119, 22);
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
            this.selectIconToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.selectIconToolStripMenuItem.Text = "Select icon...";
            // 
            // blueauthserverToolStripMenuItem
            // 
            this.blueauthserverToolStripMenuItem.Name = "blueauthserverToolStripMenuItem";
            this.blueauthserverToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.blueauthserverToolStripMenuItem.Text = "authserver";
            this.blueauthserverToolStripMenuItem.Click += new System.EventHandler(this.changeIconToolStripMenuItem_Click);
            // 
            // redworldserverToolStripMenuItem
            // 
            this.redworldserverToolStripMenuItem.Name = "redworldserverToolStripMenuItem";
            this.redworldserverToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.redworldserverToolStripMenuItem.Text = "worldserver";
            this.redworldserverToolStripMenuItem.Click += new System.EventHandler(this.changeIconToolStripMenuItem_Click);
            // 
            // warcraft1ToolStripMenuItem
            // 
            this.warcraft1ToolStripMenuItem.Name = "warcraft1ToolStripMenuItem";
            this.warcraft1ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.warcraft1ToolStripMenuItem.Text = "WoW1";
            this.warcraft1ToolStripMenuItem.Click += new System.EventHandler(this.changeIconToolStripMenuItem_Click);
            // 
            // warcraft2ToolStripMenuItem
            // 
            this.warcraft2ToolStripMenuItem.Name = "warcraft2ToolStripMenuItem";
            this.warcraft2ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.warcraft2ToolStripMenuItem.Text = "WoW2";
            this.warcraft2ToolStripMenuItem.Click += new System.EventHandler(this.changeIconToolStripMenuItem_Click);
            // 
            // warcraft3ToolStripMenuItem
            // 
            this.warcraft3ToolStripMenuItem.Name = "warcraft3ToolStripMenuItem";
            this.warcraft3ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.warcraft3ToolStripMenuItem.Text = "WoW3";
            this.warcraft3ToolStripMenuItem.Click += new System.EventHandler(this.changeIconToolStripMenuItem_Click);
            // 
            // warcraft4ToolStripMenuItem
            // 
            this.warcraft4ToolStripMenuItem.Name = "warcraft4ToolStripMenuItem";
            this.warcraft4ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.warcraft4ToolStripMenuItem.Text = "WoW4";
            this.warcraft4ToolStripMenuItem.Click += new System.EventHandler(this.changeIconToolStripMenuItem_Click);
            // 
            // showInTaskbarToolStripMenuItem
            // 
            this.showInTaskbarToolStripMenuItem.CheckOnClick = true;
            this.showInTaskbarToolStripMenuItem.Name = "showInTaskbarToolStripMenuItem";
            this.showInTaskbarToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.showInTaskbarToolStripMenuItem.Text = "Show in taskbar";
            this.showInTaskbarToolStripMenuItem.Click += new System.EventHandler(this.showInTaskbarToolStripMenuItem_Click);
            // 
            // showTrayIconToolStripMenuItem
            // 
            this.showTrayIconToolStripMenuItem.CheckOnClick = true;
            this.showTrayIconToolStripMenuItem.Name = "showTrayIconToolStripMenuItem";
            this.showTrayIconToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.showTrayIconToolStripMenuItem.Text = "Show tray icon";
            this.showTrayIconToolStripMenuItem.Click += new System.EventHandler(this.showTrayIconToolStripMenuItem_Click);
            // 
            // clearConsoleToolStripMenuItem
            // 
            this.clearConsoleToolStripMenuItem.CheckOnClick = true;
            this.clearConsoleToolStripMenuItem.Name = "clearConsoleToolStripMenuItem";
            this.clearConsoleToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.clearConsoleToolStripMenuItem.Text = "Startup clears console";
            this.clearConsoleToolStripMenuItem.ToolTipText = "Set to clear the world console log on (re)start. ";
            this.clearConsoleToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // sqlToolStripMenuItem
            // 
            this.sqlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountManagerToolStripMenuItem});
            this.sqlToolStripMenuItem.Name = "sqlToolStripMenuItem";
            this.sqlToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.sqlToolStripMenuItem.Text = "Sql";
            // 
            // accountManagerToolStripMenuItem
            // 
            this.accountManagerToolStripMenuItem.Name = "accountManagerToolStripMenuItem";
            this.accountManagerToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.accountManagerToolStripMenuItem.Text = "Account Manager";
            this.accountManagerToolStripMenuItem.Click += new System.EventHandler(this.accountManagerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(108, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.eventLogTabPage);
            this.tabControl1.Controls.Add(this.worldConsoleTabPage);
            this.tabControl1.Controls.Add(this.dBErrorsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(68, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(291, 223);
            this.tabControl1.TabIndex = 7;
            // 
            // eventLogTabPage
            // 
            this.eventLogTabPage.Controls.Add(this.eventLogTextBox);
            this.eventLogTabPage.Location = new System.Drawing.Point(4, 21);
            this.eventLogTabPage.Name = "eventLogTabPage";
            this.eventLogTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.eventLogTabPage.Size = new System.Drawing.Size(283, 198);
            this.eventLogTabPage.TabIndex = 2;
            this.eventLogTabPage.Text = "Event Log";
            this.eventLogTabPage.UseVisualStyleBackColor = true;
            // 
            // eventLogTextBox
            // 
            this.eventLogTextBox.Location = new System.Drawing.Point(0, 0);
            this.eventLogTextBox.Name = "eventLogTextBox";
            this.eventLogTextBox.ReadOnly = true;
            this.eventLogTextBox.Size = new System.Drawing.Size(287, 202);
            this.eventLogTextBox.TabIndex = 2;
            this.eventLogTextBox.Text = "";
            // 
            // worldConsoleTabPage
            // 
            this.worldConsoleTabPage.Controls.Add(this.WorldConsole_InputTextBox);
            this.worldConsoleTabPage.Controls.Add(this.worldConsoleTextBox);
            this.worldConsoleTabPage.Location = new System.Drawing.Point(4, 21);
            this.worldConsoleTabPage.Name = "worldConsoleTabPage";
            this.worldConsoleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.worldConsoleTabPage.Size = new System.Drawing.Size(283, 198);
            this.worldConsoleTabPage.TabIndex = 0;
            this.worldConsoleTabPage.Text = "World Console";
            this.worldConsoleTabPage.UseVisualStyleBackColor = true;
            // 
            // WorldConsole_InputTextBox
            // 
            this.WorldConsole_InputTextBox.Location = new System.Drawing.Point(3, 177);
            this.WorldConsole_InputTextBox.Name = "WorldConsole_InputTextBox";
            this.WorldConsole_InputTextBox.Size = new System.Drawing.Size(276, 18);
            this.WorldConsole_InputTextBox.TabIndex = 3;
            this.WorldConsole_InputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorldConsole_InputTextBox_Enter);
            // 
            // worldConsoleTextBox
            // 
            this.worldConsoleTextBox.DetectUrls = false;
            this.worldConsoleTextBox.HideSelection = false;
            this.worldConsoleTextBox.Location = new System.Drawing.Point(0, 0);
            this.worldConsoleTextBox.Name = "worldConsoleTextBox";
            this.worldConsoleTextBox.ReadOnly = true;
            this.worldConsoleTextBox.Size = new System.Drawing.Size(287, 172);
            this.worldConsoleTextBox.TabIndex = 0;
            this.worldConsoleTextBox.Text = "";
            // 
            // dBErrorsTabPage
            // 
            this.dBErrorsTabPage.Controls.Add(this.DBErrorsTextBox);
            this.dBErrorsTabPage.Location = new System.Drawing.Point(4, 21);
            this.dBErrorsTabPage.Name = "dBErrorsTabPage";
            this.dBErrorsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dBErrorsTabPage.Size = new System.Drawing.Size(283, 198);
            this.dBErrorsTabPage.TabIndex = 1;
            this.dBErrorsTabPage.Text = "DB Errors";
            this.dBErrorsTabPage.UseVisualStyleBackColor = true;
            // 
            // DBErrorsTextBox
            // 
            this.DBErrorsTextBox.DetectUrls = false;
            this.DBErrorsTextBox.HideSelection = false;
            this.DBErrorsTextBox.Location = new System.Drawing.Point(0, 0);
            this.DBErrorsTextBox.Name = "DBErrorsTextBox";
            this.DBErrorsTextBox.ReadOnly = true;
            this.DBErrorsTextBox.Size = new System.Drawing.Size(287, 202);
            this.DBErrorsTextBox.TabIndex = 1;
            this.DBErrorsTextBox.Text = "";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // MySql_ToggleButton
            // 
            this.MySql_ToggleButton.BackColor = System.Drawing.Color.White;
            this.MySql_ToggleButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.MySql_ToggleButton.Image = ((System.Drawing.Image)(resources.GetObject("MySql_ToggleButton.Image")));
            this.MySql_ToggleButton.Location = new System.Drawing.Point(8, 195);
            this.MySql_ToggleButton.Name = "MySql_ToggleButton";
            this.MySql_ToggleButton.Size = new System.Drawing.Size(52, 50);
            this.MySql_ToggleButton.TabIndex = 8;
            this.MySql_ToggleButton.UseVisualStyleBackColor = false;
            this.MySql_ToggleButton.Click += new System.EventHandler(this.ToggleServerButton);
            // 
            // ServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(359, 251);
            this.Controls.Add(this.bnetServer_toggleButton);
            this.Controls.Add(this.MySql_ToggleButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.worldServer_toggleButton);
            this.Controls.Add(this.authServer_toggleButton);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(375, 290);
            this.MinimumSize = new System.Drawing.Size(375, 290);
            this.Name = "ServerControl";
            this.Text = "staleLauncher";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.eventLogTabPage.ResumeLayout(false);
            this.worldConsoleTabPage.ResumeLayout(false);
            this.worldConsoleTabPage.PerformLayout();
            this.dBErrorsTabPage.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem clearConsoleToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem launchClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTrayIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountManagerToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage worldConsoleTabPage;
        private System.Windows.Forms.TextBox WorldConsole_InputTextBox;
        private System.Windows.Forms.RichTextBox worldConsoleTextBox;
        private System.Windows.Forms.TabPage dBErrorsTabPage;
        private System.Windows.Forms.RichTextBox DBErrorsTextBox;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.TabPage eventLogTabPage;
        private System.Windows.Forms.RichTextBox eventLogTextBox;
        private System.Windows.Forms.Button MySql_ToggleButton;
        private System.Windows.Forms.Button bnetServer_toggleButton;
    }
}