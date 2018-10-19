namespace V1000_Prog_SQL
{
    partial class frmProg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProg));
            this.dgvParamViewFull = new System.Windows.Forms.DataGridView();
            this.cmRegAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmParamNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmParmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmDefVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmVFDVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statProgLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.btnVFDRead = new System.Windows.Forms.Button();
            this.bwrkReadVFDVals = new System.ComponentModel.BackgroundWorker();
            this.ctxtSchedChng = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxtSchedChng_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtSchedChng_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtSchedChng_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtSchedChng_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtDriveMod = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxtDriveMod_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtDriveMod_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtDriveMod_UpdDefParam = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtDriveMod_StoreParamList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVFDMod = new System.Windows.Forms.Button();
            this.bwrkModVFD = new System.ComponentModel.BackgroundWorker();
            this.grpSetDrive = new System.Windows.Forms.GroupBox();
            this.grpSetDrv = new System.Windows.Forms.GroupBox();
            this.lblDriveSel = new System.Windows.Forms.Label();
            this.lblDriveDuty = new System.Windows.Forms.Label();
            this.cmbDrvParamGrp = new System.Windows.Forms.ComboBox();
            this.cmbDrvDuty = new System.Windows.Forms.ComboBox();
            this.cmbDrvList = new System.Windows.Forms.ComboBox();
            this.lblParamGroup = new System.Windows.Forms.Label();
            this.grpSetMach = new System.Windows.Forms.GroupBox();
            this.txtMachDrvName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMachChrtCnt = new System.Windows.Forms.TextBox();
            this.cmbMachSupplyFreq = new System.Windows.Forms.ComboBox();
            this.lblSelMotor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMachDrvNum = new System.Windows.Forms.ComboBox();
            this.txtMachDrvCnt = new System.Windows.Forms.TextBox();
            this.btnMachListDel = new System.Windows.Forms.Button();
            this.btnMachListLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVoltMachSupply = new System.Windows.Forms.Label();
            this.btnMachListStore = new System.Windows.Forms.Button();
            this.cmbMachChrtNum = new System.Windows.Forms.ComboBox();
            this.cmbMachSupplyVolt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMachSel = new System.Windows.Forms.ComboBox();
            this.lblSelMach = new System.Windows.Forms.Label();
            this.lblParamFullList = new System.Windows.Forms.Label();
            this.dgvParamViewMisMatch = new System.Windows.Forms.DataGridView();
            this.cmMisMatchParamAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMisMatchParamNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMisMatchParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMisMatchDefVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMisMatchReadVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblParamMismatch = new System.Windows.Forms.Label();
            this.grpDrvComm = new System.Windows.Forms.GroupBox();
            this.btnVFDVer = new System.Windows.Forms.Button();
            this.btnVFDReset = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msFile_LoadParamList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblParamModSched = new System.Windows.Forms.Label();
            this.dgvParamViewChng = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVoltMotorMax = new System.Windows.Forms.Label();
            this.cmbMtrVoltMax = new System.Windows.Forms.ComboBox();
            this.lblFreqMotorBase = new System.Windows.Forms.Label();
            this.cmbMtrFreqBase = new System.Windows.Forms.ComboBox();
            this.lblMotorFLC = new System.Windows.Forms.Label();
            this.lblUnitsAmps1 = new System.Windows.Forms.Label();
            this.txtMtrFLC = new System.Windows.Forms.TextBox();
            this.btnMtrSetVals = new System.Windows.Forms.Button();
            this.grpParamChng = new System.Windows.Forms.GroupBox();
            this.cmbMtrPartNum = new System.Windows.Forms.ComboBox();
            this.lblMotorPartNum = new System.Windows.Forms.Label();
            this.bwrkVFDVerify = new System.ComponentModel.BackgroundWorker();
            this.grpMtrSet = new System.Windows.Forms.GroupBox();
            this.btnMtrDel = new System.Windows.Forms.Button();
            this.btnMtrStore = new System.Windows.Forms.Button();
            this.grpMtr2Set = new System.Windows.Forms.GroupBox();
            this.btnMtr2SetVals = new System.Windows.Forms.Button();
            this.txtMtr2FLC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMtr2PartNum = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMtr2VoltMax = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMtr2FreqBase = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewFull)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.ctxtSchedChng.SuspendLayout();
            this.ctxtDriveMod.SuspendLayout();
            this.grpSetDrive.SuspendLayout();
            this.grpSetDrv.SuspendLayout();
            this.grpSetMach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewMisMatch)).BeginInit();
            this.grpDrvComm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewChng)).BeginInit();
            this.grpParamChng.SuspendLayout();
            this.grpMtrSet.SuspendLayout();
            this.grpMtr2Set.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvParamViewFull
            // 
            this.dgvParamViewFull.AllowUserToAddRows = false;
            this.dgvParamViewFull.AllowUserToDeleteRows = false;
            this.dgvParamViewFull.AllowUserToResizeColumns = false;
            this.dgvParamViewFull.AllowUserToResizeRows = false;
            this.dgvParamViewFull.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParamViewFull.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmRegAddr,
            this.cmParamNum,
            this.cmParmName,
            this.cmDefVal,
            this.cmVFDVal});
            this.dgvParamViewFull.Location = new System.Drawing.Point(5, 265);
            this.dgvParamViewFull.Name = "dgvParamViewFull";
            this.dgvParamViewFull.RowHeadersVisible = false;
            this.dgvParamViewFull.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParamViewFull.Size = new System.Drawing.Size(598, 407);
            this.dgvParamViewFull.TabIndex = 36;
            this.dgvParamViewFull.TabStop = false;
            this.dgvParamViewFull.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvParamViewFull_CellBeginEdit);
            this.dgvParamViewFull.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParamViewFull_CellEndEdit);
            // 
            // cmRegAddr
            // 
            this.cmRegAddr.DataPropertyName = "RegAddress";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmRegAddr.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmRegAddr.HeaderText = "Parameter Address";
            this.cmRegAddr.Name = "cmRegAddr";
            this.cmRegAddr.ReadOnly = true;
            this.cmRegAddr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmRegAddr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmRegAddr.Width = 60;
            // 
            // cmParamNum
            // 
            this.cmParamNum.DataPropertyName = "ParamNum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmParamNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmParamNum.HeaderText = "Parameter Number";
            this.cmParamNum.Name = "cmParamNum";
            this.cmParamNum.ReadOnly = true;
            this.cmParamNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmParamNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmParamNum.Width = 60;
            // 
            // cmParmName
            // 
            this.cmParmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmParmName.DataPropertyName = "ParamName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cmParmName.DefaultCellStyle = dataGridViewCellStyle3;
            this.cmParmName.HeaderText = "Parameter Name";
            this.cmParmName.Name = "cmParmName";
            this.cmParmName.ReadOnly = true;
            this.cmParmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmDefVal
            // 
            this.cmDefVal.DataPropertyName = "DefVal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmDefVal.DefaultCellStyle = dataGridViewCellStyle4;
            this.cmDefVal.HeaderText = "Default Value";
            this.cmDefVal.Name = "cmDefVal";
            this.cmDefVal.ReadOnly = true;
            this.cmDefVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmDefVal.Width = 70;
            // 
            // cmVFDVal
            // 
            this.cmVFDVal.DataPropertyName = "VFDVal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmVFDVal.DefaultCellStyle = dataGridViewCellStyle5;
            this.cmVFDVal.HeaderText = "VFD Value";
            this.cmVFDVal.Name = "cmVFDVal";
            this.cmVFDVal.ReadOnly = true;
            this.cmVFDVal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmVFDVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmVFDVal.Width = 70;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statProgLabel,
            this.statProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 763);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statProgLabel
            // 
            this.statProgLabel.Name = "statProgLabel";
            this.statProgLabel.Size = new System.Drawing.Size(162, 17);
            this.statProgLabel.Text = "Parameter List Load Progress:";
            this.statProgLabel.Visible = false;
            // 
            // statProgress
            // 
            this.statProgress.Name = "statProgress";
            this.statProgress.Size = new System.Drawing.Size(900, 16);
            this.statProgress.Visible = false;
            // 
            // btnVFDRead
            // 
            this.btnVFDRead.Enabled = false;
            this.btnVFDRead.Location = new System.Drawing.Point(161, 19);
            this.btnVFDRead.Name = "btnVFDRead";
            this.btnVFDRead.Size = new System.Drawing.Size(130, 23);
            this.btnVFDRead.TabIndex = 2;
            this.btnVFDRead.Text = "Read VFD Settings";
            this.btnVFDRead.UseVisualStyleBackColor = true;
            this.btnVFDRead.Click += new System.EventHandler(this.btnReadVFD_Click);
            // 
            // bwrkReadVFDVals
            // 
            this.bwrkReadVFDVals.WorkerReportsProgress = true;
            this.bwrkReadVFDVals.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrkReadVFDVals_DoWork);
            this.bwrkReadVFDVals.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwrkDGV_ProgressChanged);
            this.bwrkReadVFDVals.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrkReadVFDVals_RunWorkerCompleted);
            // 
            // ctxtSchedChng
            // 
            this.ctxtSchedChng.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxtSchedChng_Load,
            this.ctxtSchedChng_Save,
            this.ctxtSchedChng_Remove,
            this.ctxtSchedChng_Clear});
            this.ctxtSchedChng.Name = "ctxtSchedChng";
            this.ctxtSchedChng.Size = new System.Drawing.Size(219, 92);
            this.ctxtSchedChng.Opening += new System.ComponentModel.CancelEventHandler(this.ctxtSchedChng_Opening);
            // 
            // ctxtSchedChng_Load
            // 
            this.ctxtSchedChng_Load.Name = "ctxtSchedChng_Load";
            this.ctxtSchedChng_Load.Size = new System.Drawing.Size(218, 22);
            this.ctxtSchedChng_Load.Text = "Load Change List from File";
            this.ctxtSchedChng_Load.Click += new System.EventHandler(this.LoadParams);
            // 
            // ctxtSchedChng_Save
            // 
            this.ctxtSchedChng_Save.Name = "ctxtSchedChng_Save";
            this.ctxtSchedChng_Save.Size = new System.Drawing.Size(218, 22);
            this.ctxtSchedChng_Save.Text = "Save Change List to File";
            this.ctxtSchedChng_Save.Click += new System.EventHandler(this.SaveParams);
            // 
            // ctxtSchedChng_Remove
            // 
            this.ctxtSchedChng_Remove.Name = "ctxtSchedChng_Remove";
            this.ctxtSchedChng_Remove.Size = new System.Drawing.Size(218, 22);
            this.ctxtSchedChng_Remove.Text = "Remove Parameter Change";
            this.ctxtSchedChng_Remove.Click += new System.EventHandler(this.ctxtSchedChng_Remove_Click);
            // 
            // ctxtSchedChng_Clear
            // 
            this.ctxtSchedChng_Clear.Name = "ctxtSchedChng_Clear";
            this.ctxtSchedChng_Clear.Size = new System.Drawing.Size(218, 22);
            this.ctxtSchedChng_Clear.Text = "Clear Change List";
            this.ctxtSchedChng_Clear.Click += new System.EventHandler(this.clearScheduledChangesToolStripMenuItem_Click);
            // 
            // ctxtDriveMod
            // 
            this.ctxtDriveMod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxtDriveMod_Save,
            this.ctxtDriveMod_Clear,
            this.ctxtDriveMod_UpdDefParam,
            this.ctxtDriveMod_StoreParamList});
            this.ctxtDriveMod.Name = "ctxtDriveMod";
            this.ctxtDriveMod.Size = new System.Drawing.Size(247, 114);
            this.ctxtDriveMod.Opening += new System.ComponentModel.CancelEventHandler(this.ctxtDriveMod_Opening);
            // 
            // ctxtDriveMod_Save
            // 
            this.ctxtDriveMod_Save.Name = "ctxtDriveMod_Save";
            this.ctxtDriveMod_Save.Size = new System.Drawing.Size(246, 22);
            this.ctxtDriveMod_Save.Text = "Save Modified Parameters to File";
            this.ctxtDriveMod_Save.Click += new System.EventHandler(this.SaveParams);
            // 
            // ctxtDriveMod_Clear
            // 
            this.ctxtDriveMod_Clear.Name = "ctxtDriveMod_Clear";
            this.ctxtDriveMod_Clear.Size = new System.Drawing.Size(246, 22);
            this.ctxtDriveMod_Clear.Text = "Clear List";
            this.ctxtDriveMod_Clear.Click += new System.EventHandler(this.clearListToolStripMenuItem_Click);
            // 
            // ctxtDriveMod_UpdDefParam
            // 
            this.ctxtDriveMod_UpdDefParam.Name = "ctxtDriveMod_UpdDefParam";
            this.ctxtDriveMod_UpdDefParam.Size = new System.Drawing.Size(246, 22);
            this.ctxtDriveMod_UpdDefParam.Text = "Update Default Parameters";
            this.ctxtDriveMod_UpdDefParam.Click += new System.EventHandler(this.ctxtDriveMod_UpdDefParam_Click);
            // 
            // ctxtDriveMod_StoreParamList
            // 
            this.ctxtDriveMod_StoreParamList.Name = "ctxtDriveMod_StoreParamList";
            this.ctxtDriveMod_StoreParamList.Size = new System.Drawing.Size(246, 22);
            this.ctxtDriveMod_StoreParamList.Text = "Store Parameter List";
            this.ctxtDriveMod_StoreParamList.Click += new System.EventHandler(this.ctxtDriveMod_StoreParamList_Click);
            // 
            // btnVFDMod
            // 
            this.btnVFDMod.Enabled = false;
            this.btnVFDMod.Location = new System.Drawing.Point(318, 19);
            this.btnVFDMod.Name = "btnVFDMod";
            this.btnVFDMod.Size = new System.Drawing.Size(130, 23);
            this.btnVFDMod.TabIndex = 4;
            this.btnVFDMod.Text = "Modify VFD Parameters";
            this.btnVFDMod.UseVisualStyleBackColor = true;
            this.btnVFDMod.Click += new System.EventHandler(this.btnModVFD_Click);
            // 
            // bwrkModVFD
            // 
            this.bwrkModVFD.WorkerReportsProgress = true;
            this.bwrkModVFD.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrkModVFD_DoWork);
            this.bwrkModVFD.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwrkDGV_ProgressChanged);
            this.bwrkModVFD.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrkModVFD_RunWorkerCompleted);
            // 
            // grpSetDrive
            // 
            this.grpSetDrive.Controls.Add(this.grpSetDrv);
            this.grpSetDrive.Controls.Add(this.grpSetMach);
            this.grpSetDrive.Controls.Add(this.lblParamFullList);
            this.grpSetDrive.Controls.Add(this.dgvParamViewFull);
            this.grpSetDrive.Location = new System.Drawing.Point(7, 27);
            this.grpSetDrive.Name = "grpSetDrive";
            this.grpSetDrive.Size = new System.Drawing.Size(610, 679);
            this.grpSetDrive.TabIndex = 45;
            this.grpSetDrive.TabStop = false;
            this.grpSetDrive.Text = "VFD Complete Parameter Information";
            // 
            // grpSetDrv
            // 
            this.grpSetDrv.Controls.Add(this.lblDriveSel);
            this.grpSetDrv.Controls.Add(this.lblDriveDuty);
            this.grpSetDrv.Controls.Add(this.cmbDrvParamGrp);
            this.grpSetDrv.Controls.Add(this.cmbDrvDuty);
            this.grpSetDrv.Controls.Add(this.cmbDrvList);
            this.grpSetDrv.Controls.Add(this.lblParamGroup);
            this.grpSetDrv.Location = new System.Drawing.Point(5, 150);
            this.grpSetDrv.Name = "grpSetDrv";
            this.grpSetDrv.Size = new System.Drawing.Size(598, 86);
            this.grpSetDrv.TabIndex = 51;
            this.grpSetDrv.TabStop = false;
            this.grpSetDrv.Text = "Drive Settings";
            // 
            // lblDriveSel
            // 
            this.lblDriveSel.AutoSize = true;
            this.lblDriveSel.Location = new System.Drawing.Point(14, 28);
            this.lblDriveSel.Name = "lblDriveSel";
            this.lblDriveSel.Size = new System.Drawing.Size(82, 13);
            this.lblDriveSel.TabIndex = 40;
            this.lblDriveSel.Text = "Drive Selection:";
            // 
            // lblDriveDuty
            // 
            this.lblDriveDuty.AutoSize = true;
            this.lblDriveDuty.Location = new System.Drawing.Point(393, 28);
            this.lblDriveDuty.Name = "lblDriveDuty";
            this.lblDriveDuty.Size = new System.Drawing.Size(96, 13);
            this.lblDriveDuty.TabIndex = 49;
            this.lblDriveDuty.Text = "Drive Duty Setting:";
            // 
            // cmbDrvParamGrp
            // 
            this.cmbDrvParamGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvParamGrp.Enabled = false;
            this.cmbDrvParamGrp.FormattingEnabled = true;
            this.cmbDrvParamGrp.Location = new System.Drawing.Point(102, 52);
            this.cmbDrvParamGrp.Name = "cmbDrvParamGrp";
            this.cmbDrvParamGrp.Size = new System.Drawing.Size(277, 21);
            this.cmbDrvParamGrp.TabIndex = 1;
            this.cmbDrvParamGrp.SelectedIndexChanged += new System.EventHandler(this.cmbDrvParamGrp_SelectedIndexChanged);
            // 
            // cmbDrvDuty
            // 
            this.cmbDrvDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvDuty.Enabled = false;
            this.cmbDrvDuty.FormattingEnabled = true;
            this.cmbDrvDuty.Items.AddRange(new object[] {
            "Normal Duty",
            "Heavy Duty"});
            this.cmbDrvDuty.Location = new System.Drawing.Point(495, 25);
            this.cmbDrvDuty.Name = "cmbDrvDuty";
            this.cmbDrvDuty.Size = new System.Drawing.Size(97, 21);
            this.cmbDrvDuty.TabIndex = 48;
            this.cmbDrvDuty.SelectedIndexChanged += new System.EventHandler(this.cmbDrvDuty_SelectedIndexChanged);
            // 
            // cmbDrvList
            // 
            this.cmbDrvList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvList.FormattingEnabled = true;
            this.cmbDrvList.Location = new System.Drawing.Point(102, 25);
            this.cmbDrvList.Name = "cmbDrvList";
            this.cmbDrvList.Size = new System.Drawing.Size(277, 21);
            this.cmbDrvList.TabIndex = 0;
            this.cmbDrvList.SelectedIndexChanged += new System.EventHandler(this.cmbDrvList_SelectedIndexChanged);
            // 
            // lblParamGroup
            // 
            this.lblParamGroup.AutoSize = true;
            this.lblParamGroup.Location = new System.Drawing.Point(6, 55);
            this.lblParamGroup.Name = "lblParamGroup";
            this.lblParamGroup.Size = new System.Drawing.Size(90, 13);
            this.lblParamGroup.TabIndex = 41;
            this.lblParamGroup.Text = "Parameter Group:";
            // 
            // grpSetMach
            // 
            this.grpSetMach.Controls.Add(this.txtMachDrvName);
            this.grpSetMach.Controls.Add(this.label5);
            this.grpSetMach.Controls.Add(this.txtMachChrtCnt);
            this.grpSetMach.Controls.Add(this.cmbMachSupplyFreq);
            this.grpSetMach.Controls.Add(this.lblSelMotor);
            this.grpSetMach.Controls.Add(this.label3);
            this.grpSetMach.Controls.Add(this.cmbMachDrvNum);
            this.grpSetMach.Controls.Add(this.txtMachDrvCnt);
            this.grpSetMach.Controls.Add(this.btnMachListDel);
            this.grpSetMach.Controls.Add(this.btnMachListLoad);
            this.grpSetMach.Controls.Add(this.label1);
            this.grpSetMach.Controls.Add(this.lblVoltMachSupply);
            this.grpSetMach.Controls.Add(this.btnMachListStore);
            this.grpSetMach.Controls.Add(this.cmbMachChrtNum);
            this.grpSetMach.Controls.Add(this.cmbMachSupplyVolt);
            this.grpSetMach.Controls.Add(this.label4);
            this.grpSetMach.Controls.Add(this.label2);
            this.grpSetMach.Controls.Add(this.cmbMachSel);
            this.grpSetMach.Controls.Add(this.lblSelMach);
            this.grpSetMach.Location = new System.Drawing.Point(6, 19);
            this.grpSetMach.Name = "grpSetMach";
            this.grpSetMach.Size = new System.Drawing.Size(598, 125);
            this.grpSetMach.TabIndex = 50;
            this.grpSetMach.TabStop = false;
            this.grpSetMach.Text = "Machine Settings";
            // 
            // txtMachDrvName
            // 
            this.txtMachDrvName.Location = new System.Drawing.Point(87, 92);
            this.txtMachDrvName.Name = "txtMachDrvName";
            this.txtMachDrvName.ReadOnly = true;
            this.txtMachDrvName.Size = new System.Drawing.Size(106, 20);
            this.txtMachDrvName.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Chart Count:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMachChrtCnt
            // 
            this.txtMachChrtCnt.Enabled = false;
            this.txtMachChrtCnt.Location = new System.Drawing.Point(87, 55);
            this.txtMachChrtCnt.Name = "txtMachChrtCnt";
            this.txtMachChrtCnt.ReadOnly = true;
            this.txtMachChrtCnt.Size = new System.Drawing.Size(23, 20);
            this.txtMachChrtCnt.TabIndex = 98;
            this.txtMachChrtCnt.TabStop = false;
            this.txtMachChrtCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbMachSupplyFreq
            // 
            this.cmbMachSupplyFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachSupplyFreq.FormattingEnabled = true;
            this.cmbMachSupplyFreq.Items.AddRange(new object[] {
            "50 Hz",
            "60 Hz"});
            this.cmbMachSupplyFreq.Location = new System.Drawing.Point(244, 17);
            this.cmbMachSupplyFreq.Name = "cmbMachSupplyFreq";
            this.cmbMachSupplyFreq.Size = new System.Drawing.Size(55, 21);
            this.cmbMachSupplyFreq.TabIndex = 68;
            this.cmbMachSupplyFreq.SelectedIndexChanged += new System.EventHandler(this.cmbMachSupplyFreq_SelectedIndexChanged);
            // 
            // lblSelMotor
            // 
            this.lblSelMotor.AutoSize = true;
            this.lblSelMotor.Location = new System.Drawing.Point(472, 58);
            this.lblSelMotor.Name = "lblSelMotor";
            this.lblSelMotor.Size = new System.Drawing.Size(75, 13);
            this.lblSelMotor.TabIndex = 61;
            this.lblSelMotor.Text = "Drive Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Drive Count:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMachDrvNum
            // 
            this.cmbMachDrvNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachDrvNum.FormattingEnabled = true;
            this.cmbMachDrvNum.Location = new System.Drawing.Point(549, 55);
            this.cmbMachDrvNum.Name = "cmbMachDrvNum";
            this.cmbMachDrvNum.Size = new System.Drawing.Size(42, 21);
            this.cmbMachDrvNum.TabIndex = 64;
            this.cmbMachDrvNum.SelectedIndexChanged += new System.EventHandler(this.cmbMachDrvNum_SelectedIndexChanged);
            // 
            // txtMachDrvCnt
            // 
            this.txtMachDrvCnt.Enabled = false;
            this.txtMachDrvCnt.Location = new System.Drawing.Point(201, 55);
            this.txtMachDrvCnt.Name = "txtMachDrvCnt";
            this.txtMachDrvCnt.ReadOnly = true;
            this.txtMachDrvCnt.Size = new System.Drawing.Size(23, 20);
            this.txtMachDrvCnt.TabIndex = 98;
            this.txtMachDrvCnt.TabStop = false;
            this.txtMachDrvCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMachListDel
            // 
            this.btnMachListDel.Enabled = false;
            this.btnMachListDel.Location = new System.Drawing.Point(205, 90);
            this.btnMachListDel.Name = "btnMachListDel";
            this.btnMachListDel.Size = new System.Drawing.Size(125, 23);
            this.btnMachListDel.TabIndex = 65;
            this.btnMachListDel.Text = "Delete Parameter List";
            this.btnMachListDel.UseVisualStyleBackColor = true;
            this.btnMachListDel.Click += new System.EventHandler(this.btnMachListDel_Click);
            // 
            // btnMachListLoad
            // 
            this.btnMachListLoad.Enabled = false;
            this.btnMachListLoad.Location = new System.Drawing.Point(467, 90);
            this.btnMachListLoad.Name = "btnMachListLoad";
            this.btnMachListLoad.Size = new System.Drawing.Size(125, 23);
            this.btnMachListLoad.TabIndex = 65;
            this.btnMachListLoad.Text = "Load Parameter List";
            this.btnMachListLoad.UseVisualStyleBackColor = true;
            this.btnMachListLoad.Click += new System.EventHandler(this.btnMachListLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Supply Frequency:";
            // 
            // lblVoltMachSupply
            // 
            this.lblVoltMachSupply.AutoSize = true;
            this.lblVoltMachSupply.Location = new System.Drawing.Point(6, 20);
            this.lblVoltMachSupply.Name = "lblVoltMachSupply";
            this.lblVoltMachSupply.Size = new System.Drawing.Size(81, 13);
            this.lblVoltMachSupply.TabIndex = 47;
            this.lblVoltMachSupply.Text = "Supply Voltage:";
            // 
            // btnMachListStore
            // 
            this.btnMachListStore.Enabled = false;
            this.btnMachListStore.Location = new System.Drawing.Point(336, 90);
            this.btnMachListStore.Name = "btnMachListStore";
            this.btnMachListStore.Size = new System.Drawing.Size(125, 23);
            this.btnMachListStore.TabIndex = 65;
            this.btnMachListStore.Text = "Store Parameter List";
            this.btnMachListStore.UseVisualStyleBackColor = true;
            this.btnMachListStore.Click += new System.EventHandler(this.btnMachListStore_Click);
            // 
            // cmbMachChrtNum
            // 
            this.cmbMachChrtNum.FormattingEnabled = true;
            this.cmbMachChrtNum.Location = new System.Drawing.Point(353, 54);
            this.cmbMachChrtNum.Name = "cmbMachChrtNum";
            this.cmbMachChrtNum.Size = new System.Drawing.Size(97, 21);
            this.cmbMachChrtNum.TabIndex = 63;
            // 
            // cmbMachSupplyVolt
            // 
            this.cmbMachSupplyVolt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachSupplyVolt.FormattingEnabled = true;
            this.cmbMachSupplyVolt.Items.AddRange(new object[] {
            "200 V",
            "208 V",
            "220 V",
            "230 V",
            "240 V",
            "380 V",
            "400 V",
            "415 V",
            "460 V"});
            this.cmbMachSupplyVolt.Location = new System.Drawing.Point(87, 17);
            this.cmbMachSupplyVolt.Name = "cmbMachSupplyVolt";
            this.cmbMachSupplyVolt.Size = new System.Drawing.Size(55, 21);
            this.cmbMachSupplyVolt.TabIndex = 50;
            this.cmbMachSupplyVolt.SelectedIndexChanged += new System.EventHandler(this.cmbMachSupplyVolt_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Chart Part Number:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Drive Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMachSel
            // 
            this.cmbMachSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachSel.FormattingEnabled = true;
            this.cmbMachSel.Location = new System.Drawing.Point(409, 17);
            this.cmbMachSel.Name = "cmbMachSel";
            this.cmbMachSel.Size = new System.Drawing.Size(182, 21);
            this.cmbMachSel.TabIndex = 63;
            this.cmbMachSel.SelectedIndexChanged += new System.EventHandler(this.cmbMachSel_SelectedIndexChanged);
            // 
            // lblSelMach
            // 
            this.lblSelMach.AutoSize = true;
            this.lblSelMach.Location = new System.Drawing.Point(312, 20);
            this.lblSelMach.Name = "lblSelMach";
            this.lblSelMach.Size = new System.Drawing.Size(98, 13);
            this.lblSelMach.TabIndex = 62;
            this.lblSelMach.Text = "Machine Selection:";
            // 
            // lblParamFullList
            // 
            this.lblParamFullList.AutoSize = true;
            this.lblParamFullList.Location = new System.Drawing.Point(6, 249);
            this.lblParamFullList.Name = "lblParamFullList";
            this.lblParamFullList.Size = new System.Drawing.Size(96, 13);
            this.lblParamFullList.TabIndex = 47;
            this.lblParamFullList.Text = "Full Parameter List:";
            // 
            // dgvParamViewMisMatch
            // 
            this.dgvParamViewMisMatch.AllowUserToAddRows = false;
            this.dgvParamViewMisMatch.AllowUserToDeleteRows = false;
            this.dgvParamViewMisMatch.AllowUserToResizeColumns = false;
            this.dgvParamViewMisMatch.AllowUserToResizeRows = false;
            this.dgvParamViewMisMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParamViewMisMatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmMisMatchParamAddr,
            this.cmMisMatchParamNum,
            this.cmMisMatchParamName,
            this.cmMisMatchDefVal,
            this.cmMisMatchReadVal});
            this.dgvParamViewMisMatch.ContextMenuStrip = this.ctxtDriveMod;
            this.dgvParamViewMisMatch.Location = new System.Drawing.Point(6, 309);
            this.dgvParamViewMisMatch.Name = "dgvParamViewMisMatch";
            this.dgvParamViewMisMatch.RowHeadersVisible = false;
            this.dgvParamViewMisMatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParamViewMisMatch.Size = new System.Drawing.Size(600, 245);
            this.dgvParamViewMisMatch.TabIndex = 41;
            this.dgvParamViewMisMatch.TabStop = false;
            // 
            // cmMisMatchParamAddr
            // 
            this.cmMisMatchParamAddr.DataPropertyName = "RegAddress";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmMisMatchParamAddr.DefaultCellStyle = dataGridViewCellStyle6;
            this.cmMisMatchParamAddr.HeaderText = "Parameter Address";
            this.cmMisMatchParamAddr.Name = "cmMisMatchParamAddr";
            this.cmMisMatchParamAddr.ReadOnly = true;
            this.cmMisMatchParamAddr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMisMatchParamAddr.Width = 60;
            // 
            // cmMisMatchParamNum
            // 
            this.cmMisMatchParamNum.DataPropertyName = "ParamNum";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmMisMatchParamNum.DefaultCellStyle = dataGridViewCellStyle7;
            this.cmMisMatchParamNum.HeaderText = "Parameter Number";
            this.cmMisMatchParamNum.Name = "cmMisMatchParamNum";
            this.cmMisMatchParamNum.ReadOnly = true;
            this.cmMisMatchParamNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMisMatchParamNum.Width = 60;
            // 
            // cmMisMatchParamName
            // 
            this.cmMisMatchParamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmMisMatchParamName.DataPropertyName = "ParamName";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cmMisMatchParamName.DefaultCellStyle = dataGridViewCellStyle8;
            this.cmMisMatchParamName.HeaderText = "Parameter Name";
            this.cmMisMatchParamName.Name = "cmMisMatchParamName";
            this.cmMisMatchParamName.ReadOnly = true;
            // 
            // cmMisMatchDefVal
            // 
            this.cmMisMatchDefVal.DataPropertyName = "DefVal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmMisMatchDefVal.DefaultCellStyle = dataGridViewCellStyle9;
            this.cmMisMatchDefVal.HeaderText = "Default Value";
            this.cmMisMatchDefVal.Name = "cmMisMatchDefVal";
            this.cmMisMatchDefVal.ReadOnly = true;
            this.cmMisMatchDefVal.Width = 70;
            // 
            // cmMisMatchReadVal
            // 
            this.cmMisMatchReadVal.DataPropertyName = "ReadVal";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmMisMatchReadVal.DefaultCellStyle = dataGridViewCellStyle10;
            this.cmMisMatchReadVal.HeaderText = "Read Value";
            this.cmMisMatchReadVal.Name = "cmMisMatchReadVal";
            this.cmMisMatchReadVal.ReadOnly = true;
            this.cmMisMatchReadVal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMisMatchReadVal.Width = 70;
            // 
            // lblParamMismatch
            // 
            this.lblParamMismatch.AutoSize = true;
            this.lblParamMismatch.Location = new System.Drawing.Point(7, 293);
            this.lblParamMismatch.Name = "lblParamMismatch";
            this.lblParamMismatch.Size = new System.Drawing.Size(134, 13);
            this.lblParamMismatch.TabIndex = 46;
            this.lblParamMismatch.Text = "Drive Modified Parameters:";
            // 
            // grpDrvComm
            // 
            this.grpDrvComm.Controls.Add(this.btnVFDVer);
            this.grpDrvComm.Controls.Add(this.btnVFDReset);
            this.grpDrvComm.Controls.Add(this.btnVFDRead);
            this.grpDrvComm.Controls.Add(this.btnVFDMod);
            this.grpDrvComm.Enabled = false;
            this.grpDrvComm.Location = new System.Drawing.Point(3, 705);
            this.grpDrvComm.Name = "grpDrvComm";
            this.grpDrvComm.Size = new System.Drawing.Size(614, 53);
            this.grpDrvComm.TabIndex = 47;
            this.grpDrvComm.TabStop = false;
            this.grpDrvComm.Text = "Drive Communication Commands";
            // 
            // btnVFDVer
            // 
            this.btnVFDVer.Enabled = false;
            this.btnVFDVer.Location = new System.Drawing.Point(478, 19);
            this.btnVFDVer.Name = "btnVFDVer";
            this.btnVFDVer.Size = new System.Drawing.Size(130, 23);
            this.btnVFDVer.TabIndex = 99;
            this.btnVFDVer.Text = "Verify VFD Programming";
            this.btnVFDVer.UseVisualStyleBackColor = true;
            this.btnVFDVer.Click += new System.EventHandler(this.btnVFDVer_Click);
            // 
            // btnVFDReset
            // 
            this.btnVFDReset.Enabled = false;
            this.btnVFDReset.Location = new System.Drawing.Point(6, 19);
            this.btnVFDReset.Name = "btnVFDReset";
            this.btnVFDReset.Size = new System.Drawing.Size(130, 23);
            this.btnVFDReset.TabIndex = 3;
            this.btnVFDReset.Text = "Reintialize VFD";
            this.btnVFDReset.UseVisualStyleBackColor = true;
            this.btnVFDReset.Click += new System.EventHandler(this.btnVFDReset_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFile,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msFile
            // 
            this.msFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFile_LoadParamList,
            this.toolStripSeparator1,
            this.msFile_Exit});
            this.msFile.Name = "msFile";
            this.msFile.Size = new System.Drawing.Size(37, 20);
            this.msFile.Text = "&File";
            // 
            // msFile_LoadParamList
            // 
            this.msFile_LoadParamList.Enabled = false;
            this.msFile_LoadParamList.Name = "msFile_LoadParamList";
            this.msFile_LoadParamList.Size = new System.Drawing.Size(195, 22);
            this.msFile_LoadParamList.Text = "&Load Parameter Listing";
            this.msFile_LoadParamList.Click += new System.EventHandler(this.LoadParams);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // msFile_Exit
            // 
            this.msFile_Exit.Name = "msFile_Exit";
            this.msFile_Exit.Size = new System.Drawing.Size(195, 22);
            this.msFile_Exit.Text = "E&xit";
            this.msFile_Exit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // lblParamModSched
            // 
            this.lblParamModSched.AutoSize = true;
            this.lblParamModSched.Location = new System.Drawing.Point(7, 18);
            this.lblParamModSched.Name = "lblParamModSched";
            this.lblParamModSched.Size = new System.Drawing.Size(106, 13);
            this.lblParamModSched.TabIndex = 43;
            this.lblParamModSched.Text = "Scheduled Changes:";
            // 
            // dgvParamViewChng
            // 
            this.dgvParamViewChng.AllowUserToAddRows = false;
            this.dgvParamViewChng.AllowUserToDeleteRows = false;
            this.dgvParamViewChng.AllowUserToResizeColumns = false;
            this.dgvParamViewChng.AllowUserToResizeRows = false;
            this.dgvParamViewChng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParamViewChng.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvParamViewChng.ContextMenuStrip = this.ctxtSchedChng;
            this.dgvParamViewChng.Location = new System.Drawing.Point(5, 34);
            this.dgvParamViewChng.Name = "dgvParamViewChng";
            this.dgvParamViewChng.RowHeadersVisible = false;
            this.dgvParamViewChng.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParamViewChng.Size = new System.Drawing.Size(600, 245);
            this.dgvParamViewChng.TabIndex = 40;
            this.dgvParamViewChng.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RegAddress";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn1.HeaderText = "Parameter Address";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ParamNum";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn2.HeaderText = "Parameter Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ParamName";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn3.HeaderText = "Parameter Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DefVal";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn4.HeaderText = "Default Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SpecVal";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn5.HeaderText = "Specified Value";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // lblVoltMotorMax
            // 
            this.lblVoltMotorMax.AutoSize = true;
            this.lblVoltMotorMax.Location = new System.Drawing.Point(6, 22);
            this.lblVoltMotorMax.Name = "lblVoltMotorMax";
            this.lblVoltMotorMax.Size = new System.Drawing.Size(99, 13);
            this.lblVoltMotorMax.TabIndex = 51;
            this.lblVoltMotorMax.Text = "Max Motor Voltage:";
            // 
            // cmbMtrVoltMax
            // 
            this.cmbMtrVoltMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtrVoltMax.FormattingEnabled = true;
            this.cmbMtrVoltMax.Items.AddRange(new object[] {
            "200 V",
            "208 V",
            "220 V",
            "230 V",
            "240 V",
            "380 V",
            "400 V",
            "415 V",
            "460 V"});
            this.cmbMtrVoltMax.Location = new System.Drawing.Point(111, 19);
            this.cmbMtrVoltMax.Name = "cmbMtrVoltMax";
            this.cmbMtrVoltMax.Size = new System.Drawing.Size(68, 21);
            this.cmbMtrVoltMax.TabIndex = 52;
            this.cmbMtrVoltMax.SelectedIndexChanged += new System.EventHandler(this.MtrVoltMax_SelectedIndexChanged);
            // 
            // lblFreqMotorBase
            // 
            this.lblFreqMotorBase.AutoSize = true;
            this.lblFreqMotorBase.Location = new System.Drawing.Point(207, 22);
            this.lblFreqMotorBase.Name = "lblFreqMotorBase";
            this.lblFreqMotorBase.Size = new System.Drawing.Size(117, 13);
            this.lblFreqMotorBase.TabIndex = 55;
            this.lblFreqMotorBase.Text = "Motor Base Frequency:";
            // 
            // cmbMtrFreqBase
            // 
            this.cmbMtrFreqBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtrFreqBase.FormattingEnabled = true;
            this.cmbMtrFreqBase.Items.AddRange(new object[] {
            "50 Hz",
            "60 Hz"});
            this.cmbMtrFreqBase.Location = new System.Drawing.Point(330, 19);
            this.cmbMtrFreqBase.Name = "cmbMtrFreqBase";
            this.cmbMtrFreqBase.Size = new System.Drawing.Size(68, 21);
            this.cmbMtrFreqBase.TabIndex = 56;
            this.cmbMtrFreqBase.SelectedIndexChanged += new System.EventHandler(this.MtrFreqBase_SelectedIndexChanged);
            // 
            // lblMotorFLC
            // 
            this.lblMotorFLC.AutoSize = true;
            this.lblMotorFLC.Location = new System.Drawing.Point(475, 49);
            this.lblMotorFLC.Name = "lblMotorFLC";
            this.lblMotorFLC.Size = new System.Drawing.Size(59, 13);
            this.lblMotorFLC.TabIndex = 57;
            this.lblMotorFLC.Text = "Motor FLC:";
            // 
            // lblUnitsAmps1
            // 
            this.lblUnitsAmps1.AutoSize = true;
            this.lblUnitsAmps1.Location = new System.Drawing.Point(594, 50);
            this.lblUnitsAmps1.Name = "lblUnitsAmps1";
            this.lblUnitsAmps1.Size = new System.Drawing.Size(14, 13);
            this.lblUnitsAmps1.TabIndex = 58;
            this.lblUnitsAmps1.Text = "A";
            // 
            // txtMtrFLC
            // 
            this.txtMtrFLC.Location = new System.Drawing.Point(540, 46);
            this.txtMtrFLC.Name = "txtMtrFLC";
            this.txtMtrFLC.Size = new System.Drawing.Size(48, 20);
            this.txtMtrFLC.TabIndex = 59;
            // 
            // btnMtrSetVals
            // 
            this.btnMtrSetVals.Enabled = false;
            this.btnMtrSetVals.Location = new System.Drawing.Point(318, 44);
            this.btnMtrSetVals.Name = "btnMtrSetVals";
            this.btnMtrSetVals.Size = new System.Drawing.Size(130, 23);
            this.btnMtrSetVals.TabIndex = 60;
            this.btnMtrSetVals.Text = "Set Motor Values";
            this.btnMtrSetVals.UseVisualStyleBackColor = true;
            this.btnMtrSetVals.Click += new System.EventHandler(this.btnSetMotorVals);
            // 
            // grpParamChng
            // 
            this.grpParamChng.Controls.Add(this.dgvParamViewChng);
            this.grpParamChng.Controls.Add(this.lblParamModSched);
            this.grpParamChng.Controls.Add(this.dgvParamViewMisMatch);
            this.grpParamChng.Controls.Add(this.lblParamMismatch);
            this.grpParamChng.Location = new System.Drawing.Point(623, 195);
            this.grpParamChng.Name = "grpParamChng";
            this.grpParamChng.Size = new System.Drawing.Size(614, 563);
            this.grpParamChng.TabIndex = 46;
            this.grpParamChng.TabStop = false;
            this.grpParamChng.Text = "VFD Parameter Changes";
            // 
            // cmbMtrPartNum
            // 
            this.cmbMtrPartNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtrPartNum.FormattingEnabled = true;
            this.cmbMtrPartNum.Location = new System.Drawing.Point(540, 19);
            this.cmbMtrPartNum.Name = "cmbMtrPartNum";
            this.cmbMtrPartNum.Size = new System.Drawing.Size(68, 21);
            this.cmbMtrPartNum.TabIndex = 66;
            this.cmbMtrPartNum.SelectedIndexChanged += new System.EventHandler(this.MtrPartNum_SelectedIndexChanged);
            this.cmbMtrPartNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtrPartNum_KeyDown);
            // 
            // lblMotorPartNum
            // 
            this.lblMotorPartNum.AutoSize = true;
            this.lblMotorPartNum.Location = new System.Drawing.Point(435, 22);
            this.lblMotorPartNum.Name = "lblMotorPartNum";
            this.lblMotorPartNum.Size = new System.Drawing.Size(99, 13);
            this.lblMotorPartNum.TabIndex = 65;
            this.lblMotorPartNum.Text = "Motor Part Number:";
            // 
            // bwrkVFDVerify
            // 
            this.bwrkVFDVerify.WorkerReportsProgress = true;
            this.bwrkVFDVerify.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrkVFDVerify_DoWork);
            this.bwrkVFDVerify.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwrkDGV_ProgressChanged);
            this.bwrkVFDVerify.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrkVFDVerify_RunWorkerCompleted);
            // 
            // grpMtrSet
            // 
            this.grpMtrSet.Controls.Add(this.btnMtrDel);
            this.grpMtrSet.Controls.Add(this.btnMtrStore);
            this.grpMtrSet.Controls.Add(this.btnMtrSetVals);
            this.grpMtrSet.Controls.Add(this.txtMtrFLC);
            this.grpMtrSet.Controls.Add(this.lblUnitsAmps1);
            this.grpMtrSet.Controls.Add(this.lblMotorFLC);
            this.grpMtrSet.Controls.Add(this.cmbMtrPartNum);
            this.grpMtrSet.Controls.Add(this.lblMotorPartNum);
            this.grpMtrSet.Controls.Add(this.lblVoltMotorMax);
            this.grpMtrSet.Controls.Add(this.cmbMtrVoltMax);
            this.grpMtrSet.Controls.Add(this.lblFreqMotorBase);
            this.grpMtrSet.Controls.Add(this.cmbMtrFreqBase);
            this.grpMtrSet.Location = new System.Drawing.Point(623, 27);
            this.grpMtrSet.Name = "grpMtrSet";
            this.grpMtrSet.Size = new System.Drawing.Size(614, 79);
            this.grpMtrSet.TabIndex = 49;
            this.grpMtrSet.TabStop = false;
            this.grpMtrSet.Text = "Motor Settings";
            // 
            // btnMtrDel
            // 
            this.btnMtrDel.Location = new System.Drawing.Point(10, 44);
            this.btnMtrDel.Name = "btnMtrDel";
            this.btnMtrDel.Size = new System.Drawing.Size(130, 23);
            this.btnMtrDel.TabIndex = 69;
            this.btnMtrDel.Text = "Delete Motor Values";
            this.btnMtrDel.UseVisualStyleBackColor = true;
            this.btnMtrDel.Click += new System.EventHandler(this.btnMtrDel_Click);
            // 
            // btnMtrStore
            // 
            this.btnMtrStore.Location = new System.Drawing.Point(161, 45);
            this.btnMtrStore.Name = "btnMtrStore";
            this.btnMtrStore.Size = new System.Drawing.Size(130, 23);
            this.btnMtrStore.TabIndex = 60;
            this.btnMtrStore.Text = "Store Motor Values";
            this.btnMtrStore.UseVisualStyleBackColor = true;
            this.btnMtrStore.Click += new System.EventHandler(this.btnMtrStore_Click);
            // 
            // grpMtr2Set
            // 
            this.grpMtr2Set.Controls.Add(this.btnMtr2SetVals);
            this.grpMtr2Set.Controls.Add(this.txtMtr2FLC);
            this.grpMtr2Set.Controls.Add(this.label6);
            this.grpMtr2Set.Controls.Add(this.label7);
            this.grpMtr2Set.Controls.Add(this.cmbMtr2PartNum);
            this.grpMtr2Set.Controls.Add(this.label8);
            this.grpMtr2Set.Controls.Add(this.label9);
            this.grpMtr2Set.Controls.Add(this.cmbMtr2VoltMax);
            this.grpMtr2Set.Controls.Add(this.label10);
            this.grpMtr2Set.Controls.Add(this.cmbMtr2FreqBase);
            this.grpMtr2Set.Location = new System.Drawing.Point(623, 112);
            this.grpMtr2Set.Name = "grpMtr2Set";
            this.grpMtr2Set.Size = new System.Drawing.Size(614, 79);
            this.grpMtr2Set.TabIndex = 50;
            this.grpMtr2Set.TabStop = false;
            this.grpMtr2Set.Text = "Motor 2 Settings";
            this.grpMtr2Set.Visible = false;
            // 
            // btnMtr2SetVals
            // 
            this.btnMtr2SetVals.Location = new System.Drawing.Point(318, 44);
            this.btnMtr2SetVals.Name = "btnMtr2SetVals";
            this.btnMtr2SetVals.Size = new System.Drawing.Size(130, 23);
            this.btnMtr2SetVals.TabIndex = 60;
            this.btnMtr2SetVals.Text = "Set Motor 2 Values";
            this.btnMtr2SetVals.UseVisualStyleBackColor = true;
            this.btnMtr2SetVals.Click += new System.EventHandler(this.btnMtr2SetVals_Click);
            // 
            // txtMtr2FLC
            // 
            this.txtMtr2FLC.Location = new System.Drawing.Point(540, 46);
            this.txtMtr2FLC.Name = "txtMtr2FLC";
            this.txtMtr2FLC.Size = new System.Drawing.Size(48, 20);
            this.txtMtr2FLC.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(594, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Motor FLC:";
            // 
            // cmbMtr2PartNum
            // 
            this.cmbMtr2PartNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtr2PartNum.FormattingEnabled = true;
            this.cmbMtr2PartNum.Location = new System.Drawing.Point(540, 19);
            this.cmbMtr2PartNum.Name = "cmbMtr2PartNum";
            this.cmbMtr2PartNum.Size = new System.Drawing.Size(68, 21);
            this.cmbMtr2PartNum.TabIndex = 66;
            this.cmbMtr2PartNum.SelectedIndexChanged += new System.EventHandler(this.MtrPartNum_SelectedIndexChanged);
            this.cmbMtr2PartNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtrPartNum_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(435, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Motor Part Number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Max Motor Voltage:";
            // 
            // cmbMtr2VoltMax
            // 
            this.cmbMtr2VoltMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtr2VoltMax.FormattingEnabled = true;
            this.cmbMtr2VoltMax.Items.AddRange(new object[] {
            "200 V",
            "208 V",
            "220 V",
            "230 V",
            "240 V",
            "380 V",
            "400 V",
            "415 V",
            "460 V"});
            this.cmbMtr2VoltMax.Location = new System.Drawing.Point(111, 19);
            this.cmbMtr2VoltMax.Name = "cmbMtr2VoltMax";
            this.cmbMtr2VoltMax.Size = new System.Drawing.Size(68, 21);
            this.cmbMtr2VoltMax.TabIndex = 52;
            this.cmbMtr2VoltMax.SelectedIndexChanged += new System.EventHandler(this.MtrVoltMax_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Motor Base Frequency:";
            // 
            // cmbMtr2FreqBase
            // 
            this.cmbMtr2FreqBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMtr2FreqBase.FormattingEnabled = true;
            this.cmbMtr2FreqBase.Items.AddRange(new object[] {
            "50 Hz",
            "60 Hz"});
            this.cmbMtr2FreqBase.Location = new System.Drawing.Point(330, 19);
            this.cmbMtr2FreqBase.Name = "cmbMtr2FreqBase";
            this.cmbMtr2FreqBase.Size = new System.Drawing.Size(68, 21);
            this.cmbMtr2FreqBase.TabIndex = 56;
            this.cmbMtr2FreqBase.SelectedIndexChanged += new System.EventHandler(this.MtrFreqBase_SelectedIndexChanged);
            // 
            // frmProg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 785);
            this.Controls.Add(this.grpMtr2Set);
            this.Controls.Add(this.grpMtrSet);
            this.Controls.Add(this.grpSetDrive);
            this.Controls.Add(this.grpParamChng);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpDrvComm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProg";
            this.Text = "VFD Parameter Programmer & Monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProg_FormClosed);
            this.Load += new System.EventHandler(this.frmProg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewFull)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxtSchedChng.ResumeLayout(false);
            this.ctxtDriveMod.ResumeLayout(false);
            this.grpSetDrive.ResumeLayout(false);
            this.grpSetDrive.PerformLayout();
            this.grpSetDrv.ResumeLayout(false);
            this.grpSetDrv.PerformLayout();
            this.grpSetMach.ResumeLayout(false);
            this.grpSetMach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewMisMatch)).EndInit();
            this.grpDrvComm.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewChng)).EndInit();
            this.grpParamChng.ResumeLayout(false);
            this.grpParamChng.PerformLayout();
            this.grpMtrSet.ResumeLayout(false);
            this.grpMtrSet.PerformLayout();
            this.grpMtr2Set.ResumeLayout(false);
            this.grpMtr2Set.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvParamViewFull;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statProgLabel;
        private System.Windows.Forms.ToolStripProgressBar statProgress;
        private System.Windows.Forms.Button btnVFDRead;
        private System.ComponentModel.BackgroundWorker bwrkReadVFDVals;
        private System.Windows.Forms.Button btnVFDMod;
        private System.ComponentModel.BackgroundWorker bwrkModVFD;
        private System.Windows.Forms.GroupBox grpSetDrive;
        private System.Windows.Forms.ComboBox cmbDrvParamGrp;
        private System.Windows.Forms.GroupBox grpDrvComm;
        private System.Windows.Forms.Button btnVFDReset;
        private System.Windows.Forms.Button btnVFDVer;
        private System.Windows.Forms.ComboBox cmbDrvList;
        private System.Windows.Forms.Label lblParamGroup;
        private System.Windows.Forms.Label lblDriveSel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msFile;
        private System.Windows.Forms.ToolStripMenuItem msFile_LoadParamList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxtDriveMod;
        private System.Windows.Forms.ToolStripMenuItem ctxtDriveMod_Save;
        private System.Windows.Forms.ContextMenuStrip ctxtSchedChng;
        private System.Windows.Forms.ToolStripMenuItem ctxtSchedChng_Save;
        private System.Windows.Forms.Label lblParamFullList;
        private System.Windows.Forms.Label lblParamModSched;
        private System.Windows.Forms.DataGridView dgvParamViewChng;
        private System.Windows.Forms.Label lblVoltMachSupply;
        private System.Windows.Forms.ComboBox cmbMachSupplyVolt;
        private System.Windows.Forms.Label lblVoltMotorMax;
        private System.Windows.Forms.ComboBox cmbMtrVoltMax;
        private System.Windows.Forms.DataGridView dgvParamViewMisMatch;
        private System.Windows.Forms.Label lblParamMismatch;
        private System.Windows.Forms.Label lblFreqMotorBase;
        private System.Windows.Forms.ComboBox cmbMtrFreqBase;
        private System.Windows.Forms.Label lblMotorFLC;
        private System.Windows.Forms.Label lblUnitsAmps1;
        private System.Windows.Forms.TextBox txtMtrFLC;
        private System.Windows.Forms.Button btnMtrSetVals;
        private System.Windows.Forms.GroupBox grpParamChng;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmRegAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmParamNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmParmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmDefVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmVFDVal;
        private System.ComponentModel.BackgroundWorker bwrkVFDVerify;
        private System.Windows.Forms.Label lblDriveDuty;
        private System.Windows.Forms.ComboBox cmbDrvDuty;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMisMatchParamAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMisMatchParamNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMisMatchParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMisMatchDefVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMisMatchReadVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStripMenuItem ctxtSchedChng_Clear;
        private System.Windows.Forms.ToolStripMenuItem ctxtDriveMod_Clear;
        private System.Windows.Forms.Label lblSelMotor;
        private System.Windows.Forms.ComboBox cmbMachSel;
        private System.Windows.Forms.Label lblSelMach;
        private System.Windows.Forms.ComboBox cmbMtrPartNum;
        private System.Windows.Forms.Label lblMotorPartNum;
        private System.Windows.Forms.ToolStripMenuItem ctxtSchedChng_Load;
        private System.Windows.Forms.ComboBox cmbMachSupplyFreq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpMtrSet;
        private System.Windows.Forms.GroupBox grpSetMach;
        private System.Windows.Forms.Button btnMachListStore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMachListLoad;
        private System.Windows.Forms.ComboBox cmbMachDrvNum;
        private System.Windows.Forms.Button btnMtrStore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMachDrvCnt;
        private System.Windows.Forms.ComboBox cmbMachChrtNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMachChrtCnt;
        private System.Windows.Forms.Button btnMachListDel;
        private System.Windows.Forms.TextBox txtMachDrvName;
        private System.Windows.Forms.Button btnMtrDel;
        private System.Windows.Forms.ToolStripMenuItem ctxtSchedChng_Remove;
        private System.Windows.Forms.GroupBox grpSetDrv;
        private System.Windows.Forms.GroupBox grpMtr2Set;
        private System.Windows.Forms.Button btnMtr2SetVals;
        private System.Windows.Forms.TextBox txtMtr2FLC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMtr2PartNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMtr2VoltMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMtr2FreqBase;
        private System.Windows.Forms.ToolStripMenuItem ctxtDriveMod_UpdDefParam;
        private System.Windows.Forms.ToolStripMenuItem ctxtDriveMod_StoreParamList;
    }
}

