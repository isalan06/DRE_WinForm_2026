namespace DRE
{
    partial class UserControl_Config_CaptureSetting
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
            this.lblCaptureProgramTitle = new System.Windows.Forms.Label();
            this.tbxCaptureProgramName = new System.Windows.Forms.TextBox();
            this.lblSamplingRateTitle = new System.Windows.Forms.Label();
            this.cbxSamplingRate = new System.Windows.Forms.ComboBox();
            this.lblDataNumberTitle = new System.Windows.Forms.Label();
            this.tbxDataNumber = new System.Windows.Forms.TextBox();
            this.chbEnableRPMTrigger = new System.Windows.Forms.CheckBox();
            this.chbEnableKeyPhysor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCaptureProgramTitle
            // 
            this.lblCaptureProgramTitle.AutoSize = true;
            this.lblCaptureProgramTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptureProgramTitle.Location = new System.Drawing.Point(3, 11);
            this.lblCaptureProgramTitle.Name = "lblCaptureProgramTitle";
            this.lblCaptureProgramTitle.Size = new System.Drawing.Size(98, 17);
            this.lblCaptureProgramTitle.TabIndex = 5;
            this.lblCaptureProgramTitle.Text = "Program Name";
            // 
            // tbxCaptureProgramName
            // 
            this.tbxCaptureProgramName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCaptureProgramName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbxCaptureProgramName.Location = new System.Drawing.Point(124, 8);
            this.tbxCaptureProgramName.Name = "tbxCaptureProgramName";
            this.tbxCaptureProgramName.Size = new System.Drawing.Size(258, 25);
            this.tbxCaptureProgramName.TabIndex = 6;
            // 
            // lblSamplingRateTitle
            // 
            this.lblSamplingRateTitle.AutoSize = true;
            this.lblSamplingRateTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSamplingRateTitle.Location = new System.Drawing.Point(3, 47);
            this.lblSamplingRateTitle.Name = "lblSamplingRateTitle";
            this.lblSamplingRateTitle.Size = new System.Drawing.Size(92, 17);
            this.lblSamplingRateTitle.TabIndex = 7;
            this.lblSamplingRateTitle.Text = "Sampling Rate";
            // 
            // cbxSamplingRate
            // 
            this.cbxSamplingRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSamplingRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxSamplingRate.FormattingEnabled = true;
            this.cbxSamplingRate.Location = new System.Drawing.Point(124, 40);
            this.cbxSamplingRate.Name = "cbxSamplingRate";
            this.cbxSamplingRate.Size = new System.Drawing.Size(258, 25);
            this.cbxSamplingRate.TabIndex = 8;
            // 
            // lblDataNumberTitle
            // 
            this.lblDataNumberTitle.AutoSize = true;
            this.lblDataNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDataNumberTitle.Location = new System.Drawing.Point(3, 81);
            this.lblDataNumberTitle.Name = "lblDataNumberTitle";
            this.lblDataNumberTitle.Size = new System.Drawing.Size(87, 17);
            this.lblDataNumberTitle.TabIndex = 9;
            this.lblDataNumberTitle.Text = "Data Number";
            // 
            // tbxDataNumber
            // 
            this.tbxDataNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxDataNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbxDataNumber.Location = new System.Drawing.Point(124, 78);
            this.tbxDataNumber.Name = "tbxDataNumber";
            this.tbxDataNumber.Size = new System.Drawing.Size(258, 25);
            this.tbxDataNumber.TabIndex = 10;
            // 
            // chbEnableRPMTrigger
            // 
            this.chbEnableRPMTrigger.AutoSize = true;
            this.chbEnableRPMTrigger.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chbEnableRPMTrigger.Location = new System.Drawing.Point(6, 117);
            this.chbEnableRPMTrigger.Name = "chbEnableRPMTrigger";
            this.chbEnableRPMTrigger.Size = new System.Drawing.Size(195, 21);
            this.chbEnableRPMTrigger.TabIndex = 11;
            this.chbEnableRPMTrigger.Text = "Enable RPM Trigger Function";
            this.chbEnableRPMTrigger.UseVisualStyleBackColor = true;
            // 
            // chbEnableKeyPhysor
            // 
            this.chbEnableKeyPhysor.AutoSize = true;
            this.chbEnableKeyPhysor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chbEnableKeyPhysor.Location = new System.Drawing.Point(6, 145);
            this.chbEnableKeyPhysor.Name = "chbEnableKeyPhysor";
            this.chbEnableKeyPhysor.Size = new System.Drawing.Size(186, 21);
            this.chbEnableKeyPhysor.TabIndex = 12;
            this.chbEnableKeyPhysor.Text = "Enable Key Physor Function";
            this.chbEnableKeyPhysor.UseVisualStyleBackColor = true;
            // 
            // UserControl_Config_CaptureSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.chbEnableKeyPhysor);
            this.Controls.Add(this.chbEnableRPMTrigger);
            this.Controls.Add(this.tbxDataNumber);
            this.Controls.Add(this.lblDataNumberTitle);
            this.Controls.Add(this.cbxSamplingRate);
            this.Controls.Add(this.lblSamplingRateTitle);
            this.Controls.Add(this.tbxCaptureProgramName);
            this.Controls.Add(this.lblCaptureProgramTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_Config_CaptureSetting";
            this.Size = new System.Drawing.Size(407, 179);
            this.Load += new System.EventHandler(this.UserControl_Config_CaptureSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaptureProgramTitle;
        private System.Windows.Forms.TextBox tbxCaptureProgramName;
        private System.Windows.Forms.Label lblSamplingRateTitle;
        private System.Windows.Forms.ComboBox cbxSamplingRate;
        private System.Windows.Forms.Label lblDataNumberTitle;
        private System.Windows.Forms.TextBox tbxDataNumber;
        private System.Windows.Forms.CheckBox chbEnableRPMTrigger;
        private System.Windows.Forms.CheckBox chbEnableKeyPhysor;
    }
}
