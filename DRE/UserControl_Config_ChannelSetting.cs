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
    public partial class UserControl_Config_ChannelSetting : UserControl
    {
        private MainProcess mp = null;

        public UserControl_Config_ChannelSetting(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            DisplayRefresh();
        }

        public void DisplayRefresh()
        {
            ChannelSettingType data = mp.MyParameter.SelectedChannelSetting;
            cbxIEPE.SelectedIndex = data.IEPE;
            cbxInputType.SelectedIndex = data.InputType;
            cbxCouplingType.SelectedIndex = data.CouplingType;
            cbxDisplaySpecification.SelectedIndex = data.DisplaySpecification;
            cbxDisplayType.SelectedIndex = data.DisplayType;
        }

        public void Set()
        {
            ChannelSettingType data = new ChannelSettingType(
                    cbxIEPE.SelectedIndex,
                    cbxInputType.SelectedIndex,
                    cbxCouplingType.SelectedIndex,
                    cbxDisplaySpecification.SelectedIndex,
                    cbxDisplayType.SelectedIndex
                );
            mp.MyParameter.SelectedChannelSetting = data;
        }
        
    }
}
