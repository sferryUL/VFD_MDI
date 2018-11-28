namespace MDI_VFD.Machine
{
    partial class frmMachInfo
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
            this.cmbMach = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDrvCnt = new System.Windows.Forms.TextBox();
            this.lblDrv1Name = new System.Windows.Forms.Label();
            this.txtDrv1Name = new System.Windows.Forms.TextBox();
            this.txtDrv2Name = new System.Windows.Forms.TextBox();
            this.lblDrv2Name = new System.Windows.Forms.Label();
            this.txtDrv3Name = new System.Windows.Forms.TextBox();
            this.lblDrv3Name = new System.Windows.Forms.Label();
            this.txtDrv4Name = new System.Windows.Forms.TextBox();
            this.lblDrv4Name = new System.Windows.Forms.Label();
            this.txtDrv5Name = new System.Windows.Forms.TextBox();
            this.lblDrv5Name = new System.Windows.Forms.Label();
            this.lblDrv1DefLV = new System.Windows.Forms.Label();
            this.cmbDrv1DefLV = new System.Windows.Forms.ComboBox();
            this.cmbDrv1DefHV = new System.Windows.Forms.ComboBox();
            this.lblDrv1DefHV = new System.Windows.Forms.Label();
            this.cmbDrv2DefHV = new System.Windows.Forms.ComboBox();
            this.lblDrv2DefHV = new System.Windows.Forms.Label();
            this.cmbDrv2DefLV = new System.Windows.Forms.ComboBox();
            this.lblDrv2DefLV = new System.Windows.Forms.Label();
            this.cmbDrv3DefHV = new System.Windows.Forms.ComboBox();
            this.lblDrv3DefHV = new System.Windows.Forms.Label();
            this.cmbDrv3DefLV = new System.Windows.Forms.ComboBox();
            this.lblDrv3DefLV = new System.Windows.Forms.Label();
            this.cmbDrv4DefHV = new System.Windows.Forms.ComboBox();
            this.lblDrv4DefHV = new System.Windows.Forms.Label();
            this.cmbDrv4DefLV = new System.Windows.Forms.ComboBox();
            this.lblDrv4DefLV = new System.Windows.Forms.Label();
            this.cmbDrv5DefHV = new System.Windows.Forms.ComboBox();
            this.lblDrv5DefHV = new System.Windows.Forms.Label();
            this.cmbDrv5DefLV = new System.Windows.Forms.ComboBox();
            this.lblDrv5DefLV = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grpMtr50Hz = new System.Windows.Forms.GroupBox();
            this.cmbMtr415_50 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbMtr400_50 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbMtr380_50 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbMtr240_50 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbMtr230_50 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbMtr220_50 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbMtr200_50 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMtr208_60 = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cmbMtr575_60 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbMtr460_60 = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbMtr380_60 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbMtr240_60 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbMtr230_60 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbMtr220_60 = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbMtr200_60 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.grpMtr50Hz.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Machine Model:";
            // 
            // cmbMach
            // 
            this.cmbMach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMach.FormattingEnabled = true;
            this.cmbMach.Location = new System.Drawing.Point(100, 12);
            this.cmbMach.Name = "cmbMach";
            this.cmbMach.Size = new System.Drawing.Size(267, 21);
            this.cmbMach.TabIndex = 1;
            this.cmbMach.SelectedIndexChanged += new System.EventHandler(this.cmbMach_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Drive Count:";
            // 
            // txtDrvCnt
            // 
            this.txtDrvCnt.Enabled = false;
            this.txtDrvCnt.Location = new System.Drawing.Point(495, 13);
            this.txtDrvCnt.Name = "txtDrvCnt";
            this.txtDrvCnt.Size = new System.Drawing.Size(63, 20);
            this.txtDrvCnt.TabIndex = 3;
            // 
            // lblDrv1Name
            // 
            this.lblDrv1Name.AutoSize = true;
            this.lblDrv1Name.Location = new System.Drawing.Point(19, 63);
            this.lblDrv1Name.Name = "lblDrv1Name";
            this.lblDrv1Name.Size = new System.Drawing.Size(75, 13);
            this.lblDrv1Name.TabIndex = 4;
            this.lblDrv1Name.Text = "Drive 1 Name:";
            this.lblDrv1Name.Visible = false;
            // 
            // txtDrv1Name
            // 
            this.txtDrv1Name.Enabled = false;
            this.txtDrv1Name.Location = new System.Drawing.Point(100, 60);
            this.txtDrv1Name.Name = "txtDrv1Name";
            this.txtDrv1Name.Size = new System.Drawing.Size(155, 20);
            this.txtDrv1Name.TabIndex = 5;
            this.txtDrv1Name.Visible = false;
            // 
            // txtDrv2Name
            // 
            this.txtDrv2Name.Enabled = false;
            this.txtDrv2Name.Location = new System.Drawing.Point(100, 86);
            this.txtDrv2Name.Name = "txtDrv2Name";
            this.txtDrv2Name.Size = new System.Drawing.Size(155, 20);
            this.txtDrv2Name.TabIndex = 7;
            this.txtDrv2Name.Visible = false;
            // 
            // lblDrv2Name
            // 
            this.lblDrv2Name.AutoSize = true;
            this.lblDrv2Name.Location = new System.Drawing.Point(19, 89);
            this.lblDrv2Name.Name = "lblDrv2Name";
            this.lblDrv2Name.Size = new System.Drawing.Size(75, 13);
            this.lblDrv2Name.TabIndex = 6;
            this.lblDrv2Name.Text = "Drive 2 Name:";
            this.lblDrv2Name.Visible = false;
            // 
            // txtDrv3Name
            // 
            this.txtDrv3Name.Enabled = false;
            this.txtDrv3Name.Location = new System.Drawing.Point(100, 112);
            this.txtDrv3Name.Name = "txtDrv3Name";
            this.txtDrv3Name.Size = new System.Drawing.Size(155, 20);
            this.txtDrv3Name.TabIndex = 9;
            this.txtDrv3Name.Visible = false;
            // 
            // lblDrv3Name
            // 
            this.lblDrv3Name.AutoSize = true;
            this.lblDrv3Name.Location = new System.Drawing.Point(19, 115);
            this.lblDrv3Name.Name = "lblDrv3Name";
            this.lblDrv3Name.Size = new System.Drawing.Size(75, 13);
            this.lblDrv3Name.TabIndex = 8;
            this.lblDrv3Name.Text = "Drive 3 Name:";
            this.lblDrv3Name.Visible = false;
            // 
            // txtDrv4Name
            // 
            this.txtDrv4Name.Enabled = false;
            this.txtDrv4Name.Location = new System.Drawing.Point(100, 138);
            this.txtDrv4Name.Name = "txtDrv4Name";
            this.txtDrv4Name.Size = new System.Drawing.Size(155, 20);
            this.txtDrv4Name.TabIndex = 11;
            this.txtDrv4Name.Visible = false;
            // 
            // lblDrv4Name
            // 
            this.lblDrv4Name.AutoSize = true;
            this.lblDrv4Name.Location = new System.Drawing.Point(19, 141);
            this.lblDrv4Name.Name = "lblDrv4Name";
            this.lblDrv4Name.Size = new System.Drawing.Size(75, 13);
            this.lblDrv4Name.TabIndex = 10;
            this.lblDrv4Name.Text = "Drive 4 Name:";
            this.lblDrv4Name.Visible = false;
            // 
            // txtDrv5Name
            // 
            this.txtDrv5Name.Enabled = false;
            this.txtDrv5Name.Location = new System.Drawing.Point(100, 164);
            this.txtDrv5Name.Name = "txtDrv5Name";
            this.txtDrv5Name.Size = new System.Drawing.Size(155, 20);
            this.txtDrv5Name.TabIndex = 13;
            this.txtDrv5Name.Visible = false;
            // 
            // lblDrv5Name
            // 
            this.lblDrv5Name.AutoSize = true;
            this.lblDrv5Name.Location = new System.Drawing.Point(19, 167);
            this.lblDrv5Name.Name = "lblDrv5Name";
            this.lblDrv5Name.Size = new System.Drawing.Size(75, 13);
            this.lblDrv5Name.TabIndex = 12;
            this.lblDrv5Name.Text = "Drive 5 Name:";
            this.lblDrv5Name.Visible = false;
            // 
            // lblDrv1DefLV
            // 
            this.lblDrv1DefLV.AutoSize = true;
            this.lblDrv1DefLV.Location = new System.Drawing.Point(555, 63);
            this.lblDrv1DefLV.Name = "lblDrv1DefLV";
            this.lblDrv1DefLV.Size = new System.Drawing.Size(134, 13);
            this.lblDrv1DefLV.TabIndex = 14;
            this.lblDrv1DefLV.Text = "Default Low Voltage Drive:";
            this.lblDrv1DefLV.Visible = false;
            // 
            // cmbDrv1DefLV
            // 
            this.cmbDrv1DefLV.Enabled = false;
            this.cmbDrv1DefLV.FormattingEnabled = true;
            this.cmbDrv1DefLV.Location = new System.Drawing.Point(696, 60);
            this.cmbDrv1DefLV.Name = "cmbDrv1DefLV";
            this.cmbDrv1DefLV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv1DefLV.TabIndex = 15;
            this.cmbDrv1DefLV.Visible = false;
            // 
            // cmbDrv1DefHV
            // 
            this.cmbDrv1DefHV.Enabled = false;
            this.cmbDrv1DefHV.FormattingEnabled = true;
            this.cmbDrv1DefHV.Location = new System.Drawing.Point(426, 60);
            this.cmbDrv1DefHV.Name = "cmbDrv1DefHV";
            this.cmbDrv1DefHV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv1DefHV.TabIndex = 17;
            this.cmbDrv1DefHV.Visible = false;
            // 
            // lblDrv1DefHV
            // 
            this.lblDrv1DefHV.AutoSize = true;
            this.lblDrv1DefHV.Location = new System.Drawing.Point(285, 63);
            this.lblDrv1DefHV.Name = "lblDrv1DefHV";
            this.lblDrv1DefHV.Size = new System.Drawing.Size(136, 13);
            this.lblDrv1DefHV.TabIndex = 16;
            this.lblDrv1DefHV.Text = "Default High Voltage Drive:";
            this.lblDrv1DefHV.Visible = false;
            // 
            // cmbDrv2DefHV
            // 
            this.cmbDrv2DefHV.Enabled = false;
            this.cmbDrv2DefHV.FormattingEnabled = true;
            this.cmbDrv2DefHV.Location = new System.Drawing.Point(426, 85);
            this.cmbDrv2DefHV.Name = "cmbDrv2DefHV";
            this.cmbDrv2DefHV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv2DefHV.TabIndex = 21;
            this.cmbDrv2DefHV.Visible = false;
            // 
            // lblDrv2DefHV
            // 
            this.lblDrv2DefHV.AutoSize = true;
            this.lblDrv2DefHV.Location = new System.Drawing.Point(285, 88);
            this.lblDrv2DefHV.Name = "lblDrv2DefHV";
            this.lblDrv2DefHV.Size = new System.Drawing.Size(136, 13);
            this.lblDrv2DefHV.TabIndex = 20;
            this.lblDrv2DefHV.Text = "Default High Voltage Drive:";
            this.lblDrv2DefHV.Visible = false;
            // 
            // cmbDrv2DefLV
            // 
            this.cmbDrv2DefLV.Enabled = false;
            this.cmbDrv2DefLV.FormattingEnabled = true;
            this.cmbDrv2DefLV.Location = new System.Drawing.Point(696, 85);
            this.cmbDrv2DefLV.Name = "cmbDrv2DefLV";
            this.cmbDrv2DefLV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv2DefLV.TabIndex = 19;
            this.cmbDrv2DefLV.Visible = false;
            // 
            // lblDrv2DefLV
            // 
            this.lblDrv2DefLV.AutoSize = true;
            this.lblDrv2DefLV.Location = new System.Drawing.Point(555, 88);
            this.lblDrv2DefLV.Name = "lblDrv2DefLV";
            this.lblDrv2DefLV.Size = new System.Drawing.Size(134, 13);
            this.lblDrv2DefLV.TabIndex = 18;
            this.lblDrv2DefLV.Text = "Default Low Voltage Drive:";
            this.lblDrv2DefLV.Visible = false;
            // 
            // cmbDrv3DefHV
            // 
            this.cmbDrv3DefHV.Enabled = false;
            this.cmbDrv3DefHV.FormattingEnabled = true;
            this.cmbDrv3DefHV.Location = new System.Drawing.Point(426, 111);
            this.cmbDrv3DefHV.Name = "cmbDrv3DefHV";
            this.cmbDrv3DefHV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv3DefHV.TabIndex = 25;
            this.cmbDrv3DefHV.Visible = false;
            // 
            // lblDrv3DefHV
            // 
            this.lblDrv3DefHV.AutoSize = true;
            this.lblDrv3DefHV.Location = new System.Drawing.Point(285, 114);
            this.lblDrv3DefHV.Name = "lblDrv3DefHV";
            this.lblDrv3DefHV.Size = new System.Drawing.Size(136, 13);
            this.lblDrv3DefHV.TabIndex = 24;
            this.lblDrv3DefHV.Text = "Default High Voltage Drive:";
            this.lblDrv3DefHV.Visible = false;
            // 
            // cmbDrv3DefLV
            // 
            this.cmbDrv3DefLV.Enabled = false;
            this.cmbDrv3DefLV.FormattingEnabled = true;
            this.cmbDrv3DefLV.Location = new System.Drawing.Point(696, 111);
            this.cmbDrv3DefLV.Name = "cmbDrv3DefLV";
            this.cmbDrv3DefLV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv3DefLV.TabIndex = 23;
            this.cmbDrv3DefLV.Visible = false;
            // 
            // lblDrv3DefLV
            // 
            this.lblDrv3DefLV.AutoSize = true;
            this.lblDrv3DefLV.Location = new System.Drawing.Point(555, 114);
            this.lblDrv3DefLV.Name = "lblDrv3DefLV";
            this.lblDrv3DefLV.Size = new System.Drawing.Size(134, 13);
            this.lblDrv3DefLV.TabIndex = 22;
            this.lblDrv3DefLV.Text = "Default Low Voltage Drive:";
            this.lblDrv3DefLV.Visible = false;
            // 
            // cmbDrv4DefHV
            // 
            this.cmbDrv4DefHV.Enabled = false;
            this.cmbDrv4DefHV.FormattingEnabled = true;
            this.cmbDrv4DefHV.Location = new System.Drawing.Point(426, 137);
            this.cmbDrv4DefHV.Name = "cmbDrv4DefHV";
            this.cmbDrv4DefHV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv4DefHV.TabIndex = 29;
            this.cmbDrv4DefHV.Visible = false;
            // 
            // lblDrv4DefHV
            // 
            this.lblDrv4DefHV.AutoSize = true;
            this.lblDrv4DefHV.Location = new System.Drawing.Point(285, 140);
            this.lblDrv4DefHV.Name = "lblDrv4DefHV";
            this.lblDrv4DefHV.Size = new System.Drawing.Size(136, 13);
            this.lblDrv4DefHV.TabIndex = 28;
            this.lblDrv4DefHV.Text = "Default High Voltage Drive:";
            this.lblDrv4DefHV.Visible = false;
            // 
            // cmbDrv4DefLV
            // 
            this.cmbDrv4DefLV.Enabled = false;
            this.cmbDrv4DefLV.FormattingEnabled = true;
            this.cmbDrv4DefLV.Location = new System.Drawing.Point(696, 137);
            this.cmbDrv4DefLV.Name = "cmbDrv4DefLV";
            this.cmbDrv4DefLV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv4DefLV.TabIndex = 27;
            this.cmbDrv4DefLV.Visible = false;
            // 
            // lblDrv4DefLV
            // 
            this.lblDrv4DefLV.AutoSize = true;
            this.lblDrv4DefLV.Location = new System.Drawing.Point(555, 140);
            this.lblDrv4DefLV.Name = "lblDrv4DefLV";
            this.lblDrv4DefLV.Size = new System.Drawing.Size(134, 13);
            this.lblDrv4DefLV.TabIndex = 26;
            this.lblDrv4DefLV.Text = "Default Low Voltage Drive:";
            this.lblDrv4DefLV.Visible = false;
            // 
            // cmbDrv5DefHV
            // 
            this.cmbDrv5DefHV.Enabled = false;
            this.cmbDrv5DefHV.FormattingEnabled = true;
            this.cmbDrv5DefHV.Location = new System.Drawing.Point(426, 163);
            this.cmbDrv5DefHV.Name = "cmbDrv5DefHV";
            this.cmbDrv5DefHV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv5DefHV.TabIndex = 33;
            this.cmbDrv5DefHV.Visible = false;
            // 
            // lblDrv5DefHV
            // 
            this.lblDrv5DefHV.AutoSize = true;
            this.lblDrv5DefHV.Location = new System.Drawing.Point(285, 166);
            this.lblDrv5DefHV.Name = "lblDrv5DefHV";
            this.lblDrv5DefHV.Size = new System.Drawing.Size(136, 13);
            this.lblDrv5DefHV.TabIndex = 32;
            this.lblDrv5DefHV.Text = "Default High Voltage Drive:";
            this.lblDrv5DefHV.Visible = false;
            // 
            // cmbDrv5DefLV
            // 
            this.cmbDrv5DefLV.Enabled = false;
            this.cmbDrv5DefLV.FormattingEnabled = true;
            this.cmbDrv5DefLV.Location = new System.Drawing.Point(696, 163);
            this.cmbDrv5DefLV.Name = "cmbDrv5DefLV";
            this.cmbDrv5DefLV.Size = new System.Drawing.Size(100, 21);
            this.cmbDrv5DefLV.TabIndex = 31;
            this.cmbDrv5DefLV.Visible = false;
            // 
            // lblDrv5DefLV
            // 
            this.lblDrv5DefLV.AutoSize = true;
            this.lblDrv5DefLV.Location = new System.Drawing.Point(555, 166);
            this.lblDrv5DefLV.Name = "lblDrv5DefLV";
            this.lblDrv5DefLV.Size = new System.Drawing.Size(134, 13);
            this.lblDrv5DefLV.TabIndex = 30;
            this.lblDrv5DefLV.Text = "Default Low Voltage Drive:";
            this.lblDrv5DefLV.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(646, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(646, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Modify";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // grpMtr50Hz
            // 
            this.grpMtr50Hz.Controls.Add(this.cmbMtr415_50);
            this.grpMtr50Hz.Controls.Add(this.label24);
            this.grpMtr50Hz.Controls.Add(this.cmbMtr400_50);
            this.grpMtr50Hz.Controls.Add(this.label23);
            this.grpMtr50Hz.Controls.Add(this.cmbMtr380_50);
            this.grpMtr50Hz.Controls.Add(this.label22);
            this.grpMtr50Hz.Controls.Add(this.cmbMtr240_50);
            this.grpMtr50Hz.Controls.Add(this.label21);
            this.grpMtr50Hz.Controls.Add(this.cmbMtr230_50);
            this.grpMtr50Hz.Controls.Add(this.label20);
            this.grpMtr50Hz.Controls.Add(this.cmbMtr220_50);
            this.grpMtr50Hz.Controls.Add(this.label19);
            this.grpMtr50Hz.Controls.Add(this.cmbMtr200_50);
            this.grpMtr50Hz.Controls.Add(this.label18);
            this.grpMtr50Hz.Location = new System.Drawing.Point(14, 190);
            this.grpMtr50Hz.Name = "grpMtr50Hz";
            this.grpMtr50Hz.Size = new System.Drawing.Size(286, 242);
            this.grpMtr50Hz.TabIndex = 36;
            this.grpMtr50Hz.TabStop = false;
            this.grpMtr50Hz.Text = "50 Hz Supply Motors:";
            // 
            // cmbMtr415_50
            // 
            this.cmbMtr415_50.Enabled = false;
            this.cmbMtr415_50.FormattingEnabled = true;
            this.cmbMtr415_50.Location = new System.Drawing.Point(171, 181);
            this.cmbMtr415_50.Name = "cmbMtr415_50";
            this.cmbMtr415_50.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr415_50.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 184);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(158, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "Default 415 VAC / 50 Hz Motor:";
            // 
            // cmbMtr400_50
            // 
            this.cmbMtr400_50.Enabled = false;
            this.cmbMtr400_50.FormattingEnabled = true;
            this.cmbMtr400_50.Location = new System.Drawing.Point(171, 154);
            this.cmbMtr400_50.Name = "cmbMtr400_50";
            this.cmbMtr400_50.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr400_50.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 157);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(158, 13);
            this.label23.TabIndex = 28;
            this.label23.Text = "Default 400 VAC / 50 Hz Motor:";
            // 
            // cmbMtr380_50
            // 
            this.cmbMtr380_50.Enabled = false;
            this.cmbMtr380_50.FormattingEnabled = true;
            this.cmbMtr380_50.Location = new System.Drawing.Point(171, 127);
            this.cmbMtr380_50.Name = "cmbMtr380_50";
            this.cmbMtr380_50.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr380_50.TabIndex = 27;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 130);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(158, 13);
            this.label22.TabIndex = 26;
            this.label22.Text = "Default 380 VAC / 50 Hz Motor:";
            // 
            // cmbMtr240_50
            // 
            this.cmbMtr240_50.Enabled = false;
            this.cmbMtr240_50.FormattingEnabled = true;
            this.cmbMtr240_50.Location = new System.Drawing.Point(171, 100);
            this.cmbMtr240_50.Name = "cmbMtr240_50";
            this.cmbMtr240_50.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr240_50.TabIndex = 25;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 103);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "Default 240 VAC / 50 Hz Motor:";
            // 
            // cmbMtr230_50
            // 
            this.cmbMtr230_50.Enabled = false;
            this.cmbMtr230_50.FormattingEnabled = true;
            this.cmbMtr230_50.Location = new System.Drawing.Point(171, 73);
            this.cmbMtr230_50.Name = "cmbMtr230_50";
            this.cmbMtr230_50.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr230_50.TabIndex = 23;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(155, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "Default 230VAC / 50 Hz Motor:";
            // 
            // cmbMtr220_50
            // 
            this.cmbMtr220_50.Enabled = false;
            this.cmbMtr220_50.FormattingEnabled = true;
            this.cmbMtr220_50.Location = new System.Drawing.Point(171, 46);
            this.cmbMtr220_50.Name = "cmbMtr220_50";
            this.cmbMtr220_50.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr220_50.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Default 220 VAC / 50 Hz Motor:";
            // 
            // cmbMtr200_50
            // 
            this.cmbMtr200_50.Enabled = false;
            this.cmbMtr200_50.FormattingEnabled = true;
            this.cmbMtr200_50.Location = new System.Drawing.Point(171, 19);
            this.cmbMtr200_50.Name = "cmbMtr200_50";
            this.cmbMtr200_50.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr200_50.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(158, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Default 200 VAC / 50 Hz Motor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMtr208_60);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.cmbMtr575_60);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.cmbMtr460_60);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.cmbMtr380_60);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.cmbMtr240_60);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.cmbMtr230_60);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.cmbMtr220_60);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.cmbMtr200_60);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Location = new System.Drawing.Point(333, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 242);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "60 Hz Supply Motors:";
            // 
            // cmbMtr208_60
            // 
            this.cmbMtr208_60.Enabled = false;
            this.cmbMtr208_60.FormattingEnabled = true;
            this.cmbMtr208_60.Location = new System.Drawing.Point(171, 46);
            this.cmbMtr208_60.Name = "cmbMtr208_60";
            this.cmbMtr208_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr208_60.TabIndex = 33;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(7, 49);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(158, 13);
            this.label32.TabIndex = 32;
            this.label32.Text = "Default 208 VAC / 60 Hz Motor:";
            // 
            // cmbMtr575_60
            // 
            this.cmbMtr575_60.Enabled = false;
            this.cmbMtr575_60.FormattingEnabled = true;
            this.cmbMtr575_60.Location = new System.Drawing.Point(171, 208);
            this.cmbMtr575_60.Name = "cmbMtr575_60";
            this.cmbMtr575_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr575_60.TabIndex = 31;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 211);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(158, 13);
            this.label25.TabIndex = 30;
            this.label25.Text = "Default 575 VAC / 60 Hz Motor:";
            // 
            // cmbMtr460_60
            // 
            this.cmbMtr460_60.Enabled = false;
            this.cmbMtr460_60.FormattingEnabled = true;
            this.cmbMtr460_60.Location = new System.Drawing.Point(171, 181);
            this.cmbMtr460_60.Name = "cmbMtr460_60";
            this.cmbMtr460_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr460_60.TabIndex = 29;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(7, 184);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(158, 13);
            this.label26.TabIndex = 28;
            this.label26.Text = "Default 460 VAC / 60 Hz Motor:";
            // 
            // cmbMtr380_60
            // 
            this.cmbMtr380_60.Enabled = false;
            this.cmbMtr380_60.FormattingEnabled = true;
            this.cmbMtr380_60.Location = new System.Drawing.Point(171, 154);
            this.cmbMtr380_60.Name = "cmbMtr380_60";
            this.cmbMtr380_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr380_60.TabIndex = 27;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 157);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(158, 13);
            this.label27.TabIndex = 26;
            this.label27.Text = "Default 380 VAC / 60 Hz Motor:";
            // 
            // cmbMtr240_60
            // 
            this.cmbMtr240_60.Enabled = false;
            this.cmbMtr240_60.FormattingEnabled = true;
            this.cmbMtr240_60.Location = new System.Drawing.Point(171, 127);
            this.cmbMtr240_60.Name = "cmbMtr240_60";
            this.cmbMtr240_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr240_60.TabIndex = 25;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(7, 130);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(158, 13);
            this.label28.TabIndex = 24;
            this.label28.Text = "Default 240 VAC / 60 Hz Motor:";
            // 
            // cmbMtr230_60
            // 
            this.cmbMtr230_60.Enabled = false;
            this.cmbMtr230_60.FormattingEnabled = true;
            this.cmbMtr230_60.Location = new System.Drawing.Point(171, 100);
            this.cmbMtr230_60.Name = "cmbMtr230_60";
            this.cmbMtr230_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr230_60.TabIndex = 23;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(10, 103);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(155, 13);
            this.label29.TabIndex = 22;
            this.label29.Text = "Default 230VAC / 60 Hz Motor:";
            // 
            // cmbMtr220_60
            // 
            this.cmbMtr220_60.Enabled = false;
            this.cmbMtr220_60.FormattingEnabled = true;
            this.cmbMtr220_60.Location = new System.Drawing.Point(171, 73);
            this.cmbMtr220_60.Name = "cmbMtr220_60";
            this.cmbMtr220_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr220_60.TabIndex = 21;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(7, 76);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(158, 13);
            this.label30.TabIndex = 20;
            this.label30.Text = "Default 220 VAC / 60 Hz Motor:";
            // 
            // cmbMtr200_60
            // 
            this.cmbMtr200_60.Enabled = false;
            this.cmbMtr200_60.FormattingEnabled = true;
            this.cmbMtr200_60.Location = new System.Drawing.Point(171, 19);
            this.cmbMtr200_60.Name = "cmbMtr200_60";
            this.cmbMtr200_60.Size = new System.Drawing.Size(100, 21);
            this.cmbMtr200_60.TabIndex = 19;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 22);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(158, 13);
            this.label31.TabIndex = 18;
            this.label31.Text = "Default 200 VAC / 60 Hz Motor:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(646, 351);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 23);
            this.button3.TabIndex = 38;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmMachInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 444);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMtr50Hz);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbDrv5DefHV);
            this.Controls.Add(this.lblDrv5DefHV);
            this.Controls.Add(this.cmbDrv5DefLV);
            this.Controls.Add(this.lblDrv5DefLV);
            this.Controls.Add(this.cmbDrv4DefHV);
            this.Controls.Add(this.lblDrv4DefHV);
            this.Controls.Add(this.cmbDrv4DefLV);
            this.Controls.Add(this.lblDrv4DefLV);
            this.Controls.Add(this.cmbDrv3DefHV);
            this.Controls.Add(this.lblDrv3DefHV);
            this.Controls.Add(this.cmbDrv3DefLV);
            this.Controls.Add(this.lblDrv3DefLV);
            this.Controls.Add(this.cmbDrv2DefHV);
            this.Controls.Add(this.lblDrv2DefHV);
            this.Controls.Add(this.cmbDrv2DefLV);
            this.Controls.Add(this.lblDrv2DefLV);
            this.Controls.Add(this.cmbDrv1DefHV);
            this.Controls.Add(this.lblDrv1DefHV);
            this.Controls.Add(this.cmbDrv1DefLV);
            this.Controls.Add(this.lblDrv1DefLV);
            this.Controls.Add(this.txtDrv5Name);
            this.Controls.Add(this.lblDrv5Name);
            this.Controls.Add(this.txtDrv4Name);
            this.Controls.Add(this.lblDrv4Name);
            this.Controls.Add(this.txtDrv3Name);
            this.Controls.Add(this.lblDrv3Name);
            this.Controls.Add(this.txtDrv2Name);
            this.Controls.Add(this.lblDrv2Name);
            this.Controls.Add(this.txtDrv1Name);
            this.Controls.Add(this.lblDrv1Name);
            this.Controls.Add(this.txtDrvCnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMach);
            this.Controls.Add(this.label1);
            this.Name = "frmMachInfo";
            this.Text = "Urschel Machine Information";
            this.Load += new System.EventHandler(this.frmMachInfo_Load);
            this.grpMtr50Hz.ResumeLayout(false);
            this.grpMtr50Hz.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDrvCnt;
        private System.Windows.Forms.Label lblDrv1Name;
        private System.Windows.Forms.TextBox txtDrv1Name;
        private System.Windows.Forms.TextBox txtDrv2Name;
        private System.Windows.Forms.Label lblDrv2Name;
        private System.Windows.Forms.TextBox txtDrv3Name;
        private System.Windows.Forms.Label lblDrv3Name;
        private System.Windows.Forms.TextBox txtDrv4Name;
        private System.Windows.Forms.Label lblDrv4Name;
        private System.Windows.Forms.TextBox txtDrv5Name;
        private System.Windows.Forms.Label lblDrv5Name;
        private System.Windows.Forms.Label lblDrv1DefLV;
        private System.Windows.Forms.ComboBox cmbDrv1DefLV;
        private System.Windows.Forms.ComboBox cmbDrv1DefHV;
        private System.Windows.Forms.Label lblDrv1DefHV;
        private System.Windows.Forms.ComboBox cmbDrv2DefHV;
        private System.Windows.Forms.Label lblDrv2DefHV;
        private System.Windows.Forms.ComboBox cmbDrv2DefLV;
        private System.Windows.Forms.Label lblDrv2DefLV;
        private System.Windows.Forms.ComboBox cmbDrv3DefHV;
        private System.Windows.Forms.Label lblDrv3DefHV;
        private System.Windows.Forms.ComboBox cmbDrv3DefLV;
        private System.Windows.Forms.Label lblDrv3DefLV;
        private System.Windows.Forms.ComboBox cmbDrv4DefHV;
        private System.Windows.Forms.Label lblDrv4DefHV;
        private System.Windows.Forms.ComboBox cmbDrv4DefLV;
        private System.Windows.Forms.Label lblDrv4DefLV;
        private System.Windows.Forms.ComboBox cmbDrv5DefHV;
        private System.Windows.Forms.Label lblDrv5DefHV;
        private System.Windows.Forms.ComboBox cmbDrv5DefLV;
        private System.Windows.Forms.Label lblDrv5DefLV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grpMtr50Hz;
        private System.Windows.Forms.ComboBox cmbMtr415_50;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbMtr400_50;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbMtr380_50;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbMtr240_50;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbMtr230_50;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbMtr220_50;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbMtr200_50;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMtr575_60;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbMtr460_60;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbMtr380_60;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmbMtr240_60;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbMtr230_60;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbMtr220_60;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cmbMtr200_60;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cmbMtr208_60;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button button3;
    }
}