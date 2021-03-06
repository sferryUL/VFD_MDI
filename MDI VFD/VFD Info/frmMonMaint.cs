﻿using System;
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
    public partial class frmMonMaint : Form
    {
        // Dependent objects for database and serial comm
        dBClient dBConn;
        public bool CommPort = false;
        System.IO.Ports.SerialPort spVFD;
        public byte VFDAddr = 0;

        int MaintMonCnt = 0;
        
        List<V1000_Mon_Data> Maint_Data = new List<V1000_Mon_Data>();
        V1000_ModbusRTU_Comm Comm = new V1000_ModbusRTU_Comm();

        public frmMonMaint(dBClient p_SqlClient, bool p_CommPort, System.IO.Ports.SerialPort p_Port, byte p_SlaveAddr)
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
            MaintMonCnt = dBConn.QueryLikeStr(Resources.tblDrvV1000Mons, "*", "MON_NUM", "U4-");
            foreach(DataRow dr in dBConn.Table.Rows)
            {
                V1000_Mon_Data dat = new V1000_Mon_Data();
                dat.RegAddr = Convert.ToUInt16(dr[1].ToString());
                dat.MonNum = dr[2].ToString();
                dat.MonName = dr[3].ToString();
                dat.Multiplier = Convert.ToUInt16(dr[4].ToString());
                dat.NumBase = Convert.ToByte(dr[5].ToString());
                dat.Units = dr[6].ToString();
                Maint_Data.Add(dat);
            }

            for(int i = 0; i < Maint_Data.Count; i++)
            {
                dgvMonMaint.Rows.Add(new string[]
                    {
                            ("0x" + Maint_Data[i].RegAddr.ToString("X4")),
                            Maint_Data[i].MonNum,
                            Maint_Data[i].MonName,
                    });
            }

            stat_Maint_Prog.Maximum = MaintMonCnt - 1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMonCtrl_Click(object sender, EventArgs e)
        {
            ClearMaintVals();
            this.Height += stat_Maint.Height;
            stat_Maint.Visible = true;
            stat_Maint_Prog.Enabled = true;

            for(int i = 0; i < MaintMonCnt; i++)
            {
                // send out communication request for monitor address register contents
                if(Comm.OpenCommPort(ref spVFD) == 0x0001)
                {
                    ModbusRTUMsg msg = new ModbusRTUMsg(VFDAddr);
                    ModbusRTUMaster modbus = new ModbusRTUMaster();
                    List<ushort> data = new List<ushort>();

                    msg.Clear();
                    msg = modbus.CreateMessage(msg.SlaveAddr, ModbusRTUMaster.ReadReg, Maint_Data[i].RegAddr, 1, data);
                    if(Comm.DataTransfer(ref msg, ref spVFD) == 0x0001)
                    {
                        Maint_Data[i].MonVal = msg.Data[0];
                        // Add the resulting value to the datagridview
                        dgvMonMaint.Rows[i].Cells[3].Value = Maint_Data[i].MonValDisp;
                    }
                    Comm.CloseCommPort(ref spVFD);  // close the comm port
                }
                stat_Maint_Prog.PerformStep();
            }
            stat_Maint.Visible = false;
            stat_Maint_Prog.Enabled = false;
            this.Height -= stat_Maint.Height;
        }

        void ClearMaintVals()
        {
            stat_Maint_Prog.Value = 0;
            for(int i=0;i<MaintMonCnt;i++)
            {
                dgvMonMaint.Rows[i].Cells[3].Value = "";
                Maint_Data[i].MonVal = 0;
            }
        }

        void PopulateDGV()
        {
            for(int i = 0; i < Maint_Data.Count; i++)
            {
                dgvMonMaint.Rows.Add(new string[]
                    {
                            ("0x" + Maint_Data[i].RegAddr.ToString("X4")),
                            Maint_Data[i].MonNum,
                            Maint_Data[i].MonName,
                    });
            }
        }

        private void btnClrVals_Click(object sender, EventArgs e)
        {
            ClearMaintVals();
        }
    }
}
