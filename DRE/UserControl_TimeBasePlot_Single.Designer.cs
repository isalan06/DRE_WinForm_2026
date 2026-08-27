namespace DRE
{
    partial class UserControl_TimeBasePlot_Single
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
            this.lblDI1Counter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDI0Counter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRPMValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDisplayParameterUsed = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chbKeyPhasorByChannel4 = new System.Windows.Forms.CheckBox();
            this.chbChann4Displat1 = new System.Windows.Forms.CheckBox();
            this.chbChann3Displat1 = new System.Windows.Forms.CheckBox();
            this.chbChann2Displat1 = new System.Windows.Forms.CheckBox();
            this.chbChann1Displat1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panOP1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panOP1
            // 
            this.panOP1.BackColor = System.Drawing.Color.PaleGreen;
            this.panOP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panOP1.Controls.Add(this.lblDI1Counter);
            this.panOP1.Controls.Add(this.label5);
            this.panOP1.Controls.Add(this.lblDI0Counter);
            this.panOP1.Controls.Add(this.label3);
            this.panOP1.Controls.Add(this.lblRPMValue);
            this.panOP1.Controls.Add(this.label1);
            this.panOP1.Controls.Add(this.cbxDisplayParameterUsed);
            this.panOP1.Controls.Add(this.btnLoad);
            this.panOP1.Controls.Add(this.btnSave);
            this.panOP1.Controls.Add(this.chbKeyPhasorByChannel4);
            this.panOP1.Controls.Add(this.chbChann4Displat1);
            this.panOP1.Controls.Add(this.chbChann3Displat1);
            this.panOP1.Controls.Add(this.chbChann2Displat1);
            this.panOP1.Controls.Add(this.chbChann1Displat1);
            this.panOP1.Location = new System.Drawing.Point(4, 3);
            this.panOP1.Name = "panOP1";
            this.panOP1.Size = new System.Drawing.Size(1575, 79);
            this.panOP1.TabIndex = 1;
            // 
            // lblDI1Counter
            // 
            this.lblDI1Counter.AutoSize = true;
            this.lblDI1Counter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDI1Counter.ForeColor = System.Drawing.Color.Blue;
            this.lblDI1Counter.Location = new System.Drawing.Point(321, 46);
            this.lblDI1Counter.Name = "lblDI1Counter";
            this.lblDI1Counter.Size = new System.Drawing.Size(15, 17);
            this.lblDI1Counter.TabIndex = 18;
            this.lblDI1Counter.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(230, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "DI-1 Counter: ";
            // 
            // lblDI0Counter
            // 
            this.lblDI0Counter.AutoSize = true;
            this.lblDI0Counter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDI0Counter.ForeColor = System.Drawing.Color.Blue;
            this.lblDI0Counter.Location = new System.Drawing.Point(321, 15);
            this.lblDI0Counter.Name = "lblDI0Counter";
            this.lblDI0Counter.Size = new System.Drawing.Size(15, 17);
            this.lblDI0Counter.TabIndex = 16;
            this.lblDI0Counter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(230, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "DI-0 Counter: ";
            // 
            // lblRPMValue
            // 
            this.lblRPMValue.AutoSize = true;
            this.lblRPMValue.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblRPMValue.ForeColor = System.Drawing.Color.Blue;
            this.lblRPMValue.Location = new System.Drawing.Point(846, 44);
            this.lblRPMValue.Name = "lblRPMValue";
            this.lblRPMValue.Size = new System.Drawing.Size(15, 17);
            this.lblRPMValue.TabIndex = 14;
            this.lblRPMValue.Text = "0";
            this.lblRPMValue.Click += new System.EventHandler(this.lblRPMValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(789, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "RPM: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbxDisplayParameterUsed
            // 
            this.cbxDisplayParameterUsed.AutoSize = true;
            this.cbxDisplayParameterUsed.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbxDisplayParameterUsed.Location = new System.Drawing.Point(792, 11);
            this.cbxDisplayParameterUsed.Name = "cbxDisplayParameterUsed";
            this.cbxDisplayParameterUsed.Size = new System.Drawing.Size(245, 21);
            this.cbxDisplayParameterUsed.TabIndex = 12;
            this.cbxDisplayParameterUsed.Text = "Display is used specification and type";
            this.cbxDisplayParameterUsed.UseVisualStyleBackColor = true;
            this.cbxDisplayParameterUsed.CheckedChanged += new System.EventHandler(this.cbxDisplayParameterUsed_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Location = new System.Drawing.Point(604, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 35);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(484, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chbKeyPhasorByChannel4
            // 
            this.chbKeyPhasorByChannel4.AutoSize = true;
            this.chbKeyPhasorByChannel4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chbKeyPhasorByChannel4.Location = new System.Drawing.Point(550, 43);
            this.chbKeyPhasorByChannel4.Name = "chbKeyPhasorByChannel4";
            this.chbKeyPhasorByChannel4.Size = new System.Drawing.Size(171, 21);
            this.chbKeyPhasorByChannel4.TabIndex = 9;
            this.chbKeyPhasorByChannel4.Text = "Key Phasor By Channel-4";
            this.chbKeyPhasorByChannel4.UseVisualStyleBackColor = true;
            // 
            // chbChann4Displat1
            // 
            this.chbChann4Displat1.AutoSize = true;
            this.chbChann4Displat1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chbChann4Displat1.Location = new System.Drawing.Point(117, 42);
            this.chbChann4Displat1.Name = "chbChann4Displat1";
            this.chbChann4Displat1.Size = new System.Drawing.Size(85, 21);
            this.chbChann4Displat1.TabIndex = 3;
            this.chbChann4Displat1.Text = "Channel-4";
            this.chbChann4Displat1.UseVisualStyleBackColor = true;
            // 
            // chbChann3Displat1
            // 
            this.chbChann3Displat1.AutoSize = true;
            this.chbChann3Displat1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chbChann3Displat1.Location = new System.Drawing.Point(117, 14);
            this.chbChann3Displat1.Name = "chbChann3Displat1";
            this.chbChann3Displat1.Size = new System.Drawing.Size(85, 21);
            this.chbChann3Displat1.TabIndex = 2;
            this.chbChann3Displat1.Text = "Channel-3";
            this.chbChann3Displat1.UseVisualStyleBackColor = true;
            // 
            // chbChann2Displat1
            // 
            this.chbChann2Displat1.AutoSize = true;
            this.chbChann2Displat1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
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
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.dat";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Data File|*.dat|All File|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.dat";
            this.saveFileDialog1.Filter = "Data File|*.dat|All File|*.*";
            this.saveFileDialog1.InitialDirectory = "C:\\";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 592);
            this.panel1.TabIndex = 2;
            // 
            // UserControl_TimeBasePlot_Single
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panOP1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_TimeBasePlot_Single";
            this.Size = new System.Drawing.Size(1582, 685);
            this.panOP1.ResumeLayout(false);
            this.panOP1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panOP1;
        private System.Windows.Forms.CheckBox chbChann4Displat1;
        private System.Windows.Forms.CheckBox chbChann3Displat1;
        private System.Windows.Forms.CheckBox chbChann2Displat1;
        private System.Windows.Forms.CheckBox chbChann1Displat1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chbKeyPhasorByChannel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox cbxDisplayParameterUsed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRPMValue;
        private System.Windows.Forms.Label lblDI1Counter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDI0Counter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}
