namespace DRE
{
    partial class UserControl_VChannel
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDI1IntervalTime = new System.Windows.Forms.Label();
            this.lblDI0IntervalTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDI1Counter = new System.Windows.Forms.Label();
            this.lblDI0Counter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxCaptureIntervalTime_ms = new System.Windows.Forms.TextBox();
            this.lblCaptureIntervalTime_ms = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDI1TotalIntervalTime = new System.Windows.Forms.Label();
            this.lblDI0TotalIntervalTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDI1TotalCounter = new System.Windows.Forms.Label();
            this.lblDI0TotalCounter = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbxYAxisLimit_Min = new System.Windows.Forms.TextBox();
            this.tbxYAxisLimit_Max = new System.Windows.Forms.TextBox();
            this.lblYAxisLimit_Min = new System.Windows.Forms.Label();
            this.lblYAxisLimit_Max = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.lblValue2_ch4 = new System.Windows.Forms.Label();
            this.lblValue2_ch3 = new System.Windows.Forms.Label();
            this.lblValue2_ch2 = new System.Windows.Forms.Label();
            this.lblValue2_ch1 = new System.Windows.Forms.Label();
            this.tbxValue_ch4 = new System.Windows.Forms.TextBox();
            this.tbxValue_ch3 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblValue_ch4 = new System.Windows.Forms.Label();
            this.lblValue_ch3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tbxValue_ch2 = new System.Windows.Forms.TextBox();
            this.tbxValue_ch1 = new System.Windows.Forms.TextBox();
            this.lblValue_ch2 = new System.Windows.Forms.Label();
            this.lblValue_ch1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(32, 88);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(835, 704);
            this.zedGraphControl1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Type";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(382, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(159, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "4個Channel連線起來";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(22, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(159, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "4個Channel分別顯示";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDI1IntervalTime);
            this.groupBox2.Controls.Add(this.lblDI0IntervalTime);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblDI1Counter);
            this.groupBox2.Controls.Add(this.lblDI0Counter);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(876, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(693, 123);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RealTime Counter";
            // 
            // lblDI1IntervalTime
            // 
            this.lblDI1IntervalTime.AutoSize = true;
            this.lblDI1IntervalTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDI1IntervalTime.ForeColor = System.Drawing.Color.Blue;
            this.lblDI1IntervalTime.Location = new System.Drawing.Point(474, 77);
            this.lblDI1IntervalTime.Name = "lblDI1IntervalTime";
            this.lblDI1IntervalTime.Size = new System.Drawing.Size(15, 17);
            this.lblDI1IntervalTime.TabIndex = 24;
            this.lblDI1IntervalTime.Text = "0";
            // 
            // lblDI0IntervalTime
            // 
            this.lblDI0IntervalTime.AutoSize = true;
            this.lblDI0IntervalTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDI0IntervalTime.ForeColor = System.Drawing.Color.Blue;
            this.lblDI0IntervalTime.Location = new System.Drawing.Point(474, 46);
            this.lblDI0IntervalTime.Name = "lblDI0IntervalTime";
            this.lblDI0IntervalTime.Size = new System.Drawing.Size(15, 17);
            this.lblDI0IntervalTime.TabIndex = 23;
            this.lblDI0IntervalTime.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "DI-1 Interval Time (ms): ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "DI-0 Interval Time (ms): ";
            // 
            // lblDI1Counter
            // 
            this.lblDI1Counter.AutoSize = true;
            this.lblDI1Counter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDI1Counter.ForeColor = System.Drawing.Color.Blue;
            this.lblDI1Counter.Location = new System.Drawing.Point(129, 77);
            this.lblDI1Counter.Name = "lblDI1Counter";
            this.lblDI1Counter.Size = new System.Drawing.Size(15, 17);
            this.lblDI1Counter.TabIndex = 20;
            this.lblDI1Counter.Text = "0";
            // 
            // lblDI0Counter
            // 
            this.lblDI0Counter.AutoSize = true;
            this.lblDI0Counter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDI0Counter.ForeColor = System.Drawing.Color.Blue;
            this.lblDI0Counter.Location = new System.Drawing.Point(129, 46);
            this.lblDI0Counter.Name = "lblDI0Counter";
            this.lblDI0Counter.Size = new System.Drawing.Size(15, 17);
            this.lblDI0Counter.TabIndex = 19;
            this.lblDI0Counter.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "DI-1 Counter: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "DI-0 Counter: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.tbxCaptureIntervalTime_ms);
            this.groupBox3.Controls.Add(this.lblCaptureIntervalTime_ms);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.lblDI1TotalIntervalTime);
            this.groupBox3.Controls.Add(this.lblDI0TotalIntervalTime);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblDI1TotalCounter);
            this.groupBox3.Controls.Add(this.lblDI0TotalCounter);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(876, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(693, 164);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RealTime Total Counter";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 34);
            this.button1.TabIndex = 28;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxCaptureIntervalTime_ms
            // 
            this.tbxCaptureIntervalTime_ms.Location = new System.Drawing.Point(276, 43);
            this.tbxCaptureIntervalTime_ms.Name = "tbxCaptureIntervalTime_ms";
            this.tbxCaptureIntervalTime_ms.Size = new System.Drawing.Size(100, 25);
            this.tbxCaptureIntervalTime_ms.TabIndex = 27;
            // 
            // lblCaptureIntervalTime_ms
            // 
            this.lblCaptureIntervalTime_ms.AutoSize = true;
            this.lblCaptureIntervalTime_ms.ForeColor = System.Drawing.Color.Blue;
            this.lblCaptureIntervalTime_ms.Location = new System.Drawing.Point(129, 46);
            this.lblCaptureIntervalTime_ms.Name = "lblCaptureIntervalTime_ms";
            this.lblCaptureIntervalTime_ms.Size = new System.Drawing.Size(15, 17);
            this.lblCaptureIntervalTime_ms.TabIndex = 26;
            this.lblCaptureIntervalTime_ms.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 17);
            this.label14.TabIndex = 25;
            this.label14.Text = "擷取時間(ms):";
            // 
            // lblDI1TotalIntervalTime
            // 
            this.lblDI1TotalIntervalTime.AutoSize = true;
            this.lblDI1TotalIntervalTime.ForeColor = System.Drawing.Color.Blue;
            this.lblDI1TotalIntervalTime.Location = new System.Drawing.Point(474, 126);
            this.lblDI1TotalIntervalTime.Name = "lblDI1TotalIntervalTime";
            this.lblDI1TotalIntervalTime.Size = new System.Drawing.Size(15, 17);
            this.lblDI1TotalIntervalTime.TabIndex = 24;
            this.lblDI1TotalIntervalTime.Text = "0";
            // 
            // lblDI0TotalIntervalTime
            // 
            this.lblDI0TotalIntervalTime.AutoSize = true;
            this.lblDI0TotalIntervalTime.ForeColor = System.Drawing.Color.Blue;
            this.lblDI0TotalIntervalTime.Location = new System.Drawing.Point(474, 95);
            this.lblDI0TotalIntervalTime.Name = "lblDI0TotalIntervalTime";
            this.lblDI0TotalIntervalTime.Size = new System.Drawing.Size(15, 17);
            this.lblDI0TotalIntervalTime.TabIndex = 23;
            this.lblDI0TotalIntervalTime.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "DI-1 Interval Time (ms): ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "DI-0 Interval Time (ms): ";
            // 
            // lblDI1TotalCounter
            // 
            this.lblDI1TotalCounter.AutoSize = true;
            this.lblDI1TotalCounter.ForeColor = System.Drawing.Color.Blue;
            this.lblDI1TotalCounter.Location = new System.Drawing.Point(129, 126);
            this.lblDI1TotalCounter.Name = "lblDI1TotalCounter";
            this.lblDI1TotalCounter.Size = new System.Drawing.Size(15, 17);
            this.lblDI1TotalCounter.TabIndex = 20;
            this.lblDI1TotalCounter.Text = "0";
            // 
            // lblDI0TotalCounter
            // 
            this.lblDI0TotalCounter.AutoSize = true;
            this.lblDI0TotalCounter.ForeColor = System.Drawing.Color.Blue;
            this.lblDI0TotalCounter.Location = new System.Drawing.Point(129, 95);
            this.lblDI0TotalCounter.Name = "lblDI0TotalCounter";
            this.lblDI0TotalCounter.Size = new System.Drawing.Size(15, 17);
            this.lblDI0TotalCounter.TabIndex = 19;
            this.lblDI0TotalCounter.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "DI-1 Counter: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "DI-0 Counter: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.tbxYAxisLimit_Min);
            this.groupBox4.Controls.Add(this.tbxYAxisLimit_Max);
            this.groupBox4.Controls.Add(this.lblYAxisLimit_Min);
            this.groupBox4.Controls.Add(this.lblYAxisLimit_Max);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(876, 314);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(693, 123);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Y Axis Limit";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(414, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 34);
            this.button2.TabIndex = 30;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbxYAxisLimit_Min
            // 
            this.tbxYAxisLimit_Min.Location = new System.Drawing.Point(191, 75);
            this.tbxYAxisLimit_Min.Name = "tbxYAxisLimit_Min";
            this.tbxYAxisLimit_Min.Size = new System.Drawing.Size(100, 25);
            this.tbxYAxisLimit_Min.TabIndex = 29;
            // 
            // tbxYAxisLimit_Max
            // 
            this.tbxYAxisLimit_Max.Location = new System.Drawing.Point(191, 43);
            this.tbxYAxisLimit_Max.Name = "tbxYAxisLimit_Max";
            this.tbxYAxisLimit_Max.Size = new System.Drawing.Size(100, 25);
            this.tbxYAxisLimit_Max.TabIndex = 28;
            // 
            // lblYAxisLimit_Min
            // 
            this.lblYAxisLimit_Min.AutoSize = true;
            this.lblYAxisLimit_Min.ForeColor = System.Drawing.Color.Blue;
            this.lblYAxisLimit_Min.Location = new System.Drawing.Point(74, 77);
            this.lblYAxisLimit_Min.Name = "lblYAxisLimit_Min";
            this.lblYAxisLimit_Min.Size = new System.Drawing.Size(15, 17);
            this.lblYAxisLimit_Min.TabIndex = 20;
            this.lblYAxisLimit_Min.Text = "0";
            // 
            // lblYAxisLimit_Max
            // 
            this.lblYAxisLimit_Max.AutoSize = true;
            this.lblYAxisLimit_Max.ForeColor = System.Drawing.Color.Blue;
            this.lblYAxisLimit_Max.Location = new System.Drawing.Point(74, 46);
            this.lblYAxisLimit_Max.Name = "lblYAxisLimit_Max";
            this.lblYAxisLimit_Max.Size = new System.Drawing.Size(15, 17);
            this.lblYAxisLimit_Max.TabIndex = 19;
            this.lblYAxisLimit_Max.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 17);
            this.label16.TabIndex = 18;
            this.label16.Text = "Min:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 17);
            this.label17.TabIndex = 16;
            this.label17.Text = "Max:  ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.lblValue2_ch4);
            this.groupBox5.Controls.Add(this.lblValue2_ch3);
            this.groupBox5.Controls.Add(this.lblValue2_ch2);
            this.groupBox5.Controls.Add(this.lblValue2_ch1);
            this.groupBox5.Controls.Add(this.tbxValue_ch4);
            this.groupBox5.Controls.Add(this.tbxValue_ch3);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.lblValue_ch4);
            this.groupBox5.Controls.Add(this.lblValue_ch3);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.tbxValue_ch2);
            this.groupBox5.Controls.Add(this.tbxValue_ch1);
            this.groupBox5.Controls.Add(this.lblValue_ch2);
            this.groupBox5.Controls.Add(this.lblValue_ch1);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(876, 443);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(693, 229);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Value";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(529, 122);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 34);
            this.button4.TabIndex = 46;
            this.button4.Text = "Zero";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblValue2_ch4
            // 
            this.lblValue2_ch4.AutoSize = true;
            this.lblValue2_ch4.ForeColor = System.Drawing.Color.Blue;
            this.lblValue2_ch4.Location = new System.Drawing.Point(339, 169);
            this.lblValue2_ch4.Name = "lblValue2_ch4";
            this.lblValue2_ch4.Size = new System.Drawing.Size(15, 17);
            this.lblValue2_ch4.TabIndex = 45;
            this.lblValue2_ch4.Text = "0";
            // 
            // lblValue2_ch3
            // 
            this.lblValue2_ch3.AutoSize = true;
            this.lblValue2_ch3.ForeColor = System.Drawing.Color.Blue;
            this.lblValue2_ch3.Location = new System.Drawing.Point(339, 138);
            this.lblValue2_ch3.Name = "lblValue2_ch3";
            this.lblValue2_ch3.Size = new System.Drawing.Size(15, 17);
            this.lblValue2_ch3.TabIndex = 44;
            this.lblValue2_ch3.Text = "0";
            // 
            // lblValue2_ch2
            // 
            this.lblValue2_ch2.AutoSize = true;
            this.lblValue2_ch2.ForeColor = System.Drawing.Color.Blue;
            this.lblValue2_ch2.Location = new System.Drawing.Point(339, 109);
            this.lblValue2_ch2.Name = "lblValue2_ch2";
            this.lblValue2_ch2.Size = new System.Drawing.Size(15, 17);
            this.lblValue2_ch2.TabIndex = 43;
            this.lblValue2_ch2.Text = "0";
            // 
            // lblValue2_ch1
            // 
            this.lblValue2_ch1.AutoSize = true;
            this.lblValue2_ch1.ForeColor = System.Drawing.Color.Blue;
            this.lblValue2_ch1.Location = new System.Drawing.Point(339, 78);
            this.lblValue2_ch1.Name = "lblValue2_ch1";
            this.lblValue2_ch1.Size = new System.Drawing.Size(15, 17);
            this.lblValue2_ch1.TabIndex = 42;
            this.lblValue2_ch1.Text = "0";
            // 
            // tbxValue_ch4
            // 
            this.tbxValue_ch4.Location = new System.Drawing.Point(191, 171);
            this.tbxValue_ch4.Name = "tbxValue_ch4";
            this.tbxValue_ch4.Size = new System.Drawing.Size(100, 25);
            this.tbxValue_ch4.TabIndex = 41;
            // 
            // tbxValue_ch3
            // 
            this.tbxValue_ch3.Location = new System.Drawing.Point(191, 139);
            this.tbxValue_ch3.Name = "tbxValue_ch3";
            this.tbxValue_ch3.Size = new System.Drawing.Size(100, 25);
            this.tbxValue_ch3.TabIndex = 40;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(289, 37);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 17);
            this.label24.TabIndex = 39;
            this.label24.Text = "=";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(176, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 17);
            this.label23.TabIndex = 38;
            this.label23.Text = "-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(329, 37);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 17);
            this.label22.TabIndex = 37;
            this.label22.Text = "Value";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(214, 37);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 17);
            this.label21.TabIndex = 36;
            this.label21.Text = "Bias";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(109, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 17);
            this.label20.TabIndex = 35;
            this.label20.Text = "Value";
            // 
            // lblValue_ch4
            // 
            this.lblValue_ch4.AutoSize = true;
            this.lblValue_ch4.ForeColor = System.Drawing.Color.Blue;
            this.lblValue_ch4.Location = new System.Drawing.Point(74, 169);
            this.lblValue_ch4.Name = "lblValue_ch4";
            this.lblValue_ch4.Size = new System.Drawing.Size(15, 17);
            this.lblValue_ch4.TabIndex = 34;
            this.lblValue_ch4.Text = "0";
            // 
            // lblValue_ch3
            // 
            this.lblValue_ch3.AutoSize = true;
            this.lblValue_ch3.ForeColor = System.Drawing.Color.Blue;
            this.lblValue_ch3.Location = new System.Drawing.Point(74, 138);
            this.lblValue_ch3.Name = "lblValue_ch3";
            this.lblValue_ch3.Size = new System.Drawing.Size(15, 17);
            this.lblValue_ch3.TabIndex = 33;
            this.lblValue_ch3.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "Ch4";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 17);
            this.label15.TabIndex = 31;
            this.label15.Text = "Ch3";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(529, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 34);
            this.button3.TabIndex = 30;
            this.button3.Text = "Set";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbxValue_ch2
            // 
            this.tbxValue_ch2.Location = new System.Drawing.Point(191, 107);
            this.tbxValue_ch2.Name = "tbxValue_ch2";
            this.tbxValue_ch2.Size = new System.Drawing.Size(100, 25);
            this.tbxValue_ch2.TabIndex = 29;
            // 
            // tbxValue_ch1
            // 
            this.tbxValue_ch1.Location = new System.Drawing.Point(191, 75);
            this.tbxValue_ch1.Name = "tbxValue_ch1";
            this.tbxValue_ch1.Size = new System.Drawing.Size(100, 25);
            this.tbxValue_ch1.TabIndex = 28;
            // 
            // lblValue_ch2
            // 
            this.lblValue_ch2.AutoSize = true;
            this.lblValue_ch2.ForeColor = System.Drawing.Color.Blue;
            this.lblValue_ch2.Location = new System.Drawing.Point(74, 109);
            this.lblValue_ch2.Name = "lblValue_ch2";
            this.lblValue_ch2.Size = new System.Drawing.Size(15, 17);
            this.lblValue_ch2.TabIndex = 20;
            this.lblValue_ch2.Text = "0";
            // 
            // lblValue_ch1
            // 
            this.lblValue_ch1.AutoSize = true;
            this.lblValue_ch1.ForeColor = System.Drawing.Color.Blue;
            this.lblValue_ch1.Location = new System.Drawing.Point(74, 78);
            this.lblValue_ch1.Name = "lblValue_ch1";
            this.lblValue_ch1.Size = new System.Drawing.Size(15, 17);
            this.lblValue_ch1.TabIndex = 19;
            this.lblValue_ch1.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ch2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Ch1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(32, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 584);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // UserControl_VChannel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControl_VChannel";
            this.Size = new System.Drawing.Size(1582, 685);
            this.Load += new System.EventHandler(this.UserControl_VChannel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDI1Counter;
        private System.Windows.Forms.Label lblDI0Counter;
        private System.Windows.Forms.Label lblDI1IntervalTime;
        private System.Windows.Forms.Label lblDI0IntervalTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxCaptureIntervalTime_ms;
        private System.Windows.Forms.Label lblCaptureIntervalTime_ms;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDI1TotalIntervalTime;
        private System.Windows.Forms.Label lblDI0TotalIntervalTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDI1TotalCounter;
        private System.Windows.Forms.Label lblDI0TotalCounter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblYAxisLimit_Min;
        private System.Windows.Forms.Label lblYAxisLimit_Max;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxYAxisLimit_Min;
        private System.Windows.Forms.TextBox tbxYAxisLimit_Max;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblValue2_ch4;
        private System.Windows.Forms.Label lblValue2_ch3;
        private System.Windows.Forms.Label lblValue2_ch2;
        private System.Windows.Forms.Label lblValue2_ch1;
        private System.Windows.Forms.TextBox tbxValue_ch4;
        private System.Windows.Forms.TextBox tbxValue_ch3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblValue_ch4;
        private System.Windows.Forms.Label lblValue_ch3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbxValue_ch2;
        private System.Windows.Forms.TextBox tbxValue_ch1;
        private System.Windows.Forms.Label lblValue_ch2;
        private System.Windows.Forms.Label lblValue_ch1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
    }
}
