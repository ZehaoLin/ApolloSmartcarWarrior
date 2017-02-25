namespace UserWinFroms
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainMenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usrSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iARToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.MDKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IARToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.bootLoaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tlblSerialStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tlblSerialRxCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSerialRxCntNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSerialTxCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblSerialTxCntNymber = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSerial = new System.Windows.Forms.TabPage();
            this.groupBoxSerialRxAndTxCtrl = new System.Windows.Forms.GroupBox();
            this.btnSerialClearCnt = new System.Windows.Forms.Button();
            this.btnSerialClearTx = new System.Windows.Forms.Button();
            this.btnSerialClearRx = new System.Windows.Forms.Button();
            this.btnSerialPause = new System.Windows.Forms.Button();
            this.btnSerialReceive = new System.Windows.Forms.Button();
            this.checkBoxSerialAutoSend = new System.Windows.Forms.CheckBox();
            this.lblUnitMs = new System.Windows.Forms.Label();
            this.lbSerialSendPeriodTime = new System.Windows.Forms.Label();
            this.txbSerilaSendPeriodTime = new System.Windows.Forms.TextBox();
            this.btnSerialSend = new System.Windows.Forms.Button();
            this.rbtnSerialHex = new System.Windows.Forms.RadioButton();
            this.rbtnSerialChar = new System.Windows.Forms.RadioButton();
            this.groupBoxSeriaSendData = new System.Windows.Forms.GroupBox();
            this.txbSerialSendData = new System.Windows.Forms.TextBox();
            this.groupBoxSerialReceiveData = new System.Windows.Forms.GroupBox();
            this.txbSerialReceiveData = new System.Windows.Forms.TextBox();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.groupBoxImageCtrl = new System.Windows.Forms.GroupBox();
            this.btnBinaryGray = new System.Windows.Forms.Button();
            this.numericUpDownImageThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblImageColNumber = new System.Windows.Forms.Label();
            this.lblImageRowNumber = new System.Windows.Forms.Label();
            this.btnImageFilp = new System.Windows.Forms.Button();
            this.lblImageThreshold = new System.Windows.Forms.Label();
            this.lblImageCol = new System.Windows.Forms.Label();
            this.lblImageRow = new System.Windows.Forms.Label();
            this.btnImageGray = new System.Windows.Forms.Button();
            this.txbImageProcData = new System.Windows.Forms.TextBox();
            this.btnImageBegin = new System.Windows.Forms.Button();
            this.btnImageAlgorithm = new System.Windows.Forms.Button();
            this.groupBoxImageGray = new System.Windows.Forms.GroupBox();
            this.chartImageGray = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.binaryImagePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBoxOriginalImage = new System.Windows.Forms.GroupBox();
            this.originalImagePictureBox = new System.Windows.Forms.PictureBox();
            this.tabPageScope = new System.Windows.Forms.TabPage();
            this.tabPageNetWorker = new System.Windows.Forms.TabPage();
            this.groupBoxCOMCtrl = new System.Windows.Forms.GroupBox();
            this.lblCOMStatus = new System.Windows.Forms.Label();
            this.btnSerialportSearch = new System.Windows.Forms.Button();
            this.btnSerialportCtrl = new System.Windows.Forms.Button();
            this.cmbCOMPort = new System.Windows.Forms.ComboBox();
            this.lblCOMPort = new System.Windows.Forms.Label();
            this.groupBoxFileCtrl = new System.Windows.Forms.GroupBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnFileEmpty = new System.Windows.Forms.Button();
            this.btnFilePrevious = new System.Windows.Forms.Button();
            this.btnFileNext = new System.Windows.Forms.Button();
            this.btnFileDelete = new System.Windows.Forms.Button();
            this.btnFileSave = new System.Windows.Forms.Button();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.progressbarTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenuBar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageSerial.SuspendLayout();
            this.groupBoxSerialRxAndTxCtrl.SuspendLayout();
            this.groupBoxSeriaSendData.SuspendLayout();
            this.groupBoxSerialReceiveData.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            this.groupBoxImageCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImageThreshold)).BeginInit();
            this.groupBoxImageGray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartImageGray)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binaryImagePictureBox)).BeginInit();
            this.groupBoxOriginalImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePictureBox)).BeginInit();
            this.groupBoxCOMCtrl.SuspendLayout();
            this.groupBoxFileCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuBar.Location = new System.Drawing.Point(0, 0);
            this.mainMenuBar.Name = "mainMenuBar";
            this.mainMenuBar.Size = new System.Drawing.Size(855, 25);
            this.mainMenuBar.TabIndex = 0;
            this.mainMenuBar.Text = "menuStripMainFrm";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(105, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usrSettingToolStripMenuItem,
            this.iARToolStripMenuItem,
            this.MDKToolStripMenuItem,
            this.IARToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.bootLoaderToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // usrSettingToolStripMenuItem
            // 
            this.usrSettingToolStripMenuItem.Name = "usrSettingToolStripMenuItem";
            this.usrSettingToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.usrSettingToolStripMenuItem.Text = "Setting";
            this.usrSettingToolStripMenuItem.Click += new System.EventHandler(this.userSettingToolStripMenuItem_Click);
            // 
            // iARToolStripMenuItem
            // 
            this.iARToolStripMenuItem.Name = "iARToolStripMenuItem";
            this.iARToolStripMenuItem.Size = new System.Drawing.Size(142, 6);
            // 
            // MDKToolStripMenuItem
            // 
            this.MDKToolStripMenuItem.Name = "MDKToolStripMenuItem";
            this.MDKToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.MDKToolStripMenuItem.Text = "MDK";
            // 
            // IARToolStripMenuItem1
            // 
            this.IARToolStripMenuItem1.Name = "IARToolStripMenuItem1";
            this.IARToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.IARToolStripMenuItem1.Text = "IAR";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(142, 6);
            // 
            // bootLoaderToolStripMenuItem
            // 
            this.bootLoaderToolStripMenuItem.Name = "bootLoaderToolStripMenuItem";
            this.bootLoaderToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.bootLoaderToolStripMenuItem.Text = "BootLoader";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuidToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.feedbackToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userGuidToolStripMenuItem
            // 
            this.userGuidToolStripMenuItem.Name = "userGuidToolStripMenuItem";
            this.userGuidToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.userGuidToolStripMenuItem.Text = "User Guid";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            this.feedbackToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.feedbackToolStripMenuItem.Text = "Feedback";
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblSerialStatus,
            this.toolStripProgressBar,
            this.tlblSerialRxCnt,
            this.tlblSerialRxCntNumber,
            this.tlblSerialTxCnt,
            this.tlblSerialTxCntNymber});
            this.statusStrip.Location = new System.Drawing.Point(0, 510);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(855, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // tlblSerialStatus
            // 
            this.tlblSerialStatus.Name = "tlblSerialStatus";
            this.tlblSerialStatus.Size = new System.Drawing.Size(44, 17);
            this.tlblSerialStatus.Text = "Ready";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Step = 1;
            // 
            // tlblSerialRxCnt
            // 
            this.tlblSerialRxCnt.Name = "tlblSerialRxCnt";
            this.tlblSerialRxCnt.Size = new System.Drawing.Size(65, 17);
            this.tlblSerialRxCnt.Text = "          Rx:";
            // 
            // tlblSerialRxCntNumber
            // 
            this.tlblSerialRxCntNumber.Name = "tlblSerialRxCntNumber";
            this.tlblSerialRxCntNumber.Size = new System.Drawing.Size(15, 17);
            this.tlblSerialRxCntNumber.Text = "0";
            // 
            // tlblSerialTxCnt
            // 
            this.tlblSerialTxCnt.Name = "tlblSerialTxCnt";
            this.tlblSerialTxCnt.Size = new System.Drawing.Size(64, 17);
            this.tlblSerialTxCnt.Text = "          Tx:";
            // 
            // tlblSerialTxCntNymber
            // 
            this.tlblSerialTxCntNymber.Name = "tlblSerialTxCntNymber";
            this.tlblSerialTxCntNymber.Size = new System.Drawing.Size(15, 17);
            this.tlblSerialTxCntNymber.Text = "0";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSerial);
            this.tabControl.Controls.Add(this.tabPageImage);
            this.tabControl.Controls.Add(this.tabPageScope);
            this.tabControl.Controls.Add(this.tabPageNetWorker);
            this.tabControl.Location = new System.Drawing.Point(8, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(685, 480);
            this.tabControl.TabIndex = 3;
            // 
            // tabPageSerial
            // 
            this.tabPageSerial.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSerial.Controls.Add(this.groupBoxSerialRxAndTxCtrl);
            this.tabPageSerial.Controls.Add(this.groupBoxSeriaSendData);
            this.tabPageSerial.Controls.Add(this.groupBoxSerialReceiveData);
            this.tabPageSerial.Location = new System.Drawing.Point(4, 22);
            this.tabPageSerial.Name = "tabPageSerial";
            this.tabPageSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSerial.Size = new System.Drawing.Size(677, 454);
            this.tabPageSerial.TabIndex = 0;
            this.tabPageSerial.Text = "SerialPort";
            // 
            // groupBoxSerialRxAndTxCtrl
            // 
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.btnSerialClearCnt);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.btnSerialClearTx);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.btnSerialClearRx);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.btnSerialPause);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.btnSerialReceive);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.checkBoxSerialAutoSend);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.lblUnitMs);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.lbSerialSendPeriodTime);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.txbSerilaSendPeriodTime);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.btnSerialSend);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.rbtnSerialHex);
            this.groupBoxSerialRxAndTxCtrl.Controls.Add(this.rbtnSerialChar);
            this.groupBoxSerialRxAndTxCtrl.Location = new System.Drawing.Point(470, 267);
            this.groupBoxSerialRxAndTxCtrl.Name = "groupBoxSerialRxAndTxCtrl";
            this.groupBoxSerialRxAndTxCtrl.Size = new System.Drawing.Size(203, 187);
            this.groupBoxSerialRxAndTxCtrl.TabIndex = 4;
            this.groupBoxSerialRxAndTxCtrl.TabStop = false;
            this.groupBoxSerialRxAndTxCtrl.Text = "Rx/Tx Control";
            // 
            // btnSerialClearCnt
            // 
            this.btnSerialClearCnt.Location = new System.Drawing.Point(111, 117);
            this.btnSerialClearCnt.Name = "btnSerialClearCnt";
            this.btnSerialClearCnt.Size = new System.Drawing.Size(75, 23);
            this.btnSerialClearCnt.TabIndex = 12;
            this.btnSerialClearCnt.Text = "Clear Cnt";
            this.btnSerialClearCnt.UseVisualStyleBackColor = true;
            this.btnSerialClearCnt.Click += new System.EventHandler(this.BtnSerialClearCnt_Click);
            // 
            // btnSerialClearTx
            // 
            this.btnSerialClearTx.Location = new System.Drawing.Point(111, 146);
            this.btnSerialClearTx.Name = "btnSerialClearTx";
            this.btnSerialClearTx.Size = new System.Drawing.Size(75, 23);
            this.btnSerialClearTx.TabIndex = 11;
            this.btnSerialClearTx.Text = "Clear Tx";
            this.btnSerialClearTx.UseVisualStyleBackColor = true;
            this.btnSerialClearTx.Click += new System.EventHandler(this.btnSerialClearTx_Click);
            // 
            // btnSerialClearRx
            // 
            this.btnSerialClearRx.Location = new System.Drawing.Point(20, 146);
            this.btnSerialClearRx.Name = "btnSerialClearRx";
            this.btnSerialClearRx.Size = new System.Drawing.Size(75, 23);
            this.btnSerialClearRx.TabIndex = 10;
            this.btnSerialClearRx.Text = "Clear Rx";
            this.btnSerialClearRx.UseVisualStyleBackColor = true;
            this.btnSerialClearRx.Click += new System.EventHandler(this.btnSerialClearRx_Click);
            // 
            // btnSerialPause
            // 
            this.btnSerialPause.Location = new System.Drawing.Point(20, 117);
            this.btnSerialPause.Name = "btnSerialPause";
            this.btnSerialPause.Size = new System.Drawing.Size(75, 23);
            this.btnSerialPause.TabIndex = 9;
            this.btnSerialPause.Text = "Pause";
            this.btnSerialPause.UseVisualStyleBackColor = true;
            this.btnSerialPause.Click += new System.EventHandler(this.btnSerialPause_Click);
            // 
            // btnSerialReceive
            // 
            this.btnSerialReceive.Location = new System.Drawing.Point(111, 88);
            this.btnSerialReceive.Name = "btnSerialReceive";
            this.btnSerialReceive.Size = new System.Drawing.Size(75, 23);
            this.btnSerialReceive.TabIndex = 8;
            this.btnSerialReceive.Text = "Receive";
            this.btnSerialReceive.UseVisualStyleBackColor = true;
            this.btnSerialReceive.Click += new System.EventHandler(this.tbnSerialReceive_Click);
            // 
            // checkBoxSerialAutoSend
            // 
            this.checkBoxSerialAutoSend.AutoSize = true;
            this.checkBoxSerialAutoSend.Location = new System.Drawing.Point(117, 19);
            this.checkBoxSerialAutoSend.Name = "checkBoxSerialAutoSend";
            this.checkBoxSerialAutoSend.Size = new System.Drawing.Size(78, 16);
            this.checkBoxSerialAutoSend.TabIndex = 7;
            this.checkBoxSerialAutoSend.Text = "Auto Send";
            this.checkBoxSerialAutoSend.UseVisualStyleBackColor = true;
            this.checkBoxSerialAutoSend.CheckedChanged += new System.EventHandler(this.checkBoxSerialAutoSend_CheckedChanged);
            // 
            // lblUnitMs
            // 
            this.lblUnitMs.AutoSize = true;
            this.lblUnitMs.Location = new System.Drawing.Point(146, 48);
            this.lblUnitMs.Name = "lblUnitMs";
            this.lblUnitMs.Size = new System.Drawing.Size(17, 12);
            this.lblUnitMs.TabIndex = 6;
            this.lblUnitMs.Text = "ms";
            // 
            // lbSerialSendPeriodTime
            // 
            this.lbSerialSendPeriodTime.AutoSize = true;
            this.lbSerialSendPeriodTime.Location = new System.Drawing.Point(24, 48);
            this.lbSerialSendPeriodTime.Name = "lbSerialSendPeriodTime";
            this.lbSerialSendPeriodTime.Size = new System.Drawing.Size(71, 12);
            this.lbSerialSendPeriodTime.TabIndex = 5;
            this.lbSerialSendPeriodTime.Text = "Period Time";
            // 
            // txbSerilaSendPeriodTime
            // 
            this.txbSerilaSendPeriodTime.Location = new System.Drawing.Point(101, 45);
            this.txbSerilaSendPeriodTime.Name = "txbSerilaSendPeriodTime";
            this.txbSerilaSendPeriodTime.Size = new System.Drawing.Size(39, 21);
            this.txbSerilaSendPeriodTime.TabIndex = 4;
            this.txbSerilaSendPeriodTime.Text = "1000";
            // 
            // btnSerialSend
            // 
            this.btnSerialSend.Location = new System.Drawing.Point(20, 88);
            this.btnSerialSend.Name = "btnSerialSend";
            this.btnSerialSend.Size = new System.Drawing.Size(75, 23);
            this.btnSerialSend.TabIndex = 2;
            this.btnSerialSend.Text = "Send";
            this.btnSerialSend.UseVisualStyleBackColor = true;
            this.btnSerialSend.Click += new System.EventHandler(this.btnSerialSend_Click);
            // 
            // rbtnSerialHex
            // 
            this.rbtnSerialHex.AutoSize = true;
            this.rbtnSerialHex.Location = new System.Drawing.Point(70, 18);
            this.rbtnSerialHex.Name = "rbtnSerialHex";
            this.rbtnSerialHex.Size = new System.Drawing.Size(41, 16);
            this.rbtnSerialHex.TabIndex = 1;
            this.rbtnSerialHex.Text = "Hex";
            this.rbtnSerialHex.UseVisualStyleBackColor = true;
            this.rbtnSerialHex.CheckedChanged += new System.EventHandler(this.rbtnSerialHex_CheckedChanged);
            // 
            // rbtnSerialChar
            // 
            this.rbtnSerialChar.AutoSize = true;
            this.rbtnSerialChar.Checked = true;
            this.rbtnSerialChar.Location = new System.Drawing.Point(8, 18);
            this.rbtnSerialChar.Name = "rbtnSerialChar";
            this.rbtnSerialChar.Size = new System.Drawing.Size(47, 16);
            this.rbtnSerialChar.TabIndex = 0;
            this.rbtnSerialChar.TabStop = true;
            this.rbtnSerialChar.Text = "Char";
            this.rbtnSerialChar.UseVisualStyleBackColor = true;
            // 
            // groupBoxSeriaSendData
            // 
            this.groupBoxSeriaSendData.Controls.Add(this.txbSerialSendData);
            this.groupBoxSeriaSendData.Location = new System.Drawing.Point(8, 267);
            this.groupBoxSeriaSendData.Name = "groupBoxSeriaSendData";
            this.groupBoxSeriaSendData.Size = new System.Drawing.Size(457, 187);
            this.groupBoxSeriaSendData.TabIndex = 1;
            this.groupBoxSeriaSendData.TabStop = false;
            this.groupBoxSeriaSendData.Text = "Sending Data";
            // 
            // txbSerialSendData
            // 
            this.txbSerialSendData.AcceptsReturn = true;
            this.txbSerialSendData.AcceptsTab = true;
            this.txbSerialSendData.AllowDrop = true;
            this.txbSerialSendData.Location = new System.Drawing.Point(5, 15);
            this.txbSerialSendData.Multiline = true;
            this.txbSerialSendData.Name = "txbSerialSendData";
            this.txbSerialSendData.Size = new System.Drawing.Size(447, 168);
            this.txbSerialSendData.TabIndex = 0;
            // 
            // groupBoxSerialReceiveData
            // 
            this.groupBoxSerialReceiveData.Controls.Add(this.txbSerialReceiveData);
            this.groupBoxSerialReceiveData.Location = new System.Drawing.Point(8, 6);
            this.groupBoxSerialReceiveData.Name = "groupBoxSerialReceiveData";
            this.groupBoxSerialReceiveData.Size = new System.Drawing.Size(665, 256);
            this.groupBoxSerialReceiveData.TabIndex = 0;
            this.groupBoxSerialReceiveData.TabStop = false;
            this.groupBoxSerialReceiveData.Text = "Receiving Data";
            // 
            // txbSerialReceiveData
            // 
            this.txbSerialReceiveData.AllowDrop = true;
            this.txbSerialReceiveData.Location = new System.Drawing.Point(6, 14);
            this.txbSerialReceiveData.Multiline = true;
            this.txbSerialReceiveData.Name = "txbSerialReceiveData";
            this.txbSerialReceiveData.ReadOnly = true;
            this.txbSerialReceiveData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbSerialReceiveData.Size = new System.Drawing.Size(655, 238);
            this.txbSerialReceiveData.TabIndex = 0;
            // 
            // tabPageImage
            // 
            this.tabPageImage.BackColor = System.Drawing.Color.Transparent;
            this.tabPageImage.Controls.Add(this.groupBoxImageCtrl);
            this.tabPageImage.Controls.Add(this.groupBoxImageGray);
            this.tabPageImage.Controls.Add(this.groupBox1);
            this.tabPageImage.Controls.Add(this.groupBoxOriginalImage);
            this.tabPageImage.Location = new System.Drawing.Point(4, 22);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(677, 454);
            this.tabPageImage.TabIndex = 1;
            this.tabPageImage.Text = "Image";
            // 
            // groupBoxImageCtrl
            // 
            this.groupBoxImageCtrl.Controls.Add(this.btnBinaryGray);
            this.groupBoxImageCtrl.Controls.Add(this.numericUpDownImageThreshold);
            this.groupBoxImageCtrl.Controls.Add(this.lblImageColNumber);
            this.groupBoxImageCtrl.Controls.Add(this.lblImageRowNumber);
            this.groupBoxImageCtrl.Controls.Add(this.btnImageFilp);
            this.groupBoxImageCtrl.Controls.Add(this.lblImageThreshold);
            this.groupBoxImageCtrl.Controls.Add(this.lblImageCol);
            this.groupBoxImageCtrl.Controls.Add(this.lblImageRow);
            this.groupBoxImageCtrl.Controls.Add(this.btnImageGray);
            this.groupBoxImageCtrl.Controls.Add(this.txbImageProcData);
            this.groupBoxImageCtrl.Controls.Add(this.btnImageBegin);
            this.groupBoxImageCtrl.Controls.Add(this.btnImageAlgorithm);
            this.groupBoxImageCtrl.Location = new System.Drawing.Point(304, 231);
            this.groupBoxImageCtrl.Name = "groupBoxImageCtrl";
            this.groupBoxImageCtrl.Size = new System.Drawing.Size(368, 221);
            this.groupBoxImageCtrl.TabIndex = 4;
            this.groupBoxImageCtrl.TabStop = false;
            this.groupBoxImageCtrl.Text = "Image Control";
            // 
            // btnBinaryGray
            // 
            this.btnBinaryGray.Location = new System.Drawing.Point(272, 133);
            this.btnBinaryGray.Name = "btnBinaryGray";
            this.btnBinaryGray.Size = new System.Drawing.Size(90, 23);
            this.btnBinaryGray.TabIndex = 13;
            this.btnBinaryGray.Text = "Binary";
            this.btnBinaryGray.UseVisualStyleBackColor = true;
            this.btnBinaryGray.Click += new System.EventHandler(this.btnBinaryGray_Click);
            // 
            // numericUpDownImageThreshold
            // 
            this.numericUpDownImageThreshold.Location = new System.Drawing.Point(331, 195);
            this.numericUpDownImageThreshold.Name = "numericUpDownImageThreshold";
            this.numericUpDownImageThreshold.Size = new System.Drawing.Size(37, 21);
            this.numericUpDownImageThreshold.TabIndex = 12;
            this.numericUpDownImageThreshold.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownImageThreshold.ValueChanged += new System.EventHandler(this.numericUpDownImageThreshold_ValueChanged);
            // 
            // lblImageColNumber
            // 
            this.lblImageColNumber.AutoSize = true;
            this.lblImageColNumber.Location = new System.Drawing.Point(308, 179);
            this.lblImageColNumber.Name = "lblImageColNumber";
            this.lblImageColNumber.Size = new System.Drawing.Size(11, 12);
            this.lblImageColNumber.TabIndex = 11;
            this.lblImageColNumber.Text = "0";
            // 
            // lblImageRowNumber
            // 
            this.lblImageRowNumber.AutoSize = true;
            this.lblImageRowNumber.Location = new System.Drawing.Point(308, 159);
            this.lblImageRowNumber.Name = "lblImageRowNumber";
            this.lblImageRowNumber.Size = new System.Drawing.Size(11, 12);
            this.lblImageRowNumber.TabIndex = 10;
            this.lblImageRowNumber.Text = "0";
            // 
            // btnImageFilp
            // 
            this.btnImageFilp.Location = new System.Drawing.Point(273, 104);
            this.btnImageFilp.Name = "btnImageFilp";
            this.btnImageFilp.Size = new System.Drawing.Size(90, 23);
            this.btnImageFilp.TabIndex = 9;
            this.btnImageFilp.Text = "Flip";
            this.btnImageFilp.UseVisualStyleBackColor = true;
            this.btnImageFilp.Click += new System.EventHandler(this.btnImageFilp_Click);
            // 
            // lblImageThreshold
            // 
            this.lblImageThreshold.AutoSize = true;
            this.lblImageThreshold.Location = new System.Drawing.Point(271, 197);
            this.lblImageThreshold.Name = "lblImageThreshold";
            this.lblImageThreshold.Size = new System.Drawing.Size(65, 12);
            this.lblImageThreshold.TabIndex = 7;
            this.lblImageThreshold.Text = "Threshold:";
            // 
            // lblImageCol
            // 
            this.lblImageCol.AutoSize = true;
            this.lblImageCol.Location = new System.Drawing.Point(273, 179);
            this.lblImageCol.Name = "lblImageCol";
            this.lblImageCol.Size = new System.Drawing.Size(29, 12);
            this.lblImageCol.TabIndex = 5;
            this.lblImageCol.Text = "Col:";
            // 
            // lblImageRow
            // 
            this.lblImageRow.AutoSize = true;
            this.lblImageRow.Location = new System.Drawing.Point(273, 159);
            this.lblImageRow.Name = "lblImageRow";
            this.lblImageRow.Size = new System.Drawing.Size(29, 12);
            this.lblImageRow.TabIndex = 3;
            this.lblImageRow.Text = "Row:";
            // 
            // btnImageGray
            // 
            this.btnImageGray.Location = new System.Drawing.Point(273, 75);
            this.btnImageGray.Name = "btnImageGray";
            this.btnImageGray.Size = new System.Drawing.Size(90, 23);
            this.btnImageGray.TabIndex = 2;
            this.btnImageGray.Text = "Gray";
            this.btnImageGray.UseVisualStyleBackColor = true;
            this.btnImageGray.Click += new System.EventHandler(this.btnImageGray_Click);
            // 
            // txbImageProcData
            // 
            this.txbImageProcData.Location = new System.Drawing.Point(4, 15);
            this.txbImageProcData.Multiline = true;
            this.txbImageProcData.Name = "txbImageProcData";
            this.txbImageProcData.ReadOnly = true;
            this.txbImageProcData.Size = new System.Drawing.Size(263, 202);
            this.txbImageProcData.TabIndex = 0;
            // 
            // btnImageBegin
            // 
            this.btnImageBegin.Location = new System.Drawing.Point(273, 12);
            this.btnImageBegin.Name = "btnImageBegin";
            this.btnImageBegin.Size = new System.Drawing.Size(90, 23);
            this.btnImageBegin.TabIndex = 0;
            this.btnImageBegin.Text = "Begin";
            this.btnImageBegin.UseVisualStyleBackColor = true;
            this.btnImageBegin.Click += new System.EventHandler(this.btnImageBegin_Click);
            // 
            // btnImageAlgorithm
            // 
            this.btnImageAlgorithm.Location = new System.Drawing.Point(273, 45);
            this.btnImageAlgorithm.Name = "btnImageAlgorithm";
            this.btnImageAlgorithm.Size = new System.Drawing.Size(90, 24);
            this.btnImageAlgorithm.TabIndex = 1;
            this.btnImageAlgorithm.Text = "Algorithm";
            this.btnImageAlgorithm.UseVisualStyleBackColor = true;
            this.btnImageAlgorithm.Click += new System.EventHandler(this.btnImageAlgorithm_Click);
            // 
            // groupBoxImageGray
            // 
            this.groupBoxImageGray.Controls.Add(this.chartImageGray);
            this.groupBoxImageGray.Location = new System.Drawing.Point(304, 5);
            this.groupBoxImageGray.Name = "groupBoxImageGray";
            this.groupBoxImageGray.Size = new System.Drawing.Size(368, 221);
            this.groupBoxImageGray.TabIndex = 2;
            this.groupBoxImageGray.TabStop = false;
            this.groupBoxImageGray.Text = "Gray";
            // 
            // chartImageGray
            // 
            chartArea3.Name = "ChartArea1";
            this.chartImageGray.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartImageGray.Legends.Add(legend3);
            this.chartImageGray.Location = new System.Drawing.Point(5, 15);
            this.chartImageGray.Name = "chartImageGray";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Gray";
            this.chartImageGray.Series.Add(series3);
            this.chartImageGray.Size = new System.Drawing.Size(357, 201);
            this.chartImageGray.TabIndex = 1;
            this.chartImageGray.Text = "chart1";
            this.chartImageGray.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.binaryImagePictureBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 221);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Binary Image";
            // 
            // binaryImagePictureBox
            // 
            this.binaryImagePictureBox.BackColor = System.Drawing.Color.DarkGray;
            this.binaryImagePictureBox.ContextMenuStrip = this.contextMenuStrip;
            this.binaryImagePictureBox.Location = new System.Drawing.Point(5, 15);
            this.binaryImagePictureBox.Name = "binaryImagePictureBox";
            this.binaryImagePictureBox.Size = new System.Drawing.Size(284, 201);
            this.binaryImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.binaryImagePictureBox.TabIndex = 0;
            this.binaryImagePictureBox.TabStop = false;
            this.binaryImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.binaryImagePictureBox_MouseMove);
            // 
            // groupBoxOriginalImage
            // 
            this.groupBoxOriginalImage.Controls.Add(this.originalImagePictureBox);
            this.groupBoxOriginalImage.Location = new System.Drawing.Point(4, 5);
            this.groupBoxOriginalImage.Name = "groupBoxOriginalImage";
            this.groupBoxOriginalImage.Size = new System.Drawing.Size(295, 221);
            this.groupBoxOriginalImage.TabIndex = 0;
            this.groupBoxOriginalImage.TabStop = false;
            this.groupBoxOriginalImage.Text = "Original Image";
            // 
            // originalImagePictureBox
            // 
            this.originalImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originalImagePictureBox.BackColor = System.Drawing.Color.DarkGray;
            this.originalImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImagePictureBox.ContextMenuStrip = this.contextMenuStrip;
            this.originalImagePictureBox.Location = new System.Drawing.Point(6, 15);
            this.originalImagePictureBox.Name = "originalImagePictureBox";
            this.originalImagePictureBox.Size = new System.Drawing.Size(284, 202);
            this.originalImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalImagePictureBox.TabIndex = 0;
            this.originalImagePictureBox.TabStop = false;
            this.originalImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.originalImagePictureBox_MouseMove);
            // 
            // tabPageScope
            // 
            this.tabPageScope.Location = new System.Drawing.Point(4, 22);
            this.tabPageScope.Name = "tabPageScope";
            this.tabPageScope.Size = new System.Drawing.Size(677, 454);
            this.tabPageScope.TabIndex = 2;
            this.tabPageScope.Text = "Scope";
            this.tabPageScope.UseVisualStyleBackColor = true;
            // 
            // tabPageNetWorker
            // 
            this.tabPageNetWorker.Location = new System.Drawing.Point(4, 22);
            this.tabPageNetWorker.Name = "tabPageNetWorker";
            this.tabPageNetWorker.Size = new System.Drawing.Size(677, 454);
            this.tabPageNetWorker.TabIndex = 3;
            this.tabPageNetWorker.Text = "NetWorker";
            this.tabPageNetWorker.UseVisualStyleBackColor = true;
            // 
            // groupBoxCOMCtrl
            // 
            this.groupBoxCOMCtrl.Controls.Add(this.lblCOMStatus);
            this.groupBoxCOMCtrl.Controls.Add(this.btnSerialportSearch);
            this.groupBoxCOMCtrl.Controls.Add(this.btnSerialportCtrl);
            this.groupBoxCOMCtrl.Controls.Add(this.cmbCOMPort);
            this.groupBoxCOMCtrl.Controls.Add(this.lblCOMPort);
            this.groupBoxCOMCtrl.Location = new System.Drawing.Point(698, 28);
            this.groupBoxCOMCtrl.Name = "groupBoxCOMCtrl";
            this.groupBoxCOMCtrl.Size = new System.Drawing.Size(153, 130);
            this.groupBoxCOMCtrl.TabIndex = 4;
            this.groupBoxCOMCtrl.TabStop = false;
            this.groupBoxCOMCtrl.Text = "Serialport Control";
            // 
            // lblCOMStatus
            // 
            this.lblCOMStatus.AutoSize = true;
            this.lblCOMStatus.Location = new System.Drawing.Point(6, 108);
            this.lblCOMStatus.Name = "lblCOMStatus";
            this.lblCOMStatus.Size = new System.Drawing.Size(131, 12);
            this.lblCOMStatus.TabIndex = 4;
            this.lblCOMStatus.Text = "Serial port is close.";
            // 
            // btnSerialportSearch
            // 
            this.btnSerialportSearch.Location = new System.Drawing.Point(30, 82);
            this.btnSerialportSearch.Name = "btnSerialportSearch";
            this.btnSerialportSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSerialportSearch.TabIndex = 3;
            this.btnSerialportSearch.Text = "Search";
            this.btnSerialportSearch.UseVisualStyleBackColor = true;
            this.btnSerialportSearch.Click += new System.EventHandler(this.btnSerialportSearch_Click);
            // 
            // btnSerialportCtrl
            // 
            this.btnSerialportCtrl.Location = new System.Drawing.Point(30, 54);
            this.btnSerialportCtrl.Name = "btnSerialportCtrl";
            this.btnSerialportCtrl.Size = new System.Drawing.Size(75, 23);
            this.btnSerialportCtrl.TabIndex = 2;
            this.btnSerialportCtrl.Text = "Open";
            this.btnSerialportCtrl.UseVisualStyleBackColor = true;
            this.btnSerialportCtrl.Click += new System.EventHandler(this.btnSerialportCtrl_Click);
            // 
            // cmbCOMPort
            // 
            this.cmbCOMPort.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOMPort.FormattingEnabled = true;
            this.cmbCOMPort.Location = new System.Drawing.Point(20, 30);
            this.cmbCOMPort.Name = "cmbCOMPort";
            this.cmbCOMPort.Size = new System.Drawing.Size(108, 20);
            this.cmbCOMPort.TabIndex = 1;
            // 
            // lblCOMPort
            // 
            this.lblCOMPort.AutoSize = true;
            this.lblCOMPort.Location = new System.Drawing.Point(17, 15);
            this.lblCOMPort.Name = "lblCOMPort";
            this.lblCOMPort.Size = new System.Drawing.Size(53, 12);
            this.lblCOMPort.TabIndex = 0;
            this.lblCOMPort.Text = "COM Port";
            // 
            // groupBoxFileCtrl
            // 
            this.groupBoxFileCtrl.Controls.Add(this.listBoxFiles);
            this.groupBoxFileCtrl.Controls.Add(this.btnFileEmpty);
            this.groupBoxFileCtrl.Controls.Add(this.btnFilePrevious);
            this.groupBoxFileCtrl.Controls.Add(this.btnFileNext);
            this.groupBoxFileCtrl.Controls.Add(this.btnFileDelete);
            this.groupBoxFileCtrl.Controls.Add(this.btnFileSave);
            this.groupBoxFileCtrl.Controls.Add(this.btnFileOpen);
            this.groupBoxFileCtrl.Location = new System.Drawing.Point(698, 164);
            this.groupBoxFileCtrl.Name = "groupBoxFileCtrl";
            this.groupBoxFileCtrl.Size = new System.Drawing.Size(153, 345);
            this.groupBoxFileCtrl.TabIndex = 5;
            this.groupBoxFileCtrl.TabStop = false;
            this.groupBoxFileCtrl.Text = "File Control";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 12;
            this.listBoxFiles.Location = new System.Drawing.Point(5, 194);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(142, 148);
            this.listBoxFiles.TabIndex = 6;
            this.listBoxFiles.DoubleClick += new System.EventHandler(this.listBoxFiles_DoubleClick);
            // 
            // btnFileEmpty
            // 
            this.btnFileEmpty.Location = new System.Drawing.Point(30, 166);
            this.btnFileEmpty.Name = "btnFileEmpty";
            this.btnFileEmpty.Size = new System.Drawing.Size(90, 23);
            this.btnFileEmpty.TabIndex = 5;
            this.btnFileEmpty.Text = "Empty";
            this.btnFileEmpty.UseVisualStyleBackColor = true;
            this.btnFileEmpty.Click += new System.EventHandler(this.btnFileEmpty_Click);
            // 
            // btnFilePrevious
            // 
            this.btnFilePrevious.Location = new System.Drawing.Point(30, 137);
            this.btnFilePrevious.Name = "btnFilePrevious";
            this.btnFilePrevious.Size = new System.Drawing.Size(90, 23);
            this.btnFilePrevious.TabIndex = 4;
            this.btnFilePrevious.Text = "Previous";
            this.btnFilePrevious.UseVisualStyleBackColor = true;
            this.btnFilePrevious.Click += new System.EventHandler(this.btnFilePreviousClick);
            // 
            // btnFileNext
            // 
            this.btnFileNext.Location = new System.Drawing.Point(30, 108);
            this.btnFileNext.Name = "btnFileNext";
            this.btnFileNext.Size = new System.Drawing.Size(90, 23);
            this.btnFileNext.TabIndex = 3;
            this.btnFileNext.Text = "Next";
            this.btnFileNext.UseVisualStyleBackColor = true;
            this.btnFileNext.Click += new System.EventHandler(this.btnFileNext_Click);
            // 
            // btnFileDelete
            // 
            this.btnFileDelete.Location = new System.Drawing.Point(30, 79);
            this.btnFileDelete.Name = "btnFileDelete";
            this.btnFileDelete.Size = new System.Drawing.Size(90, 23);
            this.btnFileDelete.TabIndex = 2;
            this.btnFileDelete.Text = "Close";
            this.btnFileDelete.UseVisualStyleBackColor = true;
            this.btnFileDelete.Click += new System.EventHandler(this.btnFileClose_Click);
            // 
            // btnFileSave
            // 
            this.btnFileSave.Location = new System.Drawing.Point(30, 50);
            this.btnFileSave.Name = "btnFileSave";
            this.btnFileSave.Size = new System.Drawing.Size(90, 23);
            this.btnFileSave.TabIndex = 1;
            this.btnFileSave.Text = "Save";
            this.btnFileSave.UseVisualStyleBackColor = true;
            this.btnFileSave.Click += new System.EventHandler(this.btnFileSave_Click);
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Location = new System.Drawing.Point(30, 20);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(90, 23);
            this.btnFileOpen.TabIndex = 0;
            this.btnFileOpen.Text = "Open";
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // progressbarTimer
            // 
            this.progressbarTimer.Tick += new System.EventHandler(this.progressbarTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 532);
            this.Controls.Add(this.groupBoxFileCtrl);
            this.Controls.Add(this.groupBoxCOMCtrl);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuBar);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuBar;
            this.Name = "frmMain";
            this.Text = "Apollo Smartcar Warrior Beta 0.1.2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMian_FormClosed);
            this.Load += new System.EventHandler(this.frmMian_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMian_KeyDown);
            this.mainMenuBar.ResumeLayout(false);
            this.mainMenuBar.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageSerial.ResumeLayout(false);
            this.groupBoxSerialRxAndTxCtrl.ResumeLayout(false);
            this.groupBoxSerialRxAndTxCtrl.PerformLayout();
            this.groupBoxSeriaSendData.ResumeLayout(false);
            this.groupBoxSeriaSendData.PerformLayout();
            this.groupBoxSerialReceiveData.ResumeLayout(false);
            this.groupBoxSerialReceiveData.PerformLayout();
            this.tabPageImage.ResumeLayout(false);
            this.groupBoxImageCtrl.ResumeLayout(false);
            this.groupBoxImageCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImageThreshold)).EndInit();
            this.groupBoxImageGray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartImageGray)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binaryImagePictureBox)).EndInit();
            this.groupBoxOriginalImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePictureBox)).EndInit();
            this.groupBoxCOMCtrl.ResumeLayout(false);
            this.groupBoxCOMCtrl.PerformLayout();
            this.groupBoxFileCtrl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tlblSerialStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSerial;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.TabPage tabPageScope;
        private System.Windows.Forms.TabPage tabPageNetWorker;
        private System.Windows.Forms.GroupBox groupBoxCOMCtrl;
        private System.Windows.Forms.Button btnSerialportCtrl;
        private System.Windows.Forms.ComboBox cmbCOMPort;
        private System.Windows.Forms.Label lblCOMPort;
        private System.Windows.Forms.GroupBox groupBoxSeriaSendData;
        private System.Windows.Forms.GroupBox groupBoxSerialReceiveData;
        private System.Windows.Forms.TextBox txbSerialSendData;
        private System.Windows.Forms.TextBox txbSerialReceiveData;
        private System.Windows.Forms.GroupBox groupBoxImageGray;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox binaryImagePictureBox;
        private System.Windows.Forms.GroupBox groupBoxOriginalImage;
        private System.Windows.Forms.PictureBox originalImagePictureBox;
        private System.Windows.Forms.Button btnSerialportSearch;
        private System.Windows.Forms.GroupBox groupBoxSerialRxAndTxCtrl;
        private System.Windows.Forms.RadioButton rbtnSerialHex;
        private System.Windows.Forms.RadioButton rbtnSerialChar;
        private System.Windows.Forms.Label lblCOMStatus;
        private System.Windows.Forms.GroupBox groupBoxFileCtrl;
        private System.Windows.Forms.Button btnFileEmpty;
        private System.Windows.Forms.Button btnFilePrevious;
        private System.Windows.Forms.Button btnFileNext;
        private System.Windows.Forms.Button btnFileDelete;
        private System.Windows.Forms.Button btnFileSave;
        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usrSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator iARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MDKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IARToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem bootLoaderToolStripMenuItem;
        private System.Windows.Forms.Label lblUnitMs;
        private System.Windows.Forms.Label lbSerialSendPeriodTime;
        private System.Windows.Forms.TextBox txbSerilaSendPeriodTime;
        private System.Windows.Forms.Button btnSerialSend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartImageGray;
        private System.Windows.Forms.Button btnImageAlgorithm;
        private System.Windows.Forms.Button btnImageBegin;
        private System.Windows.Forms.Button btnImageGray;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxImageCtrl;
        private System.Windows.Forms.TextBox txbImageProcData;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnSerialClearCnt;
        private System.Windows.Forms.Button btnSerialClearTx;
        private System.Windows.Forms.Button btnSerialClearRx;
        private System.Windows.Forms.Button btnSerialPause;
        private System.Windows.Forms.Button btnSerialReceive;
        private System.Windows.Forms.CheckBox checkBoxSerialAutoSend;
        private System.Windows.Forms.Label lblImageRow;
        private System.Windows.Forms.Button btnImageFilp;
        private System.Windows.Forms.Label lblImageThreshold;
        private System.Windows.Forms.Label lblImageCol;
        private System.Windows.Forms.ToolStripStatusLabel tlblSerialRxCnt;
        private System.Windows.Forms.ToolStripStatusLabel tlblSerialRxCntNumber;
        private System.Windows.Forms.ToolStripStatusLabel tlblSerialTxCnt;
        private System.Windows.Forms.ToolStripStatusLabel tlblSerialTxCntNymber;
        private System.Windows.Forms.Label lblImageColNumber;
        private System.Windows.Forms.Label lblImageRowNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownImageThreshold;
        private System.Windows.Forms.Button btnBinaryGray;
        private System.Windows.Forms.Timer progressbarTimer;
    }
}

