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

namespace MDI_VFD.Machine
{
    public partial class frmMachData : Form
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

        // Database Globals
        dBClient dBConn;
        
        const string TblMachData = "TMP_MACH_DATA";
        const string TblMachGenData = "MACH_GEN_DATA";
        const string TblMtrData = "MTR_DATA";
        const int MaxMtr = 5;
        const int MaxDrv = 5;

        const int MtrOffset = 2;
        const int DrvOffset = 3;

        int IdxMtrAsgn = 0;

        // Form Objects
        dBRowCtrlData Vals = new dBRowCtrlData();
        List<string> ctrlOld = new List<string>();
        List<MtrObj> lstMtrObj = new List<MtrObj>();
        List<DrvObj> lstDrvObj = new List<DrvObj>();
        List<int> OldDrvChks = new List<int>();

        //List<DefMtrNums> lstMtrPNChng = new List<DefMtrNums>();
        List<dBColCtrlData> MtrColChng = new List<dBColCtrlData>();

        int InitColCnt = 0;

        int OldMtrCnt = 0;
        int OldDrvCnt = 0;

        Size SizeAllVis = new Size(650, 715);
        Size SizegrpMtrAll = new Size(530, 160);       
        const int SizeOffDrvGrp = 85;
        const int SizeOffMtr = 27;

        #endregion

        #region Class Constructors

        public frmMachData(dBClient p_SQLClient)
        {
            InitializeComponent();
            
            dBConn = p_SQLClient;
            
            StartMode = ModeIns;
            
            LoadObjs();

            if(Environment.UserName == "sferry")
                btnModSave.Visible = true;
        }

        public frmMachData(dBClient p_SQLClient, string p_MachCode, int p_Mode)
        {
            InitializeComponent();
            
            dBConn = p_SQLClient;
            MachCode = p_MachCode;
            StartMode = Mode;

            LoadObjs();

            if(Environment.UserName == "sferry")
                btnModSave.Visible = true;
        }

        #endregion

        #region Form Methods

        private void frmMachData_Load(object sender, EventArgs e)
        {
            // Fill motor HP comboboxes
            FillHPCombos();

            if(MachCode != "")
            {
                // Fill all form objects when viewing data associated with an existing machine record
                FillMachData();
            }
            else
                txtMachCode.Select();

            nudMtrCnt_ValueChanged(sender, e);
            nudDrvCnt_ValueChanged(sender, e);

            SetDataMode(StartMode);
        }

        private void frmMachData_KeyDown(object sender, KeyEventArgs e)
        {
            EventArgs evnt = new EventArgs();

            if(e.KeyCode == Keys.Escape)
                btnExitCan_Click(sender, evnt);

            if(e.KeyCode == Keys.Enter)
                btnModSave_Click(sender, evnt);

        }

        private void FillMachData()
        {
            dBConn.QueryStr(TblMachGenData, "*", "MACH_CODE", MachCode);

            // Get general database information
            for(int i = 0; i < Vals.ColData.Count; i++)
            {
                string col = Vals.ColData[i].ColInf.Name;
                Vals.ColData[i].Ctrl.Text = dBConn.Table.Rows[0][col].ToString();
            }

            // The motor assignments for the drives come in as CSV values. We 
            // Need to convert those CSV values to formatted DrvObj Check Values
            for(int i = IdxMtrAsgn, j = 0; i < (IdxMtrAsgn + MaxDrv); i++, j++)
            {
                string val = Vals.ColData[i].Ctrl.Text;
                lstDrvObj[j].SetChkVals(Csv2ChkVal(val));
            }

            // If the windows user is Steve Ferry then allow records to be deleted
            if(Environment.UserName == "sferry")
            {
                btnDel.Visible = true;
            }
        }

        private void FillHPCombos()
        {
            if(dBConn.QueryDist(TblMtrData, "MTR_HP", p_OrderBy: "MTR_HP") > 0)
            {
                for(int i=0;i<dBConn.Table.Rows.Count;i++)
                {
                    cmbMtr1HP.Items.Add(dBConn.Table.Rows[i][0].ToString());
                    cmbMtr2HP.Items.Add(dBConn.Table.Rows[i][0].ToString());
                    cmbMtr3HP.Items.Add(dBConn.Table.Rows[i][0].ToString());
                    cmbMtr4HP.Items.Add(dBConn.Table.Rows[i][0].ToString());
                    cmbMtr5HP.Items.Add(dBConn.Table.Rows[i][0].ToString());
                }
            }
        }

        #endregion

        #region Form Control Object Manipulation

        private void LoadObjs()
        {
            LoadDBObjs();
            LoadMtrObjs();
            LoadDrvObjs();
        }

        private void LoadDBObjs()
        {
            List<dBColInfo> lst = new List<dBColInfo>();
            dBConn.GetTblColInfo(TblMachGenData, ref lst);
            for(int i=0;i<lst.Count;i++)
            {
                dBColCtrlData tmp = new dBColCtrlData { ColInf = (dBColInfo)lst[i].Clone() } ;
                if(tmp.ColInf.Name != "IDX")
                    Vals.ColData.Add(tmp);
            }

            InitColCnt = Vals.Count;

            // Gen Info
            Vals["MACH_CODE"] = txtMachCode;
            Vals["MACH_DESC"] = txtMachDesc;
            Vals["MTR_CNT"] = nudMtrCnt;

            // Motor Data
            Vals["MTR1_NAME"] = txtMtr1Name;
            Vals["MTR1_HP"] = cmbMtr1HP;
            Vals["MTR2_NAME"] = txtMtr2Name;
            Vals["MTR2_HP"] = cmbMtr2HP;
            Vals["MTR3_NAME"] = txtMtr3Name;
            Vals["MTR3_HP"] = cmbMtr3HP;
            Vals["MTR4_NAME"] = txtMtr4Name;
            Vals["MTR4_HP"] = cmbMtr4HP;
            Vals["MTR5_NAME"] = txtMtr5Name;
            Vals["MTR5_HP"] = cmbMtr5HP;

            // VFD Gen Info
            Vals["DRV_CNT"] = nudDrvCnt;

            // Drive 1
            Vals["DRV1_NAME"] = txtDrv1Name;
            Vals["DEF_DRV1_HV"] = txtDrv1DefHV;
            Vals["DEF_DRV1_LV"] = txtDrv1DefLV;
            Control ctrl = new Control();
            Vals["DRV1_MTR_ASGN"] = ctrl;

            // Drive 2
            Vals["DRV2_NAME"] = txtDrv2Name;
            Vals["DEF_DRV2_HV"] = txtDrv2DefHV;
            Vals["DEF_DRV2_LV"] = txtDrv2DefLV;
            ctrl = new Control();
            Vals["DRV2_MTR_ASGN"] = ctrl;

            // Drive 3
            Vals["DRV3_NAME"] = txtDrv3Name;
            Vals["DEF_DRV3_HV"] = txtDrv3DefHV;
            Vals["DEF_DRV3_LV"] = txtDrv3DefLV;
            ctrl = new Control();
            Vals["DRV3_MTR_ASGN"] = ctrl;

            // Drive 4
            Vals["DRV4_NAME"] = txtDrv4Name;
            Vals["DEF_DRV4_HV"] = txtDrv4DefHV;
            Vals["DEF_DRV4_LV"] = txtDrv4DefLV;
            ctrl = new Control();
            Vals["DRV4_MTR_ASGN"] = ctrl;

            // Drive 5
            Vals["DRV5_NAME"] = txtDrv5Name;
            Vals["DEF_DRV5_HV"] = txtDrv5DefHV;
            Vals["DEF_DRV5_LV"] = txtDrv5DefLV;
            ctrl = new Control();
            Vals["DRV5_MTR_ASGN"] = ctrl;

            IdxMtrAsgn = Vals.FindIndex("DRV1_MTR_ASGN");
        }

        private void LoadMtrObjs()
        {
            lstMtrObj.Clear();
            
            // Motor 1
            MtrObj obj = new MtrObj();
            obj.lblMtrName = lblMtr1Name;
            obj.txtMtrName = txtMtr1Name;
            obj.lblMtrHP = lblMtr1HP;
            obj.cmbMtrHP = cmbMtr1HP;
            obj.btnMtrSel = btnMtrSel1;
            lstMtrObj.Add(obj);

            // Motor 2
            obj = new MtrObj();
            obj.lblMtrName = lblMtr2Name;
            obj.txtMtrName = txtMtr2Name;
            obj.lblMtrHP = lblMtr2HP;
            obj.cmbMtrHP = cmbMtr2HP;
            obj.btnMtrSel = btnMtrSel2;
            lstMtrObj.Add(obj);

            // Motor 3
            obj = new MtrObj();
            obj.lblMtrName = lblMtr3Name;
            obj.txtMtrName = txtMtr3Name;
            obj.lblMtrHP = lblMtr3HP;
            obj.cmbMtrHP = cmbMtr3HP;
            obj.btnMtrSel = btnMtrSel3;
            lstMtrObj.Add(obj);

            // Motor 4
            obj = new MtrObj();
            obj.lblMtrName = lblMtr4Name;
            obj.txtMtrName = txtMtr4Name;
            obj.lblMtrHP = lblMtr4HP;
            obj.cmbMtrHP = cmbMtr4HP;
            obj.btnMtrSel = btnMtrSel4;
            lstMtrObj.Add(obj);

            // Motor 5
            obj = new MtrObj();
            obj.lblMtrName = lblMtr5Name;
            obj.txtMtrName = txtMtr5Name;
            obj.lblMtrHP = lblMtr5HP;
            obj.cmbMtrHP = cmbMtr5HP;
            obj.btnMtrSel = btnMtrSel5;
            lstMtrObj.Add(obj);

            HideMtrObjs();
        }

        private void HideMtrObjs()
        {
            for(int i = 0; i < lstMtrObj.Count; i++)
                lstMtrObj[i].SetVis(false);
        }

        private void LoadDrvObjs()
        {
            lstDrvObj.Clear();
            
            // Drive 1
            DrvObj obj = new DrvObj();
            obj.grpDrv = grpDrv1;
            obj.btnDrvSel = btnDrv1Sel;
            obj.chkMtr1 = chkDrv1Mtr1;
            obj.chkMtr2 = chkDrv1Mtr2;
            obj.chkMtr3 = chkDrv1Mtr3;
            obj.chkMtr4 = chkDrv1Mtr4;
            obj.chkMtr5 = chkDrv1Mtr5;
            lstDrvObj.Add(obj);

            // Drive 2
            obj = new DrvObj();
            obj.grpDrv = grpDrv2;
            obj.btnDrvSel = btnDrv2Sel;
            obj.chkMtr1 = chkDrv2Mtr1;
            obj.chkMtr2 = chkDrv2Mtr2;
            obj.chkMtr3 = chkDrv2Mtr3;
            obj.chkMtr4 = chkDrv2Mtr4;
            obj.chkMtr5 = chkDrv2Mtr5;
            lstDrvObj.Add(obj);

            // Drive 3
            obj = new DrvObj();
            obj.grpDrv = grpDrv3;
            obj.btnDrvSel = btnDrv3Sel;
            obj.chkMtr1 = chkDrv3Mtr1;
            obj.chkMtr2 = chkDrv3Mtr2;
            obj.chkMtr3 = chkDrv3Mtr3;
            obj.chkMtr4 = chkDrv3Mtr4;
            obj.chkMtr5 = chkDrv3Mtr5;
            lstDrvObj.Add(obj);

            // Drive 4
            obj = new DrvObj();
            obj.grpDrv = grpDrv4;
            obj.btnDrvSel = btnDrv4Sel;
            obj.chkMtr1 = chkDrv4Mtr1;
            obj.chkMtr2 = chkDrv4Mtr2;
            obj.chkMtr3 = chkDrv4Mtr3;
            obj.chkMtr4 = chkDrv4Mtr4;
            obj.chkMtr5 = chkDrv4Mtr5;
            lstDrvObj.Add(obj);

            // Drive 5
            obj = new DrvObj();
            obj.grpDrv = grpDrv5;
            obj.btnDrvSel = btnDrv5Sel;
            obj.chkMtr1 = chkDrv5Mtr1;
            obj.chkMtr2 = chkDrv5Mtr2;
            obj.chkMtr3 = chkDrv5Mtr3;
            obj.chkMtr4 = chkDrv5Mtr4;
            obj.chkMtr5 = chkDrv5Mtr5;
            lstDrvObj.Add(obj);

            HideDrvObjs();
        }

        private void HideDrvObjs()
        {
            for(int i=0;i<lstDrvObj.Count;i++)
                lstDrvObj[i].SetGrpVis(false);
        }

        private void ObjStoreOld()
        {
            ctrlOld.Clear();
            //for(int i=0;i<ctrlDBVals.Count;i++)
            //    ctrlOld.Add(ctrlDBVals[i].Text);
            for(int i = 0; i < Vals.ColData.Count; i++)
                ctrlOld.Add(Vals.ColData[i].Ctrl.Text);

            OldDrvChks.Clear();
            for(int i = 0; i < lstDrvObj.Count; i++)
                OldDrvChks.Add(lstDrvObj[i].GetChkVals());


        }

        //private bool ObjCompare()
        //{
        //    bool ret_val = false;
        //    int mismatch_cnt = -1;

        //    if((ctrlOld.Count == Vals.ColData.Count) && (OldDrvChks.Count == lstDrvObj.Count))
        //    {
        //        mismatch_cnt = 0;
        //        for(int i=0;i< Vals.ColData.Count;i++)
        //        {
        //            if(Vals.ColData[i].Ctrl.Text != ctrlOld[i])
        //                mismatch_cnt++;
        //        }

        //        for(int i=0;i<lstDrvObj.Count;i++)
        //        {
        //            if(lstDrvObj[i].GetChkVals() != OldDrvChks[i])
        //                mismatch_cnt++;
        //        }
        //    }

        //    if(mismatch_cnt == 0)
        //        ret_val = true;

        //    return ret_val;
        //}

        //private int ObjCompare(ref List<int> p_IdxDB)
        //{
        //    int mismatch_cnt = -1;

        //    if((ctrlOld.Count == Vals.ColData.Count) && (OldDrvChks.Count == lstDrvObj.Count))
        //    {
        //        mismatch_cnt = 0;
        //        p_IdxDB.Clear();

        //        // First check the drive motor assignment checkboxes for changes
        //        for(int i = 0; i < lstDrvObj.Count; i++)
        //        {
        //            if(lstDrvObj[i].GetChkVals() != OldDrvChks[i])
        //                Vals.ColData[IdxMtrAsgn+i].Ctrl.Text = ChkVal2Csv(lstDrvObj[i].GetChkVals());
        //        }

        //        // Now check the actual database row control data collection for changes
        //        for(int i = 0; i < Vals.ColData.Count; i++)
        //        {
        //            if(Vals.ColData[i].Ctrl.Text != ctrlOld[i])
        //            {
        //                mismatch_cnt++;
        //                p_IdxDB.Add(i);
        //            }
        //        }


        //    }

        //    return mismatch_cnt;
        //}

        private bool ObjCompare()
        {
            bool ret_val = false;
            int mismatch_cnt = -1;

            
            mismatch_cnt = 0;

            // First check the drive motor assignment checkboxes for changes
            for(int i = 0; i < lstDrvObj.Count; i++)
            {
                if(lstDrvObj[i].GetChkVals() != OldDrvChks[i])
                    mismatch_cnt++;
            }

            // Check the actual database row control data collection for changes
            for(int i = 0; i < ctrlOld.Count; i++)
            {
                if(Vals.ColData[i].Ctrl.Text != ctrlOld[i])
                    mismatch_cnt++;
            }

            if(Vals.Count > ctrlOld.Count)
                mismatch_cnt += (Vals.Count - ctrlOld.Count);

            if(mismatch_cnt == 0)
                ret_val = true;

            return ret_val;
        }

        private int ObjCompare(ref List<int> p_IdxDB)
        {
            int mismatch_cnt = 0;
            
            p_IdxDB.Clear();

            // First check the drive motor assignment checkboxes for changes
            for(int i = 0; i < lstDrvObj.Count; i++)
            {
                if(lstDrvObj[i].GetChkVals() != OldDrvChks[i])
                    Vals.ColData[IdxMtrAsgn + i].Ctrl.Text = ChkVal2Csv(lstDrvObj[i].GetChkVals());
            }

            // Check the actual database row control data collection for changes
            for(int i = 0; i < ctrlOld.Count; i++)
            {
                if(Vals.ColData[i].Ctrl.Text != ctrlOld[i])
                {
                    mismatch_cnt++;
                    p_IdxDB.Add(i);
                }
            }

            // If we have more Vals dBRowCtrlData objects than old strings then we
            // added motors to the update/insert list. Just add those objects to the change list
            if(Vals.Count > ctrlOld.Count)
            {
                for(int i=ctrlOld.Count;i<Vals.Count;i++)
                {
                    p_IdxDB.Add(i); 
                    mismatch_cnt++;
                }
            }

            return mismatch_cnt;
        }

        private void ObjReset()
        {
            //for(int i = 0; i < ctrlDBVals.Count; i++)
            //    ctrlDBVals[i].Text = ctrlOld[i];
            for(int i=0;i<InitColCnt;i++)
                Vals.ColData[i].Ctrl.Text = ctrlOld[i];

            if(Vals.Count > InitColCnt)
                Vals.Trim(InitColCnt);

            for(int i = 0; i < lstDrvObj.Count; i++)
                lstDrvObj[i].SetChkVals(OldDrvChks[i]);
        }

        private void SetDataMode(int p_Mode)
        {
            bool CtrlEn = false;
            bool MachCodeEn = false;

            OldMode = Mode;
            Mode = p_Mode;

            ObjStoreOld();

            switch(Mode)
            {
                case ModeView:
                    CtrlEn = false;
                    btnExitCan.Text = "Exit";
                    btnModSave.Text = "Modify";
                    break;
                case ModeIns:
                    CtrlEn = true;
                    MachCodeEn = true;
                    btnExitCan.Text = "Cancel";
                    btnModSave.Text = "Save";
                    break;
                case ModeUpd:
                    CtrlEn = true;
                    btnExitCan.Text = "Cancel";
                    btnModSave.Text = "Save";
                    break;
            }

            for(int i = 0; i < Vals.ColData.Count; i++)
                Vals.ColData[i].Ctrl.Enabled = CtrlEn;
            for(int i = 0; i < lstDrvObj.Count; i++)
                lstDrvObj[i].SetObjEn(CtrlEn);
            //for(int i = 0; i < lstMtrObj.Count; i++)
            //    lstMtrObj[i].SetBtnEn(CtrlEn);

            txtMachCode.Enabled = MachCodeEn;
        }

        private int GetDataMode()
        {
            return Mode;
        }

        #endregion

        #region Motor Methods

        private void nudMtrCnt_ValueChanged(object sender, EventArgs e)
        {
            if(((Control)nudMtrCnt).Text == "")
                nudMtrCnt.Value = 1;

            int mtr_cnt = Convert.ToInt32(nudMtrCnt.Value);

            // If we are reducing the number of motors then we need to clear
            // out the motor text boxes so the database can update appropriately
            // and clear out the existing values
            if(mtr_cnt < OldMtrCnt)
            {
                int mtr_idx = Vals.FindIndex("MTR1_NAME");
                mtr_idx += MtrOffset * mtr_cnt;
                for(int i=mtr_cnt, j=mtr_idx;i<MaxMtr;i++, j+=MtrOffset)
                {
                    for(int k=0;k<2;k++)
                        Vals.ColData[j+k].Ctrl.Text = "";
                }
            }

            // Set the appropriate number of motor rows as visible
            HideMtrObjs();
            for(int i = 0; i < mtr_cnt; i++)
                lstMtrObj[i].SetVis(true);

            // Resize the Motor Info groupbox to match the number of motors
            int sub = MaxMtr - mtr_cnt;

            Size xy = new Size();
            xy = SizegrpMtrAll;
            xy.Height = xy.Height - (sub * SizeOffMtr); 
            grpMtr.Size = xy;

            // Set the number of drive motor assignment checkboxes
            // as visible based on the number of motors the machine has
            for(int i=0;i<lstDrvObj.Count;i++)
                lstDrvObj[i].SetChkVis(mtr_cnt);

            OldMtrCnt = mtr_cnt;
        }

        private void btnMtrSel_Click(object sender, EventArgs e)
        {
            string btn_name = ((Control)sender).Name;
            int mtr_num = Convert.ToInt32(btn_name.Substring(btn_name.Length-1,1));
            int idx = mtr_num - 1;

            frmMachMtrDefs mtr_defs = new frmMachMtrDefs(dBConn, MachCode, mtr_num, lstMtrObj[idx].txtMtrName.Text, lstMtrObj[idx].cmbMtrHP.Text, GetDataMode(), ref MtrColChng);
            mtr_defs.ShowDialog();
            
            // If the motor change list is non-zero then add it to the Vals dBRowCtrlData list
            if(MtrColChng.Count > 0)
            {
                if(Vals.Count > InitColCnt)
                    Vals.Trim(InitColCnt);

                for(int i=0;i<MtrColChng.Count;i++)
                    Vals.Add(MtrColChng[i]);
            }
        }
        

        #endregion

        #region Drive Methods

        private void nudDrvCnt_ValueChanged(object sender, EventArgs e)
        {
            HideDrvObjs();

            int drv_cnt = Convert.ToInt32(nudDrvCnt.Value);

            // If we are reducing the number of drives we need to clear the 
            // text values in the control so the database can get rid
            // of the drive information
            if(drv_cnt < OldDrvCnt)
            {
                int drv_idx = Vals.FindIndex("DRV1_NAME");
                drv_idx += DrvOffset * drv_cnt;
                for(int i=drv_cnt, j=drv_idx;i<MaxDrv;i++, j+=DrvOffset)
                {
                    for(int k=0;k<3;k++)
                        Vals.ColData[j+k].Ctrl.Text = "";
                    lstDrvObj[i].SetChkVals(0x00);
                }
            }

            // Set the drive groups visible based on number of drives now
            // assigned to the machine.
            for(int i=0;i<drv_cnt;i++)
                lstDrvObj[i].SetGrpVis(true);

            int sub = MaxDrv - drv_cnt;

            Size xy = new Size();
            xy = SizeAllVis;
            xy.Height = xy.Height - (SizeOffDrvGrp * sub);
            this.Size = xy;

            if(drv_cnt > 0)
                chkVFDMach.Checked = true;
            else
                chkVFDMach.Checked = false;

            OldDrvCnt = drv_cnt;
        }

        private void chkVFDMach_CheckedChanged(object sender, EventArgs e)
        {
            if(!chkVFDMach.Checked)
                nudDrvCnt.Value = 0;
            else
            {
                if(nudDrvCnt.Value < 1)
                    nudDrvCnt.Value = 1;
            }
        }

        private void chkVFDMach_Click(object sender, EventArgs e)
        {
            if(GetDataMode() != ModeView)
            {
                if(chkVFDMach.CheckState == CheckState.Checked)
                {
                    chkVFDMach.CheckState = CheckState.Unchecked;
                    nudDrvCnt.Value = 0;
                }
                else if(chkVFDMach.CheckState == CheckState.Unchecked)
                {
                    chkVFDMach.CheckState = CheckState.Checked;
                    if(nudDrvCnt.Value < 1)
                        nudDrvCnt.Value = 1;
                }
            }
        }

        private int Csv2ChkVal(string p_Str)
        {
            int chk_val = 0;
            List<string> lst_str = new List<string>();

            if(StrFunc.NumCsv2List(p_Str, ref lst_str))
            {
                for(int i=0;i<lst_str.Count;i++)
                {
                    int num = Convert.ToInt32(lst_str[i]);
                    switch(num)
                    {
                        case 1:
                            chk_val |= 0x01;
                            break;
                        case 2:
                            chk_val |= 0x02;
                            break;
                        case 3:
                            chk_val |= 0x04;
                            break;
                        case 4:
                            chk_val |= 0x08;
                            break;
                        case 5:
                            chk_val |= 0x10;
                            break;
                    }
                }
            }

            return chk_val; 
        }

        private string ChkVal2Csv(int p_Val)
        {
            StringBuilder csv = new StringBuilder();

            for(int i=0;i<MaxDrv;i++)
            {
                if((p_Val & 0x01) == 1)
                {
                    csv.AppendFormat("{0},", (i+1).ToString());
                }
                p_Val >>= 0x01;
            }

            if(csv.Length > 1)
                csv.Remove(csv.Length-1, 1);

            return csv.ToString();
        }
        
        #endregion

        #region Machine Data Insert, Update, and Delete Methods

        private void btnModSave_Click(object sender, EventArgs e)
        {
            int new_mode = 0;

            switch(GetDataMode())
            {
                case ModeView: // currently in edit mode, need to switch to modify mode
                    // Store current values so that it can be determined if the values have changed.
                    //ObjStoreOld(); 

                    // If there is a machine code then we are updating a record
                    if(txtMachCode.Text != "")
                        new_mode = ModeUpd;
                    else // otherwise this is a new record; not likely this ever occurs because the going from a view mode always is an existing value
                        new_mode = ModeIns;
                    break;
                case ModeIns: // currently in insert mode, need to insert new record database record
                    if(MtrDataIns())
                        new_mode = ModeView;
                    else
                        goto btnModSave_Click_Return;
                    break;
                case ModeUpd: // currently in update mode, need to update machine database record
                    if(MtrDataUpd())
                        new_mode = ModeView;
                    else
                        goto btnModSave_Click_Return;
                    break;
            }

            SetDataMode(new_mode);

            btnModSave_Click_Return:
            return;
        }

        private bool MtrDataIns()
        {
            bool ret_val = false;

            if((txtMachCode.Text == "") || (txtMachCode.Text[0] != 'M'))
            {
                MsgBox.Err("A valid machine Urschel machine model number that begins with the letter 'M' is required!");
                goto MtrDataIns_return;
            }

            if(dBConn.QueryStr(TblMachData, "IDX", "MACH_CODE", txtMachCode.Text) > 0)
            {
                string msg = "This machine model already exists in the database, do you wish to overwrite?";
                string cap = "Machine Record Overwrite";
                if(MsgBox.YN(msg, cap) == DialogResult.No)
                    goto MtrDataIns_return;
            }

            // Need to get the drive motor assignment checkboxes converted to CSV values
            for(int i=0, j=IdxMtrAsgn;i<MaxDrv;i++, j++)
                Vals.ColData[j].Ctrl.Text = ChkVal2Csv(lstDrvObj[i].GetChkVals());

            // Next force the database column value collection to update
            Vals.SetValues();

            // Now create the database update strings to send to the dBClient Insert method
            string cols = "", col_vals = "";
            int cnt = Vals.GetdBInsStrs(ref cols, ref col_vals);
            if(cnt > 0)
            {
                if(dBConn.Insert(TblMachData, cols, col_vals))
                {
                    MsgBox.Info("Machine model successfully added to the database.", "Machine Record Add");
                    ret_val = true;
                }
                else
                    MsgBox.dBErr("Error adding machine model to the database.\nContact Steve Ferry for more assistance");
            }

            MtrDataIns_return:
            return ret_val;
        }

        private bool MtrDataUpd()
        {
            bool ret_val = false;
            
            // Run the object compare method to make sure there are changes and
            // get a listing of all the index numbers in the dBRowCtrlData collection
            // that have changed. If there are changes then start process of updating
            // the database.
            List<int> idx_chng = new List<int>();
            int cnt = ObjCompare(ref idx_chng);
            if(cnt > 0)
            {
                // First force the dBRowCtrlData object to set the actual string formats 
                // to send to the database
                Vals.SetValues();

                // Next get the List objects containing the columns and values to update in 
                // the  database. If there are values added to the list then update the database
                List<string> lst_cols = new List<string>();
                List<string> lst_vals = new List<string>();
                if(Vals.GetdBUpdStrs(ref idx_chng, ref lst_cols, ref lst_vals) > 0)
                {
                    if(dBConn.UpdateStr(TblMachData, lst_cols, lst_vals, "MACH_CODE", txtMachCode.Text))
                    {
                        string msg = "Machine database record successfully updated.";
                        string cap = "Machine Record Update";
                        MsgBox.Info(msg, cap);
                        ret_val = true;
                    }
                    else
                        MsgBox.dBErr("Error updating machine model to the database.\nContact Steve Ferry for more assistance");
                }

            }

            return ret_val;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string msg = "Deleting a machine record is permenant, are you sure you want to delete this record?";
            string cap = "Motor Record Delete";
            if(MsgBox.YN(msg, cap) == DialogResult.Yes)
            {
                msg = "Are you really sure?";
                if(MsgBox.YN(msg, cap) == DialogResult.Yes)
                {
                    if(dBConn.DeleteStr(TblMachData, "MACH_CODE", txtMachCode.Text))
                    {
                        MsgBox.Info("Machine record successfully deleted.", cap);
                        this.Close();
                    }
                    else
                        MsgBox.dBErr("Error deleting machine record form the database, contact Steve Ferry for assistance.");
                }
            }
        }

        #endregion

        #region Exit Methods

