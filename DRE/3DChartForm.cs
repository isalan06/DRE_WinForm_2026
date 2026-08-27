using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DRE
{
    public partial class _3DChartForm : Form
    {
        private bool useData = false;
        private MainProcess mp = null;
        public _3DChartForm(MainProcess inMp=null)
        {
            if (inMp == null) useData = false;
            else
            {
                useData = true;
                mp = inMp;
            }

            InitializeComponent();

            prepare3dChart(chart1, chart1.ChartAreas[0]);

            chart1.ChartAreas[0].Area3DStyle.Rotation = 30;
            chart1.ChartAreas[0].Area3DStyle.Inclination = 30;
        }

        private void prepare3dChart(Chart chart, ChartArea ca)
        {
          

            chart.Series.Clear();

            if (useData && (mp.XYZData.Count > 1))
            {
                ca.Area3DStyle.Enable3D = true;
                //ca.AxisX.Minimum = 0;
                //ca.AxisY.Minimum = 0;
                //ca.AxisX2.Maximum = 250;
                //ca.AxisY2.Maximum = 250;
                //ca.AxisX.Interval = 50;
                //ca.AxisY.Interval = 50;
                ca.AxisX.Title = "BIM";
                ca.AxisY.Title = "Y";
                //ca.AxisX.MajorGrid.Interval = 250;
                //ca.AxisY.MajorGrid.Interval = 250;
                //ca.AxisX.MinorGrid.Enabled = true;
                //ca.AxisY.MinorGrid.Enabled = true;
                //ca.AxisX.MinorGrid.Interval = 50;
                //ca.AxisY.MinorGrid.Interval = 50;
                ca.AxisX.MinorGrid.LineColor = Color.LightSlateGray;
                ca.AxisY.MinorGrid.LineColor = Color.LightSlateGray;

                chart.Series.Clear();

                for (int i = 0; i < mp.XYZData.Count; i++)
                {

                    Series s = chart.Series.Add(mp.XYZData[i].Title);
                    s.ChartType = SeriesChartType.Bubble;
                    s.MarkerStyle = MarkerStyle.Circle;
                    s["PixelPointWidth"] = "50";
                    s["PixelPointGapDepth"] = "1";
                }
                chart.ApplyPaletteColors();
                addRealData(chart);
            }
            else
            {
                ca.Area3DStyle.Enable3D = true;
                ca.AxisX.Minimum = -250;
                ca.AxisY.Minimum = -250;
                ca.AxisX2.Maximum = 250;
                ca.AxisY2.Maximum = 250;
                ca.AxisX.Interval = 50;
                ca.AxisY.Interval = 50;
                ca.AxisX.Title = "X-Achse";
                ca.AxisY.Title = "Y-Achse";
                ca.AxisX.MajorGrid.Interval = 250;
                ca.AxisY.MajorGrid.Interval = 250;
                ca.AxisX.MinorGrid.Enabled = true;
                ca.AxisY.MinorGrid.Enabled = true;
                ca.AxisX.MinorGrid.Interval = 50;
                ca.AxisY.MinorGrid.Interval = 50;
                ca.AxisX.MinorGrid.LineColor = Color.LightSlateGray;
                ca.AxisY.MinorGrid.LineColor = Color.LightSlateGray;

                chart.Series.Clear();

                for (int i = 0; i < 3; i++)
                {
                    Series s = chart.Series.Add("S" + i.ToString("00"));
                    s.ChartType = SeriesChartType.Bubble;
                    s.MarkerStyle = MarkerStyle.Circle;
                    s["PixelPointWidth"] = "10";
                    s["PixelPointGapDepth"] = "1";
                }
                chart.ApplyPaletteColors();
                addTestData(chart);
            }
        }

        private void addTestData(Chart chart)
        {
            Random rnd = new Random(9);
            for (int i = 0; i < 100; i++)
            {
                double x = Math.Cos(i / 10f) * 88 + rnd.Next(5);
                double y = Math.Cos(i / 11f) * 88 + rnd.Next(5);
                double z = Math.Cos(i * 2f) * 88 + rnd.Next(5);

                AddXY3d(chart.Series[0], x, y, z);
                AddXY3d(chart.Series[1], x - 111, y - 222, z);
                AddXY3d(chart.Series[2], i + 5, i + 10, i);
            }
        }
        private void addRealData(Chart chart)
        {
            for (int i = 0; i < mp.XYZData.Count; i++)
            {
                for (int j = 0; j < mp.XYZData[i].Y_Value.Length; j++)
                {
                    if (j >= 1000) 
                        break;
                    AddXY3d(chart.Series[i], mp.XYZData[i].X_Value[j], mp.XYZData[i].Y_Value[j], (i * 3));
                }
            }
        }

        private int AddXY3d(Series s, double xVal, double yVal, double zVal)
        {
            int p = s.Points.AddXY(xVal, yVal, zVal);
            s.Points[p].Color = Color.Transparent;

            return p;
        }

        private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            Chart chart = sender as Chart;

            if (chart.Series.Count < 1) return;
            if (chart.Series[0].Points.Count < 1) return;

            ChartArea ca = chart.ChartAreas[0];
            e.ChartGraphics.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            List<List<PointF>> data = new List<List<PointF>>();
            foreach (Series s in chart.Series)
                data.Add(GetPointsFrom3D(ca, s, s.Points.ToList(), e.ChartGraphics));

            renderLines(data, e.ChartGraphics.Graphics, chart, true);
            renderPoints(data, e.ChartGraphics.Graphics, chart, 2);

        }

        private List<PointF> GetPointsFrom3D(ChartArea ca, Series s, List<DataPoint> dPoints, ChartGraphics cg)
        {
            var p3t = dPoints.Select(x => new Point3D((float)ca.AxisX.ValueToPosition(x.XValue), (float)ca.AxisY.ValueToPosition(x.YValues[0]), (float)ca.AxisY.ValueToPosition(x.YValues[1]))).ToArray();
            ca.TransformPoints(p3t.ToArray());

            return p3t.Select(x => cg.GetAbsolutePoint(new PointF(x.X, x.Y))).ToList();
        }

        private void renderLines(List<List<PointF>> data, Graphics graphics, Chart chart, bool curves, int startindex = 0, int showcount=1000)
        {
            //for (int i = 0; i < chart.Series.Count; i++)
            for (int i = chart.Series.Count-1; i >= 0; i--)
            {
                if (data[i].Count > 1)
                {
                    using (Pen pen = new Pen(Color.FromArgb(64, chart.Series[i].Color), 2.5f))
                    {
                        if (curves) graphics.DrawCurve(pen, data[i].GetRange(startindex, showcount).ToArray());
                        else graphics.DrawLines(pen, data[i].GetRange(startindex, showcount).ToArray());
                    }
                }
            }
        }

        private void renderPoints(List<List<PointF>> data, Graphics graphics, Chart chart, float width, int startindex = 0, int showcount = 1000)
        {
            //for (int i = 0; i < chart.Series.Count; i++)
            for (int s = chart.Series.Count - 1; s >= 0; s--)
            { 
                Series S = chart.Series[s];
                for (int p = startindex; p < showcount; p++)
                {
                    if (p >= S.Points.Count) break;

                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(64, S.Color)))
                    {
                        graphics.FillEllipse(brush, data[s][p].X - width / 2, data[s][p].Y - width / 2, width, width);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Value = chart1.ChartAreas[0].Area3DStyle.Rotation;
            trackBar2.Value = chart1.ChartAreas[0].Area3DStyle.Inclination;
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = chart1.ChartAreas[0].Area3DStyle.Rotation + 1;
            if (a > 180) a = -180;
            chart1.ChartAreas[0].Area3DStyle.Rotation = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = chart1.ChartAreas[0].Area3DStyle.Rotation - 1;
            if (a < -180) a = 180;
            chart1.ChartAreas[0].Area3DStyle.Rotation = a;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = chart1.ChartAreas[0].Area3DStyle.Inclination + 1;
            if (a > 180) a = -180;
            chart1.ChartAreas[0].Area3DStyle.Inclination = a;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = chart1.ChartAreas[0].Area3DStyle.Inclination - 1;
            if (a < -180) a = 180;
            chart1.ChartAreas[0].Area3DStyle.Inclination = a;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lblRotate.Text = trackBar1.Value.ToString();
            chart1.ChartAreas[0].Area3DStyle.Rotation = trackBar1.Value;
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            lblInc.Text = trackBar2.Value.ToString();
            chart1.ChartAreas[0].Area3DStyle.Inclination = trackBar2.Value;
        }
    }
}
