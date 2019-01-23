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
using MDI_VFD.Motor;
using GenFunc;

namespace MDI_VFD.Machine
{
    public partial class frmMachMtrDefs : Form
    {
        #region Class Global Values
        // Data Form Modes
        const int ModeView = 0;
        const int ModeIns = 1;
        const int ModeUpd = 2;
        int Mode = ModeView;
        int StartMode = ModeView;
        int OldMode = ModeView;

        string MachCode = "";
        int MtrNum = 0;
        string MtrName = "";
        string MtrHP = "";

        // Database Globals
        dBClient dBConn;

        string dBMtrPrfx;
        int IdxMtrPNStrt = 0;
        int IdxMtrPNEnd = 0;

        // Form Objects
        dBRowCtrlData Vals = new dBRowCtrlData();
        List<string> ctrlOld = new List<string>();
        List<Button> lstBtns = new List<Button>();

        List<dBColCtrlData> MtrChngs;

        const int MaxMtrPN = 16;

        #endregion

        #region Class Constructors

        public frmMachMtrDefs(dBClient p_SQLClient, string p_MachCode, int p_MtrNum, string p_MtrName, string p_MtrHP, int p_Mode, ref List<dBColCtrlData> p_ColDataChng)
        {
            InitializeComponent();

            dBConn = p_SQLClient;
            MachCode = p_MachCode;
            MtrNum = p_MtrNum;
            MtrName = p_MtrName;
            MtrHP = p_MtrHP;
            StartMode = p_Mode;
            MtrChngs = p_ColDataChng;

            LoadObjs();
        }

        #endregion

        #region Form Methods

        private void frmMachMtrDefs_Load(object sender, EventArgs e)
        {
            if(GetDataMode() != ModeIns)
            {
                if(dBConn.QueryStr(Resources.tblMachDataMtrDefs, "*", "MACH_CODE", MachCode) > 0)
                {
                    for(int i=IdxMtrPNStrt, j=1;i<(IdxMtrPNStrt + MaxMtrPN);i++, j++)
                        Vals.ColData[i].Ctrl.Text = PartFunc.CnvFromULFrmt(dBConn.Table.Rows[0][i].ToString());
                }
            }

            txtMachCode.Text = MachCode;
            txtMtrName.Text = MtrName;
            txtMtrHP.Text = MtrHP;

            SetDataMode(StartMode);
        }

