namespace DRE
{
    partial class UserControl_Config_ScopeSetting
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
            this.cbxRange = new System.Windows.Forms.ComboBox();
            this.lblRangeTitle = new System.Windows.Forms.Label();
            this.tbxDisplayTime = new System.Windows.Forms.TextBox();
            this.lblDisplayTimeTitle = new System.Windows.Forms.Label();
            this.cbxLayoutNumber = new System.Windows.Forms.ComboBox();
            this.lblLayoutTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxRange
            // 
            this.cbxRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRange.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxRange.FormattingEnabled = true;
            this.cbxRange.Location = new System.Drawing.Point(134, 13);
            this.cbxRange.Name = "cbxRange";
            this.cbxRange.Size = new System.Drawing.Size(252, 25);
            this.cbxRange.TabIndex = 3;
            // 
            // lblRangeTitle
            // 
            this.lblRangeTitle.AutoSize = true;
            this.lblRangeTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblRangeTitle.Location = new System.Drawing.Point(17, 13);
            this.lblRangeTitle.Name = "lblRangeTitle";
            this.lblRangeTitle.Size = new System.Drawing.Size(45, 17);
            this.lblRangeTitle.TabIndex = 2;
            this.lblRangeTitle.Text = "Range";
            // 
            // tbxDisplayTime
            // 
            this.tbxDisplayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxDisplayTime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbxDisplayTime.Location = new System.Drawing.Point(167, 49);
            this.tbxDisplayTime.Name = "tbxDisplayTime";
            this.tbxDisplayTime.Size = new System.Drawing.Size(225, 25);
            this.tbxDisplayTime.TabIndex = 12;
            // 
            // lblDisplayTimeTitle
            // 
            this.lblDisplayTimeTitle.AutoSize = true;
            this.lblDisplayTimeTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDisplayTimeTitle.Location = new System.Drawing.Point(17, 52);
            this.lblDisplayTimeTitle.Name = "lblDisplayTimeTitle";
            this.lblDisplayTimeTitle.Size = new System.Drawing.Size(107, 17);
            this.lblDisplayTimeTitle.TabIndex = 11;
            this.lblDisplayTimeTitle.Text = "Display Time(ms)";
            // 
            // cbxLayoutNumber
            // 
            this.cbxLayoutNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLayoutNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxLayoutNumber.FormattingEnabled = true;
            this.cbxLayoutNumber.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbxLayoutNumber.Location = new System.Drawing.Point(134, 86);
            this.cbxLayoutNumber.Name = "cbxLayoutNumber";
            this.cbxLayoutNumber.Size = new System.Drawing.Size(252, 25);
            this.cbxLayoutNumber.TabIndex = 14;
            // 
            // lblLayoutTitle
            // 
            this.lblLayoutTitle.AutoSize = true;
            this.lblLayoutTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblLayoutTitle.Location = new System.Drawing.Point(17, 90);
            this.lblLayoutTitle.Name = "lblLayoutTitle";
            this.lblLayoutTitle.Size = new System.Drawing.Size(98, 17);
            this.lblLayoutTitle.TabIndex = 13;
            this.lblLayoutTitle.Text = "Layout Number";
            // 
            // UserControl_Config_ScopeSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.cbxLayoutNumber);
            this.Controls.Add(this.lblLayoutTitle);
            this.Controls.Add(this.tbxDisplayTime);
            this.Controls.Add(this.lblDisplayTimeTitle);
            this.Controls.Add(this.cbxRange);
            this.Controls.Add(this.lblRangeTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_Config_ScopeSetting";
            this.Size = new System.Drawing.Size(407, 179);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxRange;
        private System.Windows.Forms.Label lblRangeTitle;
        private System.Windows.Forms.TextBox tbxDisplayTime;
        private System.Windows.Forms.Label lblDisplayTimeTitle;
        private System.Windows.Forms.ComboBox cbxLayoutNumber;
        private System.Windows.Forms.Label lblLayoutTitle;
    }
}
