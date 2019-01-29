using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MDI_VFD.Properties;

using ULdB;
using GenFunc;

namespace MDI_VFD.VFD_Info
{
    public partial class frmVFDChartNew : Form
    {
        #region Class Globals
        
        FormMode DataMode;
        dBClient dBConn;

        ChartInfo ChrtInf;

        #endregion

        #region Class Constructors
        
        public frmVFDChartNew(dBClient p_Client)
        {
            InitializeComponent();

            dBConn = p_Client;
            DataMode = FormMode.Insert;
            
        }

        public frmVFDChartNew(dBClient p_Client, ChartInfo p_Inf)
        {
            InitializeComponent();

            dBConn = p_Client;
            DataMode = FormMode.Revise;

            ChrtInf = p_Inf.Copy();
        }

        #endregion

        #region Form Load & Configuration Methods

        private void frmVFDChartNew_Load(object sender, EventArgs e)
        {
            SetFormMode(DataMode);
            GetMachData();
            
            if(DataMode == FormMode.Revise)
            {
                int idx = CmbFunc.FindIdxSubStr(ref cmbMach, ChrtInf.MachCode);
                cmbMach.SelectedIndex = idx;
                txtChrtNum.Text = PartFunc.CnvFromULFrmt(ChrtInf.ChrtNum);
                txtChrtRev.Text = CalcRevCode(ChrtInf.ChrtRev);
                //txtChrtDesc.Text = ChrtInf.ChrtDesc;
                txtChrtRev.Select();
            }
            else
                cmbMach.Select();
        }

        private void SetFormMode(FormMode p_Mode)
        {
            switch(p_Mode)
            {
                case FormMode.Insert:
                    cmbMach.Enabled = true;
                    txtChrtNum.ReadOnly = false;
                    //txtChrtDesc.ReadOnly = false;
                    //btnLookUp.Visible = true;
                    lblChrtRev.Visible = false;
                    txtChrtRev.Visible = false;
                    break;
                case FormMode.Revise:
                    cmbMach.Enabled = false;
                    txtChrtNum.ReadOnly = true;
                    //txtChrtDesc.ReadOnly = true;
                    //btnLookUp.Visible = false;
                    lblChrtRev.Visible = true;
                    txtChrtRev.Visible = true;
                    break;

            }
        }

        #endregion

        #region Form Keyshortcut Methods

        private void frmVFDChartNew_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnStore_Click(sender, e);
            else if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        #endregion

        #region Form Fill Methods

        private void GetMachData()
        {
            // Get list of the machines and their descriptions from the database
            string sql = String.Format("SELECT MACH_CODE, MACH_DESC FROM {0} WHERE DRV_CNT > 0", Resources.tblMachData);
            dBConn.QuerySQL(sql);
            foreach(DataRow dr in dBConn.Table.Rows)
            {
                string item = String.Format("{0} - {1}", dr["MACH_CODE"].ToString(), dr["MACH_DESC"].ToString());
                cmbMach.Items.Add(item);
            }
        }

        private string CalcRevCode(string p_CurrRevCode)
        {
            string ret_val = "";

            // Blank rev code goes to 'A'
            if(p_CurrRevCode == "")
                ret_val = "A";
            else
            {
                // For now we only work with the first character, not 
                // accounting for going beyond revision Z as of now.
                char tmp = p_CurrRevCode.ToUpper()[0];

                // Increment the temporary rev char value. If the value is
                // I or O then increment one more time becaues those get 
                // confused with 1 and 0 respectively.
                tmp++;
                if((tmp == 'I') || (tmp == 'O'))
                    tmp++;

                ret_val = tmp.ToString();
            }

            return ret_val;
        }

        //private void btnLookUp_Click(object sender, EventArgs e)
        //{
        //    if((Environment.UserName == "sferry") && (txtChrtNum.Text != ""))
        //    {
        //        string num = PartFunc.Cnv2ULFrmt(txtChrtNum.Text);
        //        string desc = PartFunc.GetULPartDesc(Resources.dBServer, Resources.dBNameUL, Resources.tblPartInfo, num);
        //        if(desc != "")
        //            txtChrtDesc.Text = desc;
        //    }
        //}

        #endregion

        #region Chart Store Methods

        private void btnStore_Click(object sender, EventArgs e)
        {
            if(cmbMach.SelectedIndex == -1)
            {
                MsgBox.Err("A valid machine selection is required.");
                goto btnStore_Click_Return;
            }
            
            string chrt_num = PartFunc.Cnv2ULFrmt(txtChrtNum.Text);
            if(chrt_num == "")
            {
                MsgBox.Err("A valid Urschel part number is required.");
                goto btnStore_Click_Return;
            }

            if(DataMode == FormMode.Revise)
            {
                if(txtChrtRev.Text == "")
                {
                    MsgBox.Err("A valid revision entry is required when creating revisions to a parameter chart.");
                    goto btnStore_Click_Return;
                }
            }
            

            // First check and see if this chart and revision level (if applicable) exists in the database
            // If it does we need to force the user to modify their input.
            string rev_chk = "";
            if(txtChrtRev.Text == "")
                rev_chk = "IS NULL";
            else
                rev_chk = String.Format("= '{0}'", txtChrtRev.Text.TrimEnd());

            string str_sql = String.Format("SELECT IDX FROM {0} WHERE CHRT_NUM = '{1}' AND CHRT_REV {2};", Resources.tblChrtList, chrt_num, rev_chk);

            if(dBConn.QuerySQL(str_sql) > 0)
            {
                MsgBox.Err("This chart already exists in the database.\nVerify the chart number, and if correct issue a chart revision.");
                goto btnStore_Click_Return;
            }
            

            string mach_code = cmbMach.Text.Substring(0, cmbMach.Text.IndexOf(' '));
            string cols = "CHRT_NUM, MACH_CODE";
            string vals = String.Format("'{0}', '{1}'", chrt_num, mach_code);

            dBConn.Insert(Resources.tblChrtList, cols, vals);

            MsgBox.Info("New chart successfully created.");

            this.Close();

            btnStore_Click_Return:
            return;
        }

        #endregion

    }
}
