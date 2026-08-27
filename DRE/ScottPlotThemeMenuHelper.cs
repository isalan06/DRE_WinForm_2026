using System;
using System.Drawing;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;

namespace DRE
{
    public static class ScottPlotThemeMenuHelper
    {
        /// <summary>
        /// 加入 ScottPlot 自訂右鍵選單
        /// </summary>
        /// <param name="formsPlot">ScottPlot 控制項</param>
        /// <param name="titleSetting">
        /// 圖表標題設定，例如：
        /// ScottPlotTitleConfig.TimeBase
        /// </param>
        /// <param name="includeTitleConfig">
        /// 是否加入標題/X/Y 軸設定選單
        /// </param>
        public static void AddThemeMenu(
            FormsPlot formsPlot,
            ChartTitleSetting titleSetting = null,
            bool includeTitleConfig = false)
        {
            if (formsPlot == null)
                throw new ArgumentNullException("formsPlot");

            // =====================================================
            // 顏色設定
            // =====================================================

            formsPlot.Menu.AddSeparator();

            formsPlot.Menu.Add(
                "外部背景顏色",
                delegate (Plot plot)
                {
                    SelectFigureBackgroundColor(
                        formsPlot,
                        plot);
                });

            formsPlot.Menu.Add(
                "資料區背景顏色",
                delegate (Plot plot)
                {
                    SelectDataBackgroundColor(
                        formsPlot,
                        plot);
                });

            formsPlot.Menu.Add(
                "格線顏色",
                delegate (Plot plot)
                {
                    SelectGridColor(
                        formsPlot,
                        plot);
                });

            formsPlot.Menu.Add(
                "座標軸與文字顏色",
                delegate (Plot plot)
                {
                    SelectAxisColor(
                        formsPlot,
                        plot);
                });

            // =====================================================
            // 標題設定
            // =====================================================

            if (includeTitleConfig &&
                titleSetting != null)
            {
                formsPlot.Menu.AddSeparator();

                formsPlot.Menu.Add(
                    "修改圖表標題",
                    delegate (Plot plot)
                    {
                        EditPlotTitle(
                            formsPlot,
                            plot,
                            titleSetting);
                    });

                formsPlot.Menu.Add(
                    "修改 X 軸標題",
                    delegate (Plot plot)
                    {
                        EditXAxisTitle(
                            formsPlot,
                            plot,
                            titleSetting);
                    });

                formsPlot.Menu.Add(
                    "修改 Y 軸標題",
                    delegate (Plot plot)
                    {
                        EditYAxisTitle(
                            formsPlot,
                            plot,
                            titleSetting);
                    });

                //formsPlot.Menu.Add(
                //    "儲存標題設定",
                //    delegate (Plot plot)
                //    {
                //        SaveTitleConfig();
                //    });

                formsPlot.Menu.Add(
                    "重新讀取標題設定",
                    delegate (Plot plot)
                    {
                        ReloadTitleConfig(
                            formsPlot,
                            plot,
                            titleSetting);
                    });
            }

            // =====================================================
            // 主題
            // =====================================================

            formsPlot.Menu.AddSeparator();

            formsPlot.Menu.Add(
                "暗色主題",
                delegate (Plot plot)
                {
                    ApplyDarkTheme(
                        formsPlot,
                        plot);
                });

            formsPlot.Menu.Add(
                "亮色主題",
                delegate (Plot plot)
                {
                    ApplyLightTheme(
                        formsPlot,
                        plot);
                });

            formsPlot.Menu.Add(
                "工業深色主題",
                delegate (Plot plot)
                {
                    ApplyIndustrialDarkTheme(
                        formsPlot,
                        plot);
                });

            formsPlot.Menu.Add(
                "恢復預設主題",
                delegate (Plot plot)
                {
                    ApplyDefaultTheme(
                        formsPlot,
                        plot);
                });
        }

        // =========================================================
        // 標題設定
        // =========================================================

        private static void EditPlotTitle(
            FormsPlot formsPlot,
            Plot plot,
            ChartTitleSetting setting)
        {
            string value =
                ShowInputDialog(
                    "修改圖表標題",
                    "請輸入圖表標題：",
                    setting.Title);

            if (value == null)
                return;

            // 直接更新設定物件
            setting.Title = value;

            // 套用到目前 Plot
            plot.Title(value);

            // 立即寫入 XML
            ScottPlotTitleConfig.Save();

            formsPlot.Refresh();
        }

