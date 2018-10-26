using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GenFunc;
using ULdB;
using V1000_ModbusRTU;
using ModbusRTU;
using System.Threading;


namespace MDI_VFD
{
    public partial class frmFlt : Form
    {
        // Dependent objects for database and serial comm
        dBClient dBConn;
        public bool CommPort = false;
        System.IO.Ports.SerialPort spVFD;
        public byte VFDAddr = 0;

        // Database Manipulation Variables
        const string UL_Flt_Tbl = "DRV_V1000_FLT";
        
        int FltTrcCnt = 0;
        int FltHstCnt = 0;
        int FltHstTimeCnt = 0;
        int FltHstTot = 0;

        List<V1000_Mon_Data> FltTrc_Data;
        List<V1000_Mon_Data> FltHst_Data;
        List<V1000_Mon_Data> FltHstTime_Data;
        V1000_ModbusRTU_Comm Comm = new V1000_ModbusRTU_Comm();

        public frmFlt(dBClient p_SqlClient, bool p_CommPort, System.IO.Ports.SerialPort p_Port, byte p_SlaveAddr)
        { 
            InitializeComponent();
            dBConn = p_SqlClient;
            CommPort = p_CommPort;
            spVFD = p_Port;
            VFDAddr = p_SlaveAddr;
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void frmFlt_Load(object sender, EventArgs e)
        {
            FltTrcCnt = dBConn.QueryLikeStr(UL_Flt_Tbl, "*", "FLT_NUM", "U2-");
            FltTrc_Data = CreateMonList(dBConn.Table.Rows);

            string query = string.Format("SELECT * FROM {0} WHERE FLT_NUM LIKE 'U3-%' AND FLT_NAME NOT LIKE '%Time%';", UL_Flt_Tbl);
            FltHstCnt = dBConn.QuerySQL(query);
            FltHst_Data = CreateMonList(dBConn.Table.Rows);

            query = string.Format("SELECT * FROM {0} WHERE FLT_NUM LIKE 'U3-%' AND FLT_NAME LIKE '%Time%';", UL_Flt_Tbl);
            FltHstTimeCnt = dBConn.QuerySQL(query);
            FltHstTime_Data = CreateMonList(dBConn.Table.Rows);

            FltHstTot = FltHstCnt + FltHstTimeCnt;

            PopulateDGVs();
            stat_Flt_Prog.Maximum = FltTrcCnt + FltHstTot;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClrVals_Click(object sender, EventArgs e)
        {
            ClrFltVals();
        }

        private void btnMonCtrl_Click(object sender, EventArgs e)
        {
            this.Height += stat_Flt.Height;
            stat_Flt.Visible = true;
            stat_Flt_Prog.Enabled = true;

            GetMonData(ref FltTrc_Data);
            GetMonData(ref FltHst_Data);
            GetMonData(ref FltHstTime_Data);

            PopulateDGVs();

            stat_Flt.Visible = false;
            stat_Flt_Prog.Enabled = false;
            this.Height -= stat_Flt.Height;
        }

        void PopulateDGVs()
        {
            ClrFltVals();

            for(int i = 0; i < FltTrc_Data.Count; i++)
            {
                dgvFltTrc.Rows.Add(new string[]
                    {
                            ("0x" + FltTrc_Data[i].RegAddr.ToString("X4")),
                            FltTrc_Data[i].MonNum,
                            FltTrc_Data[i].MonName,
                    });
                if(FltTrc_Data[i].MonValDisp != "")
                    dgvFltTrc.Rows[i].Cells[3].Value = FltTrc_Data[i].MonValDisp;
            }

            for(int i=0;i<FltHst_Data.Count;i++)
            {
                dgvFltHst.Rows.Add(new string[]
                    {
                            ("0x" + FltHst_Data[i].RegAddr.ToString("X4")),
                            FltHst_Data[i].MonNum,
                            FltHst_Data[i].MonName
                    });
                if(FltHst_Data[i].MonValDisp != "")
                    dgvFltHst.Rows[i].Cells[3].Value = FltHst_Data[i].MonValDisp;
                if(FltHstTime_Data[i].MonValDisp != "")
                    dgvFltHst.Rows[i].Cells[4].Value = FltHstTime_Data[i].MonValDisp;
            }
        }

        private List<V1000_Mon_Data> CreateMonList(DataRowCollection p_Row)
        {
            List<V1000_Mon_Data> list = new List<V1000_Mon_Data>();
            foreach(DataRow dr in p_Row)
            {
                V1000_Mon_Data dat = new V1000_Mon_Data();
                dat.RegAddr = Convert.ToUInt16(dr[1].ToString());
                dat.MonNum = dr[2].ToString();
                dat.MonName = dr[3].ToString();
                dat.Multiplier = Convert.ToUInt16(dr[4].ToString());
                dat.NumBase = Convert.ToByte(dr[5].ToString());
                dat.Units = dr[6].ToString();
                list.Add(dat);
            }

            return list;
        }

        private void GetMonData(ref List<V1000_Mon_Data> p_Data)
        {
            for(int i = 0; i < p_Data.Count; i++)
            {
                // send out communication request for monitor address register contents
                if(Comm.OpenCommPort(ref spVFD) == 0x0001)
                {
                    ModbusRTUMsg msg = new ModbusRTUMsg(VFDAddr);
                    ModbusRTUMaster modbus = new ModbusRTUMaster();
                    List<ushort> data = new List<ushort>();

                    msg.Clear();
                    msg = modbus.CreateMessage(msg.SlaveAddr, ModbusRTUMaster.ReadReg, p_Data[i].RegAddr, 1, data);
                    if(Comm.DataTransfer(ref msg, ref spVFD) == 0x0001)
                        p_Data[i].MonVal = msg.Data[0];
                    Comm.CloseCommPort(ref spVFD);  // close the comm port
                }
                stat_Flt_Prog.PerformStep();
            }
        }

        private void ClrFltVals()
        {
            stat_Flt_Prog.Value = 0;
            dgvFltTrc.Rows.Clear();
            dgvFltHst.Rows.Clear();
        }
    }
}
