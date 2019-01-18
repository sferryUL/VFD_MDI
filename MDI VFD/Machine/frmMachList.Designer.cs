namespace MDI_VFD.Machine
{
    partial class frmMachList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMachList = new System.Windows.Forms.DataGridView();
            this.cmMachList_MachModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMachList_ModDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMachList_MtrCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMachList_DrvCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMachList_ChrtCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMachList
            // 
            this.dgvMachList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMachList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMachList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMachList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmMachList_MachModel,
            this.cmMachList_ModDesc,
            this.cmMachList_MtrCnt,
            this.cmMachList_DrvCnt,
            this.cmMachList_ChrtCnt});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMachList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMachList.Location = new System.Drawing.Point(12, 12);
            this.dgvMachList.MultiSelect = false;
            this.dgvMachList.Name = "dgvMachList";
            this.dgvMachList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMachList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMachList.RowHeadersVisible = false;
            this.dgvMachList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMachList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMachList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMachList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMachList.Size = new System.Drawing.Size(581, 317);
            this.dgvMachList.TabIndex = 0;
            this.dgvMachList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMachList_CellDoubleClick);
            // 
            // cmMachList_MachModel
            // 
            this.cmMachList_MachModel.DataPropertyName = "MACH_CODE";
            this.cmMachList_MachModel.HeaderText = "Machine Model";
            this.cmMachList_MachModel.Name = "cmMachList_MachModel";
            this.cmMachList_MachModel.ReadOnly = true;
            this.cmMachList_MachModel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMachList_MachModel.Width = 75;
            // 
            // cmMachList_ModDesc
            // 
            this.cmMachList_ModDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmMachList_ModDesc.DataPropertyName = "MACH_DESC";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.cmMachList_ModDesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmMachList_ModDesc.HeaderText = "Model Description";
            this.cmMachList_ModDesc.Name = "cmMachList_ModDesc";
            this.cmMachList_ModDesc.ReadOnly = true;
            this.cmMachList_ModDesc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmMachList_MtrCnt
            // 
            this.cmMachList_MtrCnt.DataPropertyName = "MTR_CNT";
            this.cmMachList_MtrCnt.HeaderText = "Motor Count";
            this.cmMachList_MtrCnt.Name = "cmMachList_MtrCnt";
            this.cmMachList_MtrCnt.ReadOnly = true;
            this.cmMachList_MtrCnt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMachList_MtrCnt.Width = 60;
            // 
            // cmMachList_DrvCnt
            // 
            this.cmMachList_DrvCnt.DataPropertyName = "DRV_CNT";
            this.cmMachList_DrvCnt.HeaderText = "VFD Count";
            this.cmMachList_DrvCnt.Name = "cmMachList_DrvCnt";
            this.cmMachList_DrvCnt.ReadOnly = true;
            this.cmMachList_DrvCnt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMachList_DrvCnt.Width = 60;
            // 
            // cmMachList_ChrtCnt
            // 
            this.cmMachList_ChrtCnt.DataPropertyName = "CHRT_CNT";
            this.cmMachList_ChrtCnt.HeaderText = "Parameter Chart Count";
            this.cmMachList_ChrtCnt.Name = "cmMachList_ChrtCnt";
            this.cmMachList_ChrtCnt.ReadOnly = true;
            this.cmMachList_ChrtCnt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMachList_ChrtCnt.Width = 90;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(437, 335);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(518, 335);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMachList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 366);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dgvMachList);
            this.Name = "frmMachList";
            this.Text = "Urschel Machine Listing";
            this.Load += new System.EventHandler(this.frmMachList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMachList;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMachList_MachModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMachList_ModDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMachList_MtrCnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMachList_DrvCnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMachList_ChrtCnt;
    }
}