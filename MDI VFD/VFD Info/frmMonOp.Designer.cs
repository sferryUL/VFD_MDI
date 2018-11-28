namespace MDI_VFD
{
    partial class frmMonOp
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
            this.dgvMonOp = new System.Windows.Forms.DataGridView();
            this.btnMonCtrl = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.bwrkMon = new System.ComponentModel.BackgroundWorker();
            this.cmRegAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMonVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonOp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMonOp
            // 
            this.dgvMonOp.AllowUserToAddRows = false;
            this.dgvMonOp.AllowUserToDeleteRows = false;
            this.dgvMonOp.AllowUserToResizeColumns = false;
            this.dgvMonOp.AllowUserToResizeRows = false;
            this.dgvMonOp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonOp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmRegAddr,
            this.cmMonNum,
            this.cmMonName,
            this.cmMonVal});
            this.dgvMonOp.Location = new System.Drawing.Point(12, 12);
            this.dgvMonOp.Name = "dgvMonOp";
            this.dgvMonOp.ReadOnly = true;
            this.dgvMonOp.RowHeadersVisible = false;
            this.dgvMonOp.Size = new System.Drawing.Size(460, 520);
            this.dgvMonOp.TabIndex = 0;
            // 
            // btnMonCtrl
            // 
            this.btnMonCtrl.Location = new System.Drawing.Point(269, 538);
            this.btnMonCtrl.Name = "btnMonCtrl";
            this.btnMonCtrl.Size = new System.Drawing.Size(100, 23);
            this.btnMonCtrl.TabIndex = 1;
            this.btnMonCtrl.Text = "Start Monitor";
            this.btnMonCtrl.UseVisualStyleBackColor = true;
            this.btnMonCtrl.Click += new System.EventHandler(this.btnMonCtrl_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(375, 538);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // bwrkMon
            // 
            this.bwrkMon.WorkerSupportsCancellation = true;
            this.bwrkMon.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrkMon_DoWork);
            this.bwrkMon.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrkMon_RunWorkerCompleted);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            // frmMonOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 568);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMonCtrl);
            this.Controls.Add(this.dgvMonOp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMonOp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Drive Operation Monitors";
            this.Load += new System.EventHandler(this.frmMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonOp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMonOp;
        private System.Windows.Forms.Button btnMonCtrl;
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker bwrkMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmRegAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMonVal;
    }
}