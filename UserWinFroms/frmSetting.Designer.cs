namespace UserWinFroms
{
    partial class frmSetting
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
            this.groupBoxSerialProperty = new System.Windows.Forms.GroupBox();
            this.txbSerialParityData = new System.Windows.Forms.TextBox();
            this.lblSerialParityData = new System.Windows.Forms.Label();
            this.lblSerialStopBit = new System.Windows.Forms.Label();
            this.cmbSerialStopBit = new System.Windows.Forms.ComboBox();
            this.cmbSerialParity = new System.Windows.Forms.ComboBox();
            this.lblSerialParity = new System.Windows.Forms.Label();
            this.cmbSerialDataBit = new System.Windows.Forms.ComboBox();
            this.lblSerialDataBit = new System.Windows.Forms.Label();
            this.cmbSerialBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.groupBoxImageProperty = new System.Windows.Forms.GroupBox();
            this.txbImageHeader2 = new System.Windows.Forms.TextBox();
            this.lblImageHeader2 = new System.Windows.Forms.Label();
            this.txbImageHeader1 = new System.Windows.Forms.TextBox();
            this.lblImageHeader1 = new System.Windows.Forms.Label();
            this.txbImageCol = new System.Windows.Forms.TextBox();
            this.lblImageCol = new System.Windows.Forms.Label();
            this.txbImageRow = new System.Windows.Forms.TextBox();
            this.lblImageRow = new System.Windows.Forms.Label();
            this.groupBoxSerialProperty.SuspendLayout();
            this.groupBoxImageProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSerialProperty
            // 
            this.groupBoxSerialProperty.Controls.Add(this.txbSerialParityData);
            this.groupBoxSerialProperty.Controls.Add(this.lblSerialParityData);
            this.groupBoxSerialProperty.Controls.Add(this.lblSerialStopBit);
            this.groupBoxSerialProperty.Controls.Add(this.cmbSerialStopBit);
            this.groupBoxSerialProperty.Controls.Add(this.cmbSerialParity);
            this.groupBoxSerialProperty.Controls.Add(this.lblSerialParity);
            this.groupBoxSerialProperty.Controls.Add(this.cmbSerialDataBit);
            this.groupBoxSerialProperty.Controls.Add(this.lblSerialDataBit);
            this.groupBoxSerialProperty.Controls.Add(this.cmbSerialBaudRate);
            this.groupBoxSerialProperty.Controls.Add(this.lblBaudRate);
            this.groupBoxSerialProperty.Location = new System.Drawing.Point(7, 5);
            this.groupBoxSerialProperty.Name = "groupBoxSerialProperty";
            this.groupBoxSerialProperty.Size = new System.Drawing.Size(238, 182);
            this.groupBoxSerialProperty.TabIndex = 0;
            this.groupBoxSerialProperty.TabStop = false;
            this.groupBoxSerialProperty.Text = "SerialPort Property";
            // 
            // txbSerialParityData
            // 
            this.txbSerialParityData.Location = new System.Drawing.Point(88, 149);
            this.txbSerialParityData.Name = "txbSerialParityData";
            this.txbSerialParityData.Size = new System.Drawing.Size(121, 21);
            this.txbSerialParityData.TabIndex = 9;
            this.txbSerialParityData.TextChanged += new System.EventHandler(this.txbSerialParityData_TextChanged);
            // 
            // lblSerialParityData
            // 
            this.lblSerialParityData.AutoSize = true;
            this.lblSerialParityData.Location = new System.Drawing.Point(11, 152);
            this.lblSerialParityData.Name = "lblSerialParityData";
            this.lblSerialParityData.Size = new System.Drawing.Size(71, 12);
            this.lblSerialParityData.TabIndex = 8;
            this.lblSerialParityData.Text = "Parity Data";
            // 
            // lblSerialStopBit
            // 
            this.lblSerialStopBit.AutoSize = true;
            this.lblSerialStopBit.Location = new System.Drawing.Point(23, 118);
            this.lblSerialStopBit.Name = "lblSerialStopBit";
            this.lblSerialStopBit.Size = new System.Drawing.Size(53, 12);
            this.lblSerialStopBit.TabIndex = 7;
            this.lblSerialStopBit.Text = "Stop Bit";
            // 
            // cmbSerialStopBit
            // 
            this.cmbSerialStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialStopBit.FormattingEnabled = true;
            this.cmbSerialStopBit.Location = new System.Drawing.Point(88, 115);
            this.cmbSerialStopBit.Name = "cmbSerialStopBit";
            this.cmbSerialStopBit.Size = new System.Drawing.Size(121, 20);
            this.cmbSerialStopBit.TabIndex = 6;
            this.cmbSerialStopBit.SelectedIndexChanged += new System.EventHandler(this.cmbSerialStopBit_SelectedIndexChanged);
            // 
            // cmbSerialParity
            // 
            this.cmbSerialParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialParity.FormattingEnabled = true;
            this.cmbSerialParity.Location = new System.Drawing.Point(88, 80);
            this.cmbSerialParity.Name = "cmbSerialParity";
            this.cmbSerialParity.Size = new System.Drawing.Size(121, 20);
            this.cmbSerialParity.TabIndex = 5;
            this.cmbSerialParity.SelectedIndexChanged += new System.EventHandler(this.cmbSerialParity_SelectedIndexChanged);
            // 
            // lblSerialParity
            // 
            this.lblSerialParity.AutoSize = true;
            this.lblSerialParity.Location = new System.Drawing.Point(23, 83);
            this.lblSerialParity.Name = "lblSerialParity";
            this.lblSerialParity.Size = new System.Drawing.Size(41, 12);
            this.lblSerialParity.TabIndex = 4;
            this.lblSerialParity.Text = "Parity";
            // 
            // cmbSerialDataBit
            // 
            this.cmbSerialDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialDataBit.FormattingEnabled = true;
            this.cmbSerialDataBit.Location = new System.Drawing.Point(88, 47);
            this.cmbSerialDataBit.Name = "cmbSerialDataBit";
            this.cmbSerialDataBit.Size = new System.Drawing.Size(121, 20);
            this.cmbSerialDataBit.TabIndex = 3;
            this.cmbSerialDataBit.SelectedIndexChanged += new System.EventHandler(this.cmbSerialDataBit_SelectedIndexChanged);
            // 
            // lblSerialDataBit
            // 
            this.lblSerialDataBit.AutoSize = true;
            this.lblSerialDataBit.Location = new System.Drawing.Point(23, 50);
            this.lblSerialDataBit.Name = "lblSerialDataBit";
            this.lblSerialDataBit.Size = new System.Drawing.Size(53, 12);
            this.lblSerialDataBit.TabIndex = 2;
            this.lblSerialDataBit.Text = "Data Bit";
            // 
            // cmbSerialBaudRate
            // 
            this.cmbSerialBaudRate.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSerialBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialBaudRate.FormattingEnabled = true;
            this.cmbSerialBaudRate.Location = new System.Drawing.Point(88, 17);
            this.cmbSerialBaudRate.Name = "cmbSerialBaudRate";
            this.cmbSerialBaudRate.Size = new System.Drawing.Size(121, 20);
            this.cmbSerialBaudRate.TabIndex = 1;
            this.cmbSerialBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbSerialBaudRate_SelectedIndexChanged);
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(23, 20);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(59, 12);
            this.lblBaudRate.TabIndex = 0;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // groupBoxImageProperty
            // 
            this.groupBoxImageProperty.Controls.Add(this.txbImageHeader2);
            this.groupBoxImageProperty.Controls.Add(this.lblImageHeader2);
            this.groupBoxImageProperty.Controls.Add(this.txbImageHeader1);
            this.groupBoxImageProperty.Controls.Add(this.lblImageHeader1);
            this.groupBoxImageProperty.Controls.Add(this.txbImageCol);
            this.groupBoxImageProperty.Controls.Add(this.lblImageCol);
            this.groupBoxImageProperty.Controls.Add(this.txbImageRow);
            this.groupBoxImageProperty.Controls.Add(this.lblImageRow);
            this.groupBoxImageProperty.Location = new System.Drawing.Point(7, 193);
            this.groupBoxImageProperty.Name = "groupBoxImageProperty";
            this.groupBoxImageProperty.Size = new System.Drawing.Size(238, 168);
            this.groupBoxImageProperty.TabIndex = 2;
            this.groupBoxImageProperty.TabStop = false;
            this.groupBoxImageProperty.Text = "Image Property";
            // 
            // txbImageHeader2
            // 
            this.txbImageHeader2.Location = new System.Drawing.Point(88, 135);
            this.txbImageHeader2.Name = "txbImageHeader2";
            this.txbImageHeader2.Size = new System.Drawing.Size(121, 21);
            this.txbImageHeader2.TabIndex = 7;
            this.txbImageHeader2.TextChanged += new System.EventHandler(this.txbImageHeader2_TextChanged);
            // 
            // lblImageHeader2
            // 
            this.lblImageHeader2.AutoSize = true;
            this.lblImageHeader2.Location = new System.Drawing.Point(23, 138);
            this.lblImageHeader2.Name = "lblImageHeader2";
            this.lblImageHeader2.Size = new System.Drawing.Size(53, 12);
            this.lblImageHeader2.TabIndex = 6;
            this.lblImageHeader2.Text = "Header 2";
            // 
            // txbImageHeader1
            // 
            this.txbImageHeader1.Location = new System.Drawing.Point(88, 98);
            this.txbImageHeader1.Name = "txbImageHeader1";
            this.txbImageHeader1.Size = new System.Drawing.Size(121, 21);
            this.txbImageHeader1.TabIndex = 5;
            this.txbImageHeader1.TextChanged += new System.EventHandler(this.txbImageHeader1_TextChanged);
            // 
            // lblImageHeader1
            // 
            this.lblImageHeader1.AutoSize = true;
            this.lblImageHeader1.Location = new System.Drawing.Point(23, 101);
            this.lblImageHeader1.Name = "lblImageHeader1";
            this.lblImageHeader1.Size = new System.Drawing.Size(53, 12);
            this.lblImageHeader1.TabIndex = 4;
            this.lblImageHeader1.Text = "Header 1";
            // 
            // txbImageCol
            // 
            this.txbImageCol.Location = new System.Drawing.Point(88, 62);
            this.txbImageCol.Name = "txbImageCol";
            this.txbImageCol.Size = new System.Drawing.Size(121, 21);
            this.txbImageCol.TabIndex = 3;
            this.txbImageCol.TextChanged += new System.EventHandler(this.txbImageCol_TextChanged);
            // 
            // lblImageCol
            // 
            this.lblImageCol.AutoSize = true;
            this.lblImageCol.Location = new System.Drawing.Point(23, 65);
            this.lblImageCol.Name = "lblImageCol";
            this.lblImageCol.Size = new System.Drawing.Size(41, 12);
            this.lblImageCol.TabIndex = 2;
            this.lblImageCol.Text = "Column";
            // 
            // txbImageRow
            // 
            this.txbImageRow.Location = new System.Drawing.Point(88, 24);
            this.txbImageRow.Name = "txbImageRow";
            this.txbImageRow.Size = new System.Drawing.Size(121, 21);
            this.txbImageRow.TabIndex = 1;
            this.txbImageRow.TextChanged += new System.EventHandler(this.txbImageRow_TextChanged);
            // 
            // lblImageRow
            // 
            this.lblImageRow.AutoSize = true;
            this.lblImageRow.Location = new System.Drawing.Point(23, 27);
            this.lblImageRow.Name = "lblImageRow";
            this.lblImageRow.Size = new System.Drawing.Size(23, 12);
            this.lblImageRow.TabIndex = 0;
            this.lblImageRow.Text = "Row";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 370);
            this.Controls.Add(this.groupBoxImageProperty);
            this.Controls.Add(this.groupBoxSerialProperty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.Text = "User Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetting_FormClosed);
            this.groupBoxSerialProperty.ResumeLayout(false);
            this.groupBoxSerialProperty.PerformLayout();
            this.groupBoxImageProperty.ResumeLayout(false);
            this.groupBoxImageProperty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSerialProperty;
        private System.Windows.Forms.GroupBox groupBoxImageProperty;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cmbSerialBaudRate;
        private System.Windows.Forms.ComboBox cmbSerialDataBit;
        private System.Windows.Forms.Label lblSerialDataBit;
        private System.Windows.Forms.ComboBox cmbSerialParity;
        private System.Windows.Forms.Label lblSerialParity;
        private System.Windows.Forms.ComboBox cmbSerialStopBit;
        private System.Windows.Forms.TextBox txbSerialParityData;
        private System.Windows.Forms.Label lblSerialParityData;
        private System.Windows.Forms.Label lblSerialStopBit;
        private System.Windows.Forms.TextBox txbImageCol;
        private System.Windows.Forms.Label lblImageCol;
        private System.Windows.Forms.TextBox txbImageRow;
        private System.Windows.Forms.Label lblImageRow;
        private System.Windows.Forms.TextBox txbImageHeader2;
        private System.Windows.Forms.Label lblImageHeader2;
        private System.Windows.Forms.TextBox txbImageHeader1;
        private System.Windows.Forms.Label lblImageHeader1;
    }
}