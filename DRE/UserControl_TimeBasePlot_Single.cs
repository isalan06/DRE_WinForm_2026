using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
using ScottPlot.WinForms;

namespace DRE
{
    public partial class UserControl_TimeBasePlot_Single : UserControl
    {
        private MainProcess mp = null;
        private readonly FormsPlot formsPlot1;


        public UserControl_TimeBasePlot_Single(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            formsPlot1 = new FormsPlot
            {
                Name = "formsPlot1",
                Dock = DockStyle.Fill
            };

            panel1.Controls.Add(formsPlot1);

            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot1);
        }

        private void DrawData()
        {
            #region Graph2 - Data in Scott

            ScottPlot.Plot plot = formsPlot1.Plot;

            // 相當於：
            // zedGraphControl1.GraphPane.CurveList.Clear();
            plot.Clear();

            int number2 = (int)mp.DataNumber;

            if (number2 <= 0)
            {
                formsPlot1.Refresh();
                return;
            }

            double[] xLabel = new double[number2];

            int[] keyPhasorIndexes = mp.KeyPhasorList ?? Array.Empty<int>();
            double[] keyPhasorX = new double[keyPhasorIndexes.Length];
            double[] keyPhasorY = new double[keyPhasorIndexes.Length];

            int keyPhasorIndex = 0;
            double maxXLabel = 0.0;

            for (int i = 0; i < number2; i++)
            {
                if (mp.IsPoolingStatus)
                    xLabel[i] = i;
                else
                    xLabel[i] = mp.MSPerPoint * i;

                if (xLabel[i] > maxXLabel)
                    maxXLabel = xLabel[i];

                if (keyPhasorIndex < keyPhasorIndexes.Length &&
                    i == keyPhasorIndexes[keyPhasorIndex])
                {
                    keyPhasorX[keyPhasorIndex] = xLabel[i];
                    keyPhasorY[keyPhasorIndex] = 0.0;

                    keyPhasorIndex++;
                }
            }

            // 圖表標題及座標軸
            plot.Title("Data");
            plot.XLabel("Time(ms)");

            plot.Axes.Left.Label.Text = "Voltage(V)";
            plot.Axes.Right.Label.Text = "Unit(mil)";

            bool displayParameter = cbxDisplayParameterUsed.Checked;

            if (displayParameter)
            {
                plot.Axes.Left.Label.Text = "Unit(g)";
                plot.Axes.Right.IsVisible = true;
            }
            else
            {
                plot.Axes.Right.IsVisible = false;
            }

            bool[] setChannelDisplay2 =
            {
        chbChann1Displat1.Checked,
        chbChann2Displat1.Checked,
        chbChann3Displat1.Checked,
        chbChann4Displat1.Checked,
    };

            for (int channel = 0; channel < 4; channel++)
            {
                if (!setChannelDisplay2[channel])
                    continue;

                if (mp.VoltageValue[channel] == null)
                    continue;

                double[] yValues;

                if (displayParameter)
                {
                    yValues = ConvertDisplayValues(channel);
                }
                else
                {
                    yValues = mp.VoltageValue[channel];
                }

                // 避免 X、Y 陣列長度不一致
                int validLength = Math.Min(xLabel.Length, yValues.Length);

                if (validLength <= 0)
                    continue;

                double[] xs = xLabel;
                double[] ys = yValues;

                if (validLength != xLabel.Length)
                {
                    xs = new double[validLength];
                    Array.Copy(xLabel, xs, validLength);
                }

                if (validLength != yValues.Length)
                {
                    ys = new double[validLength];
                    Array.Copy(yValues, ys, validLength);
                }

                ScottPlot.Plottables.Scatter scatter =
                    plot.Add.Scatter(xs, ys);

                if (displayParameter)
                {
                    string unit = mp.MyParameter
                        .ChannelSetting[channel]
                        .IsUnitGram
                        ? "g"
                        : "mil";

                    scatter.LegendText =
                        $"Chan-{channel + 1}-{unit}";

                    /*
                     * g 通道使用左側 Y 軸
                     * mil 通道使用右側 Y 軸
                     *
                     * 原本 ZedGraph 程式雖然顯示 Y2 軸，
                     * 但沒有明確將曲線指定到 Y2 軸。
                     * ScottPlot 這裡依單位正確分配。
                     */
                    scatter.Axes.YAxis =
                        mp.MyParameter.ChannelSetting[channel].IsUnitGram
                        ? plot.Axes.Left
                        : plot.Axes.Right;
                }
                else
                {
                    scatter.LegendText =
                        $"Chan-{channel + 1}";

                    scatter.Axes.YAxis = plot.Axes.Left;
                }

                if (channel == 3 && chbKeyPhasorByChannel4.Checked)
                {
                    scatter.LineWidth = 2;
                    scatter.MarkerSize = 0;
                    scatter.Smooth = false;
                }
                else
                {

                    // MATLAB 類似的連續平滑曲線
                    scatter.LineWidth = 1.5f;
                    scatter.MarkerSize = 0;

                    // 使用 cubic spline 平滑連接資料點
                    scatter.Smooth = true;

                    // 建議 0.5～0.8
                    // 越低越圓滑，但可能在峰值處產生 overshoot
                    // 越高越接近原始折線
                    scatter.SmoothTension = 0.65;
                }

                // mp.CurveColor 假設是 System.Drawing.Color[]
                scatter.Color =
                    ScottPlot.Color.FromColor(
                        mp.CurveColor[channel]);
            }

            DrawKeyPhasor(
                plot,
                keyPhasorX,
                keyPhasorY,
                keyPhasorIndex);

            plot.ShowLegend();

            if (mp.IsExecutingProcedure || mp.bCaptureOneTimeFinished)
            {
                if (mp.bCaptureOneTimeFinished) mp.bCaptureOneTimeFinished = false;
                // 先自動計算 Y 軸範圍
                plot.Axes.AutoScale();

                // 再限制 X 軸範圍，避免 AutoScale 將設定覆蓋
                double timeRange =
                    mp.MyParameter.ScopeSetting.TimeRange;

                double xMaximum =
                    maxXLabel > timeRange
                    ? timeRange
                    : maxXLabel;

                if (xMaximum <= 0)
                    xMaximum = 1;

                plot.Axes.SetLimitsX(
                    left: 0,
                    right: xMaximum);
            }

            //if (_isFirstPlot_TimeBasePlot_Single)
            //{
            //    // 先自動計算 Y 軸範圍
            //    plot.Axes.AutoScale();

            //    // 再限制 X 軸範圍，避免 AutoScale 將設定覆蓋
            //    double timeRange =
            //        mp.MyParameter.ScopeSetting.TimeRange;

            //    double xMaximum =
            //        maxXLabel > timeRange
            //        ? timeRange
            //        : maxXLabel;

            //    if (xMaximum <= 0)
            //        xMaximum = 1;

            //    plot.Axes.SetLimitsX(
            //        left: 0,
            //        right: xMaximum);

            //    _isFirstPlot_TimeBasePlot_Single = false;
            //}

            formsPlot1.Refresh();

            #endregion

            lblRPMValue.Text = mp.RPM.ToString("F2");

            lblDI0Counter.Text = mp.uiEdgeCounter[0].ToString();
            lblDI1Counter.Text = mp.uiEdgeCounter[1].ToString();
        }

