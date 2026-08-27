namespace DRE
{
    partial class UserControl_Orbit
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
            this.lblRPMTitle = new System.Windows.Forms.Label();
            this.lblRPM = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbxXAxis_4 = new System.Windows.Forms.RadioButton();
            this.rbxXAxis_3 = new System.Windows.Forms.RadioButton();
            this.rbxXAxis_2 = new System.Windows.Forms.RadioButton();
            this.rbxXAxis_1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbxYAxis_4 = new System.Windows.Forms.RadioButton();
            this.rbxYAxis_3 = new System.Windows.Forms.RadioButton();
            this.rbxYAxis_2 = new System.Windows.Forms.RadioButton();
            this.rbxYAxis_1 = new System.Windows.Forms.RadioButton();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrbitNumber = new System.Windows.Forms.Label();
            this.trbOrbitNumber = new System.Windows.Forms.TrackBar();
            this.chbRemoveLast10 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbOrbitNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRPMTitle
            // 
            this.lblRPMTitle.AutoSize = true;
            this.lblRPMTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRPMTitle.Location = new System.Drawing.Point(15, 16);
            this.lblRPMTitle.Name = "lblRPMTitle";
            this.lblRPMTitle.Size = new System.Drawing.Size(42, 17);
            this.lblRPMTitle.TabIndex = 1;
            this.lblRPMTitle.Text = "RPM: ";
            // 
            // lblRPM
            // 
            this.lblRPM.AutoSize = true;
            this.lblRPM.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRPM.ForeColor = System.Drawing.Color.Blue;
            this.lblRPM.Location = new System.Drawing.Point(72, 16);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(32, 17);
            this.lblRPM.TabIndex = 2;
            this.lblRPM.Text = "0.00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbxXAxis_4);
            this.groupBox1.Controls.Add(this.rbxXAxis_3);
            this.groupBox1.Controls.Add(this.rbxXAxis_2);
            this.groupBox1.Controls.Add(this.rbxXAxis_1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X Axis Select";
            // 
            // rbxXAxis_4
            // 
            this.rbxXAxis_4.AutoSize = true;
            this.rbxXAxis_4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxXAxis_4.Location = new System.Drawing.Point(431, 25);
            this.rbxXAxis_4.Name = "rbxXAxis_4";
            this.rbxXAxis_4.Size = new System.Drawing.Size(92, 21);
            this.rbxXAxis_4.TabIndex = 3;
            this.rbxXAxis_4.Text = "Channel - 4";
            this.rbxXAxis_4.UseVisualStyleBackColor = true;
            // 
            // rbxXAxis_3
            // 
            this.rbxXAxis_3.AutoSize = true;
            this.rbxXAxis_3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxXAxis_3.Location = new System.Drawing.Point(292, 25);
            this.rbxXAxis_3.Name = "rbxXAxis_3";
            this.rbxXAxis_3.Size = new System.Drawing.Size(92, 21);
            this.rbxXAxis_3.TabIndex = 2;
            this.rbxXAxis_3.Text = "Channel - 3";
            this.rbxXAxis_3.UseVisualStyleBackColor = true;
            // 
            // rbxXAxis_2
            // 
            this.rbxXAxis_2.AutoSize = true;
            this.rbxXAxis_2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxXAxis_2.Location = new System.Drawing.Point(159, 25);
            this.rbxXAxis_2.Name = "rbxXAxis_2";
            this.rbxXAxis_2.Size = new System.Drawing.Size(92, 21);
            this.rbxXAxis_2.TabIndex = 1;
            this.rbxXAxis_2.Text = "Channel - 2";
            this.rbxXAxis_2.UseVisualStyleBackColor = true;
            // 
            // rbxXAxis_1
            // 
            this.rbxXAxis_1.AutoSize = true;
            this.rbxXAxis_1.Checked = true;
            this.rbxXAxis_1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxXAxis_1.Location = new System.Drawing.Point(26, 25);
            this.rbxXAxis_1.Name = "rbxXAxis_1";
            this.rbxXAxis_1.Size = new System.Drawing.Size(92, 21);
            this.rbxXAxis_1.TabIndex = 0;
            this.rbxXAxis_1.TabStop = true;
            this.rbxXAxis_1.Text = "Channel - 1";
            this.rbxXAxis_1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbxYAxis_4);
            this.groupBox2.Controls.Add(this.rbxYAxis_3);
            this.groupBox2.Controls.Add(this.rbxYAxis_2);
            this.groupBox2.Controls.Add(this.rbxYAxis_1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 60);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Y Axis Select";
            // 
            // rbxYAxis_4
            // 
            this.rbxYAxis_4.AutoSize = true;
            this.rbxYAxis_4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxYAxis_4.Location = new System.Drawing.Point(431, 25);
            this.rbxYAxis_4.Name = "rbxYAxis_4";
            this.rbxYAxis_4.Size = new System.Drawing.Size(92, 21);
            this.rbxYAxis_4.TabIndex = 3;
            this.rbxYAxis_4.Text = "Channel - 4";
            this.rbxYAxis_4.UseVisualStyleBackColor = true;
            // 
            // rbxYAxis_3
            // 
            this.rbxYAxis_3.AutoSize = true;
            this.rbxYAxis_3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxYAxis_3.Location = new System.Drawing.Point(292, 25);
            this.rbxYAxis_3.Name = "rbxYAxis_3";
            this.rbxYAxis_3.Size = new System.Drawing.Size(92, 21);
            this.rbxYAxis_3.TabIndex = 2;
            this.rbxYAxis_3.Text = "Channel - 3";
            this.rbxYAxis_3.UseVisualStyleBackColor = true;
            // 
            // rbxYAxis_2
            // 
            this.rbxYAxis_2.AutoSize = true;
            this.rbxYAxis_2.Checked = true;
            this.rbxYAxis_2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxYAxis_2.Location = new System.Drawing.Point(159, 25);
            this.rbxYAxis_2.Name = "rbxYAxis_2";
            this.rbxYAxis_2.Size = new System.Drawing.Size(92, 21);
            this.rbxYAxis_2.TabIndex = 1;
            this.rbxYAxis_2.TabStop = true;
            this.rbxYAxis_2.Text = "Channel - 2";
            this.rbxYAxis_2.UseVisualStyleBackColor = true;
            // 
            // rbxYAxis_1
            // 
            this.rbxYAxis_1.AutoSize = true;
            this.rbxYAxis_1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxYAxis_1.Location = new System.Drawing.Point(26, 25);
            this.rbxYAxis_1.Name = "rbxYAxis_1";
            this.rbxYAxis_1.Size = new System.Drawing.Size(92, 21);
            this.rbxYAxis_1.TabIndex = 0;
            this.rbxYAxis_1.Text = "Channel - 1";
            this.rbxYAxis_1.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(613, 65);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(906, 685);
            this.zedGraphControl1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Orbit Number:";
            // 
            // lblOrbitNumber
            // 
            this.lblOrbitNumber.AutoSize = true;
            this.lblOrbitNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrbitNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblOrbitNumber.Location = new System.Drawing.Point(126, 222);
            this.lblOrbitNumber.Name = "lblOrbitNumber";
            this.lblOrbitNumber.Size = new System.Drawing.Size(15, 17);
            this.lblOrbitNumber.TabIndex = 7;
            this.lblOrbitNumber.Text = "1";
            // 
            // trbOrbitNumber
            // 
            this.trbOrbitNumber.Location = new System.Drawing.Point(105, 257);
            this.trbOrbitNumber.Minimum = 1;
            this.trbOrbitNumber.Name = "trbOrbitNumber";
            this.trbOrbitNumber.Size = new System.Drawing.Size(392, 45);
            this.trbOrbitNumber.TabIndex = 8;
            this.trbOrbitNumber.Value = 1;
            this.trbOrbitNumber.ValueChanged += new System.EventHandler(this.trbOrbitNumber_ValueChanged);
            // 
            // chbRemoveLast10
            // 
            this.chbRemoveLast10.AutoSize = true;
            this.chbRemoveLast10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRemoveLast10.Location = new System.Drawing.Point(54, 314);
            this.chbRemoveLast10.Name = "chbRemoveLast10";
            this.chbRemoveLast10.Size = new System.Drawing.Size(161, 21);
            this.chbRemoveLast10.TabIndex = 9;
            this.chbRemoveLast10.Text = "Remove Last 10% Data";
            this.chbRemoveLast10.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(613, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 598);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            // 
            // UserControl_Orbit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chbRemoveLast10);
            this.Controls.Add(this.trbOrbitNumber);
            this.Controls.Add(this.lblOrbitNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRPM);
            this.Controls.Add(this.lblRPMTitle);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_Orbit";
            this.Size = new System.Drawing.Size(1582, 685);
            this.Load += new System.EventHandler(this.UserControl_Orbit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbOrbitNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRPMTitle;
        private System.Windows.Forms.Label lblRPM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbxXAxis_4;
        private System.Windows.Forms.RadioButton rbxXAxis_3;
        private System.Windows.Forms.RadioButton rbxXAxis_2;
        private System.Windows.Forms.RadioButton rbxXAxis_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbxYAxis_4;
        private System.Windows.Forms.RadioButton rbxYAxis_3;
        private System.Windows.Forms.RadioButton rbxYAxis_2;
        private System.Windows.Forms.RadioButton rbxYAxis_1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrbitNumber;
        private System.Windows.Forms.TrackBar trbOrbitNumber;
        private System.Windows.Forms.CheckBox chbRemoveLast10;
        private System.Windows.Forms.Panel panel1;
    }
}
