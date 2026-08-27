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
    public partial class UserControl_Orbit : UserControl
    {
        private MainProcess mp = null;
        private int orbitNumber = 1;

        private readonly FormsPlot formsPlot1;

        public UserControl_Orbit(MainProcess inMp)
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
            double[][] x_value = null;
            double[][] y_value = null;

            int lineNumber = orbitNumber;//1;
            x_value = new double[lineNumber][];
            y_value = new double[lineNumber][];

            LineItem[] myPoint = new LineItem[lineNumber];
            LineItem[] myPoint2 = new LineItem[lineNumber];

            int drawNumber = mp.CyclePointNumber;

            if (mp.CyclePointNumber > 0)
            {
               

                int x_index = 0; if (rbxXAxis_2.Checked) x_index = 1; if (rbxXAxis_3.Checked) x_index = 2; if (rbxXAxis_4.Checked) x_index = 3;
                int y_index = 0; if (rbxYAxis_2.Checked) y_index = 1; if (rbxYAxis_3.Checked) y_index = 2; if (rbxYAxis_4.Checked) y_index = 3;

                int[] PointIndex = mp.KeyPhasorPoint;

                

                if (chbRemoveLast10.Checked)
                    drawNumber -= drawNumber / 10;

                for (int i = 0; i < lineNumber; i++)
                {
                    x_value[i] = new double[drawNumber];
                    y_value[i] = new double[drawNumber];

                    for (int j = 0; j < drawNumber; j++)
                    {
                        x_value[i][j] = mp.VoltageValue[x_index][PointIndex[i] + j];
                        y_value[i][j] = mp.VoltageValue[y_index][PointIndex[i] + j];
                    }
                }
            }
            else
                return;

            zedGraphControl1.GraphPane.CurveList.Clear();

            

            GraphPane myPane2 = zedGraphControl1.GraphPane;

            myPane2.Title.Text = "Orbit";

            LineItem[] myCurve2List = new LineItem[lineNumber];

            for (int i = 0; i < lineNumber; i++)
            {
                myCurve2List[i] = myPane2.AddCurve("Orbit-" + (i + 1).ToString(),
                        x_value[i], y_value[i], mp.CurveColor[i], SymbolType.None);

                myCurve2List[i].Symbol.Size = 8.0F;
                myCurve2List[i].Symbol.Fill = new Fill(Color.White);
                myCurve2List[i].Line.Width = 2.0F;

                LineItem[] myTerminalPoint = new LineItem[2];
                myTerminalPoint[0] = new LineItem("Start", new double[] { x_value[i][0] }, new double[] { y_value[i][0] }, mp.CurveColor[i], SymbolType.Circle);
                myTerminalPoint[0].Symbol.Size = 6;
                myTerminalPoint[0].Symbol.Border.Width = 3;
                //myPoint[i].Symbol.Fill = new Fill(Color.Purple);
                myTerminalPoint[0].Label.IsVisible = false;
                myPane2.CurveList.Add(myTerminalPoint[0]);

                if (drawNumber > 0)
                {
                    myTerminalPoint[1] = new LineItem("End", new double[] { x_value[i][drawNumber - 1] }, new double[] { y_value[i][drawNumber - 1] }, mp.CurveColor[i], SymbolType.XCross);
                    myTerminalPoint[1].Symbol.Size = 6;
                    myTerminalPoint[1].Symbol.Border.Width = 3;
                    //myPoint[i].Symbol.Fill = new Fill(Color.Purple);
                    myTerminalPoint[1].Label.IsVisible = false;
                    myPane2.CurveList.Add(myTerminalPoint[1]);
                }
            }

            



            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblRPM.Text = mp.RPM.ToString("F2");

            if (!mp.bGraphRefreshStop && !mp.IsExecutingProcedure && !mp.IsPoolingStatus && !mp.IsPoolingSimStatus && !mp.IsCaptureOneTimeSimStatus)
                DrawData2();
        }

        private void trbOrbitNumber_ValueChanged(object sender, EventArgs e)
        {
            lblOrbitNumber.Text = trbOrbitNumber.Value.ToString();
            orbitNumber = trbOrbitNumber.Value;
        }
        
        private void DrawData2()
        {
            if (formsPlot1 == null)
                return;

            ScottPlot.Plot plot = formsPlot1.Plot;

            // 若持續更新，可在 Clear 前保存使用者目前縮放範圍
            //ScottPlot.AxisLimits previousLimits =
            //    plot.Axes.GetLimits();

            //bool hadPreviousPlot =
            //    plot.GetPlottables().Any();

            plot.Clear();

            // ==========================================
            // 基本資料檢查
            // ==========================================

            if (mp == null ||
                mp.CyclePointNumber <= 0 ||
                mp.VoltageValue == null ||
                mp.VoltageValue.Length < 4 ||
                mp.KeyPhasorPoint == null ||
                mp.KeyPhasorPoint.Length == 0)
            {
                formsPlot1.Refresh();
                return;
            }

            int lineNumber = Math.Min(
                orbitNumber,
                mp.KeyPhasorPoint.Length);

            if (lineNumber <= 0)
            {
                formsPlot1.Refresh();
                return;
            }

            int xIndex = GetSelectedXChannel();
            int yIndex = GetSelectedYChannel();

            if (xIndex < 0 ||
                xIndex >= mp.VoltageValue.Length ||
                yIndex < 0 ||
                yIndex >= mp.VoltageValue.Length ||
                mp.VoltageValue[xIndex] == null ||
                mp.VoltageValue[yIndex] == null)
            {
                formsPlot1.Refresh();
                return;
            }

            int drawNumber =
                mp.CyclePointNumber;

            if (chbRemoveLast10.Checked)
            {
                drawNumber -=
                    drawNumber / 10;
            }

            if (drawNumber <= 0)
            {
                formsPlot1.Refresh();
                return;
            }

            // ==========================================
            // 標題與座標軸
            // ==========================================

            plot.Title("Orbit");

            plot.XLabel(
                $"Channel {xIndex + 1}");

            plot.YLabel(
                $"Channel {yIndex + 1}");

            //ScottPlotTitleConfig.Apply(
            //    formsPlot1.Plot,
            //    ScottPlotTitleConfig.Orbit);

            bool hasOrbit = false;

            // ==========================================
            // 繪製每一圈 Orbit
            // ==========================================

            for (int orbitIndex = 0;
                 orbitIndex < lineNumber;
                 orbitIndex++)
            {
                int startIndex =
                    mp.KeyPhasorPoint[orbitIndex];

                if (startIndex < 0)
                    continue;

                int availableX =
                    mp.VoltageValue[xIndex].Length -
                    startIndex;

                int availableY =
                    mp.VoltageValue[yIndex].Length -
                    startIndex;

                int validPointCount =
                    Math.Min(
                        drawNumber,
                        Math.Min(
                            availableX,
                            availableY));

                if (validPointCount <= 0)
                    continue;

                double[] xValues =
                    new double[validPointCount];

                double[] yValues =
                    new double[validPointCount];

                Array.Copy(
                    mp.VoltageValue[xIndex],
                    startIndex,
                    xValues,
                    0,
                    validPointCount);

                Array.Copy(
                    mp.VoltageValue[yIndex],
                    startIndex,
                    yValues,
                    0,
                    validPointCount);

                ScottPlot.Color orbitColor =
                    GetOrbitColor(orbitIndex);

                // Orbit 軌跡
                ScottPlot.Plottables.Scatter orbit =
                    plot.Add.ScatterLine(
                        xValues,
                        yValues);

                orbit.LegendText =
                    $"Orbit-{orbitIndex + 1}";

                orbit.LineWidth = 2.0f;
                orbit.Color = orbitColor;

                /*
                 * Orbit 屬於工程量測資料，
                 * 建議不要使用 Cubic Spline 平滑，
                 * 避免軌跡產生非原始資料的突出或變形。
                 */
                orbit.Smooth = false;

                // ======================================
                // 起點：空心圓
                // ======================================

                ScottPlot.Plottables.Marker startMarker =
                    plot.Add.Marker(
                        x: xValues[0],
                        y: yValues[0],
                        shape: ScottPlot.MarkerShape.OpenCircle);

                startMarker.MarkerSize = 8;
                startMarker.MarkerLineColor = orbitColor;
                startMarker.LineWidth = 3;

                /*
                 * 不設定 LegendText，
                 * 避免 Start 標記出現在圖例。
                 */

                // ======================================
                // 終點：十字
                // ======================================

                int endIndex =
                    validPointCount - 1;

                ScottPlot.Plottables.Marker endMarker =
                    plot.Add.Marker(
                        x: xValues[endIndex],
                        y: yValues[endIndex],
                        shape: ScottPlot.MarkerShape.Cross);

                endMarker.MarkerSize = 9;
                endMarker.MarkerLineColor = orbitColor;
                endMarker.LineWidth = 3;

                hasOrbit = true;
            }

            // ==========================================
            // Legend 與座標軸範圍
            // ==========================================

            if (hasOrbit)
            {
                plot.ShowLegend(
                    ScottPlot.Alignment.UpperRight);

                /*
                 * Orbit 圖通常 X/Y 使用相同單位，
                 * 建議維持 1:1 比例，避免圓形軌跡被拉成橢圓。
                 */
                //plot.Axes.SquareUnits();

                //if (hadPreviousPlot)
                //{
                //    // 保留使用者目前縮放與平移範圍
                //    plot.Axes.SetLimits(previousLimits);
                //}
                //else
                //{
                //    // 第一次顯示全部 Orbit
                //    plot.Axes.AutoScale();

                //    // AutoScale 後再次維持 X/Y 比例一致
                //    plot.Axes.SquareUnits();
                //}

                plot.Axes.SetLimitsY(
                    bottom: -15,
                    top: 15);

                plot.Axes.SetLimitsX(
                    left: -15,
                    right: 15);
            }

            formsPlot1.Refresh();
        }

        private int GetSelectedXChannel()
        {
            if (rbxXAxis_2.Checked)
                return 1;

            if (rbxXAxis_3.Checked)
                return 2;

            if (rbxXAxis_4.Checked)
                return 3;

            return 0;
        }

        private int GetSelectedYChannel()
        {
            if (rbxYAxis_2.Checked)
                return 1;

            if (rbxYAxis_3.Checked)
                return 2;

            if (rbxYAxis_4.Checked)
                return 3;

            return 0;
        }

        private readonly ScottPlot.IPalette _orbitPalette =
            new ScottPlot.Palettes.Category10();

        private ScottPlot.Color GetOrbitColor(int orbitIndex)
        {
            if (mp.CurveColor != null &&
                mp.CurveColor.Length > 0)
            {
                int colorIndex =
                    orbitIndex % mp.CurveColor.Length;

                return ScottPlot.Color.FromColor(
                    mp.CurveColor[colorIndex]);
            }

            return _orbitPalette.GetColor(orbitIndex);
        }

        private void UserControl_Orbit_Load(object sender, EventArgs e)
        {

        }
    }
}
