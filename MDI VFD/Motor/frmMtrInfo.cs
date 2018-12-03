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
    public partial class frmMtrInfo : Form
    {
        const string TblMtrData = "TMP_MTR_DATA";
        dBClient dBConn;

        List<ComboBox>cmbSearch = new List<ComboBox>();

        public frmMtrInfo(dBClient p_SqlClient)
        {
            dBConn = p_SqlClient;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string where = "";
            
            if(cmbMtrNum.Text != "")
            switch(cmbSrchCode.SelectedIndex)
            {
                case 1:
                    where = String.Format("WHERE MTR_NUM LIKE '%{0}%'", cmbMtrNum.Text);
                    break;
                default:
                    where = String.Format("WHERE MTR_NUM = '{0}'", cmbMtrNum.Text);
                    break;
            }

            if(cmbMtrHP.Text != "")
            {
                if(where != "")
                    where += " AND ";
                else
                    where += " WHERE ";
                where += String.Format("MTR_HP = {0}", cmbMtrHP.Text);
            }

            if(cmbMtrPoles.Text != "")
            {
                if(where != "")
                    where += " AND ";
                else
                    where += " WHERE ";
                where += String.Format("MTR_POLES = {0}", cmbMtrPoles.Text);
            }

            if(cmbMtrConst.Text != "")
            {
                if(where != "")
                    where += " AND ";
                else
                    where += " WHERE ";
                where += String.Format("MTR_CONST = '{0}'", cmbMtrConst.Text);
            }

            if(cmbMtrMfr.Text != "")
            {
                if(where != "")
                    where += " AND ";
                else
                    where += " WHERE ";
                where += String.Format("MTR_MFR = '{0}'", cmbMtrMfr.Text);
            }

            string cols = "MTR_NUM, MTR_HP, MTR_POLES, MTR_CONST, MTR_MFR";
            string sql = String.Format("SELECT {0} FROM {1} {2} ORDER BY MTR_NUM;", cols, TblMtrData, where);
            dBConn.QuerySQL(sql);
            DataTable srch_tbl = dBConn.Table.Copy();
            dgvSrchRes.DataSource = srch_tbl;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmMtrData mtr_data = new frmMtrData(dBConn, true);
            mtr_data.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbMtrNum.Text = "";
            cmbSrchCode.SelectedIndex = 0;
            cmbMtrHP.Text = "";
            cmbMtrPoles.Text = "";
            cmbMtrMfr.Text = "";
        }

        private void dgvSrchRes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
                goto dgvSrchRes_CellDblClk_Return;

            frmMtrData mtr_data = new frmMtrData(dBConn, dgvSrchRes.Rows[e.RowIndex].Cells[0].Value.ToString(), false);
            mtr_data.ShowDialog();

            dgvSrchRes_CellDblClk_Return:
            return;
        }

        private void frmMtrInfo_Load(object sender, EventArgs e)
        {
            // Populate the motor part number combobox
            dBConn.QueryDistStr(TblMtrData, "MTR_NUM");
            DataTable tbl_num = dBConn.Table.Copy();
            cmbMtrNum.DisplayMember = "MTR_NUM";
            cmbMtrNum.DataSource = tbl_num;
            cmbMtrNum.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrNum);

            // Populate the horsepower combobox
            dBConn.QueryDistStr(TblMtrData, "MTR_HP");
            DataTable tbl_hp = dBConn.Table.Copy();
            cmbMtrHP.DisplayMember = "MTR_HP";
            cmbMtrHP.DataSource = tbl_hp;
            cmbMtrHP.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrHP);

            // Populate the construction material combobox
            dBConn.QueryDistStr(TblMtrData, "MTR_CONST");
            DataTable tbl_const = dBConn.Table.Copy();
            cmbMtrConst.DisplayMember = "MTR_CONST";
            cmbMtrConst.DataSource = tbl_const;
            cmbMtrConst.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrConst);

            // Populate the pole count combobox
            dBConn.QueryDistStr(TblMtrData, "MTR_POLES");
            DataTable tbl_poles = dBConn.Table.Copy();
            cmbMtrPoles.DisplayMember = "MTR_POLES";
            cmbMtrPoles.DataSource = tbl_poles;
            cmbMtrPoles.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrPoles);

            // Populate the manufacturer combobox
            dBConn.QueryDistStr(TblMtrData, "MTR_MFR");
            DataTable tbl_mfr = dBConn.Table.Copy();
            cmbMtrMfr.DisplayMember = "MTR_MFR";
            cmbMtrMfr.DataSource = tbl_mfr;
            cmbMtrMfr.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrMfr);            

            cmbSrchCode.SelectedIndex = 0;
            cmbMtrNum.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
