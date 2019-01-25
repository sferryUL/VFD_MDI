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
    public partial class frmVFDParamData : Form
    {
        dBClient dBConn;
        ChartInfo ChrtInf = new ChartInfo();
        List<V1000_Param_Data> lstParam = new List<V1000_Param_Data>();


        public frmVFDParamData(dBClient p_Conn, ChartInfo p_Info)
        {
            InitializeComponent();

            dBConn = p_Conn;
            ChrtInf = p_Info.Copy();

            cmbDrvDuty.SelectedIndex = 0;
        }

        private void frmVFDParamData_Load(object sender, EventArgs e)
        {
            GetDrvData();   // Get list of drive families from the database 
            GetMachData();  // Get list of machines from the database 

            if(ChrtInf.ChrtNum != "")
            {
                txtChrtNum.Text = ChrtInf.ChrtNum;
                txtChrtRev.Text = ChrtInf.ChrtRev;

                // First set the machine combobox item based on the chart information
                int idx = CmbFunc.FindIdxSubStr(ref cmbMach, ChrtInf.MachCode);
                cmbMach.SelectedIndex = idx;
                
                // Now get the drive family for drive 1 for this chart
                dBConn.QueryStr(Resources.tblChrtList, "DRV_FAM", "CHRT_NUM", ChrtInf.ChrtNum, p_CondItem2:"DRV_NUM", p_Cond2:cmbDrvNum.Text);
                idx = CmbFunc.FindIdxSubStr(ref cmbDrvFam, dBConn.Table.Rows[0][0].ToString());
                cmbDrvFam.SelectedIndex = idx;

                // Build the information to verify a chart exists in the database
                string param_tbl = BuildParamTbl(); // build the parameter table name containing parameter chart values
                string param_col = BuildParamCol(); // build the chart column name to lookup

                // Check that the parameter column exists in the chart table. If it does now we start building 
                // all the default parameter information so that we can get both the chart parameter settings
                // along with the actual parameter names and default values.
                if(dBConn.VerChrtCol(param_tbl, param_col))
                {
                    string def_tbl = "", def_col = "";
                    GetDefDrvInf(cmbDrvFam.Text, ref def_tbl, ref def_col);
                    GetParamData(ref lstParam, param_tbl, param_col, def_tbl, def_col);
                }

                dgvChrtView.ClearSelection();
                btnExitCan.Select();
                
            }
        }

        private void GetDrvData()
        {
            dBConn.QueryDist(Resources.tblDrvList, "DRV_FAM");
            foreach(DataRow dr in dBConn.Table.Rows)
                cmbDrvFam.Items.Add(dr[0].ToString());
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

        private void GetParamData(ref List<V1000_Param_Data> p_List, string p_ParamTbl, string p_ParamCol, string p_DefTbl, string p_DefCol)
        {
            // {0} = p_DefTbl, {1} = p_ParamTbl, {2} = p_ChrtCol, {3} = p_DefCol
            string sql = String.Format("SELECT {0}.PARAM_NUM, {0}.PARAM_NAME, {1}.{2}, {0}.{3}, {0}.MULTIPLIER, {0}.NUM_BASE, {0}.UNITS ", p_DefTbl, p_ParamTbl, p_ParamCol, p_DefCol);
            sql += String.Format("FROM {0} ", p_DefTbl);
            sql += String.Format("JOIN {0} ON {1}.PARAM_NUM = {0}.PARAM_NUM ", p_ParamTbl, p_DefTbl);
            sql += String.Format("WHERE {0} IS NOT NULL;", p_ParamCol);

            if(dBConn.QuerySQL(sql) > 0)
            {
                foreach(DataRow dr in dBConn.Table.Rows)
                {
                    V1000_Param_Data data = new V1000_Param_Data();
                    data.ParamNum = dr["PARAM_NUM"].ToString();
                    data.ParamName = dr["PARAM_NAME"].ToString();
                    data.Multiplier = Convert.ToUInt16(dr["MULTIPLIER"].ToString());
                    data.NumBase = Convert.ToByte(dr["NUM_BASE"].ToString());
                    data.Units = dr["UNITS"].ToString();
                    data.ParamVal = Convert.ToUInt16(dr[p_ParamCol].ToString());
                    data.DefVal = Convert.ToUInt16(dr[p_DefCol].ToString());
                    p_List.Add(data);
                    dgvChrtView.Rows.Add(new string[]
                        {
                            data.ParamNum,
                            data.ParamName,
                            data.DefValDisp,
                            data.ParamValDisp
                        }
                        );
                }
            }
        }

        private string BuildParamTbl()
        {
            // Now get the associated chart table from the database for this chart
            dBConn.QueryStr(Resources.tblDrvFamInf, "DRV_TBL_PARAM", "DRV_FAM", cmbDrvFam.Text);
            return dBConn.Table.Rows[0][0].ToString();
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

        private void GetDefDrvInf(string p_DrvFam, ref string p_Tbl, ref string p_Col)
        {
            string drv_duty_col = "DRV_COL_DEF_PARAM_";
            if(cmbDrvDuty.SelectedIndex == 0)
                drv_duty_col += "HD";
            else
                drv_duty_col += "ND";

            // query the drive family table to get the default parameter table and the 
            // default column based on drive duty to reference
            string cols = String.Format("DRV_TBL_DEF_PARAM, {0}", drv_duty_col);
            dBConn.QueryStr(Resources.tblDrvFamInf, cols, "DRV_FAM", cmbDrvFam.Text);
            p_Tbl = dBConn.Table.Rows[0][0].ToString();
            p_Col = dBConn.Table.Rows[0][1].ToString();
        }

        private void btnExitCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        }

        private void cmbDrvDuty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDrvNum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
