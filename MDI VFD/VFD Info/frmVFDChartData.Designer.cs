namespace MDI_VFD.VFD_Info
{
    partial class frmVFDChartData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvChrtView = new System.Windows.Forms.DataGridView();
            this.dgvChrtView_cmParamNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChrtView_cmParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChrtView_cmDefVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChrtView_cmSpecVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChrtNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDrvNum = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExitCan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDrvDuty = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDrvFam = new System.Windows.Forms.ComboBox();
            this.txtChrtRev = new System.Windows.Forms.TextBox();
            this.cmbMach = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChrtView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChrtView
            // 
            this.dgvChrtView.AllowUserToAddRows = false;
            this.dgvChrtView.AllowUserToDeleteRows = false;
            this.dgvChrtView.AllowUserToResizeColumns = false;
            this.dgvChrtView.AllowUserToResizeRows = false;
            this.dgvChrtView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChrtView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvChrtView_cmParamNum,
            this.dgvChrtView_cmParamName,
            this.dgvChrtView_cmDefVal,
            this.dgvChrtView_cmSpecVal});
            this.dgvChrtView.Location = new System.Drawing.Point(12, 65);
            this.dgvChrtView.MultiSelect = false;
            this.dgvChrtView.Name = "dgvChrtView";
            this.dgvChrtView.RowHeadersVisible = false;
            this.dgvChrtView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChrtView.Size = new System.Drawing.Size(600, 579);
            this.dgvChrtView.TabIndex = 41;
            this.dgvChrtView.TabStop = false;
            this.dgvChrtView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvChrtView_CellBeginEdit);
            this.dgvChrtView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChrtView_CellEndEdit);
            // 
            // dgvChrtView_cmParamNum
            // 
            this.dgvChrtView_cmParamNum.DataPropertyName = "ParamNum";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChrtView_cmParamNum.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvChrtView_cmParamNum.HeaderText = "Parameter Number";
            this.dgvChrtView_cmParamNum.Name = "dgvChrtView_cmParamNum";
            this.dgvChrtView_cmParamNum.ReadOnly = true;
            this.dgvChrtView_cmParamNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChrtView_cmParamNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvChrtView_cmParamNum.Width = 60;
            // 
            // dgvChrtView_cmParamName
            // 
            this.dgvChrtView_cmParamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvChrtView_cmParamName.DataPropertyName = "ParamName";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvChrtView_cmParamName.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvChrtView_cmParamName.HeaderText = "Parameter Name";
            this.dgvChrtView_cmParamName.Name = "dgvChrtView_cmParamName";
            this.dgvChrtView_cmParamName.ReadOnly = true;
            this.dgvChrtView_cmParamName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvChrtView_cmDefVal
            // 
            this.dgvChrtView_cmDefVal.DataPropertyName = "DefVal";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChrtView_cmDefVal.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvChrtView_cmDefVal.HeaderText = "Default Value";
            this.dgvChrtView_cmDefVal.Name = "dgvChrtView_cmDefVal";
            this.dgvChrtView_cmDefVal.ReadOnly = true;
            this.dgvChrtView_cmDefVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvChrtView_cmDefVal.Width = 70;
            // 
            // dgvChrtView_cmSpecVal
            // 
            this.dgvChrtView_cmSpecVal.DataPropertyName = "SpecVal";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChrtView_cmSpecVal.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvChrtView_cmSpecVal.HeaderText = "Specified Value";
            this.dgvChrtView_cmSpecVal.Name = "dgvChrtView_cmSpecVal";
            this.dgvChrtView_cmSpecVal.ReadOnly = true;
            this.dgvChrtView_cmSpecVal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChrtView_cmSpecVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvChrtView_cmSpecVal.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Machine:";
            // 
            // txtChrtNum
            // 
            this.txtChrtNum.Location = new System.Drawing.Point(93, 38);
            this.txtChrtNum.Name = "txtChrtNum";
            this.txtChrtNum.ReadOnly = true;
            this.txtChrtNum.Size = new System.Drawing.Size(81, 20);
            this.txtChrtNum.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Chart Number:";
            // 
            // cmbDrvNum
            // 
            this.cmbDrvNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvNum.Enabled = false;
            this.cmbDrvNum.FormattingEnabled = true;
            this.cmbDrvNum.Location = new System.Drawing.Point(272, 38);
            this.cmbDrvNum.Name = "cmbDrvNum";
            this.cmbDrvNum.Size = new System.Drawing.Size(32, 21);
            this.cmbDrvNum.TabIndex = 46;
            this.cmbDrvNum.SelectedIndexChanged += new System.EventHandler(this.cmbDrvNum_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Drive Number:";
            // 
            // btnExitCan
            // 
            this.btnExitCan.Location = new System.Drawing.Point(537, 650);
            this.btnExitCan.Name = "btnExitCan";
            this.btnExitCan.Size = new System.Drawing.Size(75, 23);
            this.btnExitCan.TabIndex = 48;
            this.btnExitCan.Text = "Exit";
            this.btnExitCan.UseVisualStyleBackColor = true;
            this.btnExitCan.Click += new System.EventHandler(this.btnExitCan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Chart Revision:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 655);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Default Value Display:";
            // 
            // cmbDrvDuty
            // 
            this.cmbDrvDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvDuty.FormattingEnabled = true;
            this.cmbDrvDuty.Items.AddRange(new object[] {
            "Heavy Duty",
            "Normal Duty"});
            this.cmbDrvDuty.Location = new System.Drawing.Point(129, 652);
            this.cmbDrvDuty.Name = "cmbDrvDuty";
            this.cmbDrvDuty.Size = new System.Drawing.Size(88, 21);
            this.cmbDrvDuty.TabIndex = 51;
            this.cmbDrvDuty.SelectedIndexChanged += new System.EventHandler(this.cmbDrvDuty_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Drive Family:";
            // 
            // cmbDrvFam
            // 
            this.cmbDrvFam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvFam.Enabled = false;
            this.cmbDrvFam.FormattingEnabled = true;
            this.cmbDrvFam.Location = new System.Drawing.Point(364, 12);
            this.cmbDrvFam.Name = "cmbDrvFam";
            this.cmbDrvFam.Size = new System.Drawing.Size(88, 21);
            this.cmbDrvFam.TabIndex = 53;
            this.cmbDrvFam.SelectedIndexChanged += new System.EventHandler(this.cmbDrvFam_SelectedIndexChanged);
            // 
            // txtChrtRev
            // 
            this.txtChrtRev.Enabled = false;
            this.txtChrtRev.Location = new System.Drawing.Point(421, 38);
            this.txtChrtRev.Name = "txtChrtRev";
            this.txtChrtRev.ReadOnly = true;
            this.txtChrtRev.Size = new System.Drawing.Size(44, 20);
            this.txtChrtRev.TabIndex = 55;
            // 
            // cmbMach
            // 
            this.cmbMach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMach.Enabled = false;
            this.cmbMach.FormattingEnabled = true;
            this.cmbMach.Location = new System.Drawing.Point(93, 11);
            this.cmbMach.Name = "cmbMach";
            this.cmbMach.Size = new System.Drawing.Size(180, 21);
            this.cmbMach.TabIndex = 56;
            this.cmbMach.SelectedIndexChanged += new System.EventHandler(this.cmbMach_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(375, 650);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(456, 650);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 58;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // frmVFDChartData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 685);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbMach);
            this.Controls.Add(this.txtChrtRev);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDrvFam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDrvDuty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExitCan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDrvNum);
            this.Controls.Add(this.txtChrtNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChrtView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVFDChartData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parameter Chart Details";
            this.Load += new System.EventHandler(this.frmVFDParamData_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVFDChartData_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChrtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChrtView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChrtNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDrvNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExitCan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDrvDuty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDrvFam;
        private System.Windows.Forms.TextBox txtChrtRev;
        private System.Windows.Forms.ComboBox cmbMach;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtView_cmParamNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtView_cmParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtView_cmDefVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtView_cmSpecVal;
        private System.Windows.Forms.Button btnModify;
    }
}