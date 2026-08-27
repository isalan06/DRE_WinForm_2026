namespace DRE
{
    partial class UserControl_Specturm_Single
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panOP1 = new System.Windows.Forms.Panel();
            this.cbxMagLog = new System.Windows.Forms.CheckBox();
            this.cbxShiftHalf = new System.Windows.Forms.CheckBox();
            this.tbrEnvelopeNumberBar = new System.Windows.Forms.TrackBar();
            this.lblEnvelopePerNumber = new System.Windows.Forms.Label();
            this.chbEnvelopeUsed = new System.Windows.Forms.CheckBox();
            this.chbChann4Displat1 = new System.Windows.Forms.CheckBox();
            this.chbChann3Displat1 = new System.Windows.Forms.CheckBox();
            this.chbChann2Displat1 = new System.Windows.Forms.CheckBox();
            this.chbChann1Displat1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panOP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrEnvelopeNumberBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panOP1
            // 
            this.panOP1.BackColor = System.Drawing.Color.PaleGreen;
            this.panOP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panOP1.Controls.Add(this.cbxMagLog);
            this.panOP1.Controls.Add(this.cbxShiftHalf);
            this.panOP1.Controls.Add(this.tbrEnvelopeNumberBar);
            this.panOP1.Controls.Add(this.lblEnvelopePerNumber);
            this.panOP1.Controls.Add(this.chbEnvelopeUsed);
            this.panOP1.Controls.Add(this.chbChann4Displat1);
            this.panOP1.Controls.Add(this.chbChann3Displat1);
            this.panOP1.Controls.Add(this.chbChann2Displat1);
            this.panOP1.Controls.Add(this.chbChann1Displat1);
            this.panOP1.Location = new System.Drawing.Point(4, 3);
            this.panOP1.Name = "panOP1";
            this.panOP1.Size = new System.Drawing.Size(1575, 79);
            this.panOP1.TabIndex = 3;
            // 
            // cbxMagLog
            // 
            this.cbxMagLog.AutoSize = true;
            this.cbxMagLog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMagLog.Location = new System.Drawing.Point(1068, 15);
            this.cbxMagLog.Name = "cbxMagLog";
            this.cbxMagLog.Size = new System.Drawing.Size(80, 21);
            this.cbxMagLog.TabIndex = 8;
            this.cbxMagLog.Text = "Mag Log";
            this.cbxMagLog.UseVisualStyleBackColor = true;
            // 
            // cbxShiftHalf
            // 
            this.cbxShiftHalf.AutoSize = true;
            this.cbxShiftHalf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxShiftHalf.Location = new System.Drawing.Point(946, 15);
            this.cbxShiftHalf.Name = "cbxShiftHalf";
            this.cbxShiftHalf.Size = new System.Drawing.Size(52, 21);
            this.cbxShiftHalf.TabIndex = 7;
            this.cbxShiftHalf.Text = "Shift";
            this.cbxShiftHalf.UseVisualStyleBackColor = true;
            // 
            // tbrEnvelopeNumberBar
            // 
            this.tbrEnvelopeNumberBar.Location = new System.Drawing.Point(655, 42);
            this.tbrEnvelopeNumberBar.Maximum = 100;
            this.tbrEnvelopeNumberBar.Minimum = 1;
            this.tbrEnvelopeNumberBar.Name = "tbrEnvelopeNumberBar";
            this.tbrEnvelopeNumberBar.Size = new System.Drawing.Size(233, 45);
            this.tbrEnvelopeNumberBar.TabIndex = 6;
            this.tbrEnvelopeNumberBar.TickFrequency = 10;
            this.tbrEnvelopeNumberBar.Value = 5;
            this.tbrEnvelopeNumberBar.Scroll += new System.EventHandler(this.tbrEnvelopeNumberBar_Scroll);
            // 
            // lblEnvelopePerNumber
            // 
            this.lblEnvelopePerNumber.AutoSize = true;
            this.lblEnvelopePerNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvelopePerNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblEnvelopePerNumber.Location = new System.Drawing.Point(863, 15);
            this.lblEnvelopePerNumber.Name = "lblEnvelopePerNumber";
            this.lblEnvelopePerNumber.Size = new System.Drawing.Size(15, 17);
            this.lblEnvelopePerNumber.TabIndex = 5;
            this.lblEnvelopePerNumber.Text = "5";
            // 
            // chbEnvelopeUsed
            // 
            this.chbEnvelopeUsed.AutoSize = true;
            this.chbEnvelopeUsed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEnvelopeUsed.Location = new System.Drawing.Point(636, 14);
            this.chbEnvelopeUsed.Name = "chbEnvelopeUsed";
            this.chbEnvelopeUsed.Size = new System.Drawing.Size(203, 21);
            this.chbEnvelopeUsed.TabIndex = 4;
            this.chbEnvelopeUsed.Text = "Use Envelope - one point per ";
            this.chbEnvelopeUsed.UseVisualStyleBackColor = true;
            // 
            // chbChann4Displat1
            // 
            this.chbChann4Displat1.AutoSize = true;
            this.chbChann4Displat1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbChann4Displat1.Location = new System.Drawing.Point(130, 42);
            this.chbChann4Displat1.Name = "chbChann4Displat1";
            this.chbChann4Displat1.Size = new System.Drawing.Size(85, 21);
            this.chbChann4Displat1.TabIndex = 3;
            this.chbChann4Displat1.Text = "Channel-4";
            this.chbChann4Displat1.UseVisualStyleBackColor = true;
            // 
            // chbChann3Displat1
            // 
            this.chbChann3Displat1.AutoSize = true;
            this.chbChann3Displat1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbChann3Displat1.Location = new System.Drawing.Point(130, 14);
            this.chbChann3Displat1.Name = "chbChann3Displat1";
            this.chbChann3Displat1.Size = new System.Drawing.Size(85, 21);
            this.chbChann3Displat1.TabIndex = 2;
            this.chbChann3Displat1.Text = "Channel-3";
            this.chbChann3Displat1.UseVisualStyleBackColor = true;
            // 
            // chbChann2Displat1
            // 
            this.chbChann2Displat1.AutoSize = true;
            this.chbChann2Displat1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbChann2Displat1.Location = new System.Drawing.Point(17, 42);
            this.chbChann2Displat1.Name = "chbChann2Displat1";
            this.chbChann2Displat1.Size = new System.Drawing.Size(85, 21);
            this.chbChann2Displat1.TabIndex = 1;
            this.chbChann2Displat1.Text = "Channel-2";
            this.chbChann2Displat1.UseVisualStyleBackColor = true;
            // 
            // chbChann1Displat1
            // 
            this.chbChann1Displat1.AutoSize = true;
            this.chbChann1Displat1.Checked = true;
            this.chbChann1Displat1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbChann1Displat1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbChann1Displat1.Location = new System.Drawing.Point(17, 14);
            this.chbChann1Displat1.Name = "chbChann1Displat1";
            this.chbChann1Displat1.Size = new System.Drawing.Size(85, 21);
            this.chbChann1Displat1.TabIndex = 0;
            this.chbChann1Displat1.Text = "Channel-1";
            this.chbChann1Displat1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(4, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 592);
            this.panel1.TabIndex = 4;
            // 
            // UserControl_Specturm_Single
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panOP1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_Specturm_Single";
            this.Size = new System.Drawing.Size(1582, 685);
            this.panOP1.ResumeLayout(false);
            this.panOP1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrEnvelopeNumberBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panOP1;
        private System.Windows.Forms.CheckBox chbChann4Displat1;
        private System.Windows.Forms.CheckBox chbChann3Displat1;
        private System.Windows.Forms.CheckBox chbChann2Displat1;
        private System.Windows.Forms.CheckBox chbChann1Displat1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbrEnvelopeNumberBar;
        private System.Windows.Forms.Label lblEnvelopePerNumber;
        private System.Windows.Forms.CheckBox chbEnvelopeUsed;
        private System.Windows.Forms.CheckBox cbxShiftHalf;
        private System.Windows.Forms.CheckBox cbxMagLog;
        private System.Windows.Forms.Panel panel1;
    }
}
