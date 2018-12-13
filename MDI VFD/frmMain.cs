using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using V1000_Prog_SQL;
using MDI_VFD.Motor;
using MDI_VFD.Machine;
using GenFunc;
using ULdB;

namespace MDI_VFD
{
    public partial class frmMain : Form
    {
        #region Class_Globals
        const string BuildVersion = "0.9.0";

        frmMonOp VFDMonOp;
        frmProg VFDProg;
        frmMonMaint VFDMonMaint;
        frmFlt VFDFlt;
        frmMtrInfo MtrInfo;
        frmMachList MachList;

        byte SlaveAddr = 0x1F;
        bool CommPort = false;

        const string UL_Srv = "ULSQL12T";
        const string UL_EEdB = "ElectricalApps";

        dBClient dBConn = new dBClient();
        #endregion

        #region Form_Functions
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadCommComboBoxes();

            
            if(Environment.UserName == "sferry")
                chkWinAuth.Checked = true;
            else
                chkWinAuth.Checked = false;
            
            btnDBConn_Click(sender, e);

            if(dBConn.State == ConnectionState.Open)
            {
                //msMain_VFD_Prog_Click(sender, e);
                msMain_Mach_Info_Click(sender, e);
                //msMain_Mtr_Info_Click(sender, e);
            }
        }

        public void frmMain_ChildClosing(object sender, FormClosingEventArgs e)
        {
            switch(((Form)sender).Name)
            {
                case "frmProg":
                    VFDProg.Dispose();
                    VFDProg = null;
                    break;
                case "frmMonOp":
                    VFDMonOp.Stop();
                    VFDMonOp.Dispose();
                    VFDMonOp = null;
                    break;
                case "frmFlt":
                    VFDFlt.Dispose();
                    VFDFlt = null;
                    break;
                case "frmMonMaint":
                    VFDMonMaint.Dispose();
                    VFDMonMaint = null;
                    break;
                case "frmMtrInfo":
                    MtrInfo.Dispose();
                    MtrInfo = null;
                    break;
                case "frmMachInfo":
                    MachList.Dispose();
                    MachList = null;
                    break;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(dBConn.State == ConnectionState.Open)
                dBConn.Close();

            if(spPort.IsOpen)
                spPort.Close();
        }
        #endregion

        #region Comm
        private void LoadCommComboBoxes()
        {
            // Load available serial ports
            foreach(string s in System.IO.Ports.SerialPort.GetPortNames())
                tsComm_cmbPort.Items.Add(s);

            // select last serial port, by default it seems the add-on port is always last.
            if(tsComm_cmbPort.Items.Count > 0)
            {
                CommPort = true;
                if(tsComm_cmbPort.Items.Count > 1)
                    tsComm_cmbPort.SelectedIndex = tsComm_cmbPort.Items.Count - 1;
                else
                    tsComm_cmbPort.SelectedIndex = 0;
            }
            else
            {
                string msg = "No communication port detected, would you like to continue without drive programming functionality?";
                string caption = "Communication Port Error";

                if(MsgBox.YN(msg, caption) == DialogResult.No)
                    this.Close();
            }
        }

        private void tsComm_cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            spPort.PortName = tsComm_cmbPort.Text;
        }

