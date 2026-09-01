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
using Color = System.Drawing.Color;

namespace DRE
{
    public partial class UserControl_WaterFall : UserControl
    {
        private MainProcess mp = null;

        private readonly FormsPlot formsPlot1;


        public UserControl_WaterFall(MainProcess inMp)
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


            ScottPlotThemeMenuHelper.AddThemeMenu(formsPlot1, ScottPlotTitleConfig.WaterFall, true);
        }

        //public void CreateWaterFall()
        //{
        //    if (mp.MultiFileNamePaths != null)
        //    {
        //        if (mp.MultiFileNamePaths.Length > 0)
        //        {
        //            InitialData();
        //            double lastValue = 0.0;
        //            int axisindex = 0;
        //            int index = 0;

        //            for (int i = 0; i < mp.MultiFileNamePaths.Length; i++)
        //            {
        //                mp.LoadDataWithInfo(mp.MultiFileNamePaths[i]);
        //                lastValue = DrawData(axisindex, index, lastValue, i);
        //                index++;
        //            }

        //            RefreshData();
        //        }
        //    }
        //}

        public void CreateWaterFall()
        {
            if (mp.MultiFileNamePaths == null ||
                mp.MultiFileNamePaths.Length == 0)
            {
                return;
            }

            InitialData();

            // 開始繪製新一批 Waterfall 前先清除舊曲線
            formsPlot1.Plot.Clear();

            formsPlot1.Plot.Title("Water Fall");
            formsPlot1.Plot.XLabel("Frequency (Hz)");
            formsPlot1.Plot.YLabel("Magnitude");

            formsPlot1.Plot.Axes.Left.IsVisible = true;
            formsPlot1.Plot.Axes.Left.Label.IsVisible = false;
            formsPlot1.Plot.Axes.Left.TickLabelStyle.IsVisible = false;

            double lastValue = 0.0;
            int axisIndex = 0;
            int colorIndex = 0;

            for (int i = 0;
                 i < mp.MultiFileNamePaths.Length;
                 i++)
            {
                mp.LoadDataWithInfo(
                    mp.MultiFileNamePaths[i]);

                lastValue = DrawData2(
                    axisIndex,
                    colorIndex,
                    lastValue,
                    i);

                colorIndex++;
            }

            RefreshData();
        }

