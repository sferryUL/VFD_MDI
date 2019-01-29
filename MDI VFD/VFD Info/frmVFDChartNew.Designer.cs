namespace MDI_VFD.VFD_Info
{
    partial class frmVFDChartNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtChrtNum = new System.Windows.Forms.TextBox();
            this.cmbMach = new System.Windows.Forms.ComboBox();
            this.txtChrtRev = new System.Windows.Forms.TextBox();
            this.lblChrtRev = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chart Number:";
            // 
            // txtChrtNum
            // 
            this.txtChrtNum.Location = new System.Drawing.Point(93, 39);
            this.txtChrtNum.Name = "txtChrtNum";
            this.txtChrtNum.Size = new System.Drawing.Size(100, 20);
            this.txtChrtNum.TabIndex = 1;
            // 
            // cmbMach
            // 
            this.cmbMach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMach.Enabled = false;
            this.cmbMach.FormattingEnabled = true;
            this.cmbMach.Location = new System.Drawing.Point(93, 12);
            this.cmbMach.Name = "cmbMach";
            this.cmbMach.Size = new System.Drawing.Size(222, 21);
            this.cmbMach.TabIndex = 0;
            // 
            // txtChrtRev
            // 
            this.txtChrtRev.Location = new System.Drawing.Point(272, 39);
            this.txtChrtRev.Name = "txtChrtRev";
            this.txtChrtRev.Size = new System.Drawing.Size(44, 20);
            this.txtChrtRev.TabIndex = 2;
            this.txtChrtRev.Visible = false;
            // 
            // lblChrtRev
            // 
            this.lblChrtRev.AutoSize = true;
            this.lblChrtRev.Location = new System.Drawing.Point(215, 42);
            this.lblChrtRev.Name = "lblChrtRev";
            this.lblChrtRev.Size = new System.Drawing.Size(51, 13);
            this.lblChrtRev.TabIndex = 58;
            this.lblChrtRev.Text = "Revision:";
            this.lblChrtRev.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Machine:";
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(241, 65);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(75, 23);
            this.btnStore.TabIndex = 3;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // frmVFDChartNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 95);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.cmbMach);
            this.Controls.Add(this.txtChrtRev);
            this.Controls.Add(this.lblChrtRev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChrtNum);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmVFDChartNew";
            this.Text = "New Chart Specification";
            this.Load += new System.EventHandler(this.frmVFDChartNew_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVFDChartNew_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChrtNum;
        private System.Windows.Forms.ComboBox cmbMach;
        private System.Windows.Forms.TextBox txtChrtRev;
        private System.Windows.Forms.Label lblChrtRev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStore;
    }
}