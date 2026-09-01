namespace DRE
{
    partial class MainForm
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPageVChannel = new System.Windows.Forms.Label();
            this.lblPageAutoProcedure = new System.Windows.Forms.Label();
            this.panDisplay = new System.Windows.Forms.Panel();
            this.lblPageWaterfall = new System.Windows.Forms.Label();
            this.lblPageOrbit = new System.Windows.Forms.Label();
            this.lblPageSpecturm = new System.Windows.Forms.Label();
            this.lblPageTimeBasePlot = new System.Windows.Forms.Label();
            this.lblPageConfig = new System.Windows.Forms.Label();
            this.panOp = new System.Windows.Forms.Panel();
            this.lblConnect = new System.Windows.Forms.Label();
            this.lblWaterFall3D = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxSimSetRPM = new System.Windows.Forms.TextBox();
            this.chbUseSetRPM = new System.Windows.Forms.CheckBox();
            this.lblWaterFallTrigger = new System.Windows.Forms.Label();
            this.lblMultiDataGet = new System.Windows.Forms.Label();
            this.cbxMultiDataList = new System.Windows.Forms.ComboBox();
            this.btnLoadMultiData = new System.Windows.Forms.Label();
            this.chbRefreshStop = new System.Windows.Forms.CheckBox();
            this.btnLoadData = new System.Windows.Forms.Label();
            this.btnSaveData = new System.Windows.Forms.Label();
            this.lblCaptureOneTimeSimAct = new System.Windows.Forms.Label();
            this.lblPollingSimAct = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProcedureStop = new System.Windows.Forms.Label();
            this.lblCaptureOneTimeAct = new System.Windows.Forms.Label();
            this.lblPollingAct = new System.Windows.Forms.Label();
            this.tmeDisplay = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.panMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panMain.Controls.Add(this.panel1);
            this.panMain.Controls.Add(this.panOp);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(1598, 921);
            this.panMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblPageVChannel);
            this.panel1.Controls.Add(this.lblPageAutoProcedure);
            this.panel1.Controls.Add(this.panDisplay);
            this.panel1.Controls.Add(this.lblPageWaterfall);
            this.panel1.Controls.Add(this.lblPageOrbit);
            this.panel1.Controls.Add(this.lblPageSpecturm);
            this.panel1.Controls.Add(this.lblPageTimeBasePlot);
            this.panel1.Controls.Add(this.lblPageConfig);
            this.panel1.Location = new System.Drawing.Point(3, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 750);
            this.panel1.TabIndex = 1;
            // 
            // lblPageVChannel
            // 
            this.lblPageVChannel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageVChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageVChannel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPageVChannel.Location = new System.Drawing.Point(1238, -1);
            this.lblPageVChannel.Name = "lblPageVChannel";
            this.lblPageVChannel.Size = new System.Drawing.Size(207, 50);
            this.lblPageVChannel.TabIndex = 7;
            this.lblPageVChannel.Text = "V-Channel";
            this.lblPageVChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageVChannel.Click += new System.EventHandler(this.lblPageVChannel_Click);
            // 
            // lblPageAutoProcedure
            // 
            this.lblPageAutoProcedure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageAutoProcedure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageAutoProcedure.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPageAutoProcedure.Location = new System.Drawing.Point(1032, -1);
            this.lblPageAutoProcedure.Name = "lblPageAutoProcedure";
            this.lblPageAutoProcedure.Size = new System.Drawing.Size(207, 50);
            this.lblPageAutoProcedure.TabIndex = 6;
            this.lblPageAutoProcedure.Text = "Auto";
            this.lblPageAutoProcedure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageAutoProcedure.Click += new System.EventHandler(this.lblPageAutoProcedure_Click);
            // 
            // panDisplay
            // 
            this.panDisplay.AutoScroll = true;
            this.panDisplay.BackColor = System.Drawing.Color.Cornsilk;
            this.panDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panDisplay.Location = new System.Drawing.Point(1, 48);
            this.panDisplay.Name = "panDisplay";
            this.panDisplay.Size = new System.Drawing.Size(1592, 695);
            this.panDisplay.TabIndex = 2;
            // 
            // lblPageWaterfall
            // 
            this.lblPageWaterfall.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageWaterfall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageWaterfall.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPageWaterfall.Location = new System.Drawing.Point(826, -1);
            this.lblPageWaterfall.Name = "lblPageWaterfall";
            this.lblPageWaterfall.Size = new System.Drawing.Size(207, 50);
            this.lblPageWaterfall.TabIndex = 5;
            this.lblPageWaterfall.Text = "waterfall";
            this.lblPageWaterfall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageWaterfall.Click += new System.EventHandler(this.lblPageWaterfall_Click);
            // 
            // lblPageOrbit
            // 
            this.lblPageOrbit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageOrbit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageOrbit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPageOrbit.Location = new System.Drawing.Point(620, -1);
            this.lblPageOrbit.Name = "lblPageOrbit";
            this.lblPageOrbit.Size = new System.Drawing.Size(207, 50);
            this.lblPageOrbit.TabIndex = 5;
            this.lblPageOrbit.Text = "orbit";
            this.lblPageOrbit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageOrbit.Click += new System.EventHandler(this.lblPageOrbit_Click);
            // 
            // lblPageSpecturm
            // 
            this.lblPageSpecturm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageSpecturm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageSpecturm.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPageSpecturm.Location = new System.Drawing.Point(414, -1);
            this.lblPageSpecturm.Name = "lblPageSpecturm";
            this.lblPageSpecturm.Size = new System.Drawing.Size(207, 50);
            this.lblPageSpecturm.TabIndex = 4;
            this.lblPageSpecturm.Text = "spectum";
            this.lblPageSpecturm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageSpecturm.Click += new System.EventHandler(this.lblPageSpecturm_Click);
            // 
            // lblPageTimeBasePlot
            // 
            this.lblPageTimeBasePlot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageTimeBasePlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageTimeBasePlot.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPageTimeBasePlot.Location = new System.Drawing.Point(208, -1);
            this.lblPageTimeBasePlot.Name = "lblPageTimeBasePlot";
            this.lblPageTimeBasePlot.Size = new System.Drawing.Size(207, 50);
            this.lblPageTimeBasePlot.TabIndex = 3;
            this.lblPageTimeBasePlot.Text = "timebaseplot";
            this.lblPageTimeBasePlot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageTimeBasePlot.Click += new System.EventHandler(this.lblPageTimeBasePlot_Click);
            // 
            // lblPageConfig
            // 
            this.lblPageConfig.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblPageConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageConfig.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageConfig.Location = new System.Drawing.Point(2, -1);
            this.lblPageConfig.Name = "lblPageConfig";
            this.lblPageConfig.Size = new System.Drawing.Size(207, 50);
            this.lblPageConfig.TabIndex = 1;
            this.lblPageConfig.Text = "CONFIG";
            this.lblPageConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPageConfig.Click += new System.EventHandler(this.lblPageConfig_Click);
            // 
            // panOp
            // 
            this.panOp.BackColor = System.Drawing.Color.Cornsilk;
            this.panOp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panOp.Controls.Add(this.lblConnect);
            this.panOp.Controls.Add(this.lblWaterFall3D);
            this.panOp.Controls.Add(this.button2);
            this.panOp.Controls.Add(this.button1);
            this.panOp.Controls.Add(this.tbxSimSetRPM);
            this.panOp.Controls.Add(this.chbUseSetRPM);
            this.panOp.Controls.Add(this.lblWaterFallTrigger);
            this.panOp.Controls.Add(this.lblMultiDataGet);
            this.panOp.Controls.Add(this.cbxMultiDataList);
            this.panOp.Controls.Add(this.btnLoadMultiData);
            this.panOp.Controls.Add(this.chbRefreshStop);
            this.panOp.Controls.Add(this.btnLoadData);
            this.panOp.Controls.Add(this.btnSaveData);
            this.panOp.Controls.Add(this.lblCaptureOneTimeSimAct);
            this.panOp.Controls.Add(this.lblPollingSimAct);
            this.panOp.Controls.Add(this.lblStatus);
            this.panOp.Controls.Add(this.lblProcedureStop);
            this.panOp.Controls.Add(this.lblCaptureOneTimeAct);
            this.panOp.Controls.Add(this.lblPollingAct);
            this.panOp.Location = new System.Drawing.Point(3, 3);
            this.panOp.Name = "panOp";
            this.panOp.Size = new System.Drawing.Size(1600, 154);
            this.panOp.TabIndex = 0;
            // 
            // lblConnect
            // 
            this.lblConnect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnect.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblConnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblConnect.Location = new System.Drawing.Point(174, 66);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(150, 50);
            this.lblConnect.TabIndex = 24;
            this.lblConnect.Text = "Connect";
            this.lblConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConnect.Click += new System.EventHandler(this.lblConnect_Click);
            // 
            // lblWaterFall3D
            // 
            this.lblWaterFall3D.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWaterFall3D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWaterFall3D.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblWaterFall3D.Location = new System.Drawing.Point(1212, 10);
            this.lblWaterFall3D.Name = "lblWaterFall3D";
            this.lblWaterFall3D.Size = new System.Drawing.Size(200, 50);
            this.lblWaterFall3D.TabIndex = 23;
            this.lblWaterFall3D.Text = "Show 3D";
            this.lblWaterFall3D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaterFall3D.Visible = false;
            this.lblWaterFall3D.Click += new System.EventHandler(this.lblWaterFall3D_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxSimSetRPM
            // 
            this.tbxSimSetRPM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSimSetRPM.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tbxSimSetRPM.Location = new System.Drawing.Point(1368, 91);
            this.tbxSimSetRPM.Name = "tbxSimSetRPM";
            this.tbxSimSetRPM.Size = new System.Drawing.Size(100, 25);
            this.tbxSimSetRPM.TabIndex = 20;
            this.tbxSimSetRPM.Text = "200";
            // 
            // chbUseSetRPM
            // 
            this.chbUseSetRPM.AutoSize = true;
            this.chbUseSetRPM.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chbUseSetRPM.Location = new System.Drawing.Point(1212, 95);
            this.chbUseSetRPM.Name = "chbUseSetRPM";
            this.chbUseSetRPM.Size = new System.Drawing.Size(150, 21);
            this.chbUseSetRPM.TabIndex = 19;
            this.chbUseSetRPM.Text = "Use Set RPM For Sim";
            this.chbUseSetRPM.UseVisualStyleBackColor = true;
            // 
            // lblWaterFallTrigger
            // 
            this.lblWaterFallTrigger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblWaterFallTrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWaterFallTrigger.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblWaterFallTrigger.Location = new System.Drawing.Point(1006, 67);
            this.lblWaterFallTrigger.Name = "lblWaterFallTrigger";
            this.lblWaterFallTrigger.Size = new System.Drawing.Size(200, 50);
            this.lblWaterFallTrigger.TabIndex = 18;
            this.lblWaterFallTrigger.Text = "Calculate WaterFall";
            this.lblWaterFallTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaterFallTrigger.Click += new System.EventHandler(this.lblWaterFallTrigger_Click);
            // 
            // lblMultiDataGet
            // 
            this.lblMultiDataGet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMultiDataGet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMultiDataGet.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblMultiDataGet.Location = new System.Drawing.Point(800, 67);
            this.lblMultiDataGet.Name = "lblMultiDataGet";
            this.lblMultiDataGet.Size = new System.Drawing.Size(200, 50);
            this.lblMultiDataGet.TabIndex = 17;
            this.lblMultiDataGet.Text = "Get";
            this.lblMultiDataGet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMultiDataGet.Click += new System.EventHandler(this.lblMultiDataGet_Click);
            // 
            // cbxMultiDataList
            // 
            this.cbxMultiDataList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMultiDataList.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMultiDataList.FormattingEnabled = true;
            this.cbxMultiDataList.Location = new System.Drawing.Point(585, 76);
            this.cbxMultiDataList.Name = "cbxMultiDataList";
            this.cbxMultiDataList.Size = new System.Drawing.Size(177, 33);
            this.cbxMultiDataList.TabIndex = 16;
            // 
            // btnLoadMultiData
            // 
            this.btnLoadMultiData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadMultiData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLoadMultiData.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadMultiData.Location = new System.Drawing.Point(379, 67);
            this.btnLoadMultiData.Name = "btnLoadMultiData";
            this.btnLoadMultiData.Size = new System.Drawing.Size(200, 50);
            this.btnLoadMultiData.TabIndex = 15;
            this.btnLoadMultiData.Text = "Load Multi-Data";
            this.btnLoadMultiData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadMultiData.Click += new System.EventHandler(this.btnLoadMultiData_Click);
            // 
            // chbRefreshStop
            // 
            this.chbRefreshStop.AutoSize = true;
            this.chbRefreshStop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRefreshStop.Location = new System.Drawing.Point(1212, 68);
            this.chbRefreshStop.Name = "chbRefreshStop";
            this.chbRefreshStop.Size = new System.Drawing.Size(102, 21);
            this.chbRefreshStop.TabIndex = 14;
            this.chbRefreshStop.Text = "Refresh Stop";
            this.chbRefreshStop.UseVisualStyleBackColor = true;
            this.chbRefreshStop.CheckedChanged += new System.EventHandler(this.chbRefreshStop_CheckedChanged);
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLoadData.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadData.Location = new System.Drawing.Point(1006, 10);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(200, 50);
            this.btnLoadData.TabIndex = 7;
            this.btnLoadData.Text = "Load";
            this.btnLoadData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSaveData.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveData.Location = new System.Drawing.Point(800, 9);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(200, 50);
            this.btnSaveData.TabIndex = 6;
            this.btnSaveData.Text = "Save";
            this.btnSaveData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // lblCaptureOneTimeSimAct
            // 
            this.lblCaptureOneTimeSimAct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCaptureOneTimeSimAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaptureOneTimeSimAct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCaptureOneTimeSimAct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCaptureOneTimeSimAct.Location = new System.Drawing.Point(585, 9);
            this.lblCaptureOneTimeSimAct.Name = "lblCaptureOneTimeSimAct";
            this.lblCaptureOneTimeSimAct.Size = new System.Drawing.Size(200, 50);
            this.lblCaptureOneTimeSimAct.TabIndex = 5;
            this.lblCaptureOneTimeSimAct.Text = "Sim. Capture Data";
            this.lblCaptureOneTimeSimAct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCaptureOneTimeSimAct.Click += new System.EventHandler(this.lblCaptureOneTimeSimAct_Click);
            // 
            // lblPollingSimAct
            // 
            this.lblPollingSimAct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPollingSimAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPollingSimAct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPollingSimAct.Location = new System.Drawing.Point(379, 10);
            this.lblPollingSimAct.Name = "lblPollingSimAct";
            this.lblPollingSimAct.Size = new System.Drawing.Size(200, 50);
            this.lblPollingSimAct.TabIndex = 4;
            this.lblPollingSimAct.Text = "Simulated Polling";
            this.lblPollingSimAct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPollingSimAct.Click += new System.EventHandler(this.lblPollingSimAct_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(6, 123);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1587, 27);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProcedureStop
            // 
            this.lblProcedureStop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProcedureStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcedureStop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblProcedureStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblProcedureStop.Location = new System.Drawing.Point(174, 9);
            this.lblProcedureStop.Name = "lblProcedureStop";
            this.lblProcedureStop.Size = new System.Drawing.Size(150, 50);
            this.lblProcedureStop.TabIndex = 2;
            this.lblProcedureStop.Text = "Stop";
            this.lblProcedureStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProcedureStop.Click += new System.EventHandler(this.lblProcedureStop_Click);
            // 
            // lblCaptureOneTimeAct
            // 
            this.lblCaptureOneTimeAct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCaptureOneTimeAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaptureOneTimeAct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCaptureOneTimeAct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCaptureOneTimeAct.Location = new System.Drawing.Point(5, 66);
            this.lblCaptureOneTimeAct.Name = "lblCaptureOneTimeAct";
            this.lblCaptureOneTimeAct.Size = new System.Drawing.Size(150, 50);
            this.lblCaptureOneTimeAct.TabIndex = 1;
            this.lblCaptureOneTimeAct.Text = "Capture Data";
            this.lblCaptureOneTimeAct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCaptureOneTimeAct.Click += new System.EventHandler(this.lblCaptureOneTimeAct_Click);
            // 
            // lblPollingAct
            // 
            this.lblPollingAct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPollingAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPollingAct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPollingAct.Location = new System.Drawing.Point(5, 9);
            this.lblPollingAct.Name = "lblPollingAct";
            this.lblPollingAct.Size = new System.Drawing.Size(150, 50);
            this.lblPollingAct.TabIndex = 0;
            this.lblPollingAct.Text = "Polling";
            this.lblPollingAct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPollingAct.Click += new System.EventHandler(this.lblPollingAct_Click);
            // 
            // tmeDisplay
            // 
            this.tmeDisplay.Enabled = true;
            this.tmeDisplay.Tick += new System.EventHandler(this.tmeDisplay_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.dat";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Data File|*.dat|All File|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.dat";
            this.saveFileDialog1.Filter = "Data File|*.dat|All File|*.*";
            this.saveFileDialog1.InitialDirectory = "C:\\";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.DefaultExt = "*.dat";
            this.openFileDialog2.FileName = "openFileDialog1";
            this.openFileDialog2.Filter = "Data File|*.dat|All File|*.*";
            this.openFileDialog2.InitialDirectory = "C:\\";
            this.openFileDialog2.Multiselect = true;
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            this.openFileDialog3.Filter = "CSV File|*.csv";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1598, 921);
            this.Controls.Add(this.panMain);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DRE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panOp.ResumeLayout(false);
            this.panOp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPageWaterfall;
        private System.Windows.Forms.Label lblPageOrbit;
        private System.Windows.Forms.Label lblPageSpecturm;
        private System.Windows.Forms.Panel panDisplay;
        private System.Windows.Forms.Label lblPageTimeBasePlot;
        private System.Windows.Forms.Label lblPageConfig;
        private System.Windows.Forms.Panel panOp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProcedureStop;
        private System.Windows.Forms.Label lblCaptureOneTimeAct;
        private System.Windows.Forms.Label lblPollingAct;
        private System.Windows.Forms.Timer tmeDisplay;
        private System.Windows.Forms.Label lblPollingSimAct;
        private System.Windows.Forms.Label lblCaptureOneTimeSimAct;
        private System.Windows.Forms.Label btnLoadData;
        private System.Windows.Forms.Label btnSaveData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox chbRefreshStop;
        private System.Windows.Forms.Label btnLoadMultiData;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ComboBox cbxMultiDataList;
        private System.Windows.Forms.Label lblMultiDataGet;
        private System.Windows.Forms.Label lblWaterFallTrigger;
        private System.Windows.Forms.Label lblPageAutoProcedure;
        private System.Windows.Forms.TextBox tbxSimSetRPM;
        private System.Windows.Forms.CheckBox chbUseSetRPM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblWaterFall3D;
        private System.Windows.Forms.Label lblPageVChannel;
        private System.Windows.Forms.Label lblConnect;
    }
}

