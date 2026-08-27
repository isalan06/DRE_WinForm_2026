using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DRE
{
    public partial class UserControl_Auto : UserControl
    {
        private MainProcess mp = null;
        private bool bFirst = false;
        private int index = 0;
        private List<int> IndexList = new List<int>();
        private List<double> RPMList = new List<double>();

        private double setRPM = 0.0;

        public UserControl_Auto(MainProcess inMp)
        {
            mp = inMp;

            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lblDataFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void UserControl_Auto_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                dataGridView1.Rows[i].Cells[1].Value = "Wait....";
                dataGridView1.Rows[i].Cells[2].Value = false;
                dataGridView1.Rows[i].Cells[3].Value = (100 + i * 100).ToString();
            }
        }

        

        private bool RefreshTableInitial()
        {
            bool result = true;
            bool exist = false;
            IndexList.Clear();
            RPMList.Clear();

            double value = 0.0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[2].Value)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Wait....";
                    exist = true;

                    if (double.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out value))
                    {
                        IndexList.Add(i);
                        RPMList.Add(value);
                    }
                }
                else
                    dataGridView1.Rows[i].Cells[1].Value = "NA";

                
                if (!double.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out value))
                    result = false;
            }

            result = exist && result;

            return result;
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            RefreshTableInitial();
        }

        private void btnAutoRun_Click(object sender, EventArgs e)
        {
            if (lblDataFolder.Text == "")
                MessageBox.Show("Never select one folder");
            else if (tmeProcedure.Enabled)
                MessageBox.Show("Auto procedure is executing....");
            else
            {
                if (!RefreshTableInitial())
                    MessageBox.Show("There is no selected RPM or RPM value is not double format");
                else
                {
                    index = 0;
                    bFirst = false;
                    tmeProcedure.Enabled = true;
                }
            }
        }

        private void tmeStatus_Tick(object sender, EventArgs e)
        {
            btnAutoRun.BackColor = tmeProcedure.Enabled ? Color.Lime : Color.Honeydew;
            chbUseSimData.Enabled = !tmeProcedure.Enabled;

            string status = "Status: ";
            status += "Running => " + (tmeProcedure.Enabled ? "True" : "False") + "; ";
            status += "Index => " + index.ToString() + "; ";
            status += "RPM => " + mp.RPM.ToString("F2") + "; ";
            status += "Current Index => " + ((index < IndexList.Count) ? IndexList[index].ToString() : "0") + "; ";
            status += "Current RPM =>" + ((index < IndexList.Count) ? RPMList[index].ToString("F2") : "0.00") + "; ";

            lblStatus.Text = status;
        }

        private void btnAutoStop_Click(object sender, EventArgs e)
        {
            tmeProcedure.Enabled = false;
        }

        private void TriggerCapture()
        {
            mp.SetRPM = setRPM;

            setRPM = RPMList[index];
            mp.SetSimRPM = setRPM;

            if (chbUseSimData.Checked)
                mp.CaptureOneTime_Sim_Start(true, RPMList[index]);
            else
                mp.CaptureOneTime_Start();

            mp.IsSetSimRPM = chbUseSimData.Checked;

            
            
        }

        private void tmeProcedure_Tick(object sender, EventArgs e)
        {
            if (!bFirst)
            {
                bFirst = true;
                TriggerCapture();
            }
            else if (!mp.IsExecutingProcedure)
            {
                int _index = IndexList[index];
                double _rpm = RPMList[index];

                double RPM = mp.RPM;
                if (chbUseSimData.Checked)
                    RPM = setRPM;

                if (index >= IndexList.Count) tmeProcedure.Enabled = false;
                else
                {
                    if ((RPM >= _rpm) && (mp.RPM <= RPM + 50.0))
                    {
                        dataGridView1.Rows[IndexList[index]].Cells[1].Value = "Done";
                        string filename = Path.Combine(lblDataFolder.Text, DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".dat");
                        mp.SaveDataWithInfo(filename);
                        if (++index >= IndexList.Count) tmeProcedure.Enabled = false;
                        else TriggerCapture();
                    }
                    else
                        TriggerCapture();

                }
            }
        }
    }
}
