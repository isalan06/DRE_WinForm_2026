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
    public partial class UserControl_Specturm_Single : UserControl
    {
        private MainProcess mp = null;

        private readonly FormsPlot formsPlot1;
        private bool _magnitudePlotInitialized = false;

        public UserControl_Specturm_Single(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            formsPlot1 = new FormsPlot
            {
                Name = "formsPlot1",
                Dock = DockStyle.Fill
            };

            panel1.Controls.Clear();
            panel1.Controls.Add(formsPlot1);

            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot1, ScottPlotTitleConfig.TimeBase, true);
        }

        private double[] GetMagnitudeData(
            int channel,
            bool isMagLog)
        {
            if (isMagLog)
            {
                if (mp.magLogResult == null ||
                    channel < 0 ||
                    channel >= mp.magLogResult.Length ||
                    mp.magLogResult[channel] == null)
                {
                    return Array.Empty<double>();
                }

                return mp.magLogResult[channel];
            }

            if (mp.magResult == null ||
                channel < 0 ||
                channel >= mp.magResult.Length ||
                mp.magResult[channel] == null)
            {
                return Array.Empty<double>();
            }

            return mp.magResult[channel];
        }

        private double[] GetFrequencyData(
            int channel,
            bool isMagLog,
            double[] binValues,
            int magnitudeLength)
        {
            if (isMagLog)
            {
                if (mp.fSpan == null ||
                    channel < 0 ||
                    channel >= mp.fSpan.Length ||
                    mp.fSpan[channel] == null)
                {
                    return Array.Empty<double>();
                }

                int validLength =
                    Math.Min(
                        mp.fSpan[channel].Length,
                        magnitudeLength);

                return CopyToLength(
                    mp.fSpan[channel],
                    validLength);
            }

            int binLength =
                Math.Min(
                    binValues.Length,
                    magnitudeLength);

            return CopyToLength(
                binValues,
                binLength);
        }

        private static double[] CopyToLength(
            double[] source,
            int length)
        {
            if (source == null ||
                length <= 0)
            {
                return Array.Empty<double>();
            }

            int validLength =
                Math.Min(
                    source.Length,
                    length);

            if (validLength <= 0)
                return Array.Empty<double>();

            if (validLength == source.Length)
                return source;

            double[] result =
                new double[validLength];

            Array.Copy(
                source,
                result,
                validLength);

            return result;
        }

        private static (
    double[] Xs,
    double[] Ys) CreateEnvelopeData(
        double[] xs,
        double[] ys,
        int envelopeNumber)
        {
            int validLength =
                Math.Min(
                    xs.Length,
                    ys.Length);

            if (validLength <= 0)
            {
                return (
                    Array.Empty<double>(),
                    Array.Empty<double>());
            }

            if (envelopeNumber <= 1)
            {
                return (
                    CopyToLength(xs, validLength),
                    CopyToLength(ys, validLength));
            }

            int outputLength =
                (validLength + envelopeNumber - 1) /
                envelopeNumber;

            double[] envelopeX =
                new double[outputLength];

            double[] envelopeY =
                new double[outputLength];

            for (int group = 0;
                 group < outputLength;
                 group++)
            {
                int startIndex =
                    group * envelopeNumber;

                int endIndex =
                    Math.Min(
                        startIndex + envelopeNumber,
                        validLength);

                int maximumIndex =
                    startIndex;

                double maximumValue =
                    ys[startIndex];

                for (int index = startIndex + 1;
                     index < endIndex;
                     index++)
                {
                    if (ys[index] > maximumValue)
                    {
                        maximumValue =
                            ys[index];

                        maximumIndex =
                            index;
                    }
                }

                /*
                 * X 使用最大值實際所在的位置，
                 * 比原本固定使用區段第一點更準確。
                 */
                envelopeX[group] =
                    xs[maximumIndex];

                envelopeY[group] =
                    maximumValue;
            }

            return (
                envelopeX,
                envelopeY);
        }

        private static (
    double[] Xs,
    double[] Ys) CreateShiftedSpectrum(
        double[] xs,
        double[] ys)
        {
            int count =
                Math.Min(
                    xs.Length,
                    ys.Length);

            if (count <= 0)
            {
                return (
                    Array.Empty<double>(),
                    Array.Empty<double>());
            }

            double[] shiftedX =
                new double[count];

            double[] shiftedY =
                new double[count];

            /*
             * 偶數：
             * 0 1 2 3 4 5 6 7
             * 變成
             * 4 5 6 7 0 1 2 3
             *
             * 奇數也可正常處理。
             */
            int shift =
                count / 2;

            int outputIndex = 0;

            // 後半部移到前方
            for (int sourceIndex = shift;
                 sourceIndex < count;
                 sourceIndex++)
            {
                shiftedX[outputIndex] =
                    xs[sourceIndex];

                shiftedY[outputIndex] =
                    ys[sourceIndex];

                outputIndex++;
            }

            // 前半部移到後方
            for (int sourceIndex = 0;
                 sourceIndex < shift;
                 sourceIndex++)
            {
                shiftedX[outputIndex] =
                    xs[sourceIndex];

                shiftedY[outputIndex] =
                    ys[sourceIndex];

                outputIndex++;
            }

            return (
                shiftedX,
                shiftedY);
        }

        private void DrawData()
        {
            if (formsPlot1 == null)
                return;

            ScottPlot.Plot plot = formsPlot1.Plot;

            /*
             * 在 Clear() 前保存目前的顯示範圍。
             * 這樣使用者縮放或拖曳後，資料更新時不會跳回原始範圍。
             */
            ScottPlot.AxisLimits previousLimits =
                plot.Axes.GetLimits();

            bool preserveZoom =
                _magnitudePlotInitialized;

            plot.Clear();

            bool isMagLog =
                cbxMagLog.Checked;

            // =============================================
            // 基本資料檢查
            // =============================================

            if (mp.magResult == null ||
                mp.magResult.Length == 0 ||
                mp.magResult[0] == null ||
                mp.magResult[0].Length == 0)
            {
                formsPlot1.Refresh();
                return;
            }

            int number2 =
                mp.magResult[0].Length;

            int envelopeNumber = 1;

            if (!int.TryParse(
                    lblEnvelopePerNumber.Text,
                    out envelopeNumber))
            {
                envelopeNumber = 1;
            }

            if (envelopeNumber <= 0)
                envelopeNumber = 1;

            // =============================================
            // 建立一般 Magnitude 使用的頻率 X 軸
            // =============================================

            double[] binValues =
                new double[number2];

            for (int i = 0; i < number2; i++)
            {
                /*
                 * 保留原本 BINValue 的計算方式：
                 *
                 * BINValue[i] =
                 *     i * UseFrameRate / DataNumberZero;
                 */
                if (mp.DataNumberZero > 0)
                {
                    binValues[i] =
                        (double)i *
                        mp.UseFrameRate /
                        mp.DataNumberZero;
                }
                else
                {
                    // 避免除以 0
                    binValues[i] = i;
                }
            }

            // =============================================
            // 圖表標題
            // =============================================

            plot.Title("Magnitude");
            plot.XLabel("Frequency(Hz)");
            plot.YLabel(
                isMagLog
                    ? "Mag Log"
                    : "Mag");

            bool[] setChannelDisplay =
            {
        chbChann1Displat1.Checked,
        chbChann2Displat1.Checked,
        chbChann3Displat1.Checked,
        chbChann4Displat1.Checked
    };

            bool hasCurve = false;

            // =============================================
            // 繪製四個通道
            // =============================================

            for (int channel = 0;
                 channel < 4;
                 channel++)
            {
                if (!setChannelDisplay[channel])
                    continue;

                double[] sourceMagnitude =
                    GetMagnitudeData(
                        channel,
                        isMagLog);

                if (sourceMagnitude == null ||
                    sourceMagnitude.Length == 0)
                {
                    continue;
                }

                double[] sourceX =
                    GetFrequencyData(
                        channel,
                        isMagLog,
                        binValues,
                        sourceMagnitude.Length);

                if (sourceX == null ||
                    sourceX.Length == 0)
                {
                    continue;
                }

                int validLength =
                    Math.Min(
                        sourceX.Length,
                        sourceMagnitude.Length);

                if (validLength <= 0)
                    continue;

                double[] xs =
                    CopyToLength(
                        sourceX,
                        validLength);

                double[] ys =
                    CopyToLength(
                        sourceMagnitude,
                        validLength);

                // =========================================
                // Envelope 模式
                // =========================================

                if (chbEnvelopeUsed.Checked)
                {
                    (xs, ys) =
                        CreateEnvelopeData(
                            xs,
                            ys,
                            envelopeNumber);
                }
                // =========================================
                // Shift Half 模式
                // =========================================
                else if (cbxShiftHalf.Checked)
                {
                    (xs, ys) =
                        CreateShiftedSpectrum(
                            xs,
                            ys);
                }

                if (xs.Length == 0 ||
                    ys.Length == 0)
                {
                    continue;
                }

                ScottPlot.Plottables.Scatter scatter =
                    plot.Add.Scatter(xs, ys);

                scatter.LegendText =
                    $"Magnitude-{channel + 1}";

                scatter.LineWidth = 2.0f;
                scatter.MarkerSize = 0;

                /*
                 * FFT 頻譜不建議使用 Smooth。
                 * Smooth 可能改變峰值形狀或在尖峰附近產生 overshoot。
                 */
                scatter.Smooth = false;

                if (mp.CurveColor != null &&
                    channel < mp.CurveColor.Length)
                {
                    scatter.Color =
                        ScottPlot.Color.FromColor(
                            mp.CurveColor[channel]);
                }

                hasCurve = true;
            }

            // =============================================
            // Legend
            // =============================================

            if (hasCurve)
                plot.ShowLegend();

            // =============================================
            // 座標範圍
            // =============================================

            if (preserveZoom && !mp.IsExecutingProcedure)
            {
                /*
                 * 保留使用者目前的縮放與平移範圍。
                 */
                plot.Axes.SetLimits(previousLimits);
            }
            else
            {
                /*
                 * 第一次繪圖，自動顯示全部資料。
                 */
                plot.Axes.AutoScale();

                _magnitudePlotInitialized = true;
            }

            formsPlot1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawData();
        }

        private void tbrEnvelopeNumberBar_Scroll(object sender, EventArgs e)
        {
            lblEnvelopePerNumber.Text = tbrEnvelopeNumberBar.Value.ToString();
        }
    }
}