        private void frmMachMtrDefs_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, (EventArgs)e);
            }
        }

        #endregion

        #region Form Control Object Manipulation
        private void LoadObjs()
        {
            List<dBColInfo> lst = new List<dBColInfo>();
            if(dBConn.GetTblColInfo(Resources.tblMachDataMtrDefs, ref lst) > 0)
            {
                Vals.Clear();
                for(int i=0;i<lst.Count;i++)
                {
                    dBColCtrlData tmp = new dBColCtrlData { ColInf = (dBColInfo)lst[i].Clone() } ;
                    if(tmp.ColInf.Name != "IDX")
                        Vals.ColData.Add(tmp);
                }
            }

            dBMtrPrfx = String.Format("DEF_MTR{0}_", MtrNum);

            // 50 Hz Motors
            Vals[dBMtrPrfx + "200_50"] = txtFLC_200_50;
            Vals[dBMtrPrfx + "208_50"] = txtFLC_208_50;
            Vals[dBMtrPrfx + "220_50"] = txtFLC_220_50;
            Vals[dBMtrPrfx + "230_50"] = txtFLC_230_50;
            Vals[dBMtrPrfx + "240_50"] = txtFLC_240_50;
            Vals[dBMtrPrfx + "380_50"] = txtFLC_380_50;
            Vals[dBMtrPrfx + "400_50"] = txtFLC_400_50;
            Vals[dBMtrPrfx + "415_50"] = txtFLC_415_50;

            // 60 Hz Motors
            Vals[dBMtrPrfx + "200_60"] = txtFLC_200_60;
            Vals[dBMtrPrfx + "208_60"] = txtFLC_208_60;
            Vals[dBMtrPrfx + "220_60"] = txtFLC_220_60;
            Vals[dBMtrPrfx + "230_60"] = txtFLC_230_60;
            Vals[dBMtrPrfx + "240_60"] = txtFLC_240_60;
            Vals[dBMtrPrfx + "380_60"] = txtFLC_380_60;
            Vals[dBMtrPrfx + "460_60"] = txtFLC_460_60;
            Vals[dBMtrPrfx + "575_60"] = txtFLC_575_60;

            IdxMtrPNStrt = Vals.FindIndex(dBMtrPrfx + "200_50");
            IdxMtrPNEnd = IdxMtrPNStrt + MaxMtrPN;

            lstBtns.Clear();
            
            lstBtns.Add(btnMtr_200_50);
            lstBtns.Add(btnMtr_208_50);
            lstBtns.Add(btnMtr_220_50);
            lstBtns.Add(btnMtr_230_50);
            lstBtns.Add(btnMtr_240_50);
            lstBtns.Add(btnMtr_380_50);
            lstBtns.Add(btnMtr_400_50);
            lstBtns.Add(btnMtr_415_50);

            lstBtns.Add(btnMtr_200_60);
            lstBtns.Add(btnMtr_208_60);
            lstBtns.Add(btnMtr_220_60);
            lstBtns.Add(btnMtr_230_60);
            lstBtns.Add(btnMtr_240_60);
            lstBtns.Add(btnMtr_380_60);
            lstBtns.Add(btnMtr_460_60);
            lstBtns.Add(btnMtr_575_60);
        }

        private void ObjStoreOld()
        {
            ctrlOld.Clear();

            for(int i = IdxMtrPNStrt;i<IdxMtrPNEnd; i++)
                ctrlOld.Add(Vals.ColData[i].Ctrl.Text);
        }

        private bool ObjCompare()
        {
            bool ret_val = false;
            int mismatch_cnt = 0;

            for(int i=IdxMtrPNStrt, j=0;i<IdxMtrPNEnd;i++, j++)
            {
                if(Vals.ColData[i].Ctrl.Text != ctrlOld[j])
                    mismatch_cnt++;
            }

            if(mismatch_cnt == 0)
                ret_val = true;

            return ret_val;
        }

        private int ObjCompare(ref List<int>p_ChngIdx)
        {
            int mismatch_cnt = 0;

            p_ChngIdx.Clear();

            for(int i = IdxMtrPNStrt, j = 0; i < IdxMtrPNEnd; i++, j++)
            {
                if(Vals.ColData[i].Ctrl.Text != ctrlOld[j])
                {
                    p_ChngIdx.Add(i);
                    mismatch_cnt++;
                }
            }

            return mismatch_cnt;
        }

        private void SetDataMode(int p_Mode)
        {
            bool ctrl_en = false;

            OldMode = Mode;
            Mode = p_Mode;

            ObjStoreOld();

            switch(Mode)
            {
                case ModeView:
                    break;

                case ModeIns:
                    ctrl_en = true;
                    break;

                case ModeUpd:
                    ctrl_en = true;
                    break;
            }
            
            for(int i=IdxMtrPNStrt;i<(IdxMtrPNStrt + MaxMtrPN);i++)
                Vals.ColData[i].Ctrl.Enabled = ctrl_en;

            //for(int i=0;i<lstBtns.Count;i++)
            //    lstBtns[i].Enabled = ctrl_en;

            btnLookup.Visible = ctrl_en;
        }

        private int GetDataMode()
        {
            return Mode;
        }
        
        #endregion

        #region Motor Lookup Methods

        private void btnLookup_Click(object sender, EventArgs e)
        {
            frmMtrList mtr_srch = new frmMtrList(dBConn, MtrHP);
            mtr_srch.MtrNumSelected += new frmMtrList.SendMtrNumHandler(MtrSrch_MtrSelected);
            mtr_srch.ShowDialog();

        }

        private void MtrSrch_MtrSelected(object sender, MtrNumEventArgs e)
        {
            string mtr_num = e.MtrNum;

            // Search database for motor number and gather all the FLC data
            mtr_num = PartFunc.Cnv2ULFrmt(mtr_num);
            dBConn.QueryStr(Resources.tblMtrDataFLC, "*", "MTR_NUM", mtr_num);
            if(dBConn.Table.Rows.Count > 0)
            {
                int col_idx = dBConn.Table.Columns.IndexOf("FLC_200_50");
                for(int i=IdxMtrPNStrt, j=col_idx;i<IdxMtrPNEnd;i++, j++)
                {
                    // get the FLC value for the motor and check and see if there 
                    // is a FLC value for each voltage & frequency combination
                    string flc = dBConn.Table.Rows[0][j].ToString();
                    if(flc != "")
                    {
                        // make sure there is not already a motor part number in that
                        // field. If there is, ask the user if they want to overwrite it.
                        // If the user chooses to NOT overwrite the value then we skip
                        // to the next FLC column.
                        if(Vals.ColData[i].Ctrl.Text != "")
                        {
                            string volt = "", freq = "";
                            ExtractVoltFreq(dBConn.Table.Columns[j].ColumnName, ref volt, ref freq);
                            string msg = String.Format("There is already a motor number for voltage frequency combination {0} VAC @ {1} Hz", volt, freq);
                            string cap = "Motor Part Number Overwrite";
                            if(MsgBox.YN(msg, cap) == DialogResult.No)
                                continue;
                        }

                        Vals.ColData[i].Ctrl.Text = PartFunc.CnvFromULFrmt(mtr_num);
                    }
                }
            }
        }

        private void ExtractVoltFreq(string p_Str, ref string p_Volt, ref string p_Freq)
        {
            int idx = p_Str.IndexOf('_');
            if(idx >= 0)
            {
                p_Str = p_Str.Substring(idx + 1, p_Str.Length - (idx+1));
                p_Volt = p_Str.Substring(0, 3);
                idx = p_Str.IndexOf('_');
                if(idx >= 0)
                {
                    p_Freq = p_Str.Substring(idx + 1, 2);
                }
            }
        }

        #endregion

        #region Motor Detail Methods

        private void btnDetail_Click(object sender, EventArgs e)
        {
            string btn_name = ((Button)sender).Name;
            string volt = "", freq = "";
            ExtractVoltFreq(btn_name, ref volt, ref freq);

            string db_col = String.Format("{0}{1}_{2}", dBMtrPrfx, volt, freq);
            string mtr_num = PartFunc.Cnv2ULFrmt(Vals[db_col].Text);
            if(mtr_num != "")
            {
                frmMtrData mtr_data = new frmMtrData(dBConn, true, mtr_num);
                mtr_data.ShowDialog();
            }
        }

        #endregion

        #region Form Exit Methods

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Check and see if any of the motor part numbers have changed from
            // when the form first loaded. 
            List<int> chng_idx = new List<int>();
            if(ObjCompare(ref chng_idx) > 0)
            {
                // If there are changes go through the change index and 
                // add them to the MtrChngs dBColCtrlData objects.
                for(int i = 0; i < chng_idx.Count; i++)
                {
                    // First check and see if that entry already exists in the 
                    // change index (basically changing for a second time)
                    dBColCtrlData chng_val = Vals.ColData[chng_idx[i]].Copy();
                    int idx = FindMtrChng(ref MtrChngs, ref chng_val);
                    if(idx >= 0)
                        MtrChngs.RemoveAt(idx);

                    MtrChngs.Add(chng_val);
                }
            }
            this.Close();
        }

        private int FindMtrChng(ref List<dBColCtrlData> p_ChngList, ref dBColCtrlData p_ChngVal)
        {
            int idx = -1;

            for(int i=0;i<p_ChngList.Count;i++)
            {
                if(p_ChngList[i].ColInf.Name == p_ChngVal.ColInf.Name)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }

        #endregion
        
    } // class frmMachMtrDefs
    
}
