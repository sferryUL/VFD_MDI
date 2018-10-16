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
using GenFunc;
using ULdB;

namespace MDI_VFD
{
    public partial class frmMain : Form
    {
        frmMonOp VFDMonOp;
        frmProg VFDProg;
        frmMonMaint VFDMonMaint;
        frmFlt VFDFlt;

        byte SlaveAddr = 0x1F;
        bool CommPort = false;

        const string UL_Srv = "ULSQL12T";
        const string UL_EEdB = "ElectricalApps";

        dBClient dBConn = new dBClient();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(!dBConn.Open(UL_Srv, UL_EEdB, true, "ElecTest", "ElecTest"))
            {
                MsgBox.Err("Unable to open Database!", "Program Error");
                this.Close();
            }
            LoadCommComboBoxes();
        }

        private void msMain_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void msMain_VFDProg_Click(object sender, EventArgs e)
        {
            if(VFDProg == null)
            {
                VFDProg = new frmProg(spPort, CommPort);
                VFDProg.FormClosing += frmMain_ChildClosing;
                VFDProg.MdiParent = this;
                VFDProg.Show();
            }
            else
            {
                VFDProg.BringToFront();
            }
        }

        private void msMain_VFDMon_Click(object sender, EventArgs e)
        {
            if(VFDMonOp == null)
            {
                VFDMonOp = new frmMonOp(dBConn, spPort, CommPort);
                VFDMonOp.FormClosing += frmMain_ChildClosing;
                VFDMonOp.MdiParent = this;
                VFDMonOp.Show();
            }
            else
            {
                VFDMonOp.BringToFront();
            }
        }

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

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(dBConn.State == ConnectionState.Open)
                dBConn.Close();

            if(spPort.IsOpen)
                spPort.Close();
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
            }
        }

        private void msMain_File_MonMaint_Click(object sender, EventArgs e)
        {
            if(VFDMonMaint == null)
            {
                VFDMonMaint = new frmMonMaint(dBConn, spPort, CommPort);
                VFDMonMaint.MdiParent = this;
                VFDMonMaint.FormClosing += frmMain_ChildClosing;
                VFDMonMaint.Show();
            }
            else
            {
                VFDMonMaint.BringToFront();
            }
        }

        private void msMain_File_FltTrc_Click(object sender, EventArgs e)
        {
            if(VFDFlt == null)
            {
                VFDFlt = new frmFlt(dBConn, spPort, CommPort);
                VFDFlt.MdiParent = this;
                VFDFlt.FormClosing += frmMain_ChildClosing;
                VFDFlt.Show();
            }
            else
            {
                VFDFlt.BringToFront();
            }
        }
    }
}