        private double[] ConvertDisplayValues(int channel)
        {
            double[] source = mp.VoltageValue[channel];
            double[] result = new double[source.Length];

            int displayType =
                mp.MyParameter.ChannelSetting[channel].DisplayType;

            double changedValue =
                mp.MyParameter.ChannelSetting[channel].ChangedValue;

            for (int i = 0; i < source.Length; i++)
            {
                double value = source[i];

                switch (displayType)
                {
                    default:
                    case 0:
                        // 原始值
                        break;

                    case 1:
                        // 負值歸零
                        if (value < 0.0)
                            value = 0.0;
                        break;

                    case 2:
                        // RMS 換算
                        value *= 0.707;
                        break;
                }

                result[i] = value * changedValue;
            }

            return result;
        }

        private static void DrawKeyPhasor(
    ScottPlot.Plot plot,
    double[] keyPhasorX,
    double[] keyPhasorY,
    int validCount)
        {
            if (validCount <= 0)
                return;

            double[] xs = keyPhasorX;
            double[] ys = keyPhasorY;

            // KeyPhasorList 中可能有超出 DataNumber 的索引，
            // 只保留實際找到的點。
            if (validCount != keyPhasorX.Length)
            {
                xs = new double[validCount];
                ys = new double[validCount];

                Array.Copy(keyPhasorX, xs, validCount);
                Array.Copy(keyPhasorY, ys, validCount);
            }

            ScottPlot.Plottables.Scatter points =
                plot.Add.Scatter(xs, ys);

            points.LineWidth = 0;
            points.MarkerSize = 6;
            points.MarkerShape =
                ScottPlot.MarkerShape.FilledCircle;

            points.Color = ScottPlot.Colors.Purple;

            // 不設定 LegendText，因此不會顯示於圖例
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!mp.bGraphRefreshStop)
                DrawData();

           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string ext = Path.GetExtension(saveFileDialog1.FileName);

                mp.SaveDataWithInfo(saveFileDialog1.FileName);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);

                mp.LoadDataWithInfo(openFileDialog1.FileName);
            }
        }

        private void zedGraphControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void chbRangeOpen_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cbxDisplayParameterUsed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblRPMValue_Click(object sender, EventArgs e)
        {

        }
    }
}