        private static void EditXAxisTitle(
            FormsPlot formsPlot,
            Plot plot,
            ChartTitleSetting setting)
        {
            string value =
                ShowInputDialog(
                    "修改 X 軸標題",
                    "請輸入 X 軸標題：",
                    setting.XAxisTitle);

            if (value == null)
                return;

            setting.XAxisTitle = value;

            plot.XLabel(value);

            ScottPlotTitleConfig.Save();

            formsPlot.Refresh();
        }

        private static void EditYAxisTitle(
            FormsPlot formsPlot,
            Plot plot,
            ChartTitleSetting setting)
        {
            string value =
                ShowInputDialog(
                    "修改 Y 軸標題",
                    "請輸入 Y 軸標題：",
                    setting.YAxisTitle);

            if (value == null)
                return;

            setting.YAxisTitle = value;

            plot.YLabel(value);

            ScottPlotTitleConfig.Save();

            formsPlot.Refresh();
        }

        private static void SaveTitleConfig()
        {
            bool result =
                ScottPlotTitleConfig.Save();

            if (result)
            {
                MessageBox.Show(
                    "標題設定已儲存。",
                    "ScottPlot",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private static void ReloadTitleConfig(
            FormsPlot formsPlot,
            Plot plot,
            ChartTitleSetting setting)
        {
            ScottPlotTitleConfig.Load();

            /*
             * 注意：
             * Load() 後 static property 可能已經換成新的物件。
             *
             * 所以最好依 Name 再取得一次目前設定。
             */
            ChartTitleSetting newSetting =
                GetCurrentSetting(
                    setting.Name);

            if (newSetting == null)
                return;

            ScottPlotTitleConfig.Apply(
                plot,
                newSetting);

            formsPlot.Refresh();
        }

        // =========================================================
        // 根據 Name 取得最新設定
        // =========================================================

        private static ChartTitleSetting GetCurrentSetting(
            string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            if (name.Equals(
                "TimeBase",
                StringComparison.OrdinalIgnoreCase))
            {
                return ScottPlotTitleConfig.TimeBase;
            }

            if (name.Equals(
                "Spectrum",
                StringComparison.OrdinalIgnoreCase))
            {
                return ScottPlotTitleConfig.Spectrum;
            }

            if (name.Equals(
                "Orbit",
                StringComparison.OrdinalIgnoreCase))
            {
                return ScottPlotTitleConfig.Orbit;
            }

            if (name.Equals(
                "WaterFall",
                StringComparison.OrdinalIgnoreCase))
            {
                return ScottPlotTitleConfig.WaterFall;
            }

            if (name.Equals(
                "VChannel",
                StringComparison.OrdinalIgnoreCase))
            {
                return ScottPlotTitleConfig.VChannel;
            }

            return null;
        }

        // =========================================================
        // 自製 InputBox
        // .NET Framework 4.8 不需要 Microsoft.VisualBasic
        // =========================================================

        private static string ShowInputDialog(
            string title,
            string message,
            string defaultValue)
        {
            Form inputForm =
                new Form();

            inputForm.Text = title;

            inputForm.StartPosition =
                FormStartPosition.CenterScreen;

            inputForm.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;

            inputForm.Width = 420;
            inputForm.Height = 160;

            System.Windows.Forms.Label label =
                new System.Windows.Forms.Label();

            label.Text = message;

            label.Left = 15;
            label.Top = 15;
            label.Width = 370;

            TextBox textBox =
                new TextBox();

            textBox.Left = 15;
            textBox.Top = 40;
            textBox.Width = 370;

            textBox.Text =
                defaultValue ?? "";

            Button okButton =
                new Button();

            okButton.Text = "確定";
            okButton.Left = 215;
            okButton.Top = 75;
            okButton.Width = 80;

            okButton.DialogResult =
                DialogResult.OK;

            Button cancelButton =
                new Button();

            cancelButton.Text = "取消";
            cancelButton.Left = 305;
            cancelButton.Top = 75;
            cancelButton.Width = 80;

            cancelButton.DialogResult =
                DialogResult.Cancel;

            inputForm.Controls.Add(label);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(okButton);
            inputForm.Controls.Add(cancelButton);

            inputForm.AcceptButton =
                okButton;

            inputForm.CancelButton =
                cancelButton;

            string result = null;

            if (inputForm.ShowDialog() ==
                DialogResult.OK)
            {
                result =
                    textBox.Text;
            }

            inputForm.Dispose();

            return result;
        }

        // =========================================================
        // 背景顏色
        // =========================================================

        private static void SelectFigureBackgroundColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog =
                new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                plot.FigureBackground.Color =
                    ScottPlot.Color.FromColor(
                        dialog.Color);

                formsPlot.Refresh();
            }
        }

        private static void SelectDataBackgroundColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog =
                new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                plot.DataBackground.Color =
                    ScottPlot.Color.FromColor(
                        dialog.Color);

                formsPlot.Refresh();
            }
        }

