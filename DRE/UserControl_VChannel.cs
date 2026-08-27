using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using ScottPlot.WinForms;
using ScottPlot;

namespace DRE
{
    public partial class UserControl_VChannel : UserControl
    {
        private MainProcess mp = null;

        private double YAxisMax = 10.5;
        private double YAxisMin = -10.5;

        private double ch1Value, ch2Value, ch3Value, ch4Value;
        private double[] values = new double[] { 0.0, 0.0, 0.0, 0.0 };

        private readonly FormsPlot formsPlot1;

        public UserControl_VChannel(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            zedGraphControl1.Visible = false;
            panel1.Visible = true;

            formsPlot1 = new FormsPlot
            {
                Name = "formsPlot1",
                Dock = DockStyle.Fill
            };

            panel1.Controls.Clear();
            panel1.Controls.Add(formsPlot1);

            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot1);
        }

        private void DrawData()
        {
            LineItem lineItem = new LineItem("Test");

            zedGraphControl1.GraphPane.CurveList.Clear();

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Voltage - Channel";
            myPane.YAxis.Scale.Max = YAxisMax;
            myPane.YAxis.Scale.Min = YAxisMin;
            myPane.YAxis.Title.Text = "Voltage(V)";

            myPane.XAxis.Title.Text = "Axis No";

            for (int i = 0; i < 4; i++)
            {
                lineItem = myPane.AddCurve($"Axis{i + 1}", new double[] { i + 1 }, new double[] { values[i] }, mp.CurveColor[i]);
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void DrawData2()
        {
            PointPairList allPoints = new PointPairList();

            zedGraphControl1.GraphPane.CurveList.Clear();

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Voltage - Channel";
            myPane.YAxis.Scale.Max = YAxisMax;
            myPane.YAxis.Scale.Min = YAxisMin;
            myPane.YAxis.Title.Text = "Voltage(V)";

            myPane.XAxis.Title.Text = "Axis No";

            for (int i = 0; i < 4; i++)
            {
                allPoints.Add(i + 1, values[i]);
            }

            LineItem myContinuousCurve = myPane.AddCurve("Voltage-Channel", allPoints, System.Drawing.Color.Blue, SymbolType.None);

            myContinuousCurve.Symbol.Type = SymbolType.Circle;
            myContinuousCurve.Symbol.IsVisible = true;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void DrawData3()
        {
            if (formsPlot1 == null)
                return;

            ScottPlot.Plot plot = formsPlot1.Plot;

            plot.Clear();

            plot.Title("Voltage - Channel");
            plot.XLabel("Axis No");
            plot.YLabel("Voltage(V)");

            if (values == null || values.Length < 4)
            {
                formsPlot1.Refresh();
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                ScottPlot.Color pointColor;

                if (mp.CurveColor != null &&
                    i < mp.CurveColor.Length)
                {
                    pointColor =
                        ScottPlot.Color.FromColor(
                            mp.CurveColor[i]);
                }
                else
                {
                    pointColor = ScottPlot.Colors.Blue;
                }

                ScottPlot.Plottables.Marker marker =
                    plot.Add.Marker(
                        x: i + 1,
                        y: values[i],
                        shape: ScottPlot.MarkerShape.FilledCircle);

                marker.MarkerSize = 10;

                marker.MarkerFillColor = pointColor;
                marker.MarkerLineColor = pointColor;

                marker.LegendText =
                    $"Axis{i + 1}";
            }

            // 固定 Y 軸範圍
            plot.Axes.SetLimitsY(
                bottom: YAxisMin,
                top: YAxisMax);

            // X 軸只顯示 1～4，左右留少許空間
            plot.Axes.SetLimitsX(
                left: 0.5,
                right: 4.5);

            // 將 X 軸刻度固定為 Axis 1～Axis 4
            plot.Axes.Bottom.SetTicks(
                new double[] { 1, 2, 3, 4 },
                new string[]
                {
            "Axis 1",
            "Axis 2",
            "Axis 3",
            "Axis 4"
                });

            plot.ShowLegend(
                ScottPlot.Alignment.UpperRight);

            formsPlot1.Refresh();
        }

        private void DrawData4()
        {
            if (formsPlot1 == null)
                return;

            ScottPlot.Plot plot = formsPlot1.Plot;

            plot.Clear();

            plot.Title("Voltage - Channel");
            plot.XLabel("Axis No");
            plot.YLabel("Voltage(V)");

            if (values == null || values.Length < 4)
            {
                formsPlot1.Refresh();
                return;
            }

            double[] xs =
            {
        1.0,
        2.0,
        3.0,
        4.0
    };

            double[] ys =
            {
        values[0],
        values[1],
        values[2],
        values[3]
    };

            ScottPlot.Plottables.Scatter scatter =
                plot.Add.Scatter(xs, ys);

            scatter.LegendText =
                "Voltage-Channel";

            scatter.Color =
                ScottPlot.Colors.Blue;

            scatter.LineWidth = 2.0f;

            scatter.MarkerSize = 8;

            scatter.MarkerShape =
                ScottPlot.MarkerShape.FilledCircle;

            scatter.MarkerFillColor =
                ScottPlot.Colors.White;

            scatter.MarkerLineColor =
                ScottPlot.Colors.Blue;

            scatter.MarkerLineWidth = 2;

            /*
             * 不使用平滑，避免只有 4 個點時 spline
             * 在兩點之間產生非實際數值的突出。
             */
            scatter.Smooth = false;

            plot.Axes.SetLimitsY(
                bottom: YAxisMin,
                top: YAxisMax);

            plot.Axes.SetLimitsX(
                left: 0.5,
                right: 4.5);

            plot.Axes.Bottom.SetTicks(
                new double[] { 1, 2, 3, 4 },
                new string[]
                {
            "Axis 1",
            "Axis 2",
            "Axis 3",
            "Axis 4"
                });

            plot.ShowLegend(
                ScottPlot.Alignment.UpperRight);

            formsPlot1.Refresh();
        }

        private void ShowData()
        {
            lblDI0Counter.Text = mp.uiEdgeCounter[0].ToString();
            lblDI1Counter.Text = mp.uiEdgeCounter[1].ToString();
            lblDI0IntervalTime.Text = mp.lCaptureDataIntervalTime[0].ToString();
            lblDI1IntervalTime.Text = mp.lCaptureDataIntervalTime[1].ToString();

            lblCaptureIntervalTime_ms.Text = mp.lSetCaptureToAnalysisTime.ToString();

            lblDI0TotalCounter.Text = mp.uiTotalEdgeCounter[0].ToString();
            lblDI1TotalCounter.Text = mp.uiTotalEdgeCounter[1].ToString();
            lblDI0TotalIntervalTime.Text = mp.lTotalCaptureIntervalTime[0].ToString();
            lblDI1TotalIntervalTime.Text = mp.lTotalCaptureIntervalTime[1].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                DrawData3();
            else
                DrawData4();

            ShowData();

            RefreshValue();
        }

        private void UserControl_VChannel_Load(object sender, EventArgs e)
        {
            tbxCaptureIntervalTime_ms.Text = mp.lSetCaptureToAnalysisTime.ToString();
            SetYAxisLimit();
            LoadBiasValue();

        }

        private void SetYAxisLimit()
        {
            lblYAxisLimit_Max.Text = YAxisMax.ToString("F3");
            lblYAxisLimit_Min.Text = YAxisMin.ToString("F3");
            tbxYAxisLimit_Max.Text = YAxisMax.ToString("F3");
            tbxYAxisLimit_Min.Text = YAxisMin.ToString("F3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long value = 0;
            bool result = long.TryParse(tbxCaptureIntervalTime_ms.Text, out value);

            if (result)
            {
                mp.lSetCaptureToAnalysisTime = value;
            }
            else
            {
                tbxCaptureIntervalTime_ms.Text = mp.lSetCaptureToAnalysisTime.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double value1, value2;

            if (double.TryParse(tbxYAxisLimit_Max.Text, out value1))
            {
                if (double.TryParse(tbxYAxisLimit_Min.Text, out value2))
                {
                    if (value1 >= value2)
                    {
                        YAxisMax = value1;
                        YAxisMin = value2;
                    }
                }
            }

            SetYAxisLimit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetBiasValue();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbxValue_ch1.Text = lblValue_ch1.Text;
            tbxValue_ch2.Text = lblValue_ch2.Text;
            tbxValue_ch3.Text = lblValue_ch3.Text;
            tbxValue_ch4.Text = lblValue_ch4.Text;

            SetBiasValue();
        }

        private void RefreshValue()
        {
            values[0] = mp.dTestVoltage[0] - ch1Value;
            values[1] = mp.dTestVoltage[1] - ch2Value;
            values[2] = mp.dTestVoltage[2] - ch3Value;
            values[3] = mp.dTestVoltage[3] - ch4Value;

            lblValue_ch1.Text = mp.dTestVoltage[0].ToString("F3");
            lblValue_ch2.Text = mp.dTestVoltage[1].ToString("F3");
            lblValue_ch3.Text = mp.dTestVoltage[2].ToString("F3");
            lblValue_ch4.Text = mp.dTestVoltage[3].ToString("F3");

            lblValue2_ch1.Text = values[0].ToString("F3");
            lblValue2_ch2.Text = values[1].ToString("F3");
            lblValue2_ch3.Text = values[2].ToString("F3");
            lblValue2_ch4.Text = values[3].ToString("F3");
        }

        private void LoadBiasValue()
        {
            tbxValue_ch1.Text = ch1Value.ToString("F3");
            tbxValue_ch2.Text = ch2Value.ToString("F3");
            tbxValue_ch3.Text = ch3Value.ToString("F3");
            tbxValue_ch4.Text = ch4Value.ToString("F3");
        }

        private void SetBiasValue()
        {
            double value1, value2, value3, value4;

            if (double.TryParse(tbxValue_ch1.Text, out value1))
            {
                if (double.TryParse(tbxValue_ch2.Text, out value2))
                {
                    if (double.TryParse(tbxValue_ch3.Text, out value3))
                    {
                        if (double.TryParse(tbxValue_ch4.Text, out value4))
                        {
                            ch1Value = value1;
                            ch2Value = value2;
                            ch3Value = value3;
                            ch4Value = value4;
                        }
                    }
                }
            }

            LoadBiasValue();
        }
    }
}
