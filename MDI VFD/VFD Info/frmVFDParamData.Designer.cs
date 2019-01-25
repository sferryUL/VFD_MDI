namespace MDI_VFD.VFD_Info
{
    partial class frmVFDParamData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvChrtView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvChrtView.Enabled = false;
            this.dgvChrtView.Location = new System.Drawing.Point(12, 65);
            this.dgvChrtView.Name = "dgvChrtView";
            this.dgvChrtView.RowHeadersVisible = false;
            this.dgvChrtView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChrtView.Size = new System.Drawing.Size(600, 355);
            this.dgvChrtView.TabIndex = 41;
            this.dgvChrtView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ParamNum";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle17;
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
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn3.HeaderText = "Parameter Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DefVal";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn4.HeaderText = "Default Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SpecVal";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn5.HeaderText = "Specified Value";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 70;
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
            this.cmbDrvNum.Size = new System.Drawing.Size(52, 21);
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
            this.btnExitCan.Location = new System.Drawing.Point(537, 426);
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
            this.label4.Location = new System.Drawing.Point(376, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Chart Revision:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Drive Duty:";
            // 
            // cmbDrvDuty
            // 
            this.cmbDrvDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrvDuty.FormattingEnabled = true;
            this.cmbDrvDuty.Items.AddRange(new object[] {
            "Heavy Duty",
            "Normal Duty"});
            this.cmbDrvDuty.Location = new System.Drawing.Point(524, 12);
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
            this.txtChrtRev.Location = new System.Drawing.Point(461, 38);
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
            // frmVFDParamData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 461);
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
            this.Name = "frmVFDParamData";
            this.Text = "Parameter Chart Details";
            this.Load += new System.EventHandler(this.frmVFDParamData_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDrvDuty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDrvFam;
        private System.Windows.Forms.TextBox txtChrtRev;
        private System.Windows.Forms.ComboBox cmbMach;
    }
}