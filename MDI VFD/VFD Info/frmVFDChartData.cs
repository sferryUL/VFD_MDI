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
using V1000_ModbusRTU;

namespace MDI_VFD.VFD_Info
{
    public partial class frmVFDChartData : Form
    {
        #region Class Globals

        dBClient dBConn;
        ChartInfo ChrtInf = new ChartInfo();
        List<V1000_Param_Data> lstParam = new List<V1000_Param_Data>();

        VFDInfo VFDInf = new VFDInfo();

        FormMode Mode = FormMode.View;

        #endregion

        #region Class Constructors

        public frmVFDChartData(dBClient p_Conn, ChartInfo p_Info)
        {
            InitializeComponent();

            dBConn = p_Conn;
            ChrtInf = p_Info.Copy();
        }

        #endregion

        #region Form Load & Control Methods

        private void frmVFDParamData_Load(object sender, EventArgs e)
        {
            cmbDrvDuty.SelectedIndex = 0;
            GetDrvData();   // Get list of drive families from the database 
            GetMachData();  // Get list of machines from the database 

            // Set the machine combobox item based on the chart information
            int idx = CmbFunc.FindIdxSubStr(ref cmbMach, ChrtInf.MachCode);
            cmbMach.SelectedIndex = idx;

            // Set the chart number and chart revision textboxes 
            txtChrtNum.Text = ChrtInf.ChrtNum;
            txtChrtRev.Text = ChrtInf.ChrtRev;

            // query the database for this chart, if there is only one record and the  DRV_NUM field 
            // is NULL then we know this is a new chart to be created.
            if(dBConn.QueryStr(Resources.tblChrtList, "CHRT_NUM, DRV_NUM", "CHRT_NUM", ChrtInf.ChrtNum) == 1)
            {
                if(dBConn.Table.Rows[0]["DRV_NUM"].ToString() == "")
                    SetFormMode(FormMode.Insert);
            }
            else // Chart exists and this is just a view mode.
                SetFormMode(FormMode.View);

            if(Mode == FormMode.View)
            {
                // Set drive family 
                dBConn.QueryStr(Resources.tblChrtList, "DRV_FAM", "CHRT_NUM", ChrtInf.ChrtNum, p_CondItem2: "DRV_NUM", p_Cond2: cmbDrvNum.Text);
                idx = CmbFunc.FindIdxSubStr(ref cmbDrvFam, dBConn.Table.Rows[0][0].ToString());
                cmbDrvFam.SelectedIndex = idx;
                
                // Fill The parameter datagridview with the chart data and clear the selection so that no rows highlight
                GetParamData(idx);
                dgvChrtView.ClearSelection();

                btnExitCan.Select();
            }
        }

