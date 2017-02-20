namespace UserWinFroms
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.btnApollo = new System.Windows.Forms.Button();
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnApollo
            // 
            this.btnApollo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnApollo.BackgroundImage")));
            this.btnApollo.FlatAppearance.BorderSize = 0;
            this.btnApollo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApollo.Location = new System.Drawing.Point(495, 12);
            this.btnApollo.Name = "btnApollo";
            this.btnApollo.Size = new System.Drawing.Size(87, 27);
            this.btnApollo.TabIndex = 0;
            this.btnApollo.Text = "Apollo";
            this.btnApollo.UseVisualStyleBackColor = true;
            this.btnApollo.Click += new System.EventHandler(this.btnApollo_Click);
            // 
            // fadeTimer
            // 
            this.fadeTimer.Enabled = true;
            this.fadeTimer.Interval = 50;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(594, 416);
            this.Controls.Add(this.btnApollo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStart";
            this.Text = "StartFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApollo;
        private System.Windows.Forms.Timer fadeTimer;
    }
}