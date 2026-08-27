using System;
using System.Drawing;
using System.Windows.Forms;

namespace DRE
{
    public class LoadForm : Form
    {
        private Label lblMessage;
        private ProgressBar progressBar;

        public LoadForm()
        {
            InitializeComponent();
        }

        public LoadForm(string message)
        {
            InitializeComponent();
            SetMessage(message);
        }

        private void InitializeComponent()
        {
            this.Text = "執行中";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.ShowInTaskbar = false;

            this.Width = 320;
            this.Height = 130;

            lblMessage = new Label();

            lblMessage.Text = "設備連線執行中......";
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Font = new Font(
                "Microsoft JhengHei",
                12.0f,
                FontStyle.Bold);

            //progressBar = new ProgressBar();

            //progressBar.Style =
            //    ProgressBarStyle.Marquee;

            //progressBar.MarqueeAnimationSpeed =
            //    30;

            //progressBar.Dock =
            //    DockStyle.Bottom;

            //progressBar.Height =
            //    20;

            this.Controls.Add(lblMessage);
            //this.Controls.Add(progressBar);
        }

        public void SetMessage(string message)
        {
            if (lblMessage != null)
            {
                lblMessage.Text = message;
            }
        }
    }
}
