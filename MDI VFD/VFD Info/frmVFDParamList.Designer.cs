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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvChrtList = new System.Windows.Forms.DataGridView();
            this.dgvChrtList_cmMachCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChrtList_cmChrtNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChrtList_cmParamStored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChrtList_cmChrtDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbChrtLst = new System.Windows.Forms.ComboBox();
            this.cmbSrchCode = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbMachCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChrtRev = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChrtList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChrtList
            // 
            this.dgvChrtList.AllowUserToAddRows = false;
            this.dgvChrtList.AllowUserToDeleteRows = false;
            this.dgvChrtList.AllowUserToResizeColumns = false;
            this.dgvChrtList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChrtList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChrtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChrtList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvChrtList_cmMachCode,
            this.dgvChrtList_cmChrtNum,
            this.dgvChrtList_cmParamStored,
            this.dgvChrtList_cmChrtDesc});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChrtList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChrtList.Location = new System.Drawing.Point(12, 96);
            this.dgvChrtList.MultiSelect = false;
            this.dgvChrtList.Name = "dgvChrtList";
            this.dgvChrtList.ReadOnly = true;
            this.dgvChrtList.RowHeadersVisible = false;
            this.dgvChrtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChrtList.Size = new System.Drawing.Size(640, 247);
            this.dgvChrtList.TabIndex = 0;
            this.dgvChrtList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChrtList_CellDoubleClick);
            // 
            // dgvChrtList_cmMachCode
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvChrtList_cmMachCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChrtList_cmMachCode.Frozen = true;
            this.dgvChrtList_cmMachCode.HeaderText = "Machine";
            this.dgvChrtList_cmMachCode.Name = "dgvChrtList_cmMachCode";
            this.dgvChrtList_cmMachCode.ReadOnly = true;
            // 
            // dgvChrtList_cmChrtNum
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvChrtList_cmChrtNum.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChrtList_cmChrtNum.HeaderText = "Chart Number";
            this.dgvChrtList_cmChrtNum.Name = "dgvChrtList_cmChrtNum";
            this.dgvChrtList_cmChrtNum.ReadOnly = true;
            this.dgvChrtList_cmChrtNum.Width = 65;
            // 
            // dgvChrtList_cmParamStored
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvChrtList_cmParamStored.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChrtList_cmParamStored.HeaderText = "Chart Revision";
            this.dgvChrtList_cmParamStored.Name = "dgvChrtList_cmParamStored";
            this.dgvChrtList_cmParamStored.ReadOnly = true;
            this.dgvChrtList_cmParamStored.Width = 60;
            // 
            // dgvChrtList_cmChrtDesc
            // 
            this.dgvChrtList_cmChrtDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.dgvChrtList_cmChrtDesc.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChrtList_cmChrtDesc.HeaderText = "Chart Description";
            this.dgvChrtList_cmChrtDesc.Name = "dgvChrtList_cmChrtDesc";
            this.dgvChrtList_cmChrtDesc.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Urschel VFD Chart Part Number:";
            // 
            // cmbChrtLst
            // 
            this.cmbChrtLst.FormattingEnabled = true;
            this.cmbChrtLst.Location = new System.Drawing.Point(178, 14);
            this.cmbChrtLst.Name = "cmbChrtLst";
            this.cmbChrtLst.Size = new System.Drawing.Size(95, 21);
            this.cmbChrtLst.TabIndex = 2;
            // 
            // cmbSrchCode
            // 
            this.cmbSrchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchCode.FormattingEnabled = true;
            this.cmbSrchCode.Items.AddRange(new object[] {
            "Starts with",
            "Contains",
            "Equals"});
            this.cmbSrchCode.Location = new System.Drawing.Point(279, 14);
            this.cmbSrchCode.Name = "cmbSrchCode";
            this.cmbSrchCode.Size = new System.Drawing.Size(81, 21);
            this.cmbSrchCode.TabIndex = 3;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(577, 40);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(577, 67);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(577, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbMachCode
            // 
            this.cmbMachCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachCode.FormattingEnabled = true;
            this.cmbMachCode.Location = new System.Drawing.Point(178, 69);
            this.cmbMachCode.Name = "cmbMachCode";
            this.cmbMachCode.Size = new System.Drawing.Size(95, 21);
            this.cmbMachCode.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Machine Code:";
            // 
            // cmbChrtRev
            // 
            this.cmbChrtRev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChrtRev.FormattingEnabled = true;
            this.cmbChrtRev.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbChrtRev.Location = new System.Drawing.Point(178, 42);
            this.cmbChrtRev.Name = "cmbChrtRev";
            this.cmbChrtRev.Size = new System.Drawing.Size(95, 21);
            this.cmbChrtRev.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Drive Count:";
            // 
            // frmVFDParamList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 356);
            this.Controls.Add(this.cmbChrtRev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMachCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSrchCode);
            this.Controls.Add(this.cmbChrtLst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChrtList);
            this.Name = "frmVFDParamList";
            this.Text = "Parameter Chart Listing";
            this.Load += new System.EventHandler(this.frmVFDParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChrtList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChrtList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChrtLst;
        private System.Windows.Forms.ComboBox cmbSrchCode;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbMachCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbChrtRev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtList_cmMachCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtList_cmChrtNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtList_cmParamStored;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvChrtList_cmChrtDesc;
    }
}