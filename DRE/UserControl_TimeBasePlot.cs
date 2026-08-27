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
    public partial class UserControl_TimeBasePlot : UserControl
    {
        private MainProcess mp = null;

        private UserControl_TimeBasePlot_Single userControl_TimeBasePlot_Single = null;
        private UserControl_TimeBasePlot_Two userControl_TimeBasePlot_Two = null;

        private int CheckPageIndex = -1;

        public UserControl_TimeBasePlot(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            userControl_TimeBasePlot_Single = new UserControl_TimeBasePlot_Single(mp);
            userControl_TimeBasePlot_Two = new UserControl_TimeBasePlot_Two(mp);

            CheckDisplayPageIndex();
        }

        private void SetPage(int index)
        {
            panDisplay.Controls.Clear();

            switch (index)
            {
                default:
                case 1:
                    panDisplay.Controls.Add(userControl_TimeBasePlot_Single);
                    break;

                case 2:
                    panDisplay.Controls.Add(userControl_TimeBasePlot_Two);
                    break;
            }
        }

        private void CheckDisplayPageIndex()
        {
            if (mp.MyParameter.ScopeSetting.Layout != CheckPageIndex)
            {
                CheckPageIndex = mp.MyParameter.ScopeSetting.Layout;
                SetPage(CheckPageIndex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckDisplayPageIndex();
        }
    }
}
