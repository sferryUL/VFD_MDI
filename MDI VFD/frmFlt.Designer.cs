namespace MDI_VFD
{
    partial class frmFlt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFltTrc = new System.Windows.Forms.DataGridView();
            this.btnGetVals = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.stat_Flt = new System.Windows.Forms.StatusStrip();
            this.stat_Flt_Prog = new System.Windows.Forms.ToolStripProgressBar();
            this.btnClrVals = new System.Windows.Forms.Button();
            this.dgvFltHst = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmRegAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmFltTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFltTrc)).BeginInit();
            this.stat_Flt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFltHst)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFltTrc
            // 
            this.dgvFltTrc.AllowUserToAddRows = false;
            this.dgvFltTrc.AllowUserToDeleteRows = false;
            this.dgvFltTrc.AllowUserToResizeColumns = false;
            this.dgvFltTrc.AllowUserToResizeRows = false;
            this.dgvFltTrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFltTrc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmRegAddr,
            this.cmMonNum,
            this.cmMonName,
            this.cmMonVal});
            this.dgvFltTrc.Location = new System.Drawing.Point(12, 30);
            this.dgvFltTrc.Name = "dgvFltTrc";
            this.dgvFltTrc.ReadOnly = true;
            this.dgvFltTrc.RowHeadersVisible = false;
            this.dgvFltTrc.Size = new System.Drawing.Size(460, 437);
            this.dgvFltTrc.TabIndex = 0;
            // 
            // btnGetVals
            // 
            this.btnGetVals.Location = new System.Drawing.Point(885, 473);
            this.btnGetVals.Name = "btnGetVals";
            this.btnGetVals.Size = new System.Drawing.Size(100, 23);
            this.btnGetVals.TabIndex = 1;
            this.btnGetVals.Text = "Get Values";
            this.btnGetVals.UseVisualStyleBackColor = true;
            this.btnGetVals.Click += new System.EventHandler(this.btnMonCtrl_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(991, 473);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // stat_Flt
            // 
            this.stat_Flt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stat_Flt_Prog});
            this.stat_Flt.Location = new System.Drawing.Point(0, 480);
            this.stat_Flt.Name = "stat_Flt";
            this.stat_Flt.Size = new System.Drawing.Size(1099, 22);
            this.stat_Flt.TabIndex = 2;
            this.stat_Flt.Text = "statusStrip1";
            this.stat_Flt.Visible = false;
            // 
            // stat_Flt_Prog
            // 
            this.stat_Flt_Prog.MarqueeAnimationSpeed = 10;
            this.stat_Flt_Prog.Name = "stat_Flt_Prog";
            this.stat_Flt_Prog.Size = new System.Drawing.Size(470, 16);
            this.stat_Flt_Prog.Step = 1;
            this.stat_Flt_Prog.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.stat_Flt_Prog.Value = 100;
            // 
            // btnClrVals
            // 
            this.btnClrVals.Location = new System.Drawing.Point(779, 473);
            this.btnClrVals.Name = "btnClrVals";
            this.btnClrVals.Size = new System.Drawing.Size(100, 23);
            this.btnClrVals.TabIndex = 3;
            this.btnClrVals.Text = "Clear Values";
            this.btnClrVals.UseVisualStyleBackColor = true;
            this.btnClrVals.Click += new System.EventHandler(this.btnClrVals_Click);
            // 
            // dgvFltHst
            // 
            this.dgvFltHst.AllowUserToAddRows = false;
            this.dgvFltHst.AllowUserToDeleteRows = false;
            this.dgvFltHst.AllowUserToResizeColumns = false;
            this.dgvFltHst.AllowUserToResizeRows = false;
            this.dgvFltHst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFltHst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.cmFltTime});
            this.dgvFltHst.Location = new System.Drawing.Point(506, 30);
            this.dgvFltHst.Name = "dgvFltHst";
            this.dgvFltHst.ReadOnly = true;
            this.dgvFltHst.RowHeadersVisible = false;
            this.dgvFltHst.Size = new System.Drawing.Size(585, 437);
            this.dgvFltHst.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fault Trace:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fault History:";
            // 
            // cmRegAddr
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cmRegAddr.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmRegAddr.HeaderText = "Register Address";
            this.cmRegAddr.Name = "cmRegAddr";
            this.cmRegAddr.ReadOnly = true;
            this.cmRegAddr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmRegAddr.Width = 65;
            // 
            // cmMonNum
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cmMonNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmMonNum.HeaderText = "Fault Number";
            this.cmMonNum.Name = "cmMonNum";
            this.cmMonNum.ReadOnly = true;
            this.cmMonNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMonNum.Width = 65;
            // 
            // cmMonName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cmMonName.DefaultCellStyle = dataGridViewCellStyle3;
            this.cmMonName.HeaderText = "Fault Name";
            this.cmMonName.Name = "cmMonName";
            this.cmMonName.ReadOnly = true;
            this.cmMonName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMonName.Width = 250;
            // 
            // cmMonVal
            // 
            this.cmMonVal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmMonVal.HeaderText = "Fault Value";
            this.cmMonVal.Name = "cmMonVal";
            this.cmMonVal.ReadOnly = true;
            this.cmMonVal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Register Address";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Fault Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Fault Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Fault Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmFltTime
            // 
            this.cmFltTime.HeaderText = "Fault Time";
            this.cmFltTime.Name = "cmFltTime";
            this.cmFltTime.ReadOnly = true;
            // 
            // frmFlt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 502);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFltHst);
            this.Controls.Add(this.btnClrVals);
            this.Controls.Add(this.stat_Flt);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGetVals);
            this.Controls.Add(this.dgvFltTrc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFlt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Drive Fault Data";
            this.Load += new System.EventHandler(this.frmFlt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFltTrc)).EndInit();
            this.stat_Flt.ResumeLayout(false);
            this.stat_Flt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFltHst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFltTrc;
        private System.Windows.Forms.Button btnGetVals;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.StatusStrip stat_Flt;
        private System.Windows.Forms.ToolStripProgressBar stat_Flt_Prog;
        private System.Windows.Forms.Button btnClrVals;
        private System.Windows.Forms.DataGridView dgvFltHst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmRegAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmFltTime;
    }
}