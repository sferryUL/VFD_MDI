namespace MDI_VFD
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msMain_File = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_Prog = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_VFDMon = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_File_FltTrc = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_File_MonMaint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msMain_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsComm = new System.Windows.Forms.ToolStrip();
            this.tsComm_lblPort = new System.Windows.Forms.ToolStripLabel();
            this.tsComm_cmbPort = new System.Windows.Forms.ToolStripComboBox();
            this.tsComm_lblAddr = new System.Windows.Forms.ToolStripLabel();
            this.tsComm_txtAddr = new System.Windows.Forms.ToolStripTextBox();
            this.spPort = new System.IO.Ports.SerialPort(this.components);
            this.msMain.SuspendLayout();
            this.tsComm.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.AllowMerge = false;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_File});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(800, 24);
            this.msMain.TabIndex = 6;
            this.msMain.Text = "menuStrip1";
            // 
            // msMain_File
            // 
            this.msMain_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_Prog,
            this.msMain_VFDMon,
            this.msMain_File_FltTrc,
            this.msMain_File_MonMaint,
            this.toolStripSeparator1,
            this.msMain_Exit});
            this.msMain_File.Name = "msMain_File";
            this.msMain_File.Size = new System.Drawing.Size(37, 20);
            this.msMain_File.Text = "&File";
            // 
            // msMain_Prog
            // 
            this.msMain_Prog.Name = "msMain_Prog";
            this.msMain_Prog.Size = new System.Drawing.Size(224, 22);
            this.msMain_Prog.Text = "Programmer";
            this.msMain_Prog.Click += new System.EventHandler(this.msMain_VFDProg_Click);
            // 
            // msMain_VFDMon
            // 
            this.msMain_VFDMon.Name = "msMain_VFDMon";
            this.msMain_VFDMon.Size = new System.Drawing.Size(224, 22);
            this.msMain_VFDMon.Text = "Drive Operation Monitors";
            this.msMain_VFDMon.Click += new System.EventHandler(this.msMain_VFDMon_Click);
            // 
            // msMain_File_FltTrc
            // 
            this.msMain_File_FltTrc.Name = "msMain_File_FltTrc";
            this.msMain_File_FltTrc.Size = new System.Drawing.Size(224, 22);
            this.msMain_File_FltTrc.Text = "Drive Fault Data";
            this.msMain_File_FltTrc.Click += new System.EventHandler(this.msMain_File_FltTrc_Click);
            // 
            // msMain_File_MonMaint
            // 
            this.msMain_File_MonMaint.Name = "msMain_File_MonMaint";
            this.msMain_File_MonMaint.Size = new System.Drawing.Size(224, 22);
            this.msMain_File_MonMaint.Text = "Drive Maintenance Monitors";
            this.msMain_File_MonMaint.Click += new System.EventHandler(this.msMain_File_MonMaint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // msMain_Exit
            // 
            this.msMain_Exit.Name = "msMain_Exit";
            this.msMain_Exit.Size = new System.Drawing.Size(224, 22);
            this.msMain_Exit.Text = "E&xit";
            this.msMain_Exit.Click += new System.EventHandler(this.msMain_Exit_Click);
            // 
            // tsComm
            // 
            this.tsComm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsComm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsComm_lblPort,
            this.tsComm_cmbPort,
            this.tsComm_lblAddr,
            this.tsComm_txtAddr});
            this.tsComm.Location = new System.Drawing.Point(0, 24);
            this.tsComm.Name = "tsComm";
            this.tsComm.Size = new System.Drawing.Size(800, 25);
            this.tsComm.TabIndex = 10;
            this.tsComm.Text = "toolStrip1";
            // 
            // tsComm_lblPort
            // 
            this.tsComm_lblPort.Name = "tsComm_lblPort";
            this.tsComm_lblPort.Size = new System.Drawing.Size(72, 22);
            this.tsComm_lblPort.Text = "Comm Port:";
            // 
            // tsComm_cmbPort
            // 
            this.tsComm_cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsComm_cmbPort.Name = "tsComm_cmbPort";
            this.tsComm_cmbPort.Size = new System.Drawing.Size(75, 25);
            this.tsComm_cmbPort.SelectedIndexChanged += new System.EventHandler(this.tsComm_cmbPort_SelectedIndexChanged);
            // 
            // tsComm_lblAddr
            // 
            this.tsComm_lblAddr.Margin = new System.Windows.Forms.Padding(150, 1, 0, 2);
            this.tsComm_lblAddr.Name = "tsComm_lblAddr";
            this.tsComm_lblAddr.Size = new System.Drawing.Size(82, 22);
            this.tsComm_lblAddr.Text = "Slave Address:";
            // 
            // tsComm_txtAddr
            // 
            this.tsComm_txtAddr.Name = "tsComm_txtAddr";
            this.tsComm_txtAddr.ReadOnly = true;
            this.tsComm_txtAddr.Size = new System.Drawing.Size(35, 25);
            this.tsComm_txtAddr.Text = "0x1F";
            this.tsComm_txtAddr.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tsComm_txtAddr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsComm_txtAddr_KeyDown);
            // 
            // spPort
            // 
            this.spPort.ReadBufferSize = 256;
            this.spPort.WriteBufferSize = 256;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tsComm);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.Text = "Urschel VFD Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsComm.ResumeLayout(false);
            this.tsComm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msMain_File;
        private System.Windows.Forms.ToolStripMenuItem msMain_Prog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msMain_Exit;
        private System.Windows.Forms.ToolStripMenuItem msMain_VFDMon;
        private System.Windows.Forms.ToolStrip tsComm;
        private System.Windows.Forms.ToolStripLabel tsComm_lblPort;
        private System.Windows.Forms.ToolStripComboBox tsComm_cmbPort;
        private System.Windows.Forms.ToolStripTextBox tsComm_txtAddr;
        private System.Windows.Forms.ToolStripLabel tsComm_lblAddr;
        private System.IO.Ports.SerialPort spPort;
        private System.Windows.Forms.ToolStripMenuItem msMain_File_MonMaint;
        private System.Windows.Forms.ToolStripMenuItem msMain_File_FltTrc;
    }
}

