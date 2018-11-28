namespace MDI_VFD
{
    partial class frmMonMaint
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
            this.dgvMonMaint = new System.Windows.Forms.DataGridView();
            this.btnGetVals = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.stat_Maint = new System.Windows.Forms.StatusStrip();
            this.stat_Maint_Prog = new System.Windows.Forms.ToolStripProgressBar();
            this.cmRegAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClrVals = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonMaint)).BeginInit();
            this.stat_Maint.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMonMaint
            // 
            this.dgvMonMaint.AllowUserToAddRows = false;
            this.dgvMonMaint.AllowUserToDeleteRows = false;
            this.dgvMonMaint.AllowUserToResizeColumns = false;
            this.dgvMonMaint.AllowUserToResizeRows = false;
            this.dgvMonMaint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonMaint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmRegAddr,
            this.cmMonNum,
            this.cmMonName,
            this.cmMonVal});
            this.dgvMonMaint.Location = new System.Drawing.Point(12, 12);
            this.dgvMonMaint.Name = "dgvMonMaint";
            this.dgvMonMaint.ReadOnly = true;
            this.dgvMonMaint.RowHeadersVisible = false;
            this.dgvMonMaint.Size = new System.Drawing.Size(460, 455);
            this.dgvMonMaint.TabIndex = 0;
            // 
            // btnGetVals
            // 
            this.btnGetVals.Location = new System.Drawing.Point(266, 473);
            this.btnGetVals.Name = "btnGetVals";
            this.btnGetVals.Size = new System.Drawing.Size(100, 23);
            this.btnGetVals.TabIndex = 1;
            this.btnGetVals.Text = "Get Values";
            this.btnGetVals.UseVisualStyleBackColor = true;
            this.btnGetVals.Click += new System.EventHandler(this.btnMonCtrl_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(372, 473);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // stat_Maint
            // 
            this.stat_Maint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stat_Maint_Prog});
            this.stat_Maint.Location = new System.Drawing.Point(0, 502);
            this.stat_Maint.Name = "stat_Maint";
            this.stat_Maint.Size = new System.Drawing.Size(484, 22);
            this.stat_Maint.TabIndex = 2;
            this.stat_Maint.Text = "statusStrip1";
            this.stat_Maint.Visible = false;
            // 
            // stat_Maint_Prog
            // 
            this.stat_Maint_Prog.MarqueeAnimationSpeed = 10;
            this.stat_Maint_Prog.Name = "stat_Maint_Prog";
            this.stat_Maint_Prog.Size = new System.Drawing.Size(470, 16);
            this.stat_Maint_Prog.Step = 1;
            this.stat_Maint_Prog.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.stat_Maint_Prog.Value = 100;
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
            this.cmMonNum.HeaderText = "Monitor Number";
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
            this.cmMonName.HeaderText = "Monitor Name";
            this.cmMonName.Name = "cmMonName";
            this.cmMonName.ReadOnly = true;
            this.cmMonName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmMonName.Width = 250;
            // 
            // cmMonVal
            // 
            this.cmMonVal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmMonVal.HeaderText = "Monitor Value";
            this.cmMonVal.Name = "cmMonVal";
            this.cmMonVal.ReadOnly = true;
            this.cmMonVal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnClrVals
            // 
            this.btnClrVals.Location = new System.Drawing.Point(160, 473);
            this.btnClrVals.Name = "btnClrVals";
            this.btnClrVals.Size = new System.Drawing.Size(100, 23);
            this.btnClrVals.TabIndex = 3;
            this.btnClrVals.Text = "Clear Values";
            this.btnClrVals.UseVisualStyleBackColor = true;
            this.btnClrVals.Click += new System.EventHandler(this.btnClrVals_Click);
            // 
            // frmMonMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 502);
            this.Controls.Add(this.btnClrVals);
            this.Controls.Add(this.stat_Maint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGetVals);
            this.Controls.Add(this.dgvMonMaint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMonMaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Drive Maintenance Monitors";
            this.Load += new System.EventHandler(this.frmMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonMaint)).EndInit();
            this.stat_Maint.ResumeLayout(false);
            this.stat_Maint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMonMaint;
        private System.Windows.Forms.Button btnGetVals;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.StatusStrip stat_Maint;
        private System.Windows.Forms.ToolStripProgressBar stat_Maint_Prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmRegAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonVal;
        private System.Windows.Forms.Button btnClrVals;
    }
}