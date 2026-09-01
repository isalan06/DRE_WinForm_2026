using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DRE
{
    public partial class MainForm : Form
    {
        private MainProcess mp = null;
        private UserControl_Config userControl_Config = null;
        private UserControl_TimeBasePlot userControl_TimeBasePlot = null;
        private UserControl_Specturm userControl_Specturm = null;
        private UserControl_Orbit userControl_Orbit = null;
        private UserControl_WaterFall userControl_WaterFall = null;
        private UserControl_Auto userControl_Auto = null;
        private UserControl_VChannel userControl_VChannel = null;

        private void CreateComponent()
        {
            userControl_Config = new UserControl_Config(mp);
            userControl_TimeBasePlot = new UserControl_TimeBasePlot(mp);
            userControl_Specturm = new UserControl_Specturm(mp);
            userControl_Orbit = new UserControl_Orbit(mp);
            userControl_WaterFall = new UserControl_WaterFall(mp);
            userControl_Auto = new UserControl_Auto(mp);
            userControl_VChannel = new UserControl_VChannel(mp);
        }

        // Function - SetUserControl
        // parameter - index (int)
        //  0: UserControl_Config
        private void SetUserControl(int index)
        {
            panDisplay.Controls.Clear();
            lblPageConfig.BackColor = Color.WhiteSmoke;
            lblPageTimeBasePlot.BackColor = Color.WhiteSmoke;
            lblPageSpecturm.BackColor = Color.WhiteSmoke;
            lblPageOrbit.BackColor = Color.WhiteSmoke;
            lblPageWaterfall.BackColor = Color.WhiteSmoke;
            lblPageAutoProcedure.BackColor = Color.WhiteSmoke;
            lblPageVChannel.BackColor = Color.WhiteSmoke;

            switch (index)
            {
                case 0:
                default:
                    panDisplay.Controls.Add(userControl_Config);
                    lblPageConfig.BackColor = Color.PaleTurquoise;
                    break;

                case 1:
                    panDisplay.Controls.Add(userControl_TimeBasePlot);
                    lblPageTimeBasePlot.BackColor = Color.PaleTurquoise;
                    break;

                case 2:
                    panDisplay.Controls.Add(userControl_Specturm);
                    lblPageSpecturm.BackColor = Color.PaleTurquoise;
                    break;

                case 3:
                    panDisplay.Controls.Add(userControl_Orbit);
                    lblPageOrbit.BackColor = Color.PaleTurquoise;
                    break;

                case 4:
                    panDisplay.Controls.Add(userControl_WaterFall);
                    lblPageWaterfall.BackColor = Color.PaleTurquoise;
                    break;

                case 5:
                    panDisplay.Controls.Add(userControl_Auto);
                    lblPageAutoProcedure.BackColor = Color.PaleTurquoise;
                    break;

                case 6:
                    panDisplay.Controls.Add(userControl_VChannel);
                    lblPageVChannel.BackColor = Color.PaleTurquoise;
                    break;

            }
        }

        public MainForm(MainProcess inMp)
        {
            mp = inMp;

            CreateComponent();

            InitializeComponent();

            SetUserControl(0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tmeDisplay.Enabled = false;
        }

        private void tmeDisplay_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "Status: " + mp.ErrorString;

            bool canUse = mp.IsRegisterForU2405 || mp.IsRegisterForVK701;
            bool ispooling = mp.IsExecutingProcedure && mp.IsPoolingStatus;
            bool ispoolingsim = mp.IsExecutingProcedure && mp.IsPoolingSimStatus;
            bool iscaptureonetime = mp.IsExecutingProcedure && mp.IsCaptureOneTimeStatus;
            bool iscaptureonetimesim = mp.IsExecutingProcedure && mp.IsCaptureOneTimeSimStatus;

            lblPollingAct.BackColor = canUse ? (ispooling ? Color.PaleGreen : Color.WhiteSmoke) : Color.Red;
            lblPollingSimAct.BackColor = ispoolingsim ? Color.PaleGreen : Color.WhiteSmoke;
            lblCaptureOneTimeAct.BackColor = canUse ? (iscaptureonetime ? Color.PaleGreen : Color.WhiteSmoke) : Color.Red;
            lblCaptureOneTimeSimAct.BackColor = iscaptureonetimesim ? Color.PaleGreen : Color.WhiteSmoke;
        }

        private void lblPageConfig_Click(object sender, EventArgs e)
        {
            SetUserControl(0);
        }

        private void lblPageTimeBasePlot_Click(object sender, EventArgs e)
        {
            SetUserControl(1);
        }

        private void lblPollingAct_Click(object sender, EventArgs e)
        {
            // 開啟U2405定時擷取資料流程
            mp.Polling_Start();
        }

        private void lblCaptureOneTimeAct_Click(object sender, EventArgs e)
        {
            // 開始執行U2405擷取一次資料流程
            mp.CaptureOneTime_Start();
        }

        private void lblProcedureStop_Click(object sender, EventArgs e)
        {
            // 停止執行U2405定時/一次擷取資料流程 (含虛擬資料流程)
            mp.Polling_Stop();
            mp.CaptureOneTime_Stop();
        }

        private void lblPollingSimAct_Click(object sender, EventArgs e)
        {
            // 開啟執行虛擬資料定期擷取(不使用U2405)
            mp.Polling_Sim_Start();
        }

        private void lblCaptureOneTimeSimAct_Click(object sender, EventArgs e)
        {
            // 虛擬RPM數據設定
            bool isUseSetRPM = chbUseSetRPM.Checked;
            double setRPM = 100.0;
            if (!double.TryParse(tbxSimSetRPM.Text, out setRPM))
                isUseSetRPM = false;

            // 開始執行虛擬一次資料流程
            mp.CaptureOneTime_Sim_Start(isUseSetRPM, setRPM);
        }

        private void lblPageSpecturm_Click(object sender, EventArgs e)
        {
            SetUserControl(2);
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string ext = Path.GetExtension(saveFileDialog1.FileName);

                mp.SaveDataWithInfo(saveFileDialog1.FileName);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);

                mp.LoadDataWithInfo(openFileDialog1.FileName);

                userControl_Config.DisplayRefresh();
            }
        }

        private void chbRefreshStop_CheckedChanged(object sender, EventArgs e)
        {
            mp.bGraphRefreshStop = chbRefreshStop.Checked;
        }

        private void btnLoadMultiData_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                cbxMultiDataList.Items.Clear();

                string[] filename = openFileDialog2.FileNames;
                mp.MultiFileNamePaths = filename;


                if (mp.MultiFileNamePaths != null)
                {
                    cbxMultiDataList.Items.AddRange(mp.MultiFileNames);
                    cbxMultiDataList.SelectedIndex = 0;
                }
            }
        }

        private void lblMultiDataGet_Click(object sender, EventArgs e)
        {
            if (mp.MultiFileNamePaths != null)
            {
                mp.LoadDataWithInfo(mp.MultiFileNamePaths[cbxMultiDataList.SelectedIndex]);

                userControl_Config.DisplayRefresh();
            }
        }

        private void lblPageOrbit_Click(object sender, EventArgs e)
        {
            SetUserControl(3);
        }

        private void lblPageWaterfall_Click(object sender, EventArgs e)
        {
            SetUserControl(4);
        }

        private void lblWaterFallTrigger_Click(object sender, EventArgs e)
        {
            if (cbxMultiDataList.Items.Count > 1)
            {
                userControl_WaterFall.CreateWaterFall();
            }
            else
                MessageBox.Show("至少匯入兩筆資料");
        }

        private void lblPageAutoProcedure_Click(object sender, EventArgs e)
        {
            SetUserControl(5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = Directory.GetFiles("C:\\\\Test", "ABC*9527*");

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog3.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string lineData = "";
                        int calCount = 0;
                        while ((lineData = sr.ReadLine()) != null)
                        {
                            string[] dataList = lineData.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                            if (dataList == null) break;

                            if (dataList.Length < 2) break;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new _3DChartForm().ShowDialog();
               
        }

        private void lblWaterFall3D_Click(object sender, EventArgs e)
        {
            new _3DChartForm(mp).ShowDialog();
        }

        private void lblPageVChannel_Click(object sender, EventArgs e)
        {
            SetUserControl(6);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //string title = "偵測設備";
            //string message = "1. U2405: " + (mp.IsRegisterForU2405 ? "有偵測到" : "沒有偵測到") + "\r\n";
            //message += "2. VK701: " + (mp.IsRegisterForVK701 ? "有偵測到" : "沒有偵測到") + "\r\n";
            //MessageBox.Show(message, title);
        }

        private void lblConnect_Click(object sender, EventArgs e)
        {
            //mp.InitialU2405();
            //mp.InitialVK701();

            //string title = "偵測設備";
            //string message = "1. U2405: " + (mp.IsRegisterForU2405 ? "有偵測到" : "沒有偵測到") + "\r\n";
            //message += "2. VK701: " + (mp.IsRegisterForVK701 ? "有偵測到" : "沒有偵測到") + "\r\n";
            //MessageBox.Show(message, title);

            LoadForm loadForm =
                new LoadForm("設備連線執行中......");

            try
            {
                loadForm.Show(this);

                Application.DoEvents();

                mp.InitialU2405();

                loadForm.SetMessage(
                    "VK701 設備連線執行中......");

                Application.DoEvents();

                mp.InitialVK701();
            }
            finally
            {
                loadForm.Close();
                loadForm.Dispose();
            }

            string title = "偵測設備";

            string message =
                "1. U2405: " +
                (mp.IsRegisterForU2405
                    ? "有偵測到"
                    : "沒有偵測到") +
                "\r\n";

            message +=
                "2. VK701: " +
                (mp.IsRegisterForVK701
                    ? "有偵測到"
                    : "沒有偵測到") +
                "\r\n";

            MessageBox.Show(
                message,
                title);
        }
    }
}
