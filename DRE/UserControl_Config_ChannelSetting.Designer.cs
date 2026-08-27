namespace DRE
{
    partial class UserControl_Config_ChannelSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxIEPE = new System.Windows.Forms.ComboBox();
            this.cbxInputType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCouplingType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxDisplaySpecification = new System.Windows.Forms.ComboBox();
            this.cbxDisplayType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IEPE: ";
            // 
            // cbxIEPE
            // 
            this.cbxIEPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIEPE.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxIEPE.FormattingEnabled = true;
            this.cbxIEPE.Items.AddRange(new object[] {
            "Disable IEPE",
            "Enable IEPE"});
            this.cbxIEPE.Location = new System.Drawing.Point(134, 13);
            this.cbxIEPE.Name = "cbxIEPE";
            this.cbxIEPE.Size = new System.Drawing.Size(252, 25);
            this.cbxIEPE.TabIndex = 1;
            // 
            // cbxInputType
            // 
            this.cbxInputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInputType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxInputType.FormattingEnabled = true;
            this.cbxInputType.Items.AddRange(new object[] {
            "Differential",
            "PseudoDifferential"});
            this.cbxInputType.Location = new System.Drawing.Point(134, 52);
            this.cbxInputType.Name = "cbxInputType";
            this.cbxInputType.Size = new System.Drawing.Size(252, 25);
            this.cbxInputType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Input Type:";
            // 
            // cbxCouplingType
            // 
            this.cbxCouplingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCouplingType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxCouplingType.FormattingEnabled = true;
            this.cbxCouplingType.Items.AddRange(new object[] {
            "Coupling_AC",
            "Coupling_NA"});
            this.cbxCouplingType.Location = new System.Drawing.Point(134, 91);
            this.cbxCouplingType.Name = "cbxCouplingType";
            this.cbxCouplingType.Size = new System.Drawing.Size(252, 25);
            this.cbxCouplingType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Coupling Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.Location = new System.Drawing.Point(17, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Specification:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(17, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Display";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.Location = new System.Drawing.Point(17, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Type:";
            // 
            // cbxDisplaySpecification
            // 
            this.cbxDisplaySpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisplaySpecification.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxDisplaySpecification.FormattingEnabled = true;
            this.cbxDisplaySpecification.Items.AddRange(new object[] {
            "1g / 100mV",
            "1g / 200mV",
            "1g / 300mV",
            "1g / 400mV",
            "1g / 500mV",
            "1mil / 100mV",
            "1mil / 200mV",
            "1mil / 300mV",
            "1mil / 400mV",
            "1mil / 500mV"});
            this.cbxDisplaySpecification.Location = new System.Drawing.Point(134, 158);
            this.cbxDisplaySpecification.Name = "cbxDisplaySpecification";
            this.cbxDisplaySpecification.Size = new System.Drawing.Size(252, 25);
            this.cbxDisplaySpecification.TabIndex = 9;
            // 
            // cbxDisplayType
            // 
            this.cbxDisplayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisplayType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxDisplayType.FormattingEnabled = true;
            this.cbxDisplayType.Items.AddRange(new object[] {
            "p-p",
            "0-p",
            "rms"});
            this.cbxDisplayType.Location = new System.Drawing.Point(134, 200);
            this.cbxDisplayType.Name = "cbxDisplayType";
            this.cbxDisplayType.Size = new System.Drawing.Size(252, 25);
            this.cbxDisplayType.TabIndex = 10;
            // 
            // UserControl_Config_ChannelSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.cbxDisplayType);
            this.Controls.Add(this.cbxDisplaySpecification);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxCouplingType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxInputType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxIEPE);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_Config_ChannelSetting";
            this.Size = new System.Drawing.Size(407, 249);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxIEPE;
        private System.Windows.Forms.ComboBox cbxInputType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCouplingType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxDisplaySpecification;
        private System.Windows.Forms.ComboBox cbxDisplayType;
    }
}
