namespace MDI_VFD.Motor
{
    partial class frmMtrInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSrchRes = new System.Windows.Forms.DataGridView();
            this.cmMtrInf_MtrNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMtrInf_HP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMtrInf_MtrPoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMtrInf_MtrConst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMtrInf_MtrMfr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSrchCode = new System.Windows.Forms.ComboBox();
            this.cmbMtrMfr = new System.Windows.Forms.ComboBox();
            this.cmbMtrPoles = new System.Windows.Forms.ComboBox();
            this.cmbMtrConst = new System.Windows.Forms.ComboBox();
            this.cmbMtrHP = new System.Windows.Forms.ComboBox();
            this.cmbMtrNum = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSrchRes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motor Urschel Part Number:";
            // 
            // dgvSrchRes
            // 
            this.dgvSrchRes.AllowUserToAddRows = false;
            this.dgvSrchRes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSrchRes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSrchRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSrchRes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmMtrInf_MtrNum,
            this.cmMtrInf_HP,
            this.cmMtrInf_MtrPoles,
            this.cmMtrInf_MtrConst,
            this.cmMtrInf_MtrMfr});
            this.dgvSrchRes.Location = new System.Drawing.Point(12, 124);
            this.dgvSrchRes.Name = "dgvSrchRes";
            this.dgvSrchRes.ReadOnly = true;
            this.dgvSrchRes.RowHeadersVisible = false;
            this.dgvSrchRes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSrchRes.Size = new System.Drawing.Size(455, 216);
            this.dgvSrchRes.TabIndex = 9;
            this.dgvSrchRes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSrchRes_CellDoubleClick);
            // 
            // cmMtrInf_MtrNum
            // 
            this.cmMtrInf_MtrNum.DataPropertyName = "MTR_NUM";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cmMtrInf_MtrNum.DefaultCellStyle = dataGridViewCellStyle8;
            this.cmMtrInf_MtrNum.HeaderText = "Part Number";
            this.cmMtrInf_MtrNum.Name = "cmMtrInf_MtrNum";
            this.cmMtrInf_MtrNum.ReadOnly = true;
            this.cmMtrInf_MtrNum.Width = 75;
            // 
            // cmMtrInf_HP
            // 
            this.cmMtrInf_HP.DataPropertyName = "MTR_HP";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cmMtrInf_HP.DefaultCellStyle = dataGridViewCellStyle9;
            this.cmMtrInf_HP.HeaderText = "Horsepower";
            this.cmMtrInf_HP.Name = "cmMtrInf_HP";
            this.cmMtrInf_HP.ReadOnly = true;
            this.cmMtrInf_HP.Width = 75;
            // 
            // cmMtrInf_MtrPoles
            // 
            this.cmMtrInf_MtrPoles.DataPropertyName = "MTR_POLES";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cmMtrInf_MtrPoles.DefaultCellStyle = dataGridViewCellStyle10;
            this.cmMtrInf_MtrPoles.HeaderText = "Pole Count";
            this.cmMtrInf_MtrPoles.Name = "cmMtrInf_MtrPoles";
            this.cmMtrInf_MtrPoles.ReadOnly = true;
            // 
            // cmMtrInf_MtrConst
            // 
            this.cmMtrInf_MtrConst.DataPropertyName = "MTR_CONST";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cmMtrInf_MtrConst.DefaultCellStyle = dataGridViewCellStyle11;
            this.cmMtrInf_MtrConst.HeaderText = "Construction";
            this.cmMtrInf_MtrConst.Name = "cmMtrInf_MtrConst";
            this.cmMtrInf_MtrConst.ReadOnly = true;
            // 
            // cmMtrInf_MtrMfr
            // 
            this.cmMtrInf_MtrMfr.DataPropertyName = "MTR_MFR";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cmMtrInf_MtrMfr.DefaultCellStyle = dataGridViewCellStyle12;
            this.cmMtrInf_MtrMfr.HeaderText = "Manufacturer";
            this.cmMtrInf_MtrMfr.Name = "cmMtrInf_MtrMfr";
            this.cmMtrInf_MtrMfr.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(374, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(374, 45);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(374, 72);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSrchCode);
            this.groupBox1.Controls.Add(this.cmbMtrMfr);
            this.groupBox1.Controls.Add(this.cmbMtrPoles);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cmbMtrConst);
            this.groupBox1.Controls.Add(this.cmbMtrHP);
            this.groupBox1.Controls.Add(this.cmbMtrNum);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 106);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motor Parameters";
            // 
            // cmbSrchCode
            // 
            this.cmbSrchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSrchCode.FormattingEnabled = true;
            this.cmbSrchCode.Items.AddRange(new object[] {
            "Equals",
            "Contains"});
            this.cmbSrchCode.Location = new System.Drawing.Point(258, 19);
            this.cmbSrchCode.Name = "cmbSrchCode";
            this.cmbSrchCode.Size = new System.Drawing.Size(81, 21);
            this.cmbSrchCode.TabIndex = 1;
            // 
            // cmbMtrMfr
            // 
            this.cmbMtrMfr.FormattingEnabled = true;
            this.cmbMtrMfr.Location = new System.Drawing.Point(244, 74);
            this.cmbMtrMfr.Name = "cmbMtrMfr";
            this.cmbMtrMfr.Size = new System.Drawing.Size(95, 21);
            this.cmbMtrMfr.TabIndex = 5;
            // 
            // cmbMtrPoles
            // 
            this.cmbMtrPoles.FormattingEnabled = true;
            this.cmbMtrPoles.Location = new System.Drawing.Point(79, 71);
            this.cmbMtrPoles.Name = "cmbMtrPoles";
            this.cmbMtrPoles.Size = new System.Drawing.Size(67, 21);
            this.cmbMtrPoles.TabIndex = 3;
            // 
            // cmbMtrConst
            // 
            this.cmbMtrConst.FormattingEnabled = true;
            this.cmbMtrConst.Location = new System.Drawing.Point(244, 47);
            this.cmbMtrConst.Name = "cmbMtrConst";
            this.cmbMtrConst.Size = new System.Drawing.Size(95, 21);
            this.cmbMtrConst.TabIndex = 4;
            // 
            // cmbMtrHP
            // 
            this.cmbMtrHP.FormattingEnabled = true;
            this.cmbMtrHP.Location = new System.Drawing.Point(79, 47);
            this.cmbMtrHP.Name = "cmbMtrHP";
            this.cmbMtrHP.Size = new System.Drawing.Size(67, 21);
            this.cmbMtrHP.TabIndex = 2;
            // 
            // cmbMtrNum
            // 
            this.cmbMtrNum.FormattingEnabled = true;
            this.cmbMtrNum.Location = new System.Drawing.Point(152, 19);
            this.cmbMtrNum.Name = "cmbMtrNum";
            this.cmbMtrNum.Size = new System.Drawing.Size(96, 21);
            this.cmbMtrNum.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Manufacturer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Construction:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pole Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Horsepower:";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(392, 346);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMtrInfo
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(479, 381);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSrchRes);
            this.Name = "frmMtrInfo";
            this.Text = "Motor Search";
            this.Load += new System.EventHandler(this.frmMtrInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSrchRes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSrchRes;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMtrMfr;
        private System.Windows.Forms.ComboBox cmbMtrPoles;
        private System.Windows.Forms.ComboBox cmbMtrConst;
        private System.Windows.Forms.ComboBox cmbMtrHP;
        private System.Windows.Forms.ComboBox cmbMtrNum;
        private System.Windows.Forms.ComboBox cmbSrchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMtrInf_MtrNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMtrInf_HP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMtrInf_MtrPoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMtrInf_MtrConst;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMtrInf_MtrMfr;
        private System.Windows.Forms.Button btnExit;
    }
}