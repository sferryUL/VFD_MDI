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
        const string TblMtrFLC = "TMP_MTR_FLC";

        List<MachData> GenData;
        List<DriveObjs> MachDrvObjs;
        List<MtrObjs> MachMtrObjs;

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
            LoadDrvObjs(); 
            LoadMtrObjs();

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

        void LoadDrvObjs()
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

        void LoadMtrObjs()
        {
            MachMtrObjs = new List<MtrObjs>();
            LoadMtrObjs50Hz();
            LoadMtrObjs60Hz();
        }

        void LoadMtrObjs50Hz()
        {
            MtrObjs obj = new MtrObjs();
            obj.Volt = 200;
            obj.Freq = 50;
            obj.cmbMtrNum = cmbMtr200_50;
            obj.txtFLC = txtFLC_200_50;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 220;
            obj.Freq = 50;
            obj.cmbMtrNum = cmbMtr220_50;
            obj.txtFLC = txtFLC_220_50;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 230;
            obj.Freq = 50;
            obj.cmbMtrNum = cmbMtr230_50;
            obj.txtFLC = txtFLC_230_50;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 240;
            obj.Freq = 50;
            obj.cmbMtrNum = cmbMtr240_50;
            obj.txtFLC = txtFLC_240_50;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 380;
            obj.Freq = 50;
            obj.cmbMtrNum = cmbMtr380_50;
            obj.txtFLC = txtFLC_380_50;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 400;
            obj.Freq = 50;
            obj.cmbMtrNum = cmbMtr400_50;
            obj.txtFLC = txtFLC_400_50;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 415;
            obj.Freq = 50;
            obj.cmbMtrNum = cmbMtr415_50;
            obj.txtFLC = txtFLC_415_50;
            MachMtrObjs.Add(obj);
        }

        void LoadMtrObjs60Hz() 
        {
            MtrObjs obj = new MtrObjs();
            obj.Volt = 200;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr200_60;
            obj.txtFLC = txtFLC_200_60;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 208;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr208_60;
            obj.txtFLC = txtFLC_208_60;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 220;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr220_60;
            obj.txtFLC = txtFLC_220_60;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 230;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr230_60;
            obj.txtFLC = txtFLC_230_60;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 240;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr240_60;
            obj.txtFLC = txtFLC_240_60;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 380;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr380_60;
            obj.txtFLC = txtFLC_380_60;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 460;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr460_60;
            obj.txtFLC = txtFLC_460_60;
            MachMtrObjs.Add(obj);

            obj = new MtrObjs();
            obj.Volt = 575;
            obj.Freq = 60;
            obj.cmbMtrNum = cmbMtr575_60;
            obj.txtFLC = txtFLC_575_60;
            MachMtrObjs.Add(obj);
        }

        #endregion

        private void cmbMach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure all the drive objects are hidden to start with
            for(int i=0;i<MachDrvObjs.Count;i++)
                MachDrvObjs[i].Hide();

            // Clear all the motr data
            for(int i=0;i<MachMtrObjs.Count;i++)
                MachMtrObjs[i].Clear();

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

            // Get the default motor part numbers for the selected machine from the database. 
            dBConn.QueryStr(TblMachMtrData, "*", "MACH_CODE", GenData[cmbMach.SelectedIndex].MachCode);
            dBConn.Table.Columns.Remove("MACH_CODE");
            for(int i=0;i<MachMtrObjs.Count;i++)
                MachMtrObjs[i].MtrNum = dBConn.Table.Rows[0][i].ToString();

            // Get the list of unique motor part numbers to acquire the FLC values
            List<string> mtr_list = new List<string>();
            for(int i=0;i<MachMtrObjs.Count;i++)
            {
                if(MachMtrObjs[i].cmbMtrNum.Text != "")
                {
                    StrSearch srch = new StrSearch(MachMtrObjs[i].cmbMtrNum.Text);
                    if(mtr_list.FindIndex(srch.Cmp) < 0)
                        mtr_list.Add(MachMtrObjs[i].cmbMtrNum.Text);
                }
            }

            // Query the database to get all the FLC data for each motor
            for(int i=0;i<mtr_list.Count;i++)
            {
                dBConn.QueryStr(TblMtrFLC, "*", "MTR_NUM", mtr_list[i]);
                dBConn.Table.Columns.Remove("MTR_NUM");
                for(int j=0;j<MachMtrObjs.Count;j++)
                {
                    if(!dBConn.Table.Rows[0][j].ToString().Equals("") && !MachMtrObjs[j].cmbMtrNum.Text.Equals(""))
                        MachMtrObjs[j].FLC = Convert.ToSingle(dBConn.Table.Rows[0][j].ToString());
                }
            }
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

    public class MtrObjs
    {
        public int Volt;
        public int Freq;
        public ComboBox cmbMtrNum;
        public TextBox txtFLC;

        string _mtrnum;
        float _flc;
        
        public MtrObjs()
        {
            Volt = 0;
            Freq = 0;
            _flc = 0;
            _mtrnum = "";
        }

        public string MtrNum
        {
            get { return _mtrnum; }
            set
            {
                _mtrnum = value;
                if(cmbMtrNum != null)
                    cmbMtrNum.Text = _mtrnum;
            }
        }

        public float FLC
        {
            get { return _flc; }
            set
            {
                _flc = value;
                if(txtFLC != null)
                {
                    if(_flc == 0)
                        txtFLC.Text = "";
                    else
                        txtFLC.Text = _flc.ToString();
                }
            }
        }

        public void Clear()
        {
            MtrNum = "";
            FLC = 0;
        }
    }

    public class MtrSearch
    {
        string num;

        public MtrSearch(string p_Num) { num = p_Num; }

        public bool MtrNum(MtrObjs e)
        {
            return e.cmbMtrNum.Text.Equals(num);
        }
        
    }

    public class StrSearch
    {
        string _s;

        public StrSearch(String s) { _s = s; }

        public bool Cmp(String e) { return e.Equals(_s); }
    }
}