        private void InitialData()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            mp.XYZData.Clear();
        }

        private void RefreshData()
        {
            //zedGraphControl1.AxisChange();
            //zedGraphControl1.Refresh();
            if (formsPlot1 == null)
                return;

            /*
             * 對應 ZedGraph 的 AxisChange()：
             * 依目前所有 Waterfall 曲線重新計算座標範圍。
             */
            formsPlot1.Plot.Axes.AutoScale();

            formsPlot1.Refresh();
        }

        private double DrawData(int axisindex, int colorindex, double lastMaxValue, int index = -1)
        {
            double result = lastMaxValue;

            int number2 = mp.magResult[0].Length;

            int[] xlabel2 = new int[number2];
            string[] xlabelString2 = new string[number2];
            double[] BINValue = new double[number2];
            for (int i = 0; i < number2; i++)
            {
                //xlabel2[i] = (int)((double)i * 10000.0 / 1024.0);
                //xlabelString2[i] = xlabel2[i].ToString();
                xlabel2[i] = (int)((double)i * mp.UseFrameRate / (double)number2);
                xlabelString2[i] = xlabel2[i].ToString();
                BINValue[i] = (double)i * mp.UseFrameRate / (double)mp.DataNumberZero;
            }

            double[] y_value = new double[mp.magResult[axisindex].Length];
            double[] y_value2 = new double[mp.magResult[axisindex].Length];
            double[] z_value = new double[mp.magResult[axisindex].Length];
            for (int i = 0; i < y_value.Length; i++)
            {
                y_value[i] = mp.magResult[axisindex][i] + lastMaxValue;
                if (y_value[i] > result) result = y_value[i];
                y_value2[i] = mp.magResult[axisindex][i];
                z_value[i] = mp.RPM;
            }

            mp.XYZData.Add(new XYZDataDto(BINValue, y_value2, z_value, (index+1).ToString() + "-RPM-" + mp.RPM.ToString("F2")));

            GraphPane myPane2 = zedGraphControl1.GraphPane;

            myPane2.Title.Text = ScottPlotTitleConfig.WaterFall.Title;//"Water Fall";
            myPane2.XAxis.Title.Text = ScottPlotTitleConfig.WaterFall.XAxisTitle;//"Frequency(Hz)";
            myPane2.YAxis.Title.Text = ScottPlotTitleConfig.WaterFall.YAxisTitle;//"Mangitude";
            myPane2.YAxis.IsVisible = false;

            LineItem myCurve2List = myPane2.AddCurve("RPM-" + mp.RPM.ToString("F2"),
                    BINValue, y_value, mp.CurveColor[colorindex], SymbolType.None);

            myCurve2List.Symbol.Size = 8.0F;
            myCurve2List.Symbol.Fill = new Fill(Color.White);
            myCurve2List.Line.Width = 2.0F;

            return result;
        }

        private double DrawData2(
    int axisIndex,
    int colorIndex,
    double lastMaxValue,
    int index = -1)
        {
            double result = lastMaxValue;

            if (formsPlot1 == null)
                return result;

            if (mp.magResult == null ||
                axisIndex < 0 ||
                axisIndex >= mp.magResult.Length ||
                mp.magResult[axisIndex] == null ||
                mp.magResult[axisIndex].Length == 0)
            {
                return result;
            }

            double[] magnitudeSource =
                mp.magResult[axisIndex];

            int number = magnitudeSource.Length;

            double[] binValues =
                new double[number];

            double[] offsetMagnitude =
                new double[number];

            double[] originalMagnitude =
                new double[number];

            double[] rpmValues =
                new double[number];

            // 避免 DataNumberZero 為 0
            double dataNumberZero =
                mp.DataNumberZero > 0
                    ? mp.DataNumberZero
                    : number;

            for (int i = 0; i < number; i++)
            {
                // 頻率：
                // i × SampleRate ÷ FFT點數
                binValues[i] =
                    i *
                    mp.UseFrameRate /
                    dataNumberZero;

                originalMagnitude[i] =
                    magnitudeSource[i];

                // Waterfall 每條曲線向上位移
                offsetMagnitude[i] =
                    magnitudeSource[i] +
                    lastMaxValue;

                rpmValues[i] =
                    mp.RPM;

                if (offsetMagnitude[i] > result)
                    result = offsetMagnitude[i];
            }

            // 保存原始 XYZ 資料
            mp.XYZData.Add(
                new XYZDataDto(
                    binValues,
                    originalMagnitude,
                    rpmValues,
                    $"{index + 1}-RPM-{mp.RPM:F2}"));

            ScottPlot.Plot plot =
                formsPlot1.Plot;

            // 圖表設定
            //plot.Title("Water Fall");
            //plot.XLabel("Frequency (Hz)");

            //plot.Axes.Left.Label.Text =
            //    "Magnitude";
            ScottPlotTitleConfig.Apply(
                formsPlot1.Plot,
                ScottPlotTitleConfig.WaterFall);


            plot.Axes.Left.IsVisible = true;
            plot.Axes.Left.Label.IsVisible = false;
            plot.Axes.Left.TickLabelStyle.IsVisible = false;

            // 新增一條 Waterfall 曲線
            ScottPlot.Plottables.Scatter scatter =
                plot.Add.ScatterLine(
                    binValues,
                    offsetMagnitude);

            scatter.LegendText =
                $"RPM-{mp.RPM:F2}";

            scatter.LineWidth = 2.0f;

            // 頻譜不使用平滑，避免峰值變形
            scatter.Smooth = false;

            if (mp.CurveColor != null &&
                mp.CurveColor.Length > 0)
            {
                int safeColorIndex =
                    Math.Abs(colorIndex) %
                    mp.CurveColor.Length;

                scatter.Color =
                    ScottPlot.Color.FromColor(
                        mp.CurveColor[safeColorIndex]);
            }

            return result;
        }

        
    }
}

    

