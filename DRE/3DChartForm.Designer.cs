namespace DRE
{
    partial class _3DChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panMain = new System.Windows.Forms.Panel();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblInc = new System.Windows.Forms.Label();
            this.lblRotate = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panMain.Controls.Add(this.label2);
            this.panMain.Controls.Add(this.label1);
            this.panMain.Controls.Add(this.trackBar2);
            this.panMain.Controls.Add(this.trackBar1);
            this.panMain.Controls.Add(this.lblInc);
            this.panMain.Controls.Add(this.lblRotate);
            this.panMain.Controls.Add(this.chart1);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(1111, 778);
            this.panMain.TabIndex = 0;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(414, 34);
            this.trackBar2.Maximum = 90;
            this.trackBar2.Minimum = -90;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(289, 45);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.Value = 30;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(10, 34);
            this.trackBar1.Maximum = 180;
            this.trackBar1.Minimum = -180;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(289, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 30;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblInc
            // 
            this.lblInc.AutoSize = true;
            this.lblInc.Location = new System.Drawing.Point(551, 19);
            this.lblInc.Name = "lblInc";
            this.lblInc.Size = new System.Drawing.Size(17, 12);
            this.lblInc.TabIndex = 2;
            this.lblInc.Text = "30";
            // 
            // lblRotate
            // 
            this.lblRotate.AutoSize = true;
            this.lblRotate.Location = new System.Drawing.Point(141, 19);
            this.lblRotate.Name = "lblRotate";
            this.lblRotate.Size = new System.Drawing.Size(17, 12);
            this.lblRotate.TabIndex = 1;
            this.lblRotate.Text = "30";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 85);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1101, 686);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart1_PostPaint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Right<->Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Down<->Up";
            // 
            // _3DChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 778);
            this.Controls.Add(this.panMain);
            this.Name = "_3DChartForm";
            this.Text = "_3DChartForm";
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblInc;
        private System.Windows.Forms.Label lblRotate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}