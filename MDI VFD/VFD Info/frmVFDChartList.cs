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
    public partial class frmVFDChartList : Form
    {
        #region Class Global Variables 

        dBClient dBConn;

        #endregion

        #region Class Constructors

        public frmVFDChartList(dBClient p_Conn)
        {
            InitializeComponent();
            dBConn = p_Conn;
        }

        #endregion

        #region Form Load Methods

        private void frmVFDParams_Load(object sender, EventArgs e)
        {
            // Populate the VFD charts combobox
            dBConn.QueryDist(Resources.tblChrtList, "CHRT_NUM");
            foreach(DataRow dr in dBConn.Table.Rows)
                cmbChrtLst.Items.Add(PartFunc.CnvFromULFrmt(dr[0].ToString()));

            cmbSrchCode.SelectedIndex = 0;

            // Populate the machine code combobox items
            dBConn.Query(Resources.tblMachData, "MACH_CODE");
            DataTable mach_codes = new DataTable();
            mach_codes = dBConn.Table.Copy();
            cmbMachCode.DisplayMember = "MACH_CODE";
            cmbMachCode.DataSource = mach_codes;
            cmbMachCode.SelectedIndex = -1;

        }

        #endregion

        #region Chart Search Methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvChrtList.Rows.Clear();

            List<ChartInfo> chart_info = new List<ChartInfo>();

            // Basic search for all charts
            if((cmbChrtLst.Text == "") && (cmbMachCode.SelectedIndex == -1) && (cmbChrtRev.SelectedIndex == -1))
            {
                // Get general chart information from the master chart list
                dBConn.QueryDist(Resources.tblChrtList, "CHRT_NUM, CHRT_REV, MACH_CODE", p_OrderBy: "MACH_CODE");
                foreach(DataRow dr in dBConn.Table.Rows)
                {
                    ChartInfo inf = new ChartInfo();
                    inf.MachCode = dr["MACH_CODE"].ToString();
                    inf.ChrtNum = dr["CHRT_NUM"].ToString();
                    inf.ChrtRev = dr["CHRT_REV"].ToString();
                    chart_info.Add(inf);
                }
            }
            else // Search based on selection criteria, need to build a SQL search string
            {
                // Build SQL search string
                string sql = String.Format("SELECT MACH_CODE, CHRT_NUM, CHRT_REV FROM {0} WHERE ", Resources.tblChrtList);

                if(cmbChrtLst.Text != "")
                {
                    sql += "CHRT_NUM ";
                    string part_num = cmbChrtLst.Text;
                    switch(cmbSrchCode.SelectedIndex)
                    {
                        case 0:
                            sql += String.Format("LIKE '{0}%'", part_num);
                            break;
                        case 1:
                            sql += String.Format("LIKE '%{0}%'", part_num);
                            break;
                        case 2:
                            sql += String.Format("= '{0}'", part_num);
                            break;
                    }

                    if((cmbChrtRev.SelectedIndex >= 0) || (cmbMachCode.SelectedIndex >= 0))
                        sql += " AND ";
                }

                if(cmbChrtRev.SelectedIndex >= 0)
                {
                    sql += String.Format("CHRT_REV = '{0}'", cmbChrtRev.Text);
                    if(cmbMachCode.SelectedIndex >= 0)
                        sql += " AND ";
                }

                if(cmbMachCode.SelectedIndex >= 0)
                    sql += String.Format("MACH_CODE = '{0}'", cmbMachCode.Text);

                if(dBConn.QuerySQL(sql) > 0)
                {
                    foreach(DataRow dr in dBConn.Table.Rows)
                    {
                        ChartInfo inf = new ChartInfo();
                        inf.MachCode = dr["MACH_CODE"].ToString();
                        inf.ChrtNum = dr["CHRT_NUM"].ToString();
                        inf.ChrtRev = dr["CHRT_REV"].ToString();
                        chart_info.Add(inf);
                    }
                }

            }

            // Get each Urschel official chart description from the Urschel database
            if((chart_info.Count > 0) && (Environment.UserName == "sferry"))
            {
                dBClient ulConn = new dBClient();
                if(ulConn.Open(Resources.dBServer, Resources.dBNameUL, true))
                {
                    for(int i = 0; i < chart_info.Count; i++)
                    {
                        if(ulConn.QueryStr(Resources.tblPartInfo, "FULLDESCRIPTION", "PARTNBR", chart_info[i].ChrtNum) > 0)
                        {
                            chart_info[i].ChrtDesc = ulConn.Table.Rows[0][0].ToString();
                        }

                    }
                }
            }

            // populate the Datagridview with all the chart information based on the search
            for(int i = 0; i < chart_info.Count; i++)
            {
                dgvChrtList.Rows.Add(new string[]
                    {
                            chart_info[i].MachCode,
                            PartFunc.CnvFromULFrmt(chart_info[i].ChrtNum),
                            chart_info[i].ChrtRev,
                            chart_info[i].ChrtDesc
                    }
                    );
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbChrtLst.Text = "";
            cmbMachCode.SelectedIndex = -1;
            cmbChrtRev.SelectedIndex = -1;

            dgvChrtList.Rows.Clear();
        }

        #endregion

        #region Open Chart Data Methods

        private void dgvChrtList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sel = e.RowIndex;

            string code = dgvChrtList.Rows[row_sel].Cells[0].Value.ToString();
            string num = PartFunc.Cnv2ULFrmt(dgvChrtList.Rows[row_sel].Cells[1].Value.ToString());
            string rev = dgvChrtList.Rows[row_sel].Cells[2].Value.ToString();
            string desc = dgvChrtList.Rows[row_sel].Cells[3].Value.ToString();

            frmVFDChartData param_data = new frmVFDChartData(dBConn, new ChartInfo(code, num, rev, desc));
            param_data.ShowDialog();
        }

        private void ctxtChrtList_ChrtView_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        #endregion

        #region Datagridview Row Info Parsing

        private ChartInfo GetChrtInfo(int p_RowIdx)
        {
            ChartInfo inf = new ChartInfo();

            inf.MachCode = dgvChrtList.Rows[p_RowIdx].Cells[0].Value.ToString();
            inf.ChrtNum = PartFunc.Cnv2ULFrmt(dgvChrtList.Rows[p_RowIdx].Cells[1].Value.ToString());
            inf.ChrtRev = dgvChrtList.Rows[p_RowIdx].Cells[2].Value.ToString();
            inf.ChrtDesc = dgvChrtList.Rows[p_RowIdx].Cells[3].Value.ToString();

            return inf.Copy();
        }

        #endregion

        #region New Chart Creation and Chart Revision Methods

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmVFDChartNew new_chart = new frmVFDChartNew(dBConn);

            new_chart.ShowDialog();
        }

        private void ctxtChrtList_ChrtNew_Click(object sender, EventArgs e)
        {
            btnInsert_Click(sender, e);
        }

        private void ctxtChrtList_ChrtRev_Click(object sender, EventArgs e)
        {
            ChartInfo inf = new ChartInfo();
            
            int idx = dgvChrtList.CurrentCell.RowIndex;
            if(idx >= 0)
            {
                inf = GetChrtInfo(idx);
                frmVFDChartNew new_chart = new frmVFDChartNew(dBConn, inf);
                new_chart.ShowDialog();
            }
        }

        #endregion

        #region General Context Menu Methods

        private void ctxtChrtList_Opening(object sender, CancelEventArgs e)
        {
            if(Environment.UserName == "sferry")
                ctxtChrtList_Delete.Visible = true;
        }

        #endregion

        #region Chart Delete Methods

        private void ctxtChrtList_Delete_Click(object sender, EventArgs e)
        {
            ChartInfo inf = new ChartInfo();
            string chrt_inf = "", msg = "", cap_delete = "Parameter Chart Delete";
            
            int idx = dgvChrtList.CurrentCell.RowIndex;
            if(idx >= 0)
            {
                inf = GetChrtInfo(idx);
                chrt_inf = PartFunc.CnvFromULFrmt(inf.ChrtNum);
                if(inf.ChrtRev != "")
                    chrt_inf = String.Format(" {0} revision {1}", chrt_inf, inf.ChrtRev);
                string del_msg = String.Format("Are you sure you wish to delete parameter chart {0}", chrt_inf);
                
                if(MsgBox.YN(del_msg, cap_delete) == DialogResult.No)
                    goto ctxtChrtList_Delete_Click_Return;

                // Query the chart list to get all the information for the chart that is being deleted.
                if(dBConn.QueryStr(Resources.tblChrtList, "*","CHRT_NUM", inf.ChrtNum, p_CondItem2: "DRV_NUM", p_Cond2: inf.ChrtRev) > 0)
                {
                    // If there is only one entry and the drive number is NULL then this is a new entry and no column
                    // infomation exists in the master chart list
                    if((dBConn.Table.Rows.Count == 1) && dBConn.Table.Rows[0]["DRV_NUM"].ToString() == "")
                    {
                        if(dBConn.DeleteStr(Resources.tblChrtList, "CHRT_NUM", inf.ChrtNum, "CHRT_REV", inf.ChrtRev))
                            goto DeleteChartSuccess;
                        else
                            goto DeleteChartFail;
                    }
                }
            }
            else
                goto ctxtChrtList_Delete_Click_Return;

            DeleteChartFail:
            msg = String.Format("Error deleting parameter chart {0}, contact Steve Ferry for assistance", chrt_inf);
            MsgBox.dBErr(msg);
            goto ctxtChrtList_Delete_Click_Return;

            DeleteChartSuccess:
                msg = String.Format("Parameter chart {0} was successfully deleted", chrt_inf);
            MsgBox.Info(msg, cap_delete);

            ctxtChrtList_Delete_Click_Return:
            return;
        }

        #endregion
    }

    public class ChartInfo
    {
        public string MachCode;
        public string ChrtNum;
        public string ChrtRev;
        public string ChrtDesc;
        
        public ChartInfo()
        {
            MachCode = "";
            ChrtNum = "";
            ChrtDesc = "";
        }

        public ChartInfo(string p_Mach, string p_Num, string p_Rev, string p_Desc)
        {
            MachCode = p_Mach;
            ChrtNum = p_Num;
            ChrtRev = p_Rev;
            ChrtDesc = p_Desc;
        }

        public ChartInfo(ChartInfo p_Info)
        {
            MachCode = p_Info.MachCode;
            ChrtNum = p_Info.ChrtNum;
            ChrtRev = p_Info.ChrtRev;
            ChrtDesc = p_Info.ChrtDesc;
        }

        public ChartInfo Copy()
        {
            return new ChartInfo(this.MachCode, this.ChrtNum, this.ChrtRev, this.ChrtDesc);
        }
    }
}
