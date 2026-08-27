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
    public partial class UserControl_Specturm : UserControl
    {
        private MainProcess mp = null;

        private UserControl_Specturm_Single userControl_Specturm_Single = null;
        private UserControl_Specturm_Two userControl_Specturm_Two = null;

        private int CheckPageIndex = -1;

        public UserControl_Specturm(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();

            userControl_Specturm_Single = new UserControl_Specturm_Single(mp);
            userControl_Specturm_Two = new UserControl_Specturm_Two(mp);

            CheckDisplayPageIndex();
        }

        private void SetPage(int index)
        {
            panDisplay.Controls.Clear();

            switch (index)
            {
                default:
                case 1:
                    panDisplay.Controls.Add(userControl_Specturm_Single);
                    break;

                case 2:
                    panDisplay.Controls.Add(userControl_Specturm_Two);
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
