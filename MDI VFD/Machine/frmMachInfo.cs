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
    public partial class frmMachInfo : Form
    {
        #region Class_Globals
        dBClient dBConn;
        const string TblMachData = "TMP_MACH_DATA";
        const string TblMachMtrData = "TMP_MACH_MTR_DATA";

        List<MachData> GenData;
        List<DriveObjs> MachDrvObjs;

        #endregion

        #region Form Functions
        public frmMachInfo(dBClient p_SqlClient)
        {
            dBConn = p_SqlClient;
            InitializeComponent();
        }

        private void frmMachInfo_Load(object sender, EventArgs e)
        {
            // Load all the drive info objects into the DriveObjs list for easier manipulation
            LoadObjs(); 

            // Need to load the list of machines that are already stored in the database.
            GenData = new List<MachData>();
            dBConn.Query(TblMachData,"MACH_CODE, MACH_DESC, DRV_CNT");
            for(int i=0;i<dBConn.Table.Rows.Count;i++)
            {
                MachData inf = new MachData();
                inf.MachCode = dBConn.Table.Rows[i][0].ToString();
                inf.MachDesc = dBConn.Table.Rows[i][1].ToString();
                inf.DrvCnt = Convert.ToInt32(dBConn.Table.Rows[i][2].ToString());
                GenData.Add(inf);
                cmbMach.Items.Add(String.Format("{0} - {1}", inf.MachCode, inf.MachDesc));
            }
        }

        public void LoadObjs()
        {
            MachDrvObjs = new List<DriveObjs>();

            DriveObjs obj = new DriveObjs();
            obj.LblDrvName = lblDrv1Name;
            obj.TxtDrvName = txtDrv1Name;
            obj.LblDrvDefHV = lblDrv1DefHV;
            obj.CmbDrvDefHV = cmbDrv1DefHV;
            obj.LblDrvDefLV = lblDrv1DefLV;
            obj.CmbDrvDefLV = cmbDrv1DefLV;
            MachDrvObjs.Add(obj);

            obj = new DriveObjs();
            obj.LblDrvName = lblDrv2Name;
            obj.TxtDrvName = txtDrv2Name;
            obj.LblDrvDefHV = lblDrv2DefHV;
            obj.CmbDrvDefHV = cmbDrv2DefHV;
            obj.LblDrvDefLV = lblDrv2DefLV;
            obj.CmbDrvDefLV = cmbDrv2DefLV;
            MachDrvObjs.Add(obj);

            obj = new DriveObjs();
            obj.LblDrvName = lblDrv3Name;
            obj.TxtDrvName = txtDrv3Name;
            obj.LblDrvDefHV = lblDrv3DefHV;
            obj.CmbDrvDefHV = cmbDrv3DefHV;
            obj.LblDrvDefLV = lblDrv3DefLV;
            obj.CmbDrvDefLV = cmbDrv3DefLV;
            MachDrvObjs.Add(obj);

            obj = new DriveObjs();
            obj.LblDrvName = lblDrv4Name;
            obj.TxtDrvName = txtDrv4Name;
            obj.LblDrvDefHV = lblDrv4DefHV;
            obj.CmbDrvDefHV = cmbDrv4DefHV;
            obj.LblDrvDefLV = lblDrv4DefLV;
            obj.CmbDrvDefLV = cmbDrv4DefLV;
            MachDrvObjs.Add(obj);

            obj = new DriveObjs();
            obj.LblDrvName = lblDrv5Name;
            obj.TxtDrvName = txtDrv5Name;
            obj.LblDrvDefHV = lblDrv5DefHV;
            obj.CmbDrvDefHV = cmbDrv5DefHV;
            obj.LblDrvDefLV = lblDrv5DefLV;
            obj.CmbDrvDefLV = cmbDrv5DefLV;
            MachDrvObjs.Add(obj);
        }

        #endregion

        private void cmbMach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure all the drive objects are hidden to start with
            for(int i=0;i<MachDrvObjs.Count;i++)
                MachDrvObjs[i].Hide();

            // Show only the drive objects based on the number of drives the machine has
            for(int i=0;i<GenData[cmbMach.SelectedIndex].DrvCnt;i++)
                MachDrvObjs[i].Show();

            // Fill the drive count textbox based on the machine selection
            txtDrvCnt.Text = GenData[cmbMach.SelectedIndex].DrvCnt.ToString();

            // Start forming the column for a database query regarding drive information
            string cols = "DRV1_NAME, DEF_DRV1_HV, DEF_DRV1_LV";
            for(int i=2;i<=GenData[cmbMach.SelectedIndex].DrvCnt;i++)
            {
                cols += String.Format(", DRV{0}_NAME, DEF_DRV{0}_HV, DEF_DRV{0}_LV", i.ToString());
            }

            // Get the drive information for the selected machine from the database
            List<DrvData> drv_list = new List<DrvData>();
            dBConn.QueryStr(TblMachData, cols, "MACH_CODE", GenData[cmbMach.SelectedIndex].MachCode);
            for(int i=0;i<(GenData[cmbMach.SelectedIndex].DrvCnt * 3);i+=3)
            {
                DrvData drv = new DrvData();
                drv.DrvName = dBConn.Table.Rows[0][i+0].ToString();
                drv.DrvDefHV = dBConn.Table.Rows[0][i+1].ToString();
                drv.DrvDefLV = dBConn.Table.Rows[0][i+2].ToString();
                drv_list.Add(drv);
            }

            // Populate all the drive information for each drive
            PopulateDriveData(drv_list);

            // Get the motor information for the selected machine from the database. 
            dBConn.QueryStr(TblMachMtrData, "*", "MACH_CODE", GenData[cmbMach.SelectedIndex].MachCode);

            return;
        }

        void PopulateDriveData(List<DrvData>p_List)
        {
            for(int i=0;i<GenData[cmbMach.SelectedIndex].DrvCnt;i++)
            {
                MachDrvObjs[i].TxtDrvName.Text = p_List[i].DrvName;
                MachDrvObjs[i].CmbDrvDefHV.Text = p_List[i].DrvDefHV;
                MachDrvObjs[i].CmbDrvDefLV.Text = p_List[i].DrvDefLV;
            }
        }
    }

    public class MachData
    {
        public string MachCode;
        public string MachDesc;
        public int DrvCnt;
        public DrvData DrvInf; 

        public MachData()
        {
            MachCode = "";
            MachDesc = "";
            DrvCnt = 0;
            DrvInf = new DrvData();
        }
    }

    /*
    public class DrvData
    {
        public string Drv1Name;
        public string Drv2Name;
        public string Drv3Name;
        public string Drv4Name;
        public string Drv5Name;
        public string Drv1DefHV;
        public string Drv1DefLv;
        public string Drv2DefHV;
        public string Drv2DefLv;
        public string Drv3DefHV;
        public string Drv3DefLv;
        public string Drv4DefHV;
        public string Drv4DefLv;
        public string Drv5DefHV;
        public string Drv5DefLv;

        public DrvData()
        {
            Drv1Name = "";
            Drv2Name = "";
            Drv3Name = "";
            Drv4Name = "";
            Drv5Name = "";
            Drv1DefHV = "";
            Drv1DefLv = "";
            Drv2DefHV = "";
            Drv2DefLv = "";
            Drv3DefHV = "";
            Drv3DefLv = "";
            Drv4DefHV = "";
            Drv4DefLv = "";
            Drv5DefHV = "";
            Drv5DefLv = "";
        }
    }
    */
    public class DrvData
    {
        public string DrvName;
        public string DrvDefLV;
        public string DrvDefHV;

        public DrvData()
        {
            DrvName = "";
            DrvDefHV = "";
            DrvDefLV = "";
        }
    }

    public class DriveObjs
    {
        public Label LblDrvName;
        public TextBox TxtDrvName;
        public Label LblDrvDefHV;
        public ComboBox CmbDrvDefHV;
        public Label LblDrvDefLV;
        public ComboBox CmbDrvDefLV;

        public void Show()
        {
            LblDrvName.Visible = true;
            TxtDrvName.Visible = true;
            LblDrvDefHV.Visible = true;
            CmbDrvDefHV.Visible = true;
            LblDrvDefLV.Visible = true;
            CmbDrvDefLV.Visible = true;
        }

        public void Hide()
        {
            LblDrvName.Visible = false;
            TxtDrvName.Visible = false;
            LblDrvDefHV.Visible = false;
            CmbDrvDefHV.Visible = false;
            LblDrvDefLV.Visible = false;
            CmbDrvDefLV.Visible = false;
        }
    }
}
