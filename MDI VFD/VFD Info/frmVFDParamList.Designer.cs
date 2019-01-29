namespace MDI_VFD.VFD_Info
{
    partial class frmVFDParamList
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
            if(disposing && (components != null))
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvParamViewFull = new System.Windows.Forms.DataGridView();
            this.cmRegAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmParamNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmParmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmDefVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmVFDVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpSetDrv = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDrvFam = new System.Windows.Forms.ComboBox();
            this.lblDriveSel = new System.Windows.Forms.Label();
            this.cmbDrvParamGrp = new System.Windows.Forms.ComboBox();
            this.cmbDrvList = new System.Windows.Forms.ComboBox();
            this.lblParamGroup = new System.Windows.Forms.Label();
            this.lblDriveDuty = new System.Windows.Forms.Label();
            this.cmbDrvDuty = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewFull)).BeginInit();
            this.grpSetDrv.SuspendLayout();
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
            this.dgvParamViewFull.Location = new System.Drawing.Point(12, 125);
            this.dgvParamViewFull.Name = "dgvParamViewFull";
            this.dgvParamViewFull.RowHeadersVisible = false;
            this.dgvParamViewFull.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParamViewFull.Size = new System.Drawing.Size(610, 637);
            this.dgvParamViewFull.TabIndex = 37;
            this.dgvParamViewFull.TabStop = false;
            // 
            // cmRegAddr
            // 
            this.cmRegAddr.DataPropertyName = "RegAddress";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmRegAddr.DefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmParamNum.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cmParmName.DefaultCellStyle = dataGridViewCellStyle8;
            this.cmParmName.HeaderText = "Parameter Name";
            this.cmParmName.Name = "cmParmName";
            this.cmParmName.ReadOnly = true;
            this.cmParmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmDefVal
            // 
            this.cmDefVal.DataPropertyName = "DefVal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmDefVal.DefaultCellStyle = dataGridViewCellStyle9;
            this.cmDefVal.HeaderText = "Default Value";
            this.cmDefVal.Name = "cmDefVal";
            this.cmDefVal.ReadOnly = true;
            this.cmDefVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmDefVal.Width = 70;
            // 
            // cmVFDVal
            // 
            this.cmVFDVal.DataPropertyName = "VFDVal";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cmVFDVal.DefaultCellStyle = dataGridViewCellStyle10;
            this.cmVFDVal.HeaderText = "VFD Value";
            this.cmVFDVal.Name = "cmVFDVal";
            this.cmVFDVal.ReadOnly = true;
            this.cmVFDVal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmVFDVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmVFDVal.Width = 70;
            // 
            // grpSetDrv
            // 
            this.grpSetDrv.Controls.Add(this.label6);
            this.grpSetDrv.Controls.Add(this.cmbDrvFam);
            this.grpSetDrv.Controls.Add(this.lblDriveSel);
            this.grpSetDrv.Controls.Add(this.cmbDrvParamGrp);
            this.grpSetDrv.Controls.Add(this.cmbDrvList);
            this.grpSetDrv.Controls.Add(this.lblParamGroup);
            this.grpSetDrv.Location = new System.Drawing.Point(12, 12);
            this.grpSetDrv.Name = "grpSetDrv";
            this.grpSetDrv.Size = new System.Drawing.Size(611, 107);
            this.grpSetDrv.TabIndex = 52;
            this.grpSetDrv.TabStop = false;
            this.grpSetDrv.Text = "Drive Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Drive Family:";
            // 
            // cmbDrvFam
            // 
            this.cmbDrvFam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvFam.Enabled = false;
            this.cmbDrvFam.FormattingEnabled = true;
            this.cmbDrvFam.Location = new System.Drawing.Point(104, 19);
            this.cmbDrvFam.Name = "cmbDrvFam";
            this.cmbDrvFam.Size = new System.Drawing.Size(152, 21);
            this.cmbDrvFam.TabIndex = 55;
            // 
            // lblDriveSel
            // 
            this.lblDriveSel.AutoSize = true;
            this.lblDriveSel.Location = new System.Drawing.Point(16, 49);
            this.lblDriveSel.Name = "lblDriveSel";
            this.lblDriveSel.Size = new System.Drawing.Size(82, 13);
            this.lblDriveSel.TabIndex = 40;
            this.lblDriveSel.Text = "Drive Selection:";
            // 
            // cmbDrvParamGrp
            // 
            this.cmbDrvParamGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvParamGrp.Enabled = false;
            this.cmbDrvParamGrp.FormattingEnabled = true;
            this.cmbDrvParamGrp.Location = new System.Drawing.Point(104, 73);
            this.cmbDrvParamGrp.Name = "cmbDrvParamGrp";
            this.cmbDrvParamGrp.Size = new System.Drawing.Size(277, 21);
            this.cmbDrvParamGrp.TabIndex = 1;
            // 
            // cmbDrvList
            // 
            this.cmbDrvList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvList.FormattingEnabled = true;
            this.cmbDrvList.Location = new System.Drawing.Point(104, 46);
            this.cmbDrvList.Name = "cmbDrvList";
            this.cmbDrvList.Size = new System.Drawing.Size(277, 21);
            this.cmbDrvList.TabIndex = 0;
            // 
            // lblParamGroup
            // 
            this.lblParamGroup.AutoSize = true;
            this.lblParamGroup.Location = new System.Drawing.Point(8, 76);
            this.lblParamGroup.Name = "lblParamGroup";
            this.lblParamGroup.Size = new System.Drawing.Size(90, 13);
            this.lblParamGroup.TabIndex = 41;
            this.lblParamGroup.Text = "Parameter Group:";
            // 
            // lblDriveDuty
            // 
            this.lblDriveDuty.AutoSize = true;
            this.lblDriveDuty.Location = new System.Drawing.Point(12, 773);
            this.lblDriveDuty.Name = "lblDriveDuty";
            this.lblDriveDuty.Size = new System.Drawing.Size(107, 13);
            this.lblDriveDuty.TabIndex = 49;
            this.lblDriveDuty.Text = "Drive Default Values:";
            // 
            // cmbDrvDuty
            // 
            this.cmbDrvDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvDuty.Enabled = false;
            this.cmbDrvDuty.FormattingEnabled = true;
            this.cmbDrvDuty.Items.AddRange(new object[] {
            "Heavy Duty",
            "Normal Duty"});
            this.cmbDrvDuty.Location = new System.Drawing.Point(125, 768);
            this.cmbDrvDuty.Name = "cmbDrvDuty";
            this.cmbDrvDuty.Size = new System.Drawing.Size(115, 21);
            this.cmbDrvDuty.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(547, 768);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 53;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmVFDParamList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 813);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpSetDrv);
            this.Controls.Add(this.lblDriveDuty);
            this.Controls.Add(this.dgvParamViewFull);
            this.Controls.Add(this.cmbDrvDuty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVFDParamList";
            this.Text = "Parameter Listing";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamViewFull)).EndInit();
            this.grpSetDrv.ResumeLayout(false);
            this.grpSetDrv.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParamViewFull;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmRegAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmParamNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmParmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmDefVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmVFDVal;
        private System.Windows.Forms.GroupBox grpSetDrv;
        private System.Windows.Forms.Label lblDriveSel;
        private System.Windows.Forms.ComboBox cmbDrvParamGrp;
        private System.Windows.Forms.ComboBox cmbDrvList;
        private System.Windows.Forms.Label lblParamGroup;
        private System.Windows.Forms.Label lblDriveDuty;
        private System.Windows.Forms.ComboBox cmbDrvDuty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDrvFam;
        private System.Windows.Forms.Button button1;
    }
}