        private static void SelectGridColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog =
                new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                plot.Grid.MajorLineColor =
                    ScottPlot.Color.FromColor(
                        dialog.Color);

                formsPlot.Refresh();
            }
        }

        private static void SelectAxisColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog =
                new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                ScottPlot.Color color =
                    ScottPlot.Color.FromColor(
                        dialog.Color);

                plot.Axes.Color(color);

                formsPlot.Refresh();
            }
        }

        // =========================================================
        // Dark
        // =========================================================

        public static void ApplyDarkTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null ||
                plot == null)
            {
                return;
            }

            plot.FigureBackground.Color =
                ScottPlot.Color.FromHtml(
                    "#202020");

            plot.DataBackground.Color =
                ScottPlot.Color.FromHtml(
                    "#101010");

            plot.Axes.Color(
                ScottPlot.Colors.White);

            plot.Grid.MajorLineColor =
                ScottPlot.Color.FromHtml(
                    "#404040");

            formsPlot.BackColor =
                System.Drawing.Color.FromArgb(
                    32,
                    32,
                    32);

            formsPlot.Refresh();
        }

        // =========================================================
        // Light
        // =========================================================

        public static void ApplyLightTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null ||
                plot == null)
            {
                return;
            }

            plot.FigureBackground.Color =
                ScottPlot.Colors.White;

            plot.DataBackground.Color =
                ScottPlot.Colors.White;

            plot.Axes.Color(
                ScottPlot.Colors.Black);

            plot.Grid.MajorLineColor =
                ScottPlot.Colors.LightGray;

            formsPlot.BackColor =
                System.Drawing.Color.White;

            formsPlot.Refresh();
        }

        // =========================================================
        // Industrial Dark
        // =========================================================

        public static void ApplyIndustrialDarkTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null ||
                plot == null)
            {
                return;
            }

            plot.FigureBackground.Color =
                ScottPlot.Color.FromHtml(
                    "#1E1E1E");

            plot.DataBackground.Color =
                ScottPlot.Color.FromHtml(
                    "#111820");

            plot.Axes.Color(
                ScottPlot.Color.FromHtml(
                    "#D8D8D8"));

            plot.Grid.MajorLineColor =
                ScottPlot.Color.FromHtml(
                    "#34404A");

            formsPlot.BackColor =
                System.Drawing.Color.FromArgb(
                    30,
                    30,
                    30);

            formsPlot.Refresh();
        }

        // =========================================================
        // Default
        // =========================================================

        public static void ApplyDefaultTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null ||
                plot == null)
            {
                return;
            }

            plot.FigureBackground.Color =
                ScottPlot.Colors.White;

            plot.DataBackground.Color =
                ScottPlot.Colors.White;

            plot.Axes.Color(
                ScottPlot.Colors.Black);

            plot.Grid.MajorLineColor =
                ScottPlot.Colors.LightGray;

            formsPlot.BackColor =
                System.Drawing.SystemColors.Control;

            formsPlot.Refresh();
        }
    }

    public static class ScottPlotThemeMenuHelper_x
    {
        


        /// <summary>
        /// 將自訂主題選項加入 ScottPlot 原本的右鍵選單。
        /// 不會清除 AutoScale、Save Image 等預設項目。
        /// </summary>
        public static void AddThemeMenu(FormsPlot formsPlot)
        {
            if (formsPlot == null)
                throw new ArgumentNullException("formsPlot");

            formsPlot.Menu.AddSeparator();

            formsPlot.Menu.Add(
                "外部背景顏色",
                delegate (Plot plot)
                {
                    SelectFigureBackgroundColor(formsPlot, plot);
                });

            formsPlot.Menu.Add(
                "資料區背景顏色",
                delegate (Plot plot)
                {
                    SelectDataBackgroundColor(formsPlot, plot);
                });

            formsPlot.Menu.Add(
                "格線顏色",
                delegate (Plot plot)
                {
                    SelectGridColor(formsPlot, plot);
                });

            formsPlot.Menu.Add(
                "座標軸與文字顏色",
                delegate (Plot plot)
                {
                    SelectAxisColor(formsPlot, plot);
                });

            formsPlot.Menu.AddSeparator();

            formsPlot.Menu.Add(
                "暗色主題",
                delegate (Plot plot)
                {
                    ApplyDarkTheme(formsPlot, plot);
                });

            formsPlot.Menu.Add(
                "亮色主題",
                delegate (Plot plot)
                {
                    ApplyLightTheme(formsPlot, plot);
                });

            formsPlot.Menu.Add(
                "工業深色主題",
                delegate (Plot plot)
                {
                    ApplyIndustrialDarkTheme(formsPlot, plot);
                });

            formsPlot.Menu.Add(
                "恢復預設主題",
                delegate (Plot plot)
                {
                    ApplyDefaultTheme(formsPlot, plot);
                });
        }

        private static void SelectFigureBackgroundColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                plot.FigureBackground.Color =
                    ScottPlot.Color.FromColor(dialog.Color);

                formsPlot.Refresh();
            }
        }

        private static void SelectDataBackgroundColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                plot.DataBackground.Color =
                    ScottPlot.Color.FromColor(dialog.Color);

                formsPlot.Refresh();
            }
        }

        private static void SelectGridColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                plot.Grid.MajorLineColor =
                    ScottPlot.Color.FromColor(dialog.Color);

                formsPlot.Refresh();
            }
        }

        private static void SelectAxisColor(
            FormsPlot formsPlot,
            Plot plot)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.FullOpen = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                ScottPlot.Color color =
                    ScottPlot.Color.FromColor(dialog.Color);

                plot.Axes.Color(color);

                formsPlot.Refresh();
            }
        }

        public static void ApplyDarkTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null || plot == null)
                return;

            plot.FigureBackground.Color =
                ScottPlot.Color.FromHtml("#202020");

            plot.DataBackground.Color =
                ScottPlot.Color.FromHtml("#101010");

            plot.Axes.Color(
                ScottPlot.Colors.White);

            plot.Grid.MajorLineColor =
                ScottPlot.Color.FromHtml("#404040");

            formsPlot.BackColor =
                System.Drawing.Color.FromArgb(
                    32,
                    32,
                    32);

            formsPlot.Refresh();
        }

        public static void ApplyLightTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null || plot == null)
                return;

            plot.FigureBackground.Color =
                ScottPlot.Colors.White;

            plot.DataBackground.Color =
                ScottPlot.Colors.White;

            plot.Axes.Color(
                ScottPlot.Colors.Black);

            plot.Grid.MajorLineColor =
                ScottPlot.Colors.LightGray;

            formsPlot.BackColor =
                System.Drawing.Color.White;

            formsPlot.Refresh();
        }

        public static void ApplyIndustrialDarkTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null || plot == null)
                return;

            plot.FigureBackground.Color =
                ScottPlot.Color.FromHtml("#1E1E1E");

            plot.DataBackground.Color =
                ScottPlot.Color.FromHtml("#111820");

            plot.Axes.Color(
                ScottPlot.Color.FromHtml("#D8D8D8"));

            plot.Grid.MajorLineColor =
                ScottPlot.Color.FromHtml("#34404A");

            formsPlot.BackColor =
                System.Drawing.Color.FromArgb(
                    30,
                    30,
                    30);

            formsPlot.Refresh();
        }

        public static void ApplyDefaultTheme(
            FormsPlot formsPlot,
            Plot plot)
        {
            if (formsPlot == null || plot == null)
                return;

            plot.FigureBackground.Color =
                ScottPlot.Colors.White;

            plot.DataBackground.Color =
                ScottPlot.Colors.White;

            plot.Axes.Color(
                ScottPlot.Colors.Black);

            plot.Grid.MajorLineColor =
                ScottPlot.Colors.LightGray;

            formsPlot.BackColor =
                System.Drawing.SystemColors.Control;

            formsPlot.Refresh();
        }
    }
}