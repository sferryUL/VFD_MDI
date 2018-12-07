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
        #region Class Globals
        const string TblMtr = "MTR_DATA";
        dBClient dBConn;

        List<ComboBox>cmbSearch = new List<ComboBox>();
        #endregion

        #region Class Constructors
        public frmMtrInfo(dBClient p_SqlClient)
        {
            dBConn = p_SqlClient;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region Form Load Methods
        private void frmMtrInfo_Load(object sender, EventArgs e)
        {
            // Populate the motor part number combobox
            dBConn.QueryDistStr(TblMtr, "MTR_NUM", p_OrderBy: "MTR_NUM");
            foreach(DataRow dr in dBConn.Table.Rows)
                cmbMtrNum.Items.Add(PartFunc.CnvFromULFrmt(dr[0].ToString()));
            cmbMtrNum.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrNum);

            // Populate the horsepower combobox
            dBConn.QueryDistStr(TblMtr, "MTR_HP");
            DataTable tbl_hp = dBConn.Table.Copy();
            cmbMtrHP.DisplayMember = "MTR_HP";
            cmbMtrHP.DataSource = tbl_hp;
            cmbMtrHP.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrHP);

            // Populate the construction material combobox
            dBConn.QueryDistStr(TblMtr, "MTR_CONST");
            DataTable tbl_const = dBConn.Table.Copy();
            cmbMtrConst.DisplayMember = "MTR_CONST";
            cmbMtrConst.DataSource = tbl_const;
            cmbMtrConst.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrConst);

            // Populate the pole count combobox
            dBConn.QueryDistStr(TblMtr, "MTR_POLES");
            DataTable tbl_poles = dBConn.Table.Copy();
            cmbMtrPoles.DisplayMember = "MTR_POLES";
            cmbMtrPoles.DataSource = tbl_poles;
            cmbMtrPoles.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrPoles);

            // Populate the manufacturer combobox
            dBConn.QueryDistStr(TblMtr, "MTR_MFR");
            DataTable tbl_mfr = dBConn.Table.Copy();
            cmbMtrMfr.DisplayMember = "MTR_MFR";
            cmbMtrMfr.DataSource = tbl_mfr;
            cmbMtrMfr.SelectedIndex = -1;
            cmbSearch.Add(cmbMtrMfr);

            cmbSrchCode.SelectedIndex = 0;
            cmbMtrNum.Focus();
        }
        #endregion

        #region Search Initiation and Clear Methods
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string where = "";
            
            string mtr_num = PartFunc.Cnv2ULFrmt(cmbMtrNum.Text);

            if(mtr_num != "")
            switch(cmbSrchCode.SelectedIndex)
            {
                case 1:
                    where = String.Format("WHERE MTR_NUM LIKE '%{0}%'", mtr_num);
                    break;
                default:
                    where = String.Format("WHERE MTR_NUM = '{0}'", mtr_num);
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
            string sql = String.Format("SELECT {0} FROM {1} {2} ORDER BY MTR_NUM;", cols, TblMtr, where);
            dBConn.QuerySQL(sql);
            DataTable srch_tbl = dBConn.Table.Copy();
            foreach(DataRow dr in srch_tbl.Rows)
            {
                dr[0] = PartFunc.CnvFromULFrmt(dr[0].ToString());
            }
            dgvSrchRes.DataSource = srch_tbl;
            dgvSrchRes.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbMtrNum.Text = "";
            cmbSrchCode.SelectedIndex = 0;
            cmbMtrHP.Text = "";
            cmbMtrPoles.Text = "";
            cmbMtrMfr.Text = "";

            dgvSrchRes.DataSource = "";
        }
        #endregion

        #region Datagridview Search Results Methods
        private void dgvSrchRes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = dgvSrchRes.SelectedRows[0].Index;
            if(idx < 0)
                goto dgvSrchRes_CellDblClk_Return;

            frmMtrData mtr_data = new frmMtrData(dBConn, 0, dgvSrchRes.Rows[e.RowIndex].Cells[0].Value.ToString());
            mtr_data.ShowDialog();

            btnSearch_Click(sender, (EventArgs)e);
            dgvSrchRes.Rows[idx].Selected = true;

            dgvSrchRes_CellDblClk_Return:
            return;
        }

        private void dgvSrchRes_MouseDown(object sender, MouseEventArgs e)
        {
            if(dgvSrchRes.Rows.Count > 0)
            {
                if(e.Button == MouseButtons.Right)
                {
                    var hti = dgvSrchRes.HitTest(e.X, e.Y);
                    dgvSrchRes.ClearSelection();
                    if(hti.RowIndex >= 0)
                        dgvSrchRes.Rows[hti.RowIndex].Selected = true;
                }
            }
        }
        #endregion

        #region Motor Insert Methods
        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmMtrData mtr_data = new frmMtrData(dBConn, 1);
            mtr_data.ShowDialog();
            btnSearch_Click(sender, e);
        }
        #endregion

        #region Context Menu Methods for Datagridview Search Results 
        private void ctxtSrchRes_Opening(object sender, CancelEventArgs e)
        {
            if(dgvSrchRes.Rows.Count <= 0)
            {
                e.Cancel = true;
                goto ctxtSrchRes_Opening_Return;
            }

            if(Environment.UserName == "sferry")
            {
                ctxtSrchRes_Delete.Enabled = true;
            }

            ctxtSrchRes_Opening_Return:
            return;
        }

        private void ctxtSrchRes_Details_Click(object sender, EventArgs e)
        {
            dgvSrchRes_CellDoubleClick(sender, (DataGridViewCellEventArgs)e);
        }

        private void ctxtSrchRes_Mod_Click(object sender, EventArgs e)
        {
            int row = dgvSrchRes.SelectedCells[0].RowIndex;
            int col = dgvSrchRes.SelectedCells[0].ColumnIndex;
            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(col,row);
            dgvSrchRes_CellDoubleClick(sender, args);
        }

        private void ctxtSrchRes_Delete_Click(object sender, EventArgs e)
        {
            int idx = dgvSrchRes.SelectedRows[0].Index;
            string num = dgvSrchRes.Rows[idx].Cells[0].Value.ToString();
            string msg = String.Format("Are you sure you want to delete motor part number {0} from the database?", num);
            string cap = "Delete Confirmation";
            if(MsgBox.YN(msg, cap) == DialogResult.Yes)
            {
                if(dBConn.DeleteStr(TblMtr, "MTR_NUM", num))
                {
                    string DelMsg = String.Format("Motor part number {0} successfully deleted.", num);
                    MsgBox.Info(DelMsg, "Motor Record Delete");
                    btnSearch_Click(sender, e);
                }
                else
                {
                    string DelMsg = String.Format("Error deleting motor part number {0}.", num);
                    MsgBox.dBErr(DelMsg);
                }
            }
        }

        private void ctxtSrchRes_Ins_Click(object sender, EventArgs e)
        {
            btnInsert_Click(sender, e);
        }
        #endregion

        #region Form Exit Methods
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
