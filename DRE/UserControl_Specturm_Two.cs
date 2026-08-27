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
    public partial class UserControl_Specturm_Two : UserControl
    {
        private MainProcess mp = null;
        private readonly FormsPlot formsPlot1;
        private readonly FormsPlot formsPlot2;

        public UserControl_Specturm_Two(MainProcess inMp)
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

            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot1, ScottPlotTitleConfig.Spectrum, true);
            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot2, ScottPlotTitleConfig.Spectrum, true);
        }
        /*
        private void DrawData()
        {
            #region Graph 1

            zedGraphControl1.GraphPane.CurveList.Clear();

            int number2 = mp.magResult[0].Length;

            int[] xlabel2 = new int[number2];
            string[] xlabelString2 = new string[number2];
            for (int i = 0; i < number2; i++)
            {
                xlabel2[i] = (int)((double)i * 10000.0 / 1024.0);
                xlabelString2[i] = xlabel2[i].ToString();
            }

            GraphPane myPane2 = zedGraphControl1.GraphPane;

            myPane2.Title.Text = "Magnitude";
            myPane2.XAxis.Title.Text = "Frequency(Hz)";
            myPane2.YAxis.Title.Text = "Mangitude";

            LineItem[] myCurve2List = new LineItem[4];

            bool[] setChannelDisplay = new bool[]
            {
                chbChann1Displat1.Checked, chbChann2Displat1.Checked, chbChann3Displat1.Checked, chbChann4Displat1.Checked,
            };

            for (int i = 0; i < 4; i++)
            {
                if (setChannelDisplay[i])
                {
                    myCurve2List[i] = myPane2.AddCurve("Mangitude-" + (i + 1).ToString(),
                          null, mp.magResult[i], mp.CurveColor[i], SymbolType.None);

                    myCurve2List[i].Symbol.Size = 8.0F;
                    myCurve2List[i].Symbol.Fill = new Fill(Color.White);
                    myCurve2List[i].Line.Width = 2.0F;
                }
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();

            #endregion
        }

        private void DrawData2()
        {
            #region Graph 2

            zedGraphControl2.GraphPane.CurveList.Clear();

            int number2 = mp.magResult[0].Length;

            int[] xlabel2 = new int[number2];
            string[] xlabelString2 = new string[number2];
            for (int i = 0; i < number2; i++)
            {
                xlabel2[i] = (int)((double)i * 10000.0 / 1024.0);
                xlabelString2[i] = xlabel2[i].ToString();
            }

            GraphPane myPane2 = zedGraphControl2.GraphPane;

            myPane2.Title.Text = "Magnitude";
            myPane2.XAxis.Title.Text = "Frequency(Hz)";
            myPane2.YAxis.Title.Text = "Mangitude";

            LineItem[] myCurve2List = new LineItem[4];

            bool[] setChannelDisplay = new bool[]
            {
                chbChann1Displat2.Checked, chbChann2Displat2.Checked, chbChann3Displat2.Checked, chbChann4Displat2.Checked,
            };

            for (int i = 0; i < 4; i++)
            {
                if (setChannelDisplay[i])
                {
                    myCurve2List[i] = myPane2.AddCurve("Mangitude-" + (i + 1).ToString(),
                          null, mp.magResult[i], mp.CurveColor[i], SymbolType.None);

                    myCurve2List[i].Symbol.Size = 8.0F;
                    myCurve2List[i].Symbol.Fill = new Fill(Color.White);
                    myCurve2List[i].Line.Width = 2.0F;
                }
            }

            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();

            #endregion
        }
        */
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!mp.bGraphRefreshStop)
            {
                DrawData();
                DrawData2();
            }
        }

        private void DrawData()
        {
            bool[] setChannelDisplay =
            {
        chbChann1Displat1.Checked,
        chbChann2Displat1.Checked,
        chbChann3Displat1.Checked,
        chbChann4Displat1.Checked,
    };

            DrawSpectrumPlot(
                formsPlot1,
                setChannelDisplay);
        }

        private void DrawData2()
        {
            bool[] setChannelDisplay =
            {
        chbChann1Displat2.Checked,
        chbChann2Displat2.Checked,
        chbChann3Displat2.Checked,
        chbChann4Displat2.Checked,
    };

            DrawSpectrumPlot(
                formsPlot2,
                setChannelDisplay);
        }

        private void DrawSpectrumPlot(
            ScottPlot.WinForms.FormsPlot formsPlot,
            bool[] setChannelDisplay)
        {
            if (formsPlot == null)
                return;

            ScottPlot.Plot plot = formsPlot.Plot;

            // 清除原本所有曲線
            plot.Clear();

            // ==========================================
            // 資料檢查
            // ==========================================

            if (mp.magResult == null ||
                mp.magResult.Length == 0 ||
                mp.magResult[0] == null ||
                mp.magResult[0].Length == 0)
            {
                formsPlot.Refresh();
                return;
            }

            int number = mp.magResult[0].Length;

            // 原本 xlabel2 的頻率間距：
            // i * 10000 / 1024
            double frequencyPeriod =
                10000.0 / 1024.0;

            // ==========================================
            // 圖表標題
            // ==========================================

            //plot.Title("Magnitude");
            //plot.XLabel("Frequency (Hz)");
            //plot.YLabel("Magnitude");

            plot.Title($"{ScottPlotTitleConfig.Spectrum.Title}");
            plot.XLabel($"{ScottPlotTitleConfig.Spectrum.XAxisTitle}");
            plot.YLabel($"{ScottPlotTitleConfig.Spectrum.YAxisTitle}");

            bool hasCurve = false;

            int channelCount = Math.Min(
                4,
                setChannelDisplay.Length);

            // ==========================================
            // 繪製四個頻譜通道
            // ==========================================

            for (int channel = 0;
                 channel < channelCount;
                 channel++)
            {
                if (!setChannelDisplay[channel])
                    continue;

                if (channel >= mp.magResult.Length ||
                    mp.magResult[channel] == null ||
                    mp.magResult[channel].Length == 0)
                {
                    continue;
                }

                double[] magnitude =
                    mp.magResult[channel];

                /*
                 * Signal 適用於固定間距的 X 軸資料。
                 *
                 * 預設：
                 * X = 0, 1, 2, 3...
                 *
                 * 設定 Period 後：
                 * X = 0,
                 *     10000/1024,
                 *     2*10000/1024...
                 */
                ScottPlot.Plottables.Signal signal =
                    plot.Add.Signal(magnitude);

                signal.Data.Period =
                    frequencyPeriod;

                signal.Data.XOffset = 0;

                signal.LegendText =
                    $"Magnitude-{channel + 1}";

                signal.LineWidth = 2.0f;

                /*
                 * 不顯示資料點 Marker，
                 * 只顯示頻譜曲線。
                 */
                signal.MaximumMarkerSize = 0;

                if (mp.CurveColor != null &&
                    channel < mp.CurveColor.Length)
                {
                    signal.Color =
                        ScottPlot.Color.FromColor(
                            mp.CurveColor[channel]);
                }

                hasCurve = true;
            }

            // ==========================================
            // Legend 與座標軸
            // ==========================================

            if (hasCurve)
            {
                plot.ShowLegend(
                    ScottPlot.Alignment.UpperRight);

                plot.Axes.AutoScale();

                /*
                 * 頻率軸從 0 Hz 開始。
                 *
                 * 最大頻率：
                 * (number - 1) * frequencyPeriod
                 */
                double maximumFrequency =
                    Math.Max(
                        frequencyPeriod,
                        (number - 1) * frequencyPeriod);

                plot.Axes.SetLimitsX(
                    left: 0,
                    right: maximumFrequency);
            }

            formsPlot.Refresh();
        }
    }
}