        private void tsComm_txtAddr_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyValue == (int)Keys.Enter) || (e.KeyValue == (int)Keys.Tab))
            {
                // Check if the value in the textbox is hex or base 10. If the  
                // value is invalid temp_val will be 0 and we just set the value 
                // back to the default 0x1F
                byte temp_val = NumFunc.Hex2Byte(tsComm_txtAddr.Text);
                if(temp_val > 0)
                    SlaveAddr = temp_val;
                else
                    SlaveAddr = 0x1F;

                // Reformat the the text to be displayed as standard hexadecimal format.
                tsComm_txtAddr.Text = "0x" + SlaveAddr.ToString("X2");
                VFDProg.VFDAddr = SlaveAddr;
                VFDMonOp.VFDAddr = SlaveAddr;
            }
        }
        #endregion

        #region DB_Conn
        private void chkWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            if(chkWinAuth.Checked)
            {
                txtUsr.Enabled = false;
                txtUsr.Text = Environment.UserName;
                txtPass.Enabled = false;
                txtPass.Text = "";
            }
            else
            {
                txtUsr.Enabled = true;
                txtUsr.Text = "ElecTest";
                txtPass.Enabled = true;
                txtPass.Text = "ElecTest";
            }

        }

        private void btnDBConn_Click(object sender, EventArgs e)
        {
            if(dBConn.State == ConnectionState.Closed)
            {
                bool auth = chkWinAuth.Checked;
                if(!dBConn.Open(txtDB.Text, UL_EEdB, auth, txtUsr.Text, txtPass.Text))
                    MsgBox.Err("Unable to open Database!", "Program Error");
                else
                {
                    txtDB.Enabled = false;
                    btnDBConn.Text = "Disconnect";
                    chkWinAuth.Enabled = false;
                    txtUsr.Enabled = false;
                    txtPass.Enabled = false;
                }
            }
            else if (dBConn.State == ConnectionState.Open)
            {
                dBConn.Close();
                txtDB.Enabled = true;
                btnDBConn.Text = "Connect";
                chkWinAuth.Enabled = true;
                txtUsr.Enabled = true;
                txtPass.Enabled = true;
            }
        }
        #endregion

        #region File
        private void msMain_Exit_Click(object sender, EventArgs e)
        {
            // Need to check to see if there are any active MDI Children. If
            // they are they need to be closed, otherwise Application.Exit()
            // will throw an exception.
            int cnt = this.MdiChildren.Length;
            for(int i=0;i<cnt;i++)
            {
                Form frm = new Form();
                frm = this.ActiveMdiChild;
                frm.Close();
            }
            
            Application.Exit();
        }
        #endregion

        #region VFD_Info

        private void msMain_VFD_Click(object sender, EventArgs e)
        {
            if(dBConn.State == ConnectionState.Open)
            {
                msMain_VFD_Prog.Enabled = true;
                msMain_VFD_OpMon.Enabled = true;
                msMain_VFD_FltData.Enabled = true;
                msMain_VFD_MaintMon.Enabled = true;
            }
            else
            {
                msMain_VFD_Prog.Enabled = false;
                msMain_VFD_OpMon.Enabled = false;
                msMain_VFD_FltData.Enabled = false;
                msMain_VFD_MaintMon.Enabled = false;
            }
        }

        private void msMain_VFD_Prog_Click(object sender, EventArgs e)
        {
            if(VFDProg == null)
            {
                VFDProg = new frmProg(dBConn, CommPort, spPort, SlaveAddr);
                VFDProg.FormClosing += frmMain_ChildClosing;
                VFDProg.MdiParent = this;
                VFDProg.Show();
            }
            else
            {
                VFDProg.BringToFront();
            }
        }

        private void msMain_VFD_OpMon_Click(object sender, EventArgs e)
        {
            if(VFDMonOp == null)
            {
                VFDMonOp = new frmMonOp(dBConn, CommPort, spPort, SlaveAddr);
                VFDMonOp.FormClosing += frmMain_ChildClosing;
                VFDMonOp.MdiParent = this;
                VFDMonOp.Show();
            }
            else
            {
                VFDMonOp.BringToFront();
            }
        }

        private void msMain_VFD_FltData_Click(object sender, EventArgs e)
        {
            if(VFDFlt == null)
            {
                VFDFlt = new frmFlt(dBConn, CommPort, spPort, SlaveAddr);
                VFDFlt.MdiParent = this;
                VFDFlt.FormClosing += frmMain_ChildClosing;
                VFDFlt.Show();
            }
            else
            {
                VFDFlt.BringToFront();
            }
        }

        private void msMain_VFD_MaintMon_Click(object sender, EventArgs e)
        {
            if(VFDMonMaint == null)
            {
                VFDMonMaint = new frmMonMaint(dBConn, CommPort, spPort, SlaveAddr);
                VFDMonMaint.MdiParent = this;
                VFDMonMaint.FormClosing += frmMain_ChildClosing;
                VFDMonMaint.Show();
            }
            else
            {
                VFDMonMaint.BringToFront();
            }
        }

        #endregion

        #region Motor

        private void msMain_Mtr_Click(object sender, EventArgs e)
        {
            if(dBConn.State == ConnectionState.Open)
            {
                msMain_Mtr_Info.Enabled = true;
            }
            else
            {
                msMain_Mtr_Info.Enabled = false;
            }
        }

        private void msMain_Mtr_Info_Click(object sender, EventArgs e)
        {
            if(MtrInfo == null)
            {
                MtrInfo = new frmMtrInfo(dBConn);
                MtrInfo.MdiParent = this;
                MtrInfo.FormClosing += frmMain_ChildClosing;
                MtrInfo.Show();
            }
            else
            {
                MtrInfo.BringToFront();
            }
        }

        #endregion

        #region Machine

        private void msMain_Mach_Click(object sender, EventArgs e)
        {
            if(dBConn.State == ConnectionState.Open)
            {
                msMain_Mach_Info.Enabled = true;
            }
            else
            {
                msMain_Mach_Info.Enabled = false;
            }
        }

        private void msMain_Mach_Info_Click(object sender, EventArgs e)
        {
            if(MachList == null)
            {
                MachList = new frmMachList(dBConn);
                MachList.FormClosing += frmMain_ChildClosing;
                MachList.MdiParent = this;
                MachList.Show();
            }
            else
            {
                MachList.BringToFront();
            }
        }



        #endregion

        private void msMain_Help_About_Click(object sender, EventArgs e)
        {
            string msg = String.Format("Electrical Info Version: {0}", BuildVersion);
            MsgBox.Info(msg, "Program Information");
        }
    }
}
