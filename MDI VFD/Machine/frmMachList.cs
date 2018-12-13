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
        const string TblMachList = "TMP_MACH_DATA";

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
            dBConn.Query(TblMachList, "MACH_CODE, MACH_DESC, MTR_CNT, DRV_CNT, CHRT_CNT");
            DataTable tbl_list = dBConn.Table.Copy();
            dgvMachList.DataSource = tbl_list;
            dgvMachList.ClearSelection();
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
                frmMachData mach_data = new frmMachData(dBConn, mach_code, 0);
                mach_data.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMachData mach_data = new frmMachData(dBConn);
            mach_data.ShowDialog();
        }
    }
}
