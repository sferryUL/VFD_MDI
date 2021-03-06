﻿namespace MDI_VFD
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
            this.msMain_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_VFD = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_VFD_Prog = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_VFD_OpMon = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_VFD_FltData = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_VFD_MaintMon = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_Mtr = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_Mtr_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_Mach = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_Mach_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain_Help_About = new System.Windows.Forms.ToolStripMenuItem();
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
            this.msMain_File,
            this.msMain_VFD,
            this.msMain_Mtr,
            this.msMain_Mach,
            this.msMain_Help});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(957, 24);
            this.msMain.TabIndex = 6;
            this.msMain.Text = "menuStrip1";
            // 
            // msMain_File
            // 
            this.msMain_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_Exit});
            this.msMain_File.Name = "msMain_File";
            this.msMain_File.Size = new System.Drawing.Size(37, 20);
            this.msMain_File.Text = "&File";
            // 
            // msMain_Exit
            // 
            this.msMain_Exit.Name = "msMain_Exit";
            this.msMain_Exit.Size = new System.Drawing.Size(92, 22);
            this.msMain_Exit.Text = "E&xit";
            this.msMain_Exit.Click += new System.EventHandler(this.msMain_Exit_Click);
            // 
            // msMain_VFD
            // 
            this.msMain_VFD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_VFD_Prog,
            this.msMain_VFD_OpMon,
            this.msMain_VFD_FltData,
            this.msMain_VFD_MaintMon});
            this.msMain_VFD.Name = "msMain_VFD";
            this.msMain_VFD.Size = new System.Drawing.Size(40, 20);
            this.msMain_VFD.Text = "VFD";
            this.msMain_VFD.Click += new System.EventHandler(this.msMain_VFD_Click);
            // 
            // msMain_VFD_Prog
            // 
            this.msMain_VFD_Prog.Name = "msMain_VFD_Prog";
            this.msMain_VFD_Prog.Size = new System.Drawing.Size(198, 22);
            this.msMain_VFD_Prog.Text = "Parameter Programmer";
            this.msMain_VFD_Prog.Click += new System.EventHandler(this.msMain_VFD_Prog_Click);
            // 
            // msMain_VFD_OpMon
            // 
            this.msMain_VFD_OpMon.Name = "msMain_VFD_OpMon";
            this.msMain_VFD_OpMon.Size = new System.Drawing.Size(198, 22);
            this.msMain_VFD_OpMon.Text = "Operation Monitors";
            this.msMain_VFD_OpMon.Click += new System.EventHandler(this.msMain_VFD_OpMon_Click);
            // 
            // msMain_VFD_FltData
            // 
            this.msMain_VFD_FltData.Name = "msMain_VFD_FltData";
            this.msMain_VFD_FltData.Size = new System.Drawing.Size(198, 22);
            this.msMain_VFD_FltData.Text = "Fault Data";
            this.msMain_VFD_FltData.Click += new System.EventHandler(this.msMain_VFD_FltData_Click);
            // 
            // msMain_VFD_MaintMon
            // 
            this.msMain_VFD_MaintMon.Name = "msMain_VFD_MaintMon";
            this.msMain_VFD_MaintMon.Size = new System.Drawing.Size(198, 22);
            this.msMain_VFD_MaintMon.Text = "Maintenance Monitors";
            this.msMain_VFD_MaintMon.Click += new System.EventHandler(this.msMain_VFD_MaintMon_Click);
            // 
            // msMain_Mtr
            // 
            this.msMain_Mtr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_Mtr_Info});
            this.msMain_Mtr.Name = "msMain_Mtr";
            this.msMain_Mtr.Size = new System.Drawing.Size(52, 20);
            this.msMain_Mtr.Text = "Motor";
            this.msMain_Mtr.Click += new System.EventHandler(this.msMain_Mtr_Click);
            // 
            // msMain_Mtr_Info
            // 
            this.msMain_Mtr_Info.Name = "msMain_Mtr_Info";
            this.msMain_Mtr_Info.Size = new System.Drawing.Size(131, 22);
            this.msMain_Mtr_Info.Text = "Motor Info";
            this.msMain_Mtr_Info.Click += new System.EventHandler(this.msMain_Mtr_Info_Click);
            // 
            // msMain_Mach
            // 
            this.msMain_Mach.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_Mach_Info});
            this.msMain_Mach.Name = "msMain_Mach";
            this.msMain_Mach.Size = new System.Drawing.Size(65, 20);
            this.msMain_Mach.Text = "Machine";
            this.msMain_Mach.Click += new System.EventHandler(this.msMain_Mach_Click);
            // 
            // msMain_Mach_Info
            // 
            this.msMain_Mach_Info.Name = "msMain_Mach_Info";
            this.msMain_Mach_Info.Size = new System.Drawing.Size(180, 22);
            this.msMain_Mach_Info.Text = "Machine Info";
            this.msMain_Mach_Info.Click += new System.EventHandler(this.msMain_Mach_Info_Click);
            // 
            // msMain_Help
            // 
            this.msMain_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_Help_About});
            this.msMain_Help.Name = "msMain_Help";
            this.msMain_Help.Size = new System.Drawing.Size(44, 20);
            this.msMain_Help.Text = "Help";
            // 
            // msMain_Help_About
            // 
            this.msMain_Help_About.Name = "msMain_Help_About";
            this.msMain_Help_About.Size = new System.Drawing.Size(180, 22);
            this.msMain_Help_About.Text = "About";
            this.msMain_Help_About.Click += new System.EventHandler(this.msMain_Help_About_Click);
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
        private System.Windows.Forms.ToolStripMenuItem msMain_Exit;
        private System.Windows.Forms.ToolStrip tsComm;
        private System.Windows.Forms.ToolStripLabel tsComm_lblPort;
        private System.Windows.Forms.ToolStripComboBox tsComm_cmbPort;
        private System.Windows.Forms.ToolStripTextBox tsComm_txtAddr;
        private System.Windows.Forms.ToolStripLabel tsComm_lblAddr;
        private System.IO.Ports.SerialPort spPort;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.CheckBox chkWinAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsr;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnDBConn;
        private System.Windows.Forms.ToolStripMenuItem msMain_VFD;
        private System.Windows.Forms.ToolStripMenuItem msMain_VFD_Prog;
        private System.Windows.Forms.ToolStripMenuItem msMain_VFD_OpMon;
        private System.Windows.Forms.ToolStripMenuItem msMain_VFD_FltData;
        private System.Windows.Forms.ToolStripMenuItem msMain_VFD_MaintMon;
        private System.Windows.Forms.ToolStripMenuItem msMain_Mtr;
        private System.Windows.Forms.ToolStripMenuItem msMain_Mach;
        private System.Windows.Forms.ToolStripMenuItem msMain_Mach_Info;
        private System.Windows.Forms.ToolStripMenuItem msMain_Mtr_Info;
        private System.Windows.Forms.ToolStripMenuItem msMain_Help;
        private System.Windows.Forms.ToolStripMenuItem msMain_Help_About;
    }
}

