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
    public partial class UserControl_Config : UserControl
    {
        private MainProcess mp = null;

        private UserControl_Config_ChannelSetting userControl_Config_ChannelSetting = null;
        private UserControl_Config_CaptureSetting userControl_Config_CaptureSetting = null;
        private UserControl_Config_ScopeSetting userControl_Config_ScopeSetting = null;

        public UserControl_Config(MainProcess inMp)
        {
            mp = inMp;
            

            InitializeComponent();

            userControl_Config_ChannelSetting = new UserControl_Config_ChannelSetting(mp);
            userControl_Config_CaptureSetting = new UserControl_Config_CaptureSetting(mp);
            userControl_Config_ScopeSetting = new UserControl_Config_ScopeSetting(mp);
            panChannelSetting.Controls.Add(userControl_Config_ChannelSetting);
            panCaptureSetting.Controls.Add(userControl_Config_CaptureSetting);
            panScopeSetting.Controls.Add(userControl_Config_ScopeSetting);
            userControl_Config_ChannelSetting.DisplayRefresh();

            cbxChannelList.Items.Clear();
            for (int i = 0; i < mp.MyParameter.ChannelSetting.Length; i++)
                cbxChannelList.Items.Add("Channel-" + (i + 1).ToString());
            if (cbxChannelList.Items.Count > 0) cbxChannelList.SelectedIndex = 0;
        }

        public void DisplayRefresh()
        {
            userControl_Config_ChannelSetting.DisplayRefresh();
            userControl_Config_CaptureSetting.DisplayRefresh();
            userControl_Config_ScopeSetting.DisplayRefresh();
        }

        private void cbxChannelList_TextChanged(object sender, EventArgs e)
        {
            mp.MyParameter.ChannelSettingIndex = cbxChannelList.SelectedIndex;
            userControl_Config_ChannelSetting.DisplayRefresh();
        }

        private void btnSet_ChannelSetting_Click(object sender, EventArgs e)
        {
            userControl_Config_ChannelSetting.Set();
        }

        private void btnSet_CaptureSetting_Click(object sender, EventArgs e)
        {
            userControl_Config_CaptureSetting.Set();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mp.MyParameter.Save();
        }

        private void btnSet_ScopeSetting_Click(object sender, EventArgs e)
        {
            userControl_Config_ScopeSetting.Set();
        }
    }
}
