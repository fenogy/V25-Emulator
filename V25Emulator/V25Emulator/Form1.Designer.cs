namespace V25Emulator
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddToShortcut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPolling = new System.Windows.Forms.Button();
            this.comboBoxCommand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddToQ = new System.Windows.Forms.Button();
            this.buttonHex_Dec = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.comboBoxDeviceType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewCaptureQ = new System.Windows.Forms.ListView();
            this.columnPacket = new System.Windows.Forms.ColumnHeader();
            this.columnTime = new System.Windows.Forms.ColumnHeader();
            this.columnProcess = new System.Windows.Forms.ColumnHeader();
            this.columnDevice = new System.Windows.Forms.ColumnHeader();
            this.columnCommand = new System.Windows.Forms.ColumnHeader();
            this.columnData = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richtextBoxDataDetails = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCaptureQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectCommToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.shortcutButton5 = new System.Windows.Forms.Button();
            this.shortcutButton4 = new System.Windows.Forms.Button();
            this.shortcutButton3 = new System.Windows.Forms.Button();
            this.shortcutButton2 = new System.Windows.Forms.Button();
            this.shortcutButton1 = new System.Windows.Forms.Button();
            this.buttonClearQ = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonCommConnect = new System.Windows.Forms.Button();
            this.textBoxComm = new System.Windows.Forms.TextBox();
            this.sendDataDisplay1 = new V25Emulator.SendDataDisplay();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddToShortcut);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonPolling);
            this.groupBox1.Controls.Add(this.comboBoxCommand);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonAddToQ);
            this.groupBox1.Controls.Add(this.buttonHex_Dec);
            this.groupBox1.Controls.Add(this.buttonSend);
            this.groupBox1.Controls.Add(this.comboBoxDeviceType);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(100, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(231, 435);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // buttonAddToShortcut
            // 
            this.buttonAddToShortcut.Location = new System.Drawing.Point(11, 406);
            this.buttonAddToShortcut.Name = "buttonAddToShortcut";
            this.buttonAddToShortcut.Size = new System.Drawing.Size(75, 23);
            this.buttonAddToShortcut.TabIndex = 10;
            this.buttonAddToShortcut.Text = "To Shortcut";
            this.buttonAddToShortcut.UseVisualStyleBackColor = true;
            this.buttonAddToShortcut.Click += new System.EventHandler(this.buttonAddToShortcut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Command";
            // 
            // buttonPolling
            // 
            this.buttonPolling.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPolling.Location = new System.Drawing.Point(11, 374);
            this.buttonPolling.Name = "buttonPolling";
            this.buttonPolling.Size = new System.Drawing.Size(75, 23);
            this.buttonPolling.TabIndex = 9;
            this.buttonPolling.Text = "Start Polling";
            this.buttonPolling.UseVisualStyleBackColor = true;
            this.buttonPolling.Click += new System.EventHandler(this.buttonPolling_Click);
            // 
            // comboBoxCommand
            // 
            this.comboBoxCommand.FormattingEnabled = true;
            this.comboBoxCommand.Location = new System.Drawing.Point(106, 47);
            this.comboBoxCommand.Name = "comboBoxCommand";
            this.comboBoxCommand.Size = new System.Drawing.Size(112, 21);
            this.comboBoxCommand.TabIndex = 5;
            this.comboBoxCommand.SelectedIndexChanged += new System.EventHandler(this.comboBoxCommand_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Device Type";
            // 
            // buttonAddToQ
            // 
            this.buttonAddToQ.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonAddToQ.Location = new System.Drawing.Point(11, 342);
            this.buttonAddToQ.Name = "buttonAddToQ";
            this.buttonAddToQ.Size = new System.Drawing.Size(75, 23);
            this.buttonAddToQ.TabIndex = 2;
            this.buttonAddToQ.Text = "Add to Q";
            this.buttonAddToQ.UseVisualStyleBackColor = true;
            this.buttonAddToQ.Click += new System.EventHandler(this.buttonAddToQ_Click);
            // 
            // buttonHex_Dec
            // 
            this.buttonHex_Dec.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonHex_Dec.Location = new System.Drawing.Point(137, 295);
            this.buttonHex_Dec.Name = "buttonHex_Dec";
            this.buttonHex_Dec.Size = new System.Drawing.Size(75, 23);
            this.buttonHex_Dec.TabIndex = 1;
            this.buttonHex_Dec.Text = "Hex";
            this.buttonHex_Dec.UseVisualStyleBackColor = true;
            this.buttonHex_Dec.Click += new System.EventHandler(this.buttonHex_Dec_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonSend.Location = new System.Drawing.Point(11, 295);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // comboBoxDeviceType
            // 
            this.comboBoxDeviceType.FormattingEnabled = true;
            this.comboBoxDeviceType.Location = new System.Drawing.Point(106, 20);
            this.comboBoxDeviceType.Name = "comboBoxDeviceType";
            this.comboBoxDeviceType.Size = new System.Drawing.Size(112, 21);
            this.comboBoxDeviceType.TabIndex = 3;
            this.comboBoxDeviceType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeviceType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sendDataDisplay1);
            this.groupBox4.Location = new System.Drawing.Point(3, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 209);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "data ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewCaptureQ);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 307);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capture Queue";
            // 
            // listViewCaptureQ
            // 
            this.listViewCaptureQ.AllowColumnReorder = true;
            this.listViewCaptureQ.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPacket,
            this.columnTime,
            this.columnProcess,
            this.columnDevice,
            this.columnCommand,
            this.columnData});
            this.listViewCaptureQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCaptureQ.FullRowSelect = true;
            this.listViewCaptureQ.GridLines = true;
            this.listViewCaptureQ.Location = new System.Drawing.Point(3, 16);
            this.listViewCaptureQ.MultiSelect = false;
            this.listViewCaptureQ.Name = "listViewCaptureQ";
            this.listViewCaptureQ.Size = new System.Drawing.Size(608, 288);
            this.listViewCaptureQ.TabIndex = 2;
            this.listViewCaptureQ.UseCompatibleStateImageBehavior = false;
            this.listViewCaptureQ.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewCaptureQ_ItemSelectionChanged);
            // 
            // columnPacket
            // 
            this.columnPacket.Tag = "Packet";
            this.columnPacket.Text = "Packet";
            // 
            // columnTime
            // 
            this.columnTime.Tag = "Time";
            this.columnTime.Text = "Time";
            // 
            // columnProcess
            // 
            this.columnProcess.Tag = "Process";
            this.columnProcess.Text = "Process";
            // 
            // columnDevice
            // 
            this.columnDevice.Tag = "Device";
            this.columnDevice.Text = "Device";
            // 
            // columnCommand
            // 
            this.columnCommand.Tag = "Command";
            this.columnCommand.Text = "Command";
            this.columnCommand.Width = 80;
            // 
            // columnData
            // 
            this.columnData.Tag = "Data";
            this.columnData.Text = "Data";
            this.columnData.Width = 215;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richtextBoxDataDetails);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 127);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Field Details ";
            // 
            // richtextBoxDataDetails
            // 
            this.richtextBoxDataDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richtextBoxDataDetails.Location = new System.Drawing.Point(3, 16);
            this.richtextBoxDataDetails.Name = "richtextBoxDataDetails";
            this.richtextBoxDataDetails.Size = new System.Drawing.Size(608, 108);
            this.richtextBoxDataDetails.TabIndex = 1;
            this.richtextBoxDataDetails.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fielToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fielToolStripMenuItem
            // 
            this.fielToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fielToolStripMenuItem.Name = "fielToolStripMenuItem";
            this.fielToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fielToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem1.Text = "Save Current Capture Q";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandWizardToolStripMenuItem,
            this.commSettingsToolStripMenuItem,
            this.clearCaptureQToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // commandWizardToolStripMenuItem
            // 
            this.commandWizardToolStripMenuItem.Name = "commandWizardToolStripMenuItem";
            this.commandWizardToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.commandWizardToolStripMenuItem.Text = "Command Wizard";
            this.commandWizardToolStripMenuItem.Click += new System.EventHandler(this.commandWizardToolStripMenuItem_Click);
            // 
            // commSettingsToolStripMenuItem
            // 
            this.commSettingsToolStripMenuItem.Name = "commSettingsToolStripMenuItem";
            this.commSettingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.commSettingsToolStripMenuItem.Text = "Comm Settings";
            this.commSettingsToolStripMenuItem.Click += new System.EventHandler(this.commSettingsToolStripMenuItem_Click);
            // 
            // clearCaptureQToolStripMenuItem
            // 
            this.clearCaptureQToolStripMenuItem.Name = "clearCaptureQToolStripMenuItem";
            this.clearCaptureQToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.clearCaptureQToolStripMenuItem.Text = "Clear Capture Q";
            this.clearCaptureQToolStripMenuItem.Click += new System.EventHandler(this.clearCaptureQToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.connectCommToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.removeToolStripMenuItem.Text = "Polling Q";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // connectCommToolStripMenuItem
            // 
            this.connectCommToolStripMenuItem.Name = "connectCommToolStripMenuItem";
            this.connectCommToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.connectCommToolStripMenuItem.Text = "Connect Comm";
            this.connectCommToolStripMenuItem.Click += new System.EventHandler(this.connectCommToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(852, 435);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(614, 435);
            this.splitContainer2.SplitterDistance = 307;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.shortcutButton5);
            this.groupBox5.Controls.Add(this.shortcutButton4);
            this.groupBox5.Controls.Add(this.shortcutButton3);
            this.groupBox5.Controls.Add(this.shortcutButton2);
            this.groupBox5.Controls.Add(this.shortcutButton1);
            this.groupBox5.Location = new System.Drawing.Point(2, -2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox5.Size = new System.Drawing.Size(462, 59);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Quick Shortcuts";
            // 
            // shortcutButton5
            // 
            this.shortcutButton5.Location = new System.Drawing.Point(365, 22);
            this.shortcutButton5.Name = "shortcutButton5";
            this.shortcutButton5.Size = new System.Drawing.Size(75, 23);
            this.shortcutButton5.TabIndex = 4;
            this.shortcutButton5.Text = "button5";
            this.shortcutButton5.UseVisualStyleBackColor = true;
            this.shortcutButton5.Click += new System.EventHandler(this.shortcutButton5_Click);
            // 
            // shortcutButton4
            // 
            this.shortcutButton4.Location = new System.Drawing.Point(277, 22);
            this.shortcutButton4.Name = "shortcutButton4";
            this.shortcutButton4.Size = new System.Drawing.Size(75, 23);
            this.shortcutButton4.TabIndex = 3;
            this.shortcutButton4.Text = "button4";
            this.shortcutButton4.UseVisualStyleBackColor = true;
            this.shortcutButton4.Click += new System.EventHandler(this.shortcutButton4_Click);
            // 
            // shortcutButton3
            // 
            this.shortcutButton3.Location = new System.Drawing.Point(189, 22);
            this.shortcutButton3.Name = "shortcutButton3";
            this.shortcutButton3.Size = new System.Drawing.Size(75, 23);
            this.shortcutButton3.TabIndex = 2;
            this.shortcutButton3.Text = "button3";
            this.shortcutButton3.UseVisualStyleBackColor = true;
            this.shortcutButton3.Click += new System.EventHandler(this.shortcutButton3_Click);
            // 
            // shortcutButton2
            // 
            this.shortcutButton2.Location = new System.Drawing.Point(101, 22);
            this.shortcutButton2.Name = "shortcutButton2";
            this.shortcutButton2.Size = new System.Drawing.Size(75, 23);
            this.shortcutButton2.TabIndex = 1;
            this.shortcutButton2.Text = "button2";
            this.shortcutButton2.UseVisualStyleBackColor = true;
            this.shortcutButton2.Click += new System.EventHandler(this.shortcutButton2_Click);
            // 
            // shortcutButton1
            // 
            this.shortcutButton1.Location = new System.Drawing.Point(15, 22);
            this.shortcutButton1.Name = "shortcutButton1";
            this.shortcutButton1.Size = new System.Drawing.Size(75, 23);
            this.shortcutButton1.TabIndex = 0;
            this.shortcutButton1.Text = "button1";
            this.shortcutButton1.UseVisualStyleBackColor = true;
            this.shortcutButton1.Click += new System.EventHandler(this.shortcutButton1_Click);
            // 
            // buttonClearQ
            // 
            this.buttonClearQ.Location = new System.Drawing.Point(293, 23);
            this.buttonClearQ.Name = "buttonClearQ";
            this.buttonClearQ.Size = new System.Drawing.Size(75, 23);
            this.buttonClearQ.TabIndex = 5;
            this.buttonClearQ.Text = "Clear Data";
            this.buttonClearQ.UseVisualStyleBackColor = true;
            this.buttonClearQ.Click += new System.EventHandler(this.buttonClearQ_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 24);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer3.Size = new System.Drawing.Size(857, 501);
            this.splitContainer3.SplitterDistance = 437;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 6;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxComm);
            this.groupBox6.Controls.Add(this.buttonCommConnect);
            this.groupBox6.Controls.Add(this.buttonClearQ);
            this.groupBox6.Location = new System.Drawing.Point(470, -3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(384, 60);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // buttonCommConnect
            // 
            this.buttonCommConnect.Location = new System.Drawing.Point(66, 23);
            this.buttonCommConnect.Name = "buttonCommConnect";
            this.buttonCommConnect.Size = new System.Drawing.Size(92, 23);
            this.buttonCommConnect.TabIndex = 6;
            this.buttonCommConnect.Text = "Connect Comm";
            this.buttonCommConnect.UseVisualStyleBackColor = true;
            this.buttonCommConnect.Click += new System.EventHandler(this.buttonCommConnect_Click);
            // 
            // textBoxComm
            // 
            this.textBoxComm.BackColor = System.Drawing.Color.Red;
            this.textBoxComm.Location = new System.Drawing.Point(19, 27);
            this.textBoxComm.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxComm.Multiline = true;
            this.textBoxComm.Name = "textBoxComm";
            this.textBoxComm.Size = new System.Drawing.Size(43, 15);
            this.textBoxComm.TabIndex = 7;
            // 
            // sendDataDisplay1
            // 
            this.sendDataDisplay1.ConfigFilePath = "systemConfig.xml";
            this.sendDataDisplay1.DataByte = null;
            this.sendDataDisplay1.Location = new System.Drawing.Point(3, 14);
            this.sendDataDisplay1.Margin = new System.Windows.Forms.Padding(0);
            this.sendDataDisplay1.Name = "sendDataDisplay1";
            this.sendDataDisplay1.Size = new System.Drawing.Size(217, 192);
            this.sendDataDisplay1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 525);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "V25 Emulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewCaptureQ;
        private System.Windows.Forms.ColumnHeader columnPacket;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.ColumnHeader columnProcess;
        private System.Windows.Forms.ColumnHeader columnDevice;
        private System.Windows.Forms.ColumnHeader columnData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonAddToQ;
        private System.Windows.Forms.Button buttonHex_Dec;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDeviceType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandWizardToolStripMenuItem;
        private SendDataDisplay sendDataDisplay1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem commSettingsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnCommand;
        private System.Windows.Forms.RichTextBox richtextBoxDataDetails;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonPolling;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button buttonAddToShortcut;
        private System.Windows.Forms.ToolStripMenuItem clearCaptureQToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button shortcutButton5;
        private System.Windows.Forms.Button shortcutButton4;
        private System.Windows.Forms.Button shortcutButton3;
        private System.Windows.Forms.Button shortcutButton2;
        private System.Windows.Forms.Button shortcutButton1;
        private System.Windows.Forms.ToolStripMenuItem connectCommToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button buttonClearQ;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxComm;
        private System.Windows.Forms.Button buttonCommConnect;
    }
}