        private void frmVFDChartData_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                btnExitCan_Click(sender, e);
            }
        }

        private void SetFormMode(FormMode p_Mode)
        {
            switch(p_Mode)
            {
                case FormMode.View:
                    cmbDrvFam.Enabled = false;
                    btnSave.Visible = false;
                    dgvChrtView.AllowUserToAddRows = false;
                    dgvChrtView_cmParamNum.ReadOnly = true;
                    break;
                case FormMode.Insert:
                    cmbDrvFam.Enabled = true;
                    btnSave.Visible = true;
                    dgvChrtView.AllowUserToAddRows = true;
                    dgvChrtView_cmParamNum.ReadOnly = false;
                    dgvChrtView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                    break;
            }

            Mode = p_Mode;
        }

        #endregion

        #region Database Combobox Data Fill Methods

        private void GetDrvData()
        {
            dBConn.QueryDist(Resources.tblDrvList, "DRV_FAM");
            foreach(DataRow dr in dBConn.Table.Rows)
                cmbDrvFam.Items.Add(dr[0].ToString());

            if(cmbDrvFam.Items.Count > 1)
                cmbDrvFam.Enabled = true;
        }

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

        #endregion

        #region Datagridview Chart Data Fill

        private void GetParamData(int p_DrvNum)
        {
            string def_col = "";

            dgvChrtView.Rows.Clear();

            string chrt_col = BuildParamCol(); // build the chart column name to lookup

            def_col = GetDrvDefCol();


            // Check that the parameter column exists in the chart table. If it does now we start building 
            // all the default parameter information so that we can get both the chart parameter settings
            // along with the actual parameter names and default values.
            if(dBConn.VerChrtCol(VFDInf.ChrtTbl, chrt_col))
            {
                // Bulid the SQL query string with inner join.
                // {0} = VFDInf.ParamTbl, {1} = VFDInf.ChrtTbl, {2} = chrt_col, {3} = def_col
                string sql = String.Format("SELECT {0}.PARAM_NUM, {0}.PARAM_NAME, {1}.{2}, {0}.{3}, {0}.MULTIPLIER, {0}.NUM_BASE, {0}.UNITS ", VFDInf.ParamTbl, VFDInf.ChrtTbl, chrt_col, def_col);
                sql += String.Format("FROM {0} ", VFDInf.ParamTbl);
                sql += String.Format("JOIN {0} ON {1}.PARAM_NUM = {0}.PARAM_NUM ", VFDInf.ChrtTbl, VFDInf.ParamTbl);
                sql += String.Format("WHERE {0} IS NOT NULL;", chrt_col);

                if(dBConn.QuerySQL(sql) > 0)
                {
                    // Load the V1000 parameter data based on the 
                    foreach(DataRow dr in dBConn.Table.Rows)
                    {
                        V1000_Param_Data data = new V1000_Param_Data();
                        data.ParamNum = dr["PARAM_NUM"].ToString();
                        data.ParamName = dr["PARAM_NAME"].ToString();
                        data.Multiplier = Convert.ToUInt16(dr["MULTIPLIER"].ToString());
                        data.NumBase = Convert.ToByte(dr["NUM_BASE"].ToString());
                        data.Units = dr["UNITS"].ToString();
                        data.ParamVal = Convert.ToUInt16(dr[chrt_col].ToString());
                        data.DefVal = Convert.ToUInt16(dr[def_col].ToString());
                        lstParam.Add(data);
                        dgvChrtView.Rows.Add(new string[]
                            {
                                data.ParamNum,
                                data.ParamName,
                                data.DefValDisp,
                                data.ParamValDisp
                            });
                    }
                }
            }
        }



        private string BuildParamCol()
        {
            string num = txtChrtNum.Text;
            string drv = cmbDrvNum.Text;

            string col = String.Format("CHRT_{0}_{1}", num, drv);

            if(txtChrtRev.Text != "")
                col = String.Format("{0}_{1}", col, txtChrtRev.Text.ToUpper());

            return col;
        }
        
        #endregion

        #region Drive Number & Duty Value Display Change

        private void cmbDrvDuty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Mode == FormMode.View)
            {
                if((cmbMach.SelectedIndex >= 0) && (cmbDrvFam.SelectedIndex >= 0) && (txtChrtNum.Text != ""))
                {
                    int drv_idx = Convert.ToInt32(cmbDrvNum.Text);
                    GetParamData(drv_idx);
                }
            }
        }

        private void cmbDrvNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((Mode == FormMode.View) && (cmbDrvFam.SelectedIndex >= 0))
            {
                int drv_idx = Convert.ToInt32(cmbDrvNum.Text);
                GetParamData(drv_idx);
            }
        }

        #endregion

        #region Chart Detail Exit and Data Save Methods

        private void btnExitCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Machine and Drive Family Combobox Control

        private void cmbMach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mach_code = cmbMach.Text.Substring(0, cmbMach.Text.IndexOf(' '));
            dBConn.QueryStr(Resources.tblMachData, "DRV_CNT", "MACH_CODE", mach_code);

            // Populate the drive number comboboxes
            int drv_cnt = Convert.ToInt32(dBConn.Table.Rows[0]["DRV_CNT"].ToString());
            for(int i = 0, j = 1; i < drv_cnt; i++, j++)
                cmbDrvNum.Items.Add(j.ToString());
            cmbDrvNum.SelectedIndex = 0;
            if(cmbDrvNum.Items.Count > 1)
                cmbDrvNum.Enabled = true;
        }

        private void cmbDrvFam_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Query the database for the specific information for this drive family
            if(dBConn.QueryStr(Resources.tblVFDFamInf, "*", "DRV_FAM", cmbDrvFam.Text) > 0)
            {
                DataRow dr = dBConn.Table.Rows[0];
                GetVFDFamInfo(ref dr, ref VFDInf);
            }
        }

        private void GetVFDFamInfo(ref DataRow p_DR, ref VFDInfo p_Inf)
        {
            p_Inf.Clear();
            
            p_Inf.DrvFam     = p_DR["DRV_FAM"].ToString();
            p_Inf.ParamTbl   = p_DR["DRV_TBL_DEF_PARAM"].ToString();
            p_Inf.GrpDescTbl = p_DR["DRV_TBL_GRP_DESC"].ToString();
            p_Inf.DefColHD   = p_DR["DRV_COL_DEF_PARAM_HD"].ToString();
            p_Inf.DefColND   = p_DR["DRV_COL_DEF_PARAM_ND"].ToString();
            p_Inf.ChrtTbl    = p_DR["DRV_TBL_CHRT"].ToString();
        }

        #endregion

        private void dgvChrtView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(cmbDrvFam.SelectedIndex == -1)
            {
                MsgBox.Err("Drive family must be specified before entering parameter information.");
                dgvChrtView.ClearSelection();
                dgvChrtView.CurrentCell = null;
            }
        }

        private void dgvChrtView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if(col == 0)
            {
                // Editing the parameter number cell, search for the parameter 
                // number in the parameter table for the drive family
                string param_num = dgvChrtView.Rows[row].Cells[col].Value.ToString().ToUpper();
                string def_col = GetDrvDefCol();
                string cols = String.Format("PARAM_NUM, PARAM_NAME, MULTIPLIER, NUM_BASE, UNITS, {0}", def_col);

                if(dBConn.QueryStr(VFDInf.ParamTbl, cols, "PARAM_NUM", param_num) > 0)
                {
                    // Parameter exists so we can fill in the rest of the information
                    DataRow dr = dBConn.Table.Rows[0];
                    V1000_Param_Data data = FillParamData(dr, def_col);
                    lstParam.Add(data);
                    dgvChrtView.Rows[row].Cells[0].Value = param_num;
                    dgvChrtView.Rows[row].Cells[1].Value = data.ParamName;
                    dgvChrtView.Rows[row].Cells[2].Value = data.DefValDisp;
                    dgvChrtView.Rows[row].Cells[3].Selected = true;
                    dgvChrtView.Rows[row].Cells[3].ReadOnly = false;
                }
                else
                {
                    string msg = String.Format("Parameter number {0} does not exist for the {1} family of drives.\nCheck your entry and try again.", param_num, VFDInf.DrvFam);
                    MsgBox.Err(msg);
                    dgvChrtView.Rows.RemoveAt(row);
                    dgvChrtView.ClearSelection();
                    dgvChrtView.CurrentCell = null;
                }
            }
            else if(col == 3)
            {
                int spec_val = -2147483648;
                string str_val = dgvChrtView.Rows[row].Cells[col].Value.ToString();

                // First check and see if the value is supposed to be formatted as hex or not.
                if(lstParam[row].NumBase == 16)
                {
                    ushort ushrt_val = 0;
                    
                    if(NumFunc.Hex2UShrt(str_val, ref ushrt_val))
                    {
                        spec_val = (int)ushrt_val;
                    }
                }
                else 
                {
                    Single sgl_val = 0F;
                    if(StrFunc.Str2Sgl(str_val, ref sgl_val))
                    {
                        spec_val = (int)lstParam[row].Sgl2ValFormat(sgl_val);
                    }
                }
                
                if(spec_val != -2147483648)
                {
                    lstParam[row].ParamVal = Convert.ToUInt16(spec_val);
                    dgvChrtView.Rows[row].Cells[3].Value = lstParam[row].ParamValDisp;
                }


            }
        }

        private string GetDrvDefCol()
        {
            string col = "";

            if(cmbDrvDuty.SelectedIndex == 0)
                col = VFDInf.DefColHD;
            else
                col = VFDInf.DefColND;

            return col;
        }

        private V1000_Param_Data FillParamData(DataRow p_DR, string p_DefCol)
        {
            V1000_Param_Data data = new V1000_Param_Data();

            data.ParamNum = p_DR["PARAM_NUM"].ToString();
            data.ParamName = p_DR["PARAM_NAME"].ToString();
            data.Multiplier = Convert.ToUInt16(p_DR["MULTIPLIER"].ToString());
            data.NumBase = Convert.ToByte(p_DR["NUM_BASE"].ToString());
            data.Units = p_DR["UNITS"].ToString();
            data.DefVal = Convert.ToUInt16(p_DR[p_DefCol].ToString());

            return data;
        }
    }
}
