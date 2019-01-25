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
    public partial class frmVFDParamList : Form
    {
        dBClient dBConn;

        public frmVFDParamList(dBClient p_Conn)
        {
            InitializeComponent();
            dBConn = p_Conn;
        }

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

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void dgvChrtList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_sel = e.RowIndex;

            string code = dgvChrtList.Rows[row_sel].Cells[0].Value.ToString();
            string num = PartFunc.Cnv2ULFrmt(dgvChrtList.Rows[row_sel].Cells[1].Value.ToString());
            string rev = dgvChrtList.Rows[row_sel].Cells[2].Value.ToString();
            string desc = dgvChrtList.Rows[row_sel].Cells[3].Value.ToString();

            frmVFDParamData param_data = new frmVFDParamData(dBConn, new ChartInfo(code, num, rev, desc));
            param_data.ShowDialog();
        }
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

        public ChartInfo Copy()
        {
            return new ChartInfo(this.MachCode, this.ChrtNum, this.ChrtRev, this.ChrtDesc);
        }
    }
}
