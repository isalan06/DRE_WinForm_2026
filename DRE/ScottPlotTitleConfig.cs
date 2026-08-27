using System;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace DRE
{
    public static class ScottPlotTitleConfig
    {
        private const string ConfigFileName =
            "ScottPlotTitleConfig.xml";

        public static string ConfigFilePath
        {
            get
            {
                return Path.Combine(
                    Application.StartupPath,
                    ConfigFileName);
            }
        }

        public static ChartTitleSetting TimeBase { get; private set; }

        public static ChartTitleSetting Spectrum { get; private set; }

        public static ChartTitleSetting Orbit { get; private set; }

        public static ChartTitleSetting WaterFall { get; private set; }

        public static ChartTitleSetting VChannel { get; private set; }

        static ScottPlotTitleConfig()
        {
            Load();
        }

        private static void CreateDefault()
        {
            // 1. TimeBase
            TimeBase = new ChartTitleSetting();

            TimeBase.Name =
                "TimeBase";

            TimeBase.Title =
                "Data";

            TimeBase.XAxisTitle =
                "Time(ms)";

            TimeBase.YAxisTitle =
                "Voltage(V)";


            // 2. Spectrum
            Spectrum = new ChartTitleSetting();

            Spectrum.Name =
                "Spectrum";

            Spectrum.Title =
                "Magnitude";

            Spectrum.XAxisTitle =
                "Frequency(Hz)";

            Spectrum.YAxisTitle =
                "Mag";


            // 3. Orbit
            Orbit = new ChartTitleSetting();

            Orbit.Name =
                "Orbit";

            Orbit.Title =
                "Orbit";

            Orbit.XAxisTitle =
                "Channel 1";

            Orbit.YAxisTitle =
                "Channel 2";


            // 4. WaterFall
            WaterFall = new ChartTitleSetting();

            WaterFall.Name =
                "WaterFall";

            WaterFall.Title =
                "Water Fall";

            WaterFall.XAxisTitle =
                "Frequency(Hz)";

            WaterFall.YAxisTitle =
                "Magnitude";


            // 5. VChannel
            VChannel = new ChartTitleSetting();

            VChannel.Name =
                "VChannel";

            VChannel.Title =
                "Voltage - Channel";

            VChannel.XAxisTitle =
                "Axis No";

            VChannel.YAxisTitle =
                "Voltage(V)";
        }

        public static void Load()
        {
            try
            {
                if (!File.Exists(ConfigFilePath))
                {
                    CreateDefault();
                    Save();
                    return;
                }

                XmlSerializer serializer =
                    new XmlSerializer(
                        typeof(ScottPlotTitleConfigData));

                using (FileStream stream =
                    new FileStream(
                        ConfigFilePath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read))
                {
                    ScottPlotTitleConfigData config =
                        serializer.Deserialize(stream)
                        as ScottPlotTitleConfigData;

                    if (config == null)
                    {
                        CreateDefault();
                        Save();
                        return;
                    }

                    ApplyConfig(config);
                }
            }
            catch (Exception ex)
            {
                CreateDefault();

                MessageBox.Show(
                    "讀取 ScottPlot 標題設定失敗。\r\n\r\n" +
                    ex.Message +
                    "\r\n\r\n目前使用預設設定。",
                    "ScottPlot 設定",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        public static bool Save()
        {
            try
            {
                ScottPlotTitleConfigData config =
                    new ScottPlotTitleConfigData();

                config.TimeBase =
                    TimeBase;

                config.Spectrum =
                    Spectrum;

                config.Orbit =
                    Orbit;

                config.WaterFall =
                    WaterFall;

                config.VChannel =
                    VChannel;

                XmlSerializer serializer =
                    new XmlSerializer(
                        typeof(ScottPlotTitleConfigData));

                using (FileStream stream =
                    new FileStream(
                        ConfigFilePath,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None))
                {
                    serializer.Serialize(
                        stream,
                        config);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "儲存 ScottPlot 標題設定失敗。\r\n\r\n" +
                    ex.Message,
                    "ScottPlot 設定",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private static void ApplyConfig(
            ScottPlotTitleConfigData config)
        {
            // 先建立預設值，避免舊 XML 缺欄位
            CreateDefault();

            if (config.TimeBase != null)
                TimeBase = config.TimeBase;

            if (config.Spectrum != null)
                Spectrum = config.Spectrum;

            if (config.Orbit != null)
                Orbit = config.Orbit;

            if (config.WaterFall != null)
                WaterFall = config.WaterFall;

            if (config.VChannel != null)
                VChannel = config.VChannel;
        }

        public static void ResetDefault()
        {
            CreateDefault();
            Save();
        }

        public static void Apply(
            ScottPlot.Plot plot,
            ChartTitleSetting setting)
        {
            if (plot == null ||
                setting == null)
            {
                return;
            }

            plot.Title(
                setting.Title);

            plot.XLabel(
                setting.XAxisTitle);

            plot.YLabel(
                setting.YAxisTitle);
        }
    }


    [Serializable]
    public class ChartTitleSetting
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string XAxisTitle { get; set; }

        public string YAxisTitle { get; set; }

        public ChartTitleSetting()
        {
            Name = "";
            Title = "";
            XAxisTitle = "";
            YAxisTitle = "";
        }
    }


    [Serializable]
    [XmlRoot("ScottPlotTitleConfig")]
    public class ScottPlotTitleConfigData
    {
        public ChartTitleSetting TimeBase { get; set; }

        public ChartTitleSetting Spectrum { get; set; }

        public ChartTitleSetting Orbit { get; set; }

        public ChartTitleSetting WaterFall { get; set; }

        public ChartTitleSetting VChannel { get; set; }

        public ScottPlotTitleConfigData()
        {
        }
    }
}