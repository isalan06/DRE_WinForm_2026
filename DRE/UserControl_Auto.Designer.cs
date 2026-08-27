namespace DRE
{
    partial class UserControl_Auto
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAutoRun = new System.Windows.Forms.Button();
            this.btnAutoStop = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblDataFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCheckData = new System.Windows.Forms.Button();
            this.tmeProcedure = new System.Windows.Forms.Timer(this.components);
            this.tmeStatus = new System.Windows.Forms.Timer(this.components);
            this.chbUseSimData = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auto Capture Different RPM Data";
            // 
            // btnAutoRun
            // 
            this.btnAutoRun.BackColor = System.Drawing.Color.Honeydew;
            this.btnAutoRun.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAutoRun.Location = new System.Drawing.Point(53, 58);
            this.btnAutoRun.Name = "btnAutoRun";
            this.btnAutoRun.Size = new System.Drawing.Size(150, 50);
            this.btnAutoRun.TabIndex = 1;
            this.btnAutoRun.Text = "Run";
            this.btnAutoRun.UseVisualStyleBackColor = false;
            this.btnAutoRun.Click += new System.EventHandler(this.btnAutoRun_Click);
            // 
            // btnAutoStop
            // 
            this.btnAutoStop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAutoStop.Location = new System.Drawing.Point(229, 58);
            this.btnAutoStop.Name = "btnAutoStop";
            this.btnAutoStop.Size = new System.Drawing.Size(150, 50);
            this.btnAutoStop.TabIndex = 2;
            this.btnAutoStop.Text = "Stop";
            this.btnAutoStop.UseVisualStyleBackColor = true;
            this.btnAutoStop.Click += new System.EventHandler(this.btnAutoStop_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSelectFolder.Location = new System.Drawing.Point(419, 58);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(150, 50);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "Data Folder :";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblDataFolder
            // 
            this.lblDataFolder.AutoSize = true;
            this.lblDataFolder.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFolder.Location = new System.Drawing.Point(548, 69);
            this.lblDataFolder.Name = "lblDataFolder";
            this.lblDataFolder.Size = new System.Drawing.Size(0, 29);
            this.lblDataFolder.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(53, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(508, 323);
            this.dataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Status";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Use";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "RPM";
            this.Column4.Name = "Column4";
            // 
            // btnCheckData
            // 
            this.btnCheckData.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCheckData.Location = new System.Drawing.Point(581, 156);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Size = new System.Drawing.Size(150, 50);
            this.btnCheckData.TabIndex = 6;
            this.btnCheckData.Text = "Check";
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // tmeProcedure
            // 
            this.tmeProcedure.Tick += new System.EventHandler(this.tmeProcedure_Tick);
            // 
            // tmeStatus
            // 
            this.tmeStatus.Enabled = true;
            this.tmeStatus.Tick += new System.EventHandler(this.tmeStatus_Tick);
            // 
            // chbUseSimData
            // 
            this.chbUseSimData.AutoSize = true;
            this.chbUseSimData.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chbUseSimData.Location = new System.Drawing.Point(444, 19);
            this.chbUseSimData.Name = "chbUseSimData";
            this.chbUseSimData.Size = new System.Drawing.Size(105, 21);
            this.chbUseSimData.TabIndex = 7;
            this.chbUseSimData.Text = "Use Sim Data";
            this.chbUseSimData.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblStatus.Location = new System.Drawing.Point(50, 498);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 17);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status: ";
            // 
            // UserControl_Auto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chbUseSimData);
            this.Controls.Add(this.btnCheckData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDataFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnAutoStop);
            this.Controls.Add(this.btnAutoRun);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControl_Auto";
            this.Size = new System.Drawing.Size(1582, 685);
            this.Load += new System.EventHandler(this.UserControl_Auto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAutoRun;
        private System.Windows.Forms.Button btnAutoStop;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label lblDataFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnCheckData;
        private System.Windows.Forms.Timer tmeProcedure;
        private System.Windows.Forms.Timer tmeStatus;
        private System.Windows.Forms.CheckBox chbUseSimData;
        private System.Windows.Forms.Label lblStatus;
    }
}
