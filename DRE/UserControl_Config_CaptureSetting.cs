using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRE
{
    public partial class UserControl_Config_CaptureSetting : UserControl
    {
        private MainProcess mp = null;

        public void Set()
        {
            int datanumber = 1024;
            if (!int.TryParse(tbxDataNumber.Text, out datanumber))
            {
                MessageBox.Show("Data Number 無法轉換成整數");
                return;
            }
            else
            {
                if (datanumber <= 0)
                {
                    MessageBox.Show("Data Number 小於等於0; 無法設定");
                    return;
                }
            }

            CaptureSettingType data = new CaptureSettingType(
                    tbxCaptureProgramName.Text,
                    cbxSamplingRate.SelectedIndex,
                    datanumber,
                    chbEnableRPMTrigger.Checked,
                    chbEnableKeyPhysor.Checked
                );
            mp.MyParameter.CaptureSetting.Copy(data);
        }

        public UserControl_Config_CaptureSetting(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();
        }

        private void UserControl_Config_CaptureSetting_Load(object sender, EventArgs e)
        {
            DisplayRefresh();
        }

        public void DisplayRefresh()
        {
            tbxCaptureProgramName.Text = mp.MyParameter.CaptureSetting.ProgramName;
            cbxSamplingRate.Items.AddRange(mp.MyParameter.CaptureSetting.SameplingRateList);
            cbxSamplingRate.SelectedIndex = mp.MyParameter.CaptureSetting.SamplingRateIndex;
            tbxDataNumber.Text = mp.MyParameter.CaptureSetting.DataNumber.ToString();
            chbEnableRPMTrigger.Checked = mp.MyParameter.CaptureSetting.EnableRPMTrigger;
            chbEnableKeyPhysor.Checked = mp.MyParameter.CaptureSetting.EnableKeyPhysor;
        }
    }
}
