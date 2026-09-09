namespace DRE
{
    partial class UserControl_WaterFall
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWaterFallTrigger = new System.Windows.Forms.Label();
            this.cbxMultiDataList = new System.Windows.Forms.ComboBox();
            this.btnLoadMultiData = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 6);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1872, 802);
            this.zedGraphControl1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(6, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1570, 587);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblWaterFallTrigger);
            this.panel2.Controls.Add(this.cbxMultiDataList);
            this.panel2.Controls.Add(this.btnLoadMultiData);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1570, 82);
            this.panel2.TabIndex = 8;
            // 
            // lblWaterFallTrigger
            // 
            this.lblWaterFallTrigger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWaterFallTrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWaterFallTrigger.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblWaterFallTrigger.Location = new System.Drawing.Point(459, 18);
            this.lblWaterFallTrigger.Name = "lblWaterFallTrigger";
            this.lblWaterFallTrigger.Size = new System.Drawing.Size(200, 50);
            this.lblWaterFallTrigger.TabIndex = 21;
            this.lblWaterFallTrigger.Text = "Calculate WaterFall";
            this.lblWaterFallTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaterFallTrigger.Click += new System.EventHandler(this.lblWaterFallTrigger_Click);
            // 
            // cbxMultiDataList
            // 
            this.cbxMultiDataList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMultiDataList.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMultiDataList.FormattingEnabled = true;
            this.cbxMultiDataList.Location = new System.Drawing.Point(230, 28);
            this.cbxMultiDataList.Name = "cbxMultiDataList";
            this.cbxMultiDataList.Size = new System.Drawing.Size(177, 33);
            this.cbxMultiDataList.TabIndex = 20;
            // 
            // btnLoadMultiData
            // 
            this.btnLoadMultiData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadMultiData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLoadMultiData.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadMultiData.Location = new System.Drawing.Point(12, 17);
            this.btnLoadMultiData.Name = "btnLoadMultiData";
            this.btnLoadMultiData.Size = new System.Drawing.Size(200, 50);
            this.btnLoadMultiData.TabIndex = 19;
            this.btnLoadMultiData.Text = "Load Multi-Data";
            this.btnLoadMultiData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadMultiData.Click += new System.EventHandler(this.btnLoadMultiData_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.DefaultExt = "*.dat";
            this.openFileDialog2.FileName = "openFileDialog1";
            this.openFileDialog2.Filter = "Data File|*.dat|All File|*.*";
            this.openFileDialog2.InitialDirectory = "C:\\";
            this.openFileDialog2.Multiselect = true;
            // 
            // UserControl_WaterFall
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zedGraphControl1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_WaterFall";
            this.Size = new System.Drawing.Size(1582, 685);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWaterFallTrigger;
        private System.Windows.Forms.ComboBox cbxMultiDataList;
        private System.Windows.Forms.Label btnLoadMultiData;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}
