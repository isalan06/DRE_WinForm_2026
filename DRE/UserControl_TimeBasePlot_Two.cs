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
using ScottPlot.WinForms;


namespace DRE
{
    public partial class UserControl_TimeBasePlot_Two : UserControl
    {
        private MainProcess mp = null;
        private readonly FormsPlot formsPlot1;
        private readonly FormsPlot formsPlot2;

        public UserControl_TimeBasePlot_Two(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            formsPlot1 = new FormsPlot
            {
                Name = "formsPlot1",
                Dock = DockStyle.Fill
            };

            panel1.Controls.Add(formsPlot1);

            formsPlot2 = new FormsPlot
            {
                Name = "formsPlot2",
                Dock = DockStyle.Fill
            };

            panel2.Controls.Add(formsPlot2);

            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot1);
            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot2);
        }

        private void DrawData()
        {
            #region Graph1 - Data

            bool[] channelDisplay1 =
            {
                chbChann1Displat1.Checked,
                chbChann2Displat1.Checked,
                chbChann3Displat1.Checked,
                chbChann4Displat1.Checked,
            };

            DrawDataPlot(
                formsPlot: formsPlot1,
                channelDisplay: channelDisplay1,
                showKeyPhasor: chbKeyPhasorByChannel4.Checked,
                preserveZoom: true);

            #endregion


            #region Graph2 - Data

            bool[] channelDisplay2 =
            {
                chbChann1Displat2.Checked,
                chbChann2Displat2.Checked,
                chbChann3Displat2.Checked,
                chbChann4Displat2.Checked,
            };

            DrawDataPlot(
                formsPlot: formsPlot2,
                channelDisplay: channelDisplay2,
                showKeyPhasor: chbKeyPhasorByChannel4.Checked,
                preserveZoom: true);

            #endregion

            if (mp.bCaptureOneTimeFinished2) mp.bCaptureOneTimeFinished2 = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!mp.bGraphRefreshStop)
                DrawData();
        }

        private void DrawDataPlot(
            ScottPlot.WinForms.FormsPlot formsPlot,
            bool[] channelDisplay,
            bool showKeyPhasor,
            bool preserveZoom)
        {
            ScottPlot.Plot plot = formsPlot.Plot;

            /*
             * 在清除曲線之前保存目前座標範圍。
             *
             * preserveZoom = true：
             * 使用者縮放或框選後，下一次更新資料仍保留目前視野。
             *
             * preserveZoom = false：
             * 每次更新都重新 AutoScale。
             */
            //ScottPlot.AxisLimits previousLimits =
            //    plot.Axes.GetLimits();

            //bool hasPreviousPlot =
            //    plot.GetPlottables().Any();

            plot.Clear();

            int number = (int)mp.DataNumber;

            if (number <= 0)
            {
                formsPlot.Refresh();
                return;
            }

            double[] xLabel =
                new double[number];

            double maxXLabel = 0.0;

            for (int i = 0; i < number; i++)
            {
                if (mp.IsPoolingStatus)
                {
                    xLabel[i] = i;
                }
                else
                {
                    xLabel[i] =
                        mp.MSPerPoint * i;
                }

                if (xLabel[i] > maxXLabel)
                {
                    maxXLabel = xLabel[i];
                }
            }

            // =========================================
            // 圖表標題與座標軸名稱
            // =========================================

            plot.Title("Data");
            plot.XLabel("Time(ms)");
            plot.YLabel("Voltage(V)");

            // =========================================
            // 繪製四個 Channel
            // =========================================

            int channelCount =
                Math.Min(4, channelDisplay.Length);

            for (int channel = 0;
                 channel < channelCount;
                 channel++)
            {
                if (!channelDisplay[channel])
                {
                    continue;
                }

                if (mp.VoltageValue == null ||
                    channel >= mp.VoltageValue.Length ||
                    mp.VoltageValue[channel] == null)
                {
                    continue;
                }

                double[] sourceY =
                    mp.VoltageValue[channel];

                int validLength =
                    Math.Min(
                        xLabel.Length,
                        sourceY.Length);

                if (validLength <= 0)
                {
                    continue;
                }

                double[] xs;
                double[] ys;

                /*
                 * 若 X、Y 長度不同，只取共同有效範圍，
                 * 避免 ScottPlot 因陣列長度不同而發生例外。
                 */
                if (validLength == xLabel.Length)
                {
                    xs = xLabel;
                }
                else
                {
                    xs = new double[validLength];

                    Array.Copy(
                        xLabel,
                        xs,
                        validLength);
                }

                if (validLength == sourceY.Length)
                {
                    ys = sourceY;
                }
                else
                {
                    ys = new double[validLength];

                    Array.Copy(
                        sourceY,
                        ys,
                        validLength);
                }

                ScottPlot.Plottables.Scatter scatter =
                    plot.Add.Scatter(xs, ys);

                scatter.LegendText =
                    $"Chan-{channel + 1}";

                scatter.LineWidth = 2.0f;
                scatter.MarkerSize = 0;

                /*
                 * ZedGraph 原始程式為一般直線連接，
                 * 因此這裡不啟用 spline 平滑。
                 *
                 * 這樣方波不會產生 0→5 或 5→0 的過衝。
                 */
                scatter.Smooth = false;

                if (mp.CurveColor != null &&
                    channel < mp.CurveColor.Length)
                {
                    scatter.Color =
                        ScottPlot.Color.FromColor(
                            mp.CurveColor[channel]);
                }
            }

            // =========================================
            // Key Phasor 標記
            // =========================================

            if (showKeyPhasor)
            {
                DrawKeyPhasorMarkers(
                    plot,
                    xLabel,
                    mp.KeyPhasorList,
                    markerY: 11.0);
            }

            // 有曲線時才顯示 Legend
            if (plot.GetPlottables().Any())
            {
                plot.ShowLegend();
            }

            // =========================================
            // 座標軸範圍
            // =========================================

            if (mp.IsExecutingProcedure || mp.bCaptureOneTimeFinished2)
            {
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

            //if (preserveZoom && hasPreviousPlot)
            //{
            //    /*
            //     * 保留使用者目前縮放、平移或框選後的範圍。
            //     */
            //    plot.Axes.SetLimits(previousLimits);
            //}
            //else
            //{
            //    /*
            //     * 第一次顯示或要求重設視野時，
            //     * 先計算適當的 Y 軸範圍。
            //     */
            //    plot.Axes.AutoScale();

            //    double timeRange =
            //        mp.MyParameter.ScopeSetting.TimeRange;

            //    double xMaximum;

            //    if (timeRange > 0)
            //    {
            //        xMaximum =
            //            Math.Min(
            //                maxXLabel,
            //                timeRange);
            //    }
            //    else
            //    {
            //        xMaximum = maxXLabel;
            //    }

            //    if (xMaximum <= 0)
            //    {
            //        xMaximum = 1;
            //    }

            //    plot.Axes.SetLimitsX(
            //        left: 0,
            //        right: xMaximum);
            //}

            formsPlot.Refresh();
        }

        private static void DrawKeyPhasorMarkers(
            ScottPlot.Plot plot,
            double[] xValues,
            int[] keyPhasorIndexes,
            double markerY)
        {
            if (xValues == null ||
                xValues.Length == 0 ||
                keyPhasorIndexes == null ||
                keyPhasorIndexes.Length == 0)
            {
                return;
            }

            for (int i = 0;
                    i < keyPhasorIndexes.Length;
                    i++)
            {
                int dataIndex =
                    keyPhasorIndexes[i];

                /*
                    * 防止 KeyPhasorList 中有超出資料範圍的索引。
                    */
                if (dataIndex < 0 ||
                    dataIndex >= xValues.Length)
                {
                    continue;
                }

                ScottPlot.Plottables.Marker marker =
                    plot.Add.Marker(
                        x: xValues[dataIndex],
                        y: markerY);

                marker.Shape =
                    ScottPlot.MarkerShape.FilledCircle;

                marker.Size = 5;

                marker.Color =
                    ScottPlot.Colors.Purple;

                /*
                    * Marker 不設定 LegendText，
                    * 避免每一個 P1、P2 都出現在 Legend。
                    */
            }
        }
    }

        
}
