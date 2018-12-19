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
        #region Class Global Values
        // Database globals
        dBClient dBConn;
        const string TblMtr = "MTR_DATA";
        const string TblMtrFLC = "MTR_DATA_FLC";

        // Form user interaction mode globals
        const int ModeView = 0;
        const int ModeIns = 1;
        const int ModeUpd = 2;
        int Mode = ModeView;
        int StartMode = ModeView;
        
        // Form object and database correlation globals        
        MtrValCollection Vals = new MtrValCollection();
        List<string> OldVals = new List<string>();

        // Machine Motor Default Selection Detail View globals
        bool MachMtrDetail = false;

        #endregion

        #region Class Contructors
        public frmMtrData(dBClient p_SqlClient, int p_Mode)
        {
            InitializeComponent();

            dBConn = p_SqlClient;
            Mode = p_Mode;
            StartMode = Mode;
        }

        public frmMtrData(dBClient p_SqlClient, int p_Mode, string p_MtrNum)
        {
            InitializeComponent();

            dBConn = p_SqlClient;
            Mode = p_Mode;
            StartMode = Mode;
            txtMtrNum.Text = p_MtrNum;
        }

        // This constructor is only used for 
        public frmMtrData(dBClient p_SqlClient, bool p_MachMtrDetail, string p_MtrNum)
        {
            InitializeComponent();

            dBConn = p_SqlClient;
            Mode = ModeView;
            StartMode = Mode;
            MachMtrDetail = p_MachMtrDetail;

            txtMtrNum.Text = p_MtrNum;

        }
        #endregion

        #region Form Load Functions
        private void frmMtrInfo_Load(object sender, EventArgs e)
        {
            List<dBColInfo>inf = new List<dBColInfo>();
            dBConn.GetTblColInfo(TblMtr, ref inf);
            for(int i=0;i<inf.Count;i++)
            {
                MtrVal tmp = new MtrVal { ColInf = (dBColInfo)inf[i].Clone() };
                Vals.Add(tmp);
            }
            LoadObjs();
            

            if(txtMtrNum.Text != "")
            {
                dBConn.QueryStr(TblMtr, "*", "MTR_NUM", PartFunc.Cnv2ULFrmt(txtMtrNum.Text));
                if(dBConn.Table.Rows.Count > 0)
                {
                    DataTable tbl = new DataTable();
                    tbl = dBConn.Table.Copy();
                    FillEssInf(ref tbl);
                    FillUrschInf(ref tbl);
                    FillGenInf(ref tbl);

                    dBConn.QueryStr(TblMtrFLC, "*", "MTR_NUM", PartFunc.Cnv2ULFrmt(txtMtrNum.Text));
                    tbl = new DataTable();
                    tbl = dBConn.Table.Copy();
                    tbl.Columns.Remove("MTR_NUM");
                    FillFLCData(ref tbl);
                    btnExitCan.Select();
                }
            }
            else
                txtMtrNum.Select();

            ObjStoreOld();
            SetDataMode();
            FillCBItems();

            if(MachMtrDetail)
            {
                btnDelete.Visible = false;
                btnModSave.Visible = false;
            }

        }
        #endregion

        #region Database Information Acquisition Methods
        private void FillCBItems()
        {
            dBConn.QueryDistStr(TblMtr, "MTR_HP", p_OrderBy: "MTR_HP");
            for(int i = 0; i < dBConn.Table.Rows.Count; i++)
                cmbHP.Items.Add(dBConn.Table.Rows[i][0].ToString());

            dBConn.QueryDistStr(TblMtr, "MTR_FRM", p_OrderBy: "MTR_FRM");
            for(int i = 0; i < dBConn.Table.Rows.Count; i++)
                cmbFrame.Items.Add(dBConn.Table.Rows[i][0].ToString());

            dBConn.QueryDistStr(TblMtr, "MTR_CONST", p_OrderBy: "MTR_CONST");
            for(int i = 0; i < dBConn.Table.Rows.Count; i++)
                cmbConst.Items.Add(dBConn.Table.Rows[i][0].ToString());

            dBConn.QueryDistStr(TblMtr, "MTR_MFR", p_OrderBy: "MTR_MFR");
            for(int i = 0; i < dBConn.Table.Rows.Count; i++)
                cmbMfr.Items.Add(dBConn.Table.Rows[i][0].ToString());
        }

        private void GetMtrDBCols()
        {
            List<dBColInfo> col_inf = new List<dBColInfo>();
            int val = dBConn.GetTblColInfo(TblMtr, ref col_inf);

            return;
        }

        private void btnDescSrch_Click(object sender, EventArgs e)
        {
            dBClient db = new dBClient();
            db.Open("ULSQL12T", "PartInfo", true, "", "");
            string num = PartFunc.Cnv2ULFrmt(txtMtrNum.Text);
            if(db.QueryStr("NewPMst", "FULLDESCRIPTION", "PARTNBR", num) > 0)
                txtMtrDesc.Text = db.Table.Rows[0][0].ToString();
            db.Close();
        }

        #endregion

        #region Form Controls Manipulation
        private void LoadObjs()
        {
            Vals["MTR_NUM"] = txtMtrNum;
            Vals["MTR_DESC"] = txtMtrDesc;
            Vals["MTR_MFR"] = cmbMfr;
            Vals["MTR_MFR_NUM"] = txtMfrNum;
            Vals["MTR_HP"] = cmbHP;
            Vals["MTR_POLES"] = cmbPoles;
            Vals["MTR_FRM"] = cmbFrame;
            Vals["MTR_CONST"] = cmbConst;
            Vals["MTR_TYPE"] = cmbType;
            Vals["MTR_KVA_CDE"] = cmbKVA;
            Vals["MTR_INS"] = cmbIns;
            Vals["MTR_DSN"] = cmbDsn;
            Vals["MTR_BRG_DE"] = txtBrgDE;
            Vals["MTR_BRG_ODE"] = txtBrgODE;
            Vals["MTR_PRNT_UL"] = txtPrntUL;
            Vals["MTR_PRNT_VEND"] = txtPrntVend;
            Vals["PF_50"] = txtPF_50;
            Vals["EFF_50"] = txtEff_50;
            Vals["PF_60"] = txtPF_60;
            Vals["EFF_60"] = txtEff_60;
            Vals["FLC_200_50"] = txtFLC_200_50;
            Vals["FLC_208_50"] = txtFLC_208_50;
            Vals["FLC_220_50"] = txtFLC_220_50;
            Vals["FLC_230_50"] = txtFLC_230_50;
            Vals["FLC_240_50"] = txtFLC_240_50;
            Vals["FLC_380_50"] = txtFLC_380_50;
            Vals["FLC_400_50"] = txtFLC_400_50;
            Vals["FLC_415_50"] = txtFLC_415_50;
            Vals["FLC_200_60"] = txtFLC_200_60;
            Vals["FLC_208_60"] = txtFLC_208_60;
            Vals["FLC_220_60"] = txtFLC_220_60;
            Vals["FLC_230_60"] = txtFLC_230_60;
            Vals["FLC_240_60"] = txtFLC_240_60;
            Vals["FLC_380_60"] = txtFLC_380_60;
            Vals["FLC_460_60"] = txtFLC_460_60;
            Vals["FLC_575_60"] = txtFLC_575_60;
        }

        private void ObjStoreOld()
        {
            OldVals.Clear();
            for(int i = 0; i < Vals.Count; i++)
                OldVals.Add(Vals.ValList[i].Ctrl.Text);
        }

        private int ObjEntryChng(ref List<int> p_ChngIdx)
        {
            int chng_cnt = 0;

            p_ChngIdx.Clear();
            for(int i = 0; i < Vals.Count; i++)
            {
                if(Vals.ValList[i].Ctrl.Text != OldVals[i])
                {
                    p_ChngIdx.Add(i);
                    chng_cnt++;
                }
            }

            return chng_cnt;
        }

        private bool ObjEntryChng()
        {
            bool ret_val = false;
            int mismatch_cnt = 0;

            for(int i = 0; i < Vals.Count; i++)
            {
                if(Vals.ValList[i].Ctrl.Text != OldVals[i])
                    mismatch_cnt++;
            }
            if(mismatch_cnt > 0)
                ret_val = true;

            return ret_val;
        }

        private void ObjValsReset()
        {
            for(int i = 0; i < Vals.Count; i++)
            {
                Vals.ValList[i].Ctrl.Text = OldVals[i];
            }
        }

        private void SetDataMode()
        {
            bool CtrlEn = false;
            bool MtrNumEn = false;
            
            btnDelete.Visible = false;
            switch(Mode)
            {
                case ModeView:
                    btnModSave.Text = "Modify";
                    btnExitCan.Text = "Exit";
                    break;

                case ModeIns:
                    btnModSave.Text = "Save";
                    btnExitCan.Text = "Cancel";
                    CtrlEn = true;
                    MtrNumEn = true;
                    break;
                case ModeUpd:
                    btnModSave.Text = "Save";
                    btnExitCan.Text = "Cancel";
                    CtrlEn = true;
                    if(Environment.UserName == "sferry")
                        btnDelete.Visible = true;
                    break;
            }

            for(int i = 0; i < Vals.Count; i++)
                Vals.ValList[i].Ctrl.Enabled = CtrlEn;
            btnBrwsUL.Enabled = CtrlEn;
            btnBrwsVend.Enabled = CtrlEn;
            btnDescSrch.Enabled = CtrlEn;

            txtMtrNum.Enabled = MtrNumEn;
        }
        #endregion

        #region Exising Motor Data Form Fill Methods 

        private void FillEssInf(ref DataTable p_Tbl)
        {
            cmbHP.Text = p_Tbl.Rows[0]["MTR_HP"].ToString();
            cmbFrame.Text = p_Tbl.Rows[0]["MTR_FRM"].ToString();
            cmbConst.Text = p_Tbl.Rows[0]["MTR_CONST"].ToString();
            cmbType.SelectedIndex = cmbType.Items.IndexOf(p_Tbl.Rows[0]["MTR_TYPE"].ToString());
        }

        private void FillUrschInf(ref DataTable p_Tbl)
        {
            txtMtrDesc.Text = p_Tbl.Rows[0]["MTR_DESC"].ToString();
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

            // Get item index for the pole count
            str = p_Tbl.Rows[0]["MTR_POLES"].ToString();
            cmbPoles.SelectedIndex = CmbFunc.FindIdxSubStr(ref cmbPoles, str);

            txtBrgDE.Text = p_Tbl.Rows[0]["MTR_BRG_DE"].ToString();
            txtBrgODE.Text = p_Tbl.Rows[0]["MTR_BRG_DE"].ToString();
        }

        private void cmbHP_TextChanged(object sender, EventArgs e)
        {
            if((cmbHP.Text != "") && (StrFunc.IsNumeric(cmbHP.Text)))
            {
                txtPwr.Text = (Convert.ToSingle(cmbHP.Text) * 0.75).ToString();
            }
        }

        private void FillFLCData(ref DataTable p_Tbl)
        {
            // Get the starting index for FLC in the Motor Value Collection
            int start_idx = Vals.FindIndex("PF_50");

            for(int i = 0; i < p_Tbl.Columns.Count; i++)
            {
                Vals.ValList[i + start_idx].Ctrl.Text = p_Tbl.Rows[0][i].ToString();
            }
            return;
        }
        
        #endregion
        
        #region Datasheet Methods

        private void btnViewUL_Click(object sender, EventArgs e)
        {
            if(txtPrntUL.Text != "")
                DatasheetView(txtPrntUL.Text);
        }

        private void btnViewVend_Click(object sender, EventArgs e)
        {
            if(txtPrntVend.Text != "")
                DatasheetView(txtPrntVend.Text);
        }

        private void btnBrws_Click(object sender, EventArgs e)
        {
            string name = ((Control)sender).Name;

            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";

            if(name == "btnBrwsVend")
            {
                string dir = "N:\\Motors";
                string subdir = PartFunc.CnvFromULFrmt(PartFunc.Cnv2ULFrmt(txtMtrNum.Text));
                if(subdir != "")
                    dir += String.Format("\\{0}", subdir);
                    
                opfd.InitialDirectory = dir;
            }
            else
            {
                string dir = "S:\\Images\\Shop_dwg";
                string subdir = "";
                string ul_name = PartFunc.Cnv2ULFrmt(txtMtrNum.Text);
                if(ul_name.Length == 8)
                {
                    subdir = "\\Projects";
                }
                else if((ul_name.Length == 6) && (ul_name[0] == '0'))
                {
                    subdir = String.Format("\\Print_{0}", ul_name[1]);
                }
                else if((ul_name.Length == 6) && ((ul_name[0] == '1') || (ul_name[0] == '2') || (ul_name[0] == '3') || (ul_name[0] == '4') || (ul_name[0] == '8')))
                {
                    subdir += "\\CP_Scan";
                }
                
                dir += subdir;
                opfd.InitialDirectory = dir;
            }
            

            if(opfd.ShowDialog() == DialogResult.OK)
            {
                if(name == "btnBrwsUL")
                    txtPrntUL.Text = opfd.FileName;
                else
                    txtPrntVend.Text = opfd.FileName;

            }
        }

        private void DatasheetView(string p_File)
        {
            try
            {
                System.Diagnostics.Process.Start(p_File);
            }
            catch(Exception ex)
            {
                string msg = String.Format("Error opening Urschel Print!\n{0}", ex.Message);
                string cap = "Datasheet File Error!";
                MsgBox.Err(msg,cap);
            }
        }

        #endregion

        #region Database Save (Insert & Modify), and Delete Methods

        private void btnModSave_Click(object sender, EventArgs e)
        {
            switch(Mode)
            {
                case ModeView: // Currently in View Mode, transitioning to Update or Insert Mode
                    ObjStoreOld();
                    if(txtMtrNum.Text == "")
                        Mode = ModeIns;
                    else
                        Mode = ModeUpd;
                    break;
                case ModeIns: // Currently in Insert Mode, we need to use SQL insert on the database
                    if(dB_MtrInsert())
                        Mode = ModeView;
                    else
                        goto btnModSave_Return;
                    break;
                case ModeUpd: // Currently in Update Mode, we need to use SQL update on the database
                    dB_MtrUpdate();
                    Mode = ModeView;
                    break;
            }

            SetDataMode();

            btnModSave_Return:
            return;
        }

        private bool dB_MtrInsert()
        {
            bool ret_val = false;
            // Make sure motor number is not blank
            if(txtMtrNum.Text == "")
            {
                MsgBox.Err("Valid Urschel motor part number required!");
                goto dB_MtrInsert_Return;
            }

            string part_num = PartFunc.Cnv2ULFrmt(txtMtrNum.Text);
            if(part_num == "")
            {
                MsgBox.Err("The motor part number needs to be a valid Urschel part number format.");
                goto dB_MtrInsert_Return;
            }
            
            // Make sure motor does not already exist
            if(dBConn.QueryStr(TblMtr, "IDX", "MTR_NUM", part_num) > 0)
            {
                string msg = "This motor already exists in the database, do you wish to overwrite the existing data?";
                if(MsgBox.YN(msg, "Overwrite Confirmation") == DialogResult.No)
                    goto dB_MtrInsert_Return;
            }
            // Force the Motor Value Collection to populate its values as strings using '' 
            // or specific numbers to send to the database during inserts or updates.
            Vals.SetValues();

            string InsCols = "";
            string InsVals = "";
            int InsCnt = Vals.GetdBInsertStrings(ref InsCols, ref InsVals);
            if(InsCnt > 0)
            {
                if(dBConn.Insert(TblMtr, InsCols, InsVals))
                {
                    MsgBox.Info("Motor information successfully added to the database.");
                    ret_val = true;
                }
                else
                {
                    MsgBox.dBErr("Error adding motor to the database!");
                }
            }
            

            dB_MtrInsert_Return:
            return ret_val;
        }

        private void dB_MtrUpdate()
        {
            List<int> chg_idx = new List<int>();

            if(ObjEntryChng(ref chg_idx) > 0)
            {
                // Force the Motor Value Collection to populate its values as strings using '' 
                // or specific numbers to send to the database during inserts or updates.
                Vals.SetValues();
                List<string> UpdCols = new List<string>();
                List<string> UpdVals = new List<string>();
                int UpdCnt = Vals.GetdBUpdateStrings(ref chg_idx, ref UpdCols, ref UpdVals);
                if(UpdCnt > 0)
                {
                    if(dBConn.UpdateStr(TblMtr, UpdCols, UpdVals, "MTR_NUM", PartFunc.Cnv2ULFrmt(txtMtrNum.Text)))
                        MsgBox.Info("Motor information successfully updated.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = String.Format("Are you sure you want to delete motor part number {0} from the database?", txtMtrNum.Text);
            string cap = "Delete Confirmation";
            if(MsgBox.YN(msg, cap) == DialogResult.Yes)
            {
                dBConn.DeleteStr(TblMtr, "MTR_NUM", txtMtrNum.Text);
            }
            this.Close();
        }

        #endregion  

        #region Form Exit Methods
        private void btnExitCan_Click(object sender, EventArgs e)
        {
            List<int> chng_idx = new List<int>();

            string cap = "New Motor Specification";
            switch(Mode)
            {
                case ModeView:
                    this.Close();
                    break;
                case ModeIns:
                    if(ObjEntryChng())
                    {
                        string InsMsg = "Cancel new motor specification?";
                        if(MsgBox.YN(InsMsg, cap) == DialogResult.Yes)
                            this.Close();
                    }
                    else
                        this.Close();
                    break;
                case ModeUpd:
                    if(ObjEntryChng())
                    {
                        string UpdMsg = "Cancel updates to the motor specification?";
                        if(MsgBox.YN(UpdMsg, cap) == DialogResult.Yes)
                        {
                            ObjValsReset();
                            Mode = ModeView;
                        }
                    }
                    else
                        Mode = ModeView;
                    SetDataMode();
                    break;
            }
        }
        #endregion

    }

    public class MtrVal
    {
        public dBColInfo ColInf;
        public Control Ctrl;
        public string Value;

        public MtrVal() { }

        public MtrVal(dBColInfo p_ColInf, Control p_Ctrl, string p_Val)
        {
            ColInf = (dBColInfo)p_ColInf.Clone();
            Ctrl = p_Ctrl;
            Value = p_Val;
        }
    }

    public class MtrValCollection : InternalDataCollectionBase
    {
        // Main Collection List
        public List<MtrVal> ValList;

        // Class Constructors
        public MtrValCollection() { ValList = new List<MtrVal>(); }
        
        // Class indexers
        public MtrVal this[int index]
        {
            get => ValList[index];
            set => ValList[index] = value;
        }

        public Control this[string index]
        {
            set
            {
                int idx = GetIdx(index);
                ValList[idx].Ctrl = value;
            }
        }

        // Collection Methods
        public void Add(MtrVal p_Val) { ValList.Add(p_Val); }
        public void Clear() { ValList.Clear(); }
        public override int Count { get => ValList.Count();  }

        // Search Methods
        public int FindIndex(string p_ColName)
        {
            return GetIdx(p_ColName);
        }

        private int GetIdx(string p_Name)
        {
            int ret_val = -1;

            for(int i = 0; i < ValList.Count; i++)
            {
                if(ValList[i].ColInf.Name.Equals(p_Name))
                {
                    ret_val = i;
                    break;
                }
            }
            return ret_val;
        }

        // Database assistance methods
        public void SetValues()
        {
            for(int i=0;i<ValList.Count;i++)
            {
                if(ValList[i].Ctrl.Text != "")
                {
                    switch(ValList[i].ColInf.DataType)
                    {
                        case "nchar":
                        case "nvarchar":
                        case "varchar":
                        case "char":
                            string tmp_val = ValList[i].Ctrl.Text;
                            if(ValList[i].ColInf.Name == "MTR_NUM")
                                tmp_val = PartFunc.Cnv2ULFrmt(tmp_val);
                            if(ValList[i].ColInf.Name == "MTR_INS")
                                tmp_val = ValList[i].Ctrl.Text.Substring(0, 1);

                            ValList[i].Value = String.Format("'{0}'", tmp_val);
                            break;
                        default:
                            ValList[i].Value = ValList[i].Ctrl.Text;
                            break;
                    }
                }
            }
        }

        public int GetdBInsertStrings(ref string p_Cols, ref string p_Vals)
        {
            int cnt = 0;

            p_Cols = ""; p_Vals = "";

            for(int i=0;i<ValList.Count;i++)
            {
                if(ValList[i].Value != null)
                {
                    p_Cols += String.Format("{0}, ", ValList[i].ColInf.Name);
                    p_Vals += String.Format("{0}, ", ValList[i].Value);
                    cnt++;
                }
            }

            if(cnt > 0)
            {
                p_Cols = p_Cols.Substring(0, p_Cols.Length - 2);
                p_Vals = p_Vals.Substring(0, p_Vals.Length - 2);
            }

            return cnt;
        }

        public int GetdBUpdateStrings(ref List<int> p_Idx, ref List<string> p_Cols, ref List<string> p_Vals)
        {
            int cnt = 0;

            p_Cols.Clear();
            p_Vals.Clear();

            for(int i=0;i<p_Idx.Count;i++)
            {
                if(ValList[p_Idx[i]].Value != null)
                {
                    p_Cols.Add(ValList[p_Idx[i]].ColInf.Name);
                    p_Vals.Add(ValList[p_Idx[i]].Value);
                    cnt++;
                }
            }

            return cnt;
        }
    }

}