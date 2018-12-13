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

        string MachCode = "";

        // Database Globals
        dBClient dBConn;
        const string TblMachData = "TMP_MACH_DATA";
        const int MaxMtr = 5;
        const int MaxDrv = 5;

        // Form Objects
        List<Control> ctrlDBVals = new List<Control>();
        List<string> ctrlOld = new List<string>();
        List<MtrObj> lstMtrObj = new List<MtrObj>();
        List<DrvObj> lstDrvObj = new List<DrvObj>();
        List<int> OldDrvChks = new List<int>();

        Size SizeAllVis = new Size(650, 715);
        Size SizegrpMtrAll = new Size(530, 160);       
        const int SizeOffDrvGrp = 85;
        const int SizeOffMtr = 27;

        #endregion

        #region Class Constructors

        public frmMachData(dBClient p_SQLClient)
        {
            InitializeComponent();
            LoadObjs();
            dBConn = p_SQLClient;
            Mode = ModeIns;
        }

        public frmMachData(dBClient p_SQLClient, string p_MachCode, int p_Mode)
        {
            InitializeComponent();
            LoadObjs();
            dBConn = p_SQLClient;
            MachCode = p_MachCode;
            Mode = p_Mode;
            StartMode = Mode;
        }

        #endregion

        #region Form Load Methods

        private void frmMachData_Load(object sender, EventArgs e)
        {
            

            if(MachCode != "")
            {
                dBConn.QueryStr(TblMachData, "*", "MACH_CODE", MachCode);
                dBConn.Table.Columns.Remove("IDX");
                for(int i = 0; i < ctrlDBVals.Count; i++)
                {
                    ctrlDBVals[i].Text = dBConn.Table.Rows[0][i].ToString();
                }
            }

            nudMtrCnt_ValueChanged(sender, e);
            nudDrvCnt_ValueChanged(sender, e);

            SetDataMode(Mode);
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
            ctrlDBVals.Clear();

            // General Info Objects
            Control tmp = new Control();
            tmp = txtMachCode;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtMachDesc;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = nudMtrCnt;
            ctrlDBVals.Add(tmp);

            /************ Motor Info Objects ************/
            // Motor 1
            tmp = new Control();
            tmp = txtMtr1Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = cmbMtr1HP;
            ctrlDBVals.Add(tmp);

            // Motor 2
            tmp = new Control();
            tmp = txtMtr2Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = cmbMtr2HP;
            ctrlDBVals.Add(tmp);

            // Motor 3
            tmp = new Control();
            tmp = txtMtr3Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = cmbMtr3HP;
            ctrlDBVals.Add(tmp);

            // Motor 4
            tmp = new Control();
            tmp = txtMtr4Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = cmbMtr4HP;
            ctrlDBVals.Add(tmp);

            // Motor 5
            tmp = new Control();
            tmp = txtMtr5Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = cmbMtr5HP;
            ctrlDBVals.Add(tmp);

            /************* VFD Objects *************/
            // VFD General Info Objects
            tmp = new Control();
            tmp = nudDrvCnt;
            ctrlDBVals.Add(tmp);

            // Drive 1 Gen Info
            tmp = new Control();
            tmp = txtDrv1Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv1DefHV;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv1DefLV;
            ctrlDBVals.Add(tmp);

            // Drive 2 Gen Info
            tmp = new Control();
            tmp = txtDrv2Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv2DefHV;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv2DefLV;
            ctrlDBVals.Add(tmp);

            // Drive 3 Gen Info
            tmp = new Control();
            tmp = txtDrv3Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv3DefHV;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv3DefLV;
            ctrlDBVals.Add(tmp);

            // Drive 4 Gen Info
            tmp = new Control();
            tmp = txtDrv4Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv4DefHV;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv4DefLV;
            ctrlDBVals.Add(tmp);

            // Drive 5 Gen Info
            tmp = new Control();
            tmp = txtDrv5Name;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv5DefHV;
            ctrlDBVals.Add(tmp);

            tmp = new Control();
            tmp = txtDrv5DefLV;
            ctrlDBVals.Add(tmp);
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
            obj.btnMtrSel = btnMtr1Sel;
            lstMtrObj.Add(obj);

            // Motor 2
            obj = new MtrObj();
            obj.lblMtrName = lblMtr2Name;
            obj.txtMtrName = txtMtr2Name;
            obj.lblMtrHP = lblMtr2HP;
            obj.cmbMtrHP = cmbMtr2HP;
            obj.btnMtrSel = btnMtr2Sel;
            lstMtrObj.Add(obj);

            // Motor 3
            obj = new MtrObj();
            obj.lblMtrName = lblMtr3Name;
            obj.txtMtrName = txtMtr3Name;
            obj.lblMtrHP = lblMtr3HP;
            obj.cmbMtrHP = cmbMtr3HP;
            obj.btnMtrSel = btnMtr3Sel;
            lstMtrObj.Add(obj);

            // Motor 4
            obj = new MtrObj();
            obj.lblMtrName = lblMtr4Name;
            obj.txtMtrName = txtMtr4Name;
            obj.lblMtrHP = lblMtr4HP;
            obj.cmbMtrHP = cmbMtr4HP;
            obj.btnMtrSel = btnMtr4Sel;
            lstMtrObj.Add(obj);

            // Motor 5
            obj = new MtrObj();
            obj.lblMtrName = lblMtr5Name;
            obj.txtMtrName = txtMtr5Name;
            obj.lblMtrHP = lblMtr5HP;
            obj.cmbMtrHP = cmbMtr5HP;
            obj.btnMtrSel = btnMtr5Sel;
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
            for(int i=0;i<ctrlDBVals.Count;i++)
                ctrlOld.Add(ctrlDBVals[i].Text);

            OldDrvChks.Clear();
            for(int i=0;i<lstDrvObj.Count;i++)
                OldDrvChks.Add(lstDrvObj[i].GetChkVals());
        }

        private bool ObjCompare()
        {
            bool ret_val = false;
            int mismatch_cnt = -1;

            if((ctrlOld.Count == ctrlDBVals.Count) && (OldDrvChks.Count == lstDrvObj.Count))
            {
                mismatch_cnt = 0;
                for(int i=0;i<ctrlDBVals.Count;i++)
                {
                    if(ctrlDBVals[i].Text != ctrlOld[i])
                        mismatch_cnt++;
                }

                for(int i=0;i<lstDrvObj.Count;i++)
                {
                    if(lstDrvObj[i].GetChkVals() != OldDrvChks[i])
                        mismatch_cnt++;
                }
            }

            if(mismatch_cnt == 0)
                ret_val = true;

            return ret_val;
        }

        private int ObjCompare(ref List<int> p_IdxDB, ref List<int> p_IdxDrv)
        {
            
            return -1;
        }

        private void ObjReset()
        {
            for(int i = 0; i < ctrlDBVals.Count; i++)
            {
                ctrlDBVals[i].Text = ctrlOld[i];
            }

            for(int i = 0; i < lstDrvObj.Count; i++)
            {
                lstDrvObj[i].SetChkVals(OldDrvChks[i]);
            }
        }

        private void SetDataMode(int p_Mode)
        {
            bool CtrlEn = false;
            bool MachCodeEn = false;

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

            for(int i = 0; i < ctrlDBVals.Count; i++)
                ctrlDBVals[i].Enabled = CtrlEn;
            for(int i = 0; i < lstDrvObj.Count; i++)
                lstDrvObj[i].SetObjEn(CtrlEn);
            for(int i = 0; i < lstMtrObj.Count; i++)
                lstMtrObj[i].SetBtnEn(CtrlEn);

            txtMachCode.Enabled = MachCodeEn;
        }

        #endregion

        #region Motor Methods

        private void nudMtrCnt_ValueChanged(object sender, EventArgs e)
        {
            if(((Control)nudMtrCnt).Text == "")
                nudMtrCnt.Value = 1;

            int mtr_cnt = Convert.ToInt32(nudMtrCnt.Value);

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
        }

        #endregion

        #region Drive Methods

        private void nudDrvCnt_ValueChanged(object sender, EventArgs e)
        {
            HideDrvObjs();

            for(int i=0;i<nudDrvCnt.Value;i++)
                lstDrvObj[i].SetGrpVis(true);

            int sub = MaxDrv - Convert.ToInt32(nudDrvCnt.Value);

            Size xy = new Size();
            xy = SizeAllVis;
            xy.Height = xy.Height - (SizeOffDrvGrp * sub);
            this.Size = xy;

            if(nudDrvCnt.Value > 0)
                chkVFDMach.Checked = true;
            else
                chkVFDMach.Checked = false;
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






        #endregion

        #region Machine Insert and Update Methods

        private void btnModSave_Click(object sender, EventArgs e)
        {
            switch(Mode)
            {
                case ModeView: // currently in edit mode, need to switch to modify mode
                    // Store current values so that it can be determined if the values have changed.
                    ObjStoreOld(); 

                    // If there is a machine code then we are updating a record
                    if(txtMachCode.Text != "")
                        Mode = ModeUpd;
                    else // otherwise this is a new record; not likely this ever occurs because the going from a view mode always is an existing value
                        Mode = ModeIns;
                    break;
                case ModeIns: // currently in insert mode, need to insert new record database record
                    if(MtrDataIns())
                    {
                        Mode = ModeView;
                    }
                    else
                        goto btnModSave_Click_Return;
                    break;
                case ModeUpd: // currently in update mode, need to update machine database record
                    if(MtrDataUpd())
                    {
                        Mode = ModeView;
                    }
                    else
                        goto btnModSave_Click_Return;
                    break;
            }

            SetDataMode(Mode);

            btnModSave_Click_Return:
            return;
        }

        private bool MtrDataIns()
        {
            return true;
        }

        private bool MtrDataUpd()
        {
            return true;
        }



        #endregion

        #region Region 5

        #endregion

        #region Form Exit Methods

        private void btnExitCan_Click(object sender, EventArgs e)
        {
            switch(Mode)
            {
                case ModeView:
                    this.Close();
                    break;
                case ModeIns:
                case ModeUpd:
                    if(ObjCompare())
                        Mode = ModeView;
                    else
                    {
                        string msg = "Changes have been made to the machine information, are you sure you want to cancel?";
                        string cap = "Machine Record Update Cancel";
                        if(MsgBox.YN(msg, cap) == DialogResult.Yes)
                        {
                            ObjReset();
                            Mode = ModeView;
                        }
                        else
                            goto btnExitCan_Click_Return;
                    }
                    break;
            }

            SetDataMode(Mode);

            btnExitCan_Click_Return:
            return;
        }



        #endregion

        private void frmMachData_KeyDown(object sender, KeyEventArgs e)
        {
            EventArgs evnt = new EventArgs();

            if(e.KeyCode == Keys.Escape)
                btnExitCan_Click(sender, evnt);

            if(e.KeyCode == Keys.Enter)
                btnModSave_Click(sender, evnt);
            
        }
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
}
