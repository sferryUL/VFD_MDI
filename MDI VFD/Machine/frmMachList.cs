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


namespace MDI_VFD.Machine
{
    public partial class frmMachList : Form
    {
        #region Class Global Values

        // Database Globals
        dBClient dBConn;
        const string TblMachList = "MACH_DATA";

        #endregion

        #region Class Constructors

        public frmMachList(dBClient p_SQLClient)
        {
            dBConn = p_SQLClient;
            InitializeComponent();
        }

        #endregion

        #region Form Load Methods

        private void frmMachList_Load(object sender, EventArgs e)
        {
            GetMachList(0, -1);
        }

        #endregion

        #region Region 1



        #endregion

        #region Region 2



        #endregion

        #region Region 3



        #endregion

        #region Region 4



        #endregion

        #region Region 5



        #endregion

        #region Form Exit Methods



        #endregion

        private void dgvMachList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if(row >= 0)
            {
                string mach_code = dgvMachList.Rows[e.RowIndex].Cells[0].Value.ToString();
                OpenMachDetails(mach_code);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OpenMachDetails();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenMachDetails()
        {
            OpenMachDetails("");
        }

        private void OpenMachDetails(string p_MachCode)
        {
            frmMachData mach_data;
            if(p_MachCode != "")
                mach_data = new frmMachData(dBConn, p_MachCode, 0);
            else
                mach_data = new frmMachData(dBConn);

            int scroll_idx = dgvMachList.FirstDisplayedScrollingRowIndex;
            int sel_idx = - 1;
            if(dgvMachList.SelectedRows.Count > 0)
                sel_idx = dgvMachList.SelectedRows[0].Index;
            
            mach_data.ShowDialog();
            
            // Refresh the machine list view to show any changes
            GetMachList(scroll_idx, sel_idx);
        }

        private void GetMachList(int p_ScrollIdx, int p_SelIdx)
        {
            
            dBConn.Query(TblMachList, "MACH_CODE, MACH_DESC, MTR_CNT, DRV_CNT, CHRT_CNT");
            DataTable tbl_list = dBConn.Table.Copy();
            dgvMachList.DataSource = tbl_list;
            dgvMachList.ClearSelection();


            //dgvMachList.FirstDisplayedScrollingRowIndex = p_ScrollIdx;

            //if((p_SelIdx >= 0) && (p_SelIdx <= dgvMachList.Rows.Count))
            //    dgvMachList.Rows[p_SelIdx].Selected = true;
            //else
            //    dgvMachList.ClearSelection();
        }

        
    }
}