        private void btnExitCan_Click(object sender, EventArgs e)
        {
            int new_mode = 0;
            switch(GetDataMode())
            {
                case ModeView:
                    this.Close();
                    break;
                case ModeIns:
                case ModeUpd:
                    if(ObjCompare())
                        new_mode = ModeView;
                    else
                    {
                        string msg = "Changes have been made to the machine information, are you sure you want to cancel?";
                        string cap = "Machine Record Update Cancel";
                        if(MsgBox.YN(msg, cap) == DialogResult.Yes)
                        {
                            ObjReset();
                            new_mode = ModeView;
                        }
                        else
                            goto btnExitCan_Click_Return;
                    }
                    break;
            }
            

            SetDataMode(new_mode);

            if(OldMode == ModeIns)
                this.Close();

            btnExitCan_Click_Return:
            return;
        }




        #endregion
        
    } // class frmMachData
       

    class MtrObj
    {
        public Control lblMtrName;
        public Control txtMtrName;
        public Control lblMtrHP;
        public Control cmbMtrHP;
        public Control btnMtrSel;

        public void SetVis(bool p_VisState)
        {
            lblMtrName.Visible  = p_VisState;
            txtMtrName.Visible  = p_VisState;
            lblMtrHP.Visible    = p_VisState;
            cmbMtrHP.Visible    = p_VisState;
            btnMtrSel.Visible   = p_VisState;
        }

        public void SetBtnEn(bool p_EnState)
        {
            btnMtrSel.Enabled = p_EnState;
        }

    } // class MtrObj

    class DrvObj : ICloneable
    {
        public Control grpDrv;
        public Control btnDrvSel;

        CheckBox _chkMtr1;
        CheckBox _chkMtr2;
        CheckBox _chkMtr3;
        CheckBox _chkMtr4;
        CheckBox _chkMtr5;

        public DrvObj() { }

        public DrvObj(Control p_GrpDrv, Control p_BtnDrvSel, CheckBox p_Chk1, CheckBox p_Chk2, CheckBox p_Chk3, CheckBox p_Chk4, CheckBox p_Chk5)
        {
            grpDrv = p_GrpDrv;
            btnDrvSel = p_BtnDrvSel;
            chkMtr1 = p_Chk1;
            chkMtr2 = p_Chk2;
            chkMtr3 = p_Chk3;
            chkMtr4 = p_Chk4;
            chkMtr5 = p_Chk5;
        }

        public CheckBox chkMtr1
        {
            get => _chkMtr1;
            set
            {
                _chkMtr1 = value;
                if(lstChk.Count < 5)
                    lstChk.Add(_chkMtr1);
            }
        }

        public CheckBox chkMtr2
        {
            get => _chkMtr2;
            set
            {
                _chkMtr2 = value;
                if(lstChk.Count < 5)
                    lstChk.Add(_chkMtr2);
            }
        }

        public CheckBox chkMtr3
        {
            get => _chkMtr3;
            set
            {
                _chkMtr3 = value;
                if(lstChk.Count < 5)
                    lstChk.Add(_chkMtr3);
            }
        }

        public CheckBox chkMtr4
        {
            get => _chkMtr4;
            set
            {
                _chkMtr4 = value;
                if(lstChk.Count < 5)
                    lstChk.Add(_chkMtr4);
            }
        }

        public CheckBox chkMtr5
        {
            get => _chkMtr5;
            set
            {
                _chkMtr5 = value;
                if(lstChk.Count < 5)
                    lstChk.Add(_chkMtr5);
            }
        }

        List<Control> lstChk = new List<Control>();
        
        public void SetGrpVis(bool p_VisState)
        {
            grpDrv.Visible = p_VisState;
        }

        public void SetObjEn(bool p_EnState)
        {
            btnDrvSel.Enabled = p_EnState;
            chkMtr1.Enabled = p_EnState;
            chkMtr2.Enabled = p_EnState;
            chkMtr3.Enabled = p_EnState;
            chkMtr4.Enabled = p_EnState;
            chkMtr5.Enabled = p_EnState;
        }

        public void SetChkVis(int p_MtrCnt)
        {
            for(int i=0;i<lstChk.Count;i++)
                lstChk[i].Visible = false;

            for(int i=0;i<p_MtrCnt;i++)
                lstChk[i].Visible = true;
        }

        public int GetChkVals()
        {
            int chk_val = 0;

            if(chkMtr1.Checked)
                chk_val |= 0x01;
            if(chkMtr2.Checked)
                chk_val |= 0x02;
            if(chkMtr3.Checked)
                chk_val |= 0x04;
            if(chkMtr4.Checked)
                chk_val |= 0x08;
            if(chkMtr5.Checked)
                chk_val |= 0x10;

            return chk_val;
        }

        public void SetChkVals(int p_ChkVal)
        {
            if((p_ChkVal & 0x01) > 0)
                chkMtr1.Checked = true;
            else
                chkMtr1.Checked = false;

            if((p_ChkVal & 0x02) > 0)
                chkMtr2.Checked = true;
            else
                chkMtr2.Checked = false;

            if((p_ChkVal & 0x04) > 0)
                chkMtr3.Checked = true;
            else
                chkMtr3.Checked = false;

            if((p_ChkVal & 0x08) > 0)
                chkMtr4.Checked = true;
            else
                chkMtr4.Checked = false;

            if((p_ChkVal & 0x10) > 0)
                chkMtr5.Checked = true;
            else
                chkMtr5.Checked = false;
        }

        public object Clone()
        {
            return new DrvObj(grpDrv, btnDrvSel, chkMtr1, chkMtr2, chkMtr3, chkMtr4, chkMtr5);
        }
    }

    //public class DefMtrNums
    //{
    //    // General Info
    //    public int MtrNum = 0;

    //    // 50 Hz Defaults
    //    public string DEF_200_50 = "";
    //    public string DEF_208_50 = "";
    //    public string DEF_220_50 = "";
    //    public string DEF_230_50 = "";
    //    public string DEF_240_50 = "";
    //    public string DEF_380_50 = "";
    //    public string DEF_400_50 = "";
    //    public string DEF_415_50 = "";

    //    // 60 Hz Defaults
    //    public string DEF_200_60 = "";
    //    public string DEF_208_60 = "";
    //    public string DEF_220_60 = "";
    //    public string DEF_230_60 = "";
    //    public string DEF_240_60 = "";
    //    public string DEF_380_60 = "";
    //    public string DEF_460_60 = "";
    //    public string DEF_575_60 = "";

    //    public DefMtrNums() { }

    //    public DefMtrNums(int p_Num)
    //    {
    //        MtrNum = p_Num;
    //    }

    //    public DefMtrNums(int p_MtrNum, string p_200_50, string p_208_50, string p_220_50, string p_230_50, string p_240_50, string p_380_50, string p_400_50, string p_415_50, string p_200_60, string p_208_60, string p_220_60, string p_230_60, string p_240_60, string p_380_60, string p_460_60, string p_575_60)
    //    {
    //        MtrNum = p_MtrNum;

    //        DEF_200_50 = p_200_50;
    //        DEF_208_50 = p_208_50;
    //        DEF_220_50 = p_220_50;
    //        DEF_230_50 = p_230_50;
    //        DEF_240_50 = p_240_50;
    //        DEF_380_50 = p_380_50;
    //        DEF_400_50 = p_400_50;
    //        DEF_415_50 = p_415_50;

    //        DEF_200_60 = p_200_60;
    //        DEF_208_60 = p_208_60;
    //        DEF_220_60 = p_220_60;
    //        DEF_230_60 = p_230_60;
    //        DEF_240_60 = p_240_60;
    //        DEF_380_60 = p_380_60;
    //        DEF_460_60 = p_460_60;
    //        DEF_575_60 = p_575_60;
    //    }

    //    public DefMtrNums Clone()
    //    {
    //        return new DefMtrNums
    //            (
    //                MtrNum,
    //                DEF_200_50,
    //                DEF_208_50,
    //                DEF_220_50,
    //                DEF_230_50,
    //                DEF_240_50,
    //                DEF_380_50,
    //                DEF_400_50,
    //                DEF_415_50,
    //                DEF_200_60,
    //                DEF_208_60,
    //                DEF_220_60,
    //                DEF_230_60,
    //                DEF_240_60,
    //                DEF_380_60,
    //                DEF_460_60,
    //                DEF_575_60
    //             );
    //    }

    //    public bool ComparePNs(DefMtrNums p_CmpObj)
    //    {
    //        bool ret_val;

    //        if(
    //            DEF_200_50.Equals(p_CmpObj.DEF_200_50) &&
    //            DEF_208_50.Equals(p_CmpObj.DEF_208_50) &&
    //            DEF_220_50.Equals(p_CmpObj.DEF_220_50) &&
    //            DEF_230_50.Equals(p_CmpObj.DEF_230_50) &&
    //            DEF_240_50.Equals(p_CmpObj.DEF_240_50) &&
    //            DEF_380_50.Equals(p_CmpObj.DEF_380_50) &&
    //            DEF_400_50.Equals(p_CmpObj.DEF_400_50) &&
    //            DEF_415_50.Equals(p_CmpObj.DEF_415_50) &&
    //            DEF_200_60.Equals(p_CmpObj.DEF_200_60) &&
    //            DEF_208_60.Equals(p_CmpObj.DEF_208_60) &&
    //            DEF_220_60.Equals(p_CmpObj.DEF_220_60) &&
    //            DEF_230_60.Equals(p_CmpObj.DEF_230_60) &&
    //            DEF_240_60.Equals(p_CmpObj.DEF_240_60) &&
    //            DEF_380_60.Equals(p_CmpObj.DEF_380_60) &&
    //            DEF_460_60.Equals(p_CmpObj.DEF_460_60) &&
    //            DEF_575_60.Equals(p_CmpObj.DEF_575_60)
    //            )
    //            ret_val = true;
    //        else
    //            ret_val = false;

    //        return ret_val;
    //    }
    //}
}
