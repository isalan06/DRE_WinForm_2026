namespace DRE
{
    partial class UserControl_Config
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
            this.lblChannelSettingTitle = new System.Windows.Forms.Label();
            this.cbxChannelList = new System.Windows.Forms.ComboBox();
            this.panChannelSetting = new System.Windows.Forms.Panel();
            this.btnSet_ChannelSetting = new System.Windows.Forms.Button();
            this.lblCaptureSettingTitle = new System.Windows.Forms.Label();
            this.panCaptureSetting = new System.Windows.Forms.Panel();
            this.btnSet_CaptureSetting = new System.Windows.Forms.Button();
            this.btnSet_ScopeSetting = new System.Windows.Forms.Button();
            this.panScopeSetting = new System.Windows.Forms.Panel();
            this.lblScopeSettingTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblValueDisplaySettingTitle = new System.Windows.Forms.Label();
            this.panValueDisplaySetting = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panValueDisplaySetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChannelSettingTitle
            // 
            this.lblChannelSettingTitle.AutoSize = true;
            this.lblChannelSettingTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannelSettingTitle.Location = new System.Drawing.Point(13, 15);
            this.lblChannelSettingTitle.Name = "lblChannelSettingTitle";
            this.lblChannelSettingTitle.Size = new System.Drawing.Size(153, 25);
            this.lblChannelSettingTitle.TabIndex = 0;
            this.lblChannelSettingTitle.Text = "Channel Setting";
            // 
            // cbxChannelList
            // 
            this.cbxChannelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChannelList.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbxChannelList.FormattingEnabled = true;
            this.cbxChannelList.Location = new System.Drawing.Point(192, 13);
            this.cbxChannelList.Name = "cbxChannelList";
            this.cbxChannelList.Size = new System.Drawing.Size(121, 33);
            this.cbxChannelList.TabIndex = 1;
            this.cbxChannelList.TextChanged += new System.EventHandler(this.cbxChannelList_TextChanged);
            // 
            // panChannelSetting
            // 
            this.panChannelSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panChannelSetting.Location = new System.Drawing.Point(18, 53);
            this.panChannelSetting.Name = "panChannelSetting";
            this.panChannelSetting.Size = new System.Drawing.Size(407, 249);
            this.panChannelSetting.TabIndex = 2;
            // 
            // btnSet_ChannelSetting
            // 
            this.btnSet_ChannelSetting.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSet_ChannelSetting.Location = new System.Drawing.Point(325, 13);
            this.btnSet_ChannelSetting.Name = "btnSet_ChannelSetting";
            this.btnSet_ChannelSetting.Size = new System.Drawing.Size(100, 35);
            this.btnSet_ChannelSetting.TabIndex = 3;
            this.btnSet_ChannelSetting.Text = "SET";
            this.btnSet_ChannelSetting.UseVisualStyleBackColor = true;
            this.btnSet_ChannelSetting.Click += new System.EventHandler(this.btnSet_ChannelSetting_Click);
            // 
            // lblCaptureSettingTitle
            // 
            this.lblCaptureSettingTitle.AutoSize = true;
            this.lblCaptureSettingTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCaptureSettingTitle.Location = new System.Drawing.Point(15, 339);
            this.lblCaptureSettingTitle.Name = "lblCaptureSettingTitle";
            this.lblCaptureSettingTitle.Size = new System.Drawing.Size(152, 25);
            this.lblCaptureSettingTitle.TabIndex = 4;
            this.lblCaptureSettingTitle.Text = "Capture Setting";
            // 
            // panCaptureSetting
            // 
            this.panCaptureSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panCaptureSetting.Location = new System.Drawing.Point(18, 372);
            this.panCaptureSetting.Name = "panCaptureSetting";
            this.panCaptureSetting.Size = new System.Drawing.Size(407, 179);
            this.panCaptureSetting.TabIndex = 5;
            // 
            // btnSet_CaptureSetting
            // 
            this.btnSet_CaptureSetting.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSet_CaptureSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSet_CaptureSetting.Location = new System.Drawing.Point(267, 334);
            this.btnSet_CaptureSetting.Name = "btnSet_CaptureSetting";
            this.btnSet_CaptureSetting.Size = new System.Drawing.Size(100, 35);
            this.btnSet_CaptureSetting.TabIndex = 6;
            this.btnSet_CaptureSetting.Text = "SET";
            this.btnSet_CaptureSetting.UseVisualStyleBackColor = true;
            this.btnSet_CaptureSetting.Click += new System.EventHandler(this.btnSet_CaptureSetting_Click);
            // 
            // btnSet_ScopeSetting
            // 
            this.btnSet_ScopeSetting.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSet_ScopeSetting.Location = new System.Drawing.Point(756, 11);
            this.btnSet_ScopeSetting.Name = "btnSet_ScopeSetting";
            this.btnSet_ScopeSetting.Size = new System.Drawing.Size(100, 35);
            this.btnSet_ScopeSetting.TabIndex = 9;
            this.btnSet_ScopeSetting.Text = "SET";
            this.btnSet_ScopeSetting.UseVisualStyleBackColor = true;
            this.btnSet_ScopeSetting.Click += new System.EventHandler(this.btnSet_ScopeSetting_Click);
            // 
            // panScopeSetting
            // 
            this.panScopeSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panScopeSetting.Location = new System.Drawing.Point(493, 50);
            this.panScopeSetting.Name = "panScopeSetting";
            this.panScopeSetting.Size = new System.Drawing.Size(407, 179);
            this.panScopeSetting.TabIndex = 8;
            // 
            // lblScopeSettingTitle
            // 
            this.lblScopeSettingTitle.AutoSize = true;
            this.lblScopeSettingTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblScopeSettingTitle.Location = new System.Drawing.Point(490, 17);
            this.lblScopeSettingTitle.Name = "lblScopeSettingTitle";
            this.lblScopeSettingTitle.Size = new System.Drawing.Size(135, 25);
            this.lblScopeSettingTitle.TabIndex = 7;
            this.lblScopeSettingTitle.Text = "Scope Setting";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(1059, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SET";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblValueDisplaySettingTitle
            // 
            this.lblValueDisplaySettingTitle.AutoSize = true;
            this.lblValueDisplaySettingTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblValueDisplaySettingTitle.Location = new System.Drawing.Point(490, 272);
            this.lblValueDisplaySettingTitle.Name = "lblValueDisplaySettingTitle";
            this.lblValueDisplaySettingTitle.Size = new System.Drawing.Size(199, 25);
            this.lblValueDisplaySettingTitle.TabIndex = 11;
            this.lblValueDisplaySettingTitle.Text = "Value Display Setting";
            // 
            // panValueDisplaySetting
            // 
            this.panValueDisplaySetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panValueDisplaySetting.Controls.Add(this.comboBox1);
            this.panValueDisplaySetting.Location = new System.Drawing.Point(493, 305);
            this.panValueDisplaySetting.Name = "panValueDisplaySetting";
            this.panValueDisplaySetting.Size = new System.Drawing.Size(407, 158);
            this.panValueDisplaySetting.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 33);
            this.comboBox1.TabIndex = 0;
            // 
            // UserControl_Config
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.panValueDisplaySetting);
            this.Controls.Add(this.lblValueDisplaySettingTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSet_ScopeSetting);
            this.Controls.Add(this.panScopeSetting);
            this.Controls.Add(this.lblScopeSettingTitle);
            this.Controls.Add(this.btnSet_CaptureSetting);
            this.Controls.Add(this.panCaptureSetting);
            this.Controls.Add(this.lblCaptureSettingTitle);
            this.Controls.Add(this.btnSet_ChannelSetting);
            this.Controls.Add(this.panChannelSetting);
            this.Controls.Add(this.cbxChannelList);
            this.Controls.Add(this.lblChannelSettingTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_Config";
            this.Size = new System.Drawing.Size(1582, 685);
            this.panValueDisplaySetting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChannelSettingTitle;
        private System.Windows.Forms.ComboBox cbxChannelList;
        private System.Windows.Forms.Panel panChannelSetting;
        private System.Windows.Forms.Button btnSet_ChannelSetting;
        private System.Windows.Forms.Label lblCaptureSettingTitle;
        private System.Windows.Forms.Panel panCaptureSetting;
        private System.Windows.Forms.Button btnSet_CaptureSetting;
        private System.Windows.Forms.Button btnSet_ScopeSetting;
        private System.Windows.Forms.Panel panScopeSetting;
        private System.Windows.Forms.Label lblScopeSettingTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblValueDisplaySettingTitle;
        private System.Windows.Forms.Panel panValueDisplaySetting;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
