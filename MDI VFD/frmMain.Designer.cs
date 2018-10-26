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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msMain_File = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_File_Prog = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_File_OpMon = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.chkWinAuth = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnDBConn = new System.Windows.Forms.Button();
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
            this.msMain.Size = new System.Drawing.Size(957, 24);
            this.msMain.TabIndex = 6;
            this.msMain.Text = "menuStrip1";
            // 
            // msMain_File
            // 
            this.msMain_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_File_Prog,
            this.msMain_File_OpMon,
            this.msMain_File_FltTrc,
            this.msMain_File_MonMaint,
            this.toolStripSeparator1,
            this.msMain_Exit});
            this.msMain_File.Name = "msMain_File";
            this.msMain_File.Size = new System.Drawing.Size(37, 20);
            this.msMain_File.Text = "&File";
            this.msMain_File.Click += new System.EventHandler(this.msMain_File_Click);
            // 
            // msMain_File_Prog
            // 
            this.msMain_File_Prog.Name = "msMain_File_Prog";
            this.msMain_File_Prog.Size = new System.Drawing.Size(224, 22);
            this.msMain_File_Prog.Text = "Drive Programmer";
            this.msMain_File_Prog.Click += new System.EventHandler(this.msMain_File_Prog_Click);
            // 
            // msMain_File_OpMon
            // 
            this.msMain_File_OpMon.Name = "msMain_File_OpMon";
            this.msMain_File_OpMon.Size = new System.Drawing.Size(224, 22);
            this.msMain_File_OpMon.Text = "Drive Operation Monitors";
            this.msMain_File_OpMon.Click += new System.EventHandler(this.msMain_File_OpMon_Click);
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
            this.tsComm.Size = new System.Drawing.Size(957, 25);
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
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 49);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(957, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // chkWinAuth
            // 
            this.chkWinAuth.AutoSize = true;
            this.chkWinAuth.Location = new System.Drawing.Point(289, 54);
            this.chkWinAuth.Name = "chkWinAuth";
            this.chkWinAuth.Size = new System.Drawing.Size(141, 17);
            this.chkWinAuth.TabIndex = 13;
            this.chkWinAuth.Text = "Windows Authentication";
            this.chkWinAuth.UseVisualStyleBackColor = true;
            this.chkWinAuth.CheckedChanged += new System.EventHandler(this.chkWinAuth_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Database:";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(74, 52);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(100, 20);
            this.txtDB.TabIndex = 16;
            this.txtDB.Text = "ULSQL12T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(626, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password:";
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(505, 52);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(100, 20);
            this.txtUsr.TabIndex = 18;
            this.txtUsr.Text = "ElecTest";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(688, 52);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 19;
            this.txtPass.Text = "ElecTest";
            // 
            // btnDBConn
            // 
            this.btnDBConn.Location = new System.Drawing.Point(193, 50);
            this.btnDBConn.Name = "btnDBConn";
            this.btnDBConn.Size = new System.Drawing.Size(75, 23);
            this.btnDBConn.TabIndex = 20;
            this.btnDBConn.Text = "Connect";
            this.btnDBConn.UseVisualStyleBackColor = true;
            this.btnDBConn.Click += new System.EventHandler(this.btnDBConn_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.btnDBConn);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkWinAuth);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tsComm);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ToolStripMenuItem msMain_File_Prog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msMain_Exit;
        private System.Windows.Forms.ToolStripMenuItem msMain_File_OpMon;
        private System.Windows.Forms.ToolStrip tsComm;
        private System.Windows.Forms.ToolStripLabel tsComm_lblPort;
        private System.Windows.Forms.ToolStripComboBox tsComm_cmbPort;
        private System.Windows.Forms.ToolStripTextBox tsComm_txtAddr;
        private System.Windows.Forms.ToolStripLabel tsComm_lblAddr;
        private System.IO.Ports.SerialPort spPort;
        private System.Windows.Forms.ToolStripMenuItem msMain_File_MonMaint;
        private System.Windows.Forms.ToolStripMenuItem msMain_File_FltTrc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.CheckBox chkWinAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsr;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnDBConn;
    }
}

