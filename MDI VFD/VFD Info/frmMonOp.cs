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

using MDI_VFD.Properties;

using GenFunc;
using ULdB;
using V1000_ModbusRTU;
using ModbusRTU;
using System.Threading;


namespace MDI_VFD
{
    public partial class frmMonOp : Form
    {
        // Dependent objects for database and serial comm
        dBClient dBConn;
        public bool CommPort = false;
        System.IO.Ports.SerialPort spVFD;
        public byte VFDAddr = 0;

        const int OpMonStrtIdx = 0;
        const int OpMonEndIdx = 21;
        const int OpMonRecurIdx = 17;

        bool FirstCycle = false;
        int  OpMonIdx = 0;

        private bool MonActive = false;

        List<V1000_Mon_Data> Mon_Data = new List<V1000_Mon_Data>();

        V1000_ModbusRTU_Comm Comm = new V1000_ModbusRTU_Comm();

        public frmMonOp(dBClient p_SqlClient, bool p_CommPort, System.IO.Ports.SerialPort p_Port, byte p_SlaveAddr)
        { 
            InitializeComponent();
            dBConn = p_SqlClient;
            CommPort = p_CommPort;
            spVFD = p_Port;
            VFDAddr = p_SlaveAddr;
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void frmMon_Load(object sender, EventArgs e)
        {
            dBConn.QueryLikeStr(Resources.tblDrvV1000Mons, "*", "MON_NUM", "U1-");
            foreach(DataRow dr in dBConn.Table.Rows)
            {
                V1000_Mon_Data dat = new V1000_Mon_Data();
                dat.RegAddr = Convert.ToUInt16(dr[1].ToString());
                dat.MonNum = dr[2].ToString();
                dat.MonName = dr[3].ToString();
                dat.Multiplier = Convert.ToUInt16(dr[4].ToString());
                dat.NumBase = Convert.ToByte(dr[5].ToString());
                dat.Units = dr[6].ToString();
                Mon_Data.Add(dat);
            }

            for(int i=0;i<Mon_Data.Count;i++)
            {
                dgvMonOp.Rows.Add(new string[]
                    {
                            ("0x" + Mon_Data[i].RegAddr.ToString("X4")),
                            Mon_Data[i].MonNum,
                            Mon_Data[i].MonName,
                    });
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnMonCtrl_Click(object sender, EventArgs e)
        {
            if(!MonActive)
            {
                ClearMonVals();
                MonActive = true;
                
                btnMonCtrl.Text = "Stop Monitor";
                bwrkMon.RunWorkerAsync();
            }
            else
            {
                Stop();
            }
        }

        private void bwrkMon_DoWork(object sender, DoWorkEventArgs e)
        {
            while(MonActive)
            {
                if(bwrkMon.CancellationPending)
                {
                    MonActive = false;
                    e.Cancel = true;
                    break;
                }

                // send out communication request for monitor address register contents
                if(Comm.OpenCommPort(ref spVFD) == 0x0001)
                {
                    ModbusRTUMsg msg = new ModbusRTUMsg(VFDAddr);
                    ModbusRTUMaster modbus = new ModbusRTUMaster();
                    List<ushort> data = new List<ushort>();

                    msg.Clear();
                    msg = modbus.CreateMessage(msg.SlaveAddr, ModbusRTUMaster.ReadReg, Mon_Data[OpMonIdx].RegAddr, 1, data);
                    if(Comm.DataTransfer(ref msg, ref spVFD) == 0x0001)
                    {
                        
                        Mon_Data[OpMonIdx].MonVal = msg.Data[0];
                        // Add the resulting value to the datagridview
                        if(dgvMonOp.Rows.Count > 0)
                            dgvMonOp.Rows[OpMonIdx].Cells[3].Value = Mon_Data[OpMonIdx].MonValDisp;
                    }

                    Comm.CloseCommPort(ref spVFD);  // close the comm port
                }
                OpMonIdx++;                      // increment the monitor cycle count

                // check if this is the first cycle, if it is go to the max monitor count
                if(FirstCycle)
                {
                    // if the increment is greater than the monitor list then reset the 
                    // count to zero and also set the first cycle flag to false.
                    if(OpMonIdx > OpMonEndIdx)
                    {
                        OpMonIdx = 0;
                        FirstCycle = false;
                    }
                }
                else
                {
                    if(OpMonIdx > OpMonRecurIdx)
                        OpMonIdx = 0;
                }
            }
            return;
        }

        void ClearMonVals()
        {
            OpMonIdx = 0;
            FirstCycle = true;
            for(int i=0;i<Mon_Data.Count;i++)
            {
                Mon_Data[i].MonVal = 0;
                dgvMonOp.Rows[i].Cells[3].Value = "";
            }

        }

        public void Stop()
        {
            MonActive = false;
            btnMonCtrl.Text = "Start Monitor";
            bwrkMon.CancelAsync();
        }

        private void bwrkMon_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            return;
        }
    }
}
