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
    public partial class UserControl_Config_ScopeSetting : UserControl
    {
        private MainProcess mp = null;

        public UserControl_Config_ScopeSetting(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            DisplayRefresh();
        }

        public void DisplayRefresh()
        {
            cbxRange.Items.AddRange(mp.MyParameter.ScopeSetting.RangeList);
            cbxRange.SelectedIndex = mp.MyParameter.ScopeSetting.RangeIndex;
            tbxDisplayTime.Text = mp.MyParameter.ScopeSetting.TimeRange.ToString(); ;
            cbxLayoutNumber.SelectedIndex = mp.MyParameter.ScopeSetting.Layout - 1;
        }

        public void Set()
        {
            int timerange = 500;
            if (!int.TryParse(tbxDisplayTime.Text, out timerange))
            {
                MessageBox.Show("Display Time 無法轉換成整數");
                return;
            }
            else
            {
                if (timerange <= 0)
                {
                    MessageBox.Show("Display Time 小於等於0; 無法設定");
                    return;
                }
            }

            ScopeSettingType data = new ScopeSettingType(
                cbxRange.SelectedIndex,
                timerange,
                cbxLayoutNumber.SelectedIndex + 1
                );
            mp.MyParameter.ScopeSetting.Copy(data);
        }
    }
}
