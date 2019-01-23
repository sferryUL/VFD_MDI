namespace MDI_VFD.Motor
{
    partial class frmMtrCalcFLC
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
            this.cmbVoltLow = new System.Windows.Forms.ComboBox();
            this.btnCalcFLC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVoltHigh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFreq = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFLC = new System.Windows.Forms.DataGridView();
            this.dgvFLC_cmVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFLC_cmFLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFLCLow = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFLCHigh = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFLC)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVoltLow
            // 
            this.cmbVoltLow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoltLow.FormattingEnabled = true;
            this.cmbVoltLow.Location = new System.Drawing.Point(12, 66);
            this.cmbVoltLow.Name = "cmbVoltLow";
            this.cmbVoltLow.Size = new System.Drawing.Size(86, 21);
            this.cmbVoltLow.TabIndex = 1;
            // 
            // btnCalcFLC
            // 
            this.btnCalcFLC.Location = new System.Drawing.Point(147, 348);
            this.btnCalcFLC.Name = "btnCalcFLC";
            this.btnCalcFLC.Size = new System.Drawing.Size(65, 23);
            this.btnCalcFLC.TabIndex = 6;
            this.btnCalcFLC.Text = "Calculate";
            this.btnCalcFLC.UseVisualStyleBackColor = true;
            this.btnCalcFLC.Click += new System.EventHandler(this.btnCalcFLC_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // cmbVoltHigh
            // 
            this.cmbVoltHigh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoltHigh.FormattingEnabled = true;
            this.cmbVoltHigh.Location = new System.Drawing.Point(126, 66);
            this.cmbVoltHigh.Name = "cmbVoltHigh";
            this.cmbVoltHigh.Size = new System.Drawing.Size(86, 21);
            this.cmbVoltHigh.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Low Voltage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "High Voltage";
            // 
            // cmbFreq
            // 
            this.cmbFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFreq.FormattingEnabled = true;
            this.cmbFreq.Items.AddRange(new object[] {
            "50 Hz",
            "60 Hz"});
            this.cmbFreq.Location = new System.Drawing.Point(81, 16);
            this.cmbFreq.Name = "cmbFreq";
            this.cmbFreq.Size = new System.Drawing.Size(60, 21);
            this.cmbFreq.TabIndex = 0;
            this.cmbFreq.SelectedIndexChanged += new System.EventHandler(this.cmbFreq_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Frequency:";
            // 
            // dgvFLC
            // 
            this.dgvFLC.AllowUserToAddRows = false;
            this.dgvFLC.AllowUserToDeleteRows = false;
            this.dgvFLC.AllowUserToResizeColumns = false;
            this.dgvFLC.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFLC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFLC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvFLC_cmVoltage,
            this.dgvFLC_cmFLC});
            this.dgvFLC.Location = new System.Drawing.Point(12, 156);
            this.dgvFLC.MultiSelect = false;
            this.dgvFLC.Name = "dgvFLC";
            this.dgvFLC.ReadOnly = true;
            this.dgvFLC.RowHeadersVisible = false;
            this.dgvFLC.Size = new System.Drawing.Size(200, 186);
            this.dgvFLC.TabIndex = 5;
            this.dgvFLC.TabStop = false;
            // 
            // dgvFLC_cmVoltage
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvFLC_cmVoltage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFLC_cmVoltage.Frozen = true;
            this.dgvFLC_cmVoltage.HeaderText = "Voltage";
            this.dgvFLC_cmVoltage.Name = "dgvFLC_cmVoltage";
            this.dgvFLC_cmVoltage.ReadOnly = true;
            this.dgvFLC_cmVoltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvFLC_cmFLC
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvFLC_cmFLC.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFLC_cmFLC.Frozen = true;
            this.dgvFLC_cmFLC.HeaderText = "FLC";
            this.dgvFLC_cmFLC.Name = "dgvFLC_cmFLC";
            this.dgvFLC_cmFLC.ReadOnly = true;
            this.dgvFLC_cmFLC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Low Voltage FLC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "High Voltage FLC";
            // 
            // txtFLCLow
            // 
            this.txtFLCLow.Location = new System.Drawing.Point(12, 121);
            this.txtFLCLow.Name = "txtFLCLow";
            this.txtFLCLow.Size = new System.Drawing.Size(66, 20);
            this.txtFLCLow.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "A";
            // 
            // txtFLCHigh
            // 
            this.txtFLCHigh.Location = new System.Drawing.Point(126, 121);
            this.txtFLCHigh.Name = "txtFLCHigh";
            this.txtFLCHigh.Size = new System.Drawing.Size(66, 20);
            this.txtFLCHigh.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "A";
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(12, 348);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(55, 23);
            this.btnStore.TabIndex = 8;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Visible = false;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(81, 348);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmMtrCalcFLC
            // 
            this.AcceptButton = this.btnCalcFLC;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(225, 379);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFLCHigh);
            this.Controls.Add(this.txtFLCLow);
            this.Controls.Add(this.dgvFLC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFreq);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbVoltHigh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnCalcFLC);
            this.Controls.Add(this.cmbVoltLow);
            this.Name = "frmMtrCalcFLC";
            this.Text = "Motor FLC Range  Calculator";
            this.Load += new System.EventHandler(this.frmMtrCalcFLC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMtrCalcFLC_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFLC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVoltLow;
        private System.Windows.Forms.Button btnCalcFLC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVoltHigh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFreq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFLC_cmVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFLC_cmFLC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFLCLow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFLCHigh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnClear;
    }
}