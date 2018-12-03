using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ULdB;
using GenFunc;

namespace MDI_VFD.Motor
{
    public partial class frmMtrData : Form
    {
        const string MtrTbl = "TMP_MTR_DATA";
        const string MtrFLCTbl = "TMP_MTR_DATA_FLC";

        bool EditMode;
        string MtrNum;
      
        dBClient dBConn;
        MtrData MtrInf;

        List<TextBox> FLC_TB = new List<TextBox>();

        public frmMtrData(dBClient p_SqlClient, bool p_Edit)
        {
            dBConn = p_SqlClient;
            MtrInf = new MtrData();
            EditMode = p_Edit;
            InitializeComponent();
        }

        public frmMtrData(dBClient p_SqlClient, string p_MtrNum, bool p_Edit)
        {
            MtrInf = new MtrData();
            dBConn = p_SqlClient;
            MtrNum = p_MtrNum;
            EditMode = p_Edit;
            InitializeComponent();
        }

        private void frmMtrInfo_Load(object sender, EventArgs e)
        {
            SetGrpMode(EditMode);
            LoadFLCObjs();
            if(MtrNum != "")
            {
                txtMtrNum.Text = MtrNum;
                dBConn.QueryStr(MtrTbl, "*", "MTR_NUM", txtMtrNum.Text);
                DataTable tbl = new DataTable();
                tbl = dBConn.Table.Copy();
                FillEssInf(ref tbl);
                FillPrints(ref tbl);
                FillGenInf(ref tbl);

                dBConn.QueryStr(MtrFLCTbl, "*", "MTR_NUM", txtMtrNum.Text);
                tbl = new DataTable();
                tbl = dBConn.Table.Copy();
                tbl.Columns.Remove("MTR_NUM");
                FillFLCData(ref tbl);
            }

            
        }

       private void btnExitCan_Click(object sender, EventArgs e)
        {
            if(EditMode)
            {
                if(MsgBox.YN("Are you sure you would like to cancel your motor updates?", "Update Cancel") == DialogResult.Yes)
                {
                    EditMode = false;
                    SetGrpMode(EditMode);
                }
            }
            else
                this.Close();
        }

        private void btnModSave_Click(object sender, EventArgs e)
        {
            if(!EditMode)
                EditMode = true;
            else
                EditMode = false;

            SetGrpMode(EditMode);
        }

        private void SetGrpMode(bool p_EditMode)
        {
            grpEssInf.Enabled = p_EditMode;
            grpPrnts.Enabled = p_EditMode;
            grpGenInf.Enabled = p_EditMode;
            grp50Hz.Enabled = p_EditMode;
            grp60Hz.Enabled = p_EditMode;

            if(p_EditMode)
            {
                btnModSave.Text = "Save";
                btnExitCan.Text = "Cancel";
            }
            else
            {
                btnModSave.Text = "Modify";
                btnExitCan.Text = "Exit";
            }
        }

        private void FillEssInf(ref DataTable p_Tbl)
        {
            cmbHP.Text = p_Tbl.Rows[0]["MTR_HP"].ToString();
            cmbFrame.Text = p_Tbl.Rows[0]["MTR_FRM"].ToString();
        }
        private void FillPrints(ref DataTable p_Tbl)
        {
            txtPrntUL.Text = p_Tbl.Rows[0]["MTR_PRNT_UL"].ToString();
            txtPrntVend.Text = p_Tbl.Rows[0]["MTR_PRNT_VEND"].ToString();
        }
        private void FillGenInf(ref DataTable p_Tbl)
        {
            cmbMfr.Text = p_Tbl.Rows[0]["MTR_MFR"].ToString();
            txtMfrNum.Text = p_Tbl.Rows[0]["MTR_MFR_NUM"].ToString();
            
            // Get item index for insulation rating
            string str = p_Tbl.Rows[0]["MTR_INS"].ToString();
            cmbIns.SelectedIndex = CmbFunc.FindIdxSubStr(ref cmbIns, str);

            // Get item index for kVA code
            str = p_Tbl.Rows[0]["MTR_KVA_CDE"].ToString();
            cmbKVA.SelectedIndex = CmbFunc.FindIdxSubStr(ref cmbKVA, str);

            // Get item index for Motor Design Letter;
            str = p_Tbl.Rows[0]["MTR_DSN"].ToString();
            cmbDsn.SelectedIndex = CmbFunc.FindIdxSubStr(ref cmbDsn, str);

            txtBrgDE.Text = p_Tbl.Rows[0]["MTR_BRG_DE"].ToString();
            txtBrgODE.Text = p_Tbl.Rows[0]["MTR_BRG_DE"].ToString();
        }

        private void FillFLCData(ref DataTable p_Tbl)
        {
            for(int i=0;i<FLC_TB.Count;i++)
            {
                FLC_TB[i].Text = p_Tbl.Rows[0][i].ToString();
            }
        }

        private void LoadFLCObjs()
        {
            // 50 Hz TextBoxes
            TextBox tb = new TextBox();
            tb = txtPF_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtEff_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_200_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_208_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_220_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_230_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_240_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_380_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_400_50;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_415_50;
            FLC_TB.Add(tb);

            // 60 Hz TextBoxes
            tb = new TextBox();
            tb = txtPF_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtEff_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_200_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_208_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_220_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_230_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_240_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_380_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_460_60;
            FLC_TB.Add(tb);

            tb = new TextBox();
            tb = txtFLC_575_60;
            FLC_TB.Add(tb);

        }
    }

    public class MtrData
    {
        public string MtrNum;
        public string Frame;
        public string ULPrint;
        public string VendPrint;
        public string Mfr;
        public string MfrNum;
        public string kVA;
        public string Ins;
        public string Design;
        public string BrgDE;
        public string BrgODE;
        public float PF_50;
        public float Eff_50;
        public float PF_60;
        public float Eff_60;
        List<MtrFLC> FLC;

        float _hp;
        float _pwr;

        public MtrData()
        {
            MtrNum = "";
            Mfr = "";
            MfrNum = "";
            _hp = 0;
            Frame = "";
            kVA = "";
            Ins = "";
            Design = "";
            BrgDE = "";
            BrgODE = "";
            ULPrint = "";
            VendPrint = "";
            PF_50 = 0;
            Eff_50 = 0;
            PF_60 = 0;
            Eff_60 = 0;
            _pwr = 0;
            FLC = new List<MtrFLC>();

            MtrFLC param = new MtrFLC();
            param.Volt = 200;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 208;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 220;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 230;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 240;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 380;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 400;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 415;
            param.Freq = 50;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 200;
            param.Freq = 60;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 208;
            param.Freq = 60;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 220;
            param.Freq = 60;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 230;
            param.Freq = 60;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 240;
            param.Freq = 60;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 380;
            param.Freq = 60;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 460;
            param.Freq = 60;
            FLC.Add(param);

            param = new MtrFLC();
            param.Volt = 575;
            param.Freq = 60;
            FLC.Add(param);

            ULPrint = "";
            VendPrint = "";
        }

        public float HP
        {
            get { return _hp; }
            set
            {
                _hp = value;
                _pwr = _hp * 750;
            }
        }

        public float Pwr { get { return _pwr; } }
        public float kW  { get { return (_pwr / 1000); } }
    }

    public class MtrFLC
    {
        public int Volt;
        public int Freq;
        public float FLC;

        public MtrFLC()
        {
            Volt = 0;
            Freq = 0;
            FLC = 0;
        }
    }
}
