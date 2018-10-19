using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using XL = Microsoft.Office.Interop.Excel;
using V1000_Prog_SQL;
using ModbusRTU;
using V1000_ModbusRTU;
using dBFunc;
using GenFunc;

namespace V1000_Prog_SQL
{
    public partial class frmProg : Form
    {
        #region Global Class Object/Variable Declarations

        // Database Manipulation Variables

        const string UL_Srv = "ULSQL12T";
        const string UL_dB = "ElectricalApps";

        SqlConnection dBConn = new SqlConnection();

        // VFD status and communication variables
        uint VFDReadRegCnt = 0;
        public byte VFDAddr = 0x1F;
        public bool CommPort = false;
        System.IO.Ports.SerialPort spVFD;

        // VFD Parameter Objects 
        ushort AccLvlRegAddr;
        ushort InitRegAddr;
        ushort CtrlMethodRegAddr;

        ushort FreqRefRngLow;
        ushort FreqRefRngHi;

        ushort Mtr2RngLow;
        ushort Mtr2RngHi;

        string VoltSupplyParamNum;

        string Mtr1VoltMaxOutParamNum;
        string Mtr1FreqBaseParamNum;
        string Mtr1RatedCurrParamNum;

        string Mtr2VoltMaxOutParamNum;
        string Mtr2FreqBaseParamNum;
        string Mtr2RatedCurrParamNum;

        const byte VFD_V1000 = 0x01;

        List<V1000_Param_Data> Param_List;
        List<V1000_Param_Data> Param_List_ND = new List<V1000_Param_Data>();
        List<V1000_Param_Data> Param_List_HD = new List<V1000_Param_Data>();
        List<V1000_Param_Data> Param_Mod = new List<V1000_Param_Data>();
        List<V1000_Param_Data> Param_Chng = new List<V1000_Param_Data>();
        List<V1000_Param_Data> Param_Vrfy = new List<V1000_Param_Data>();

        List<V1000_Param_Data> Param_List_SQL = new List<V1000_Param_Data>();
        List<VFDInfo> DrvInf = new List<VFDInfo>();
        List<ParamGrpInfo> GrpInf = new List<ParamGrpInfo>();

        // Background Worker status 
        ThreadProgressArgs ProgressArgs = new ThreadProgressArgs();

        // Datagridview Existing Value Storage
        string dgvCellVal;

        #endregion

        #region Main Form Functions

        public frmProg(System.IO.Ports.SerialPort p_Port, bool p_CommPort)
        {
            InitializeComponent();
            spVFD = p_Port;
            CommPort = p_CommPort;
        }

        private void frmProg_Load(object sender, EventArgs e)
        {
            // Open Database
            if(!dB.Open(ref dBConn, UL_Srv, UL_dB, true, "ElecTest", "ElecTest"))
            {
                MsgBox.Err("Unable to open Database!", "Program Error");
                this.Close();
            }

            if(CommPort)
                grpDrvComm.Enabled = true;

            cmbDrvDuty.SelectedIndex = 1;
            cmbMachSupplyVolt.SelectedIndex = 8;

            LoadDriveList();
            LoadMtrPartNums();
            LoadMachComboboxes();

            SetVFDCommBtnEnable(0x00);
            cmbDrvList.Focus();

            // In order to protect the database, and rather than using a password, if the
            // Store and Delete Parameter List buttons aren't visible, don't allow
            // Chart Part Number combobox text modification.
            if(GetMachBtnVisStat() > 4)
                cmbMachChrtNum.DropDownStyle = ComboBoxStyle.DropDown;
            else
                cmbMachChrtNum.DropDownStyle = ComboBoxStyle.DropDownList;

            // Same goes for motor data saving
            if((btnMtrStore.Visible == true) && (btnMtrDel.Visible == true))
                cmbMtrPartNum.DropDownStyle = ComboBoxStyle.DropDown;
            else
                cmbMtrPartNum.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmProg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (spVFD.IsOpen)
                spVFD.Close();
            dB.Close(ref dBConn);

            this.Dispose();
        }

        #endregion

        #region Drive Combobox Functions

        private void cmbDrvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the drive info
            string drv_num = DrvInf[cmbDrvList.SelectedIndex].Info.PartNum;
            string drv_fam = DrvInf[cmbDrvList.SelectedIndex].DrvFam;
            
            // get the table for the parameter information
            string param_tbl = DrvInf[cmbDrvList.SelectedIndex].ParamTbl;
            string grp_tbl = DrvInf[cmbDrvList.SelectedIndex].GrpDescTbl;

            // Setup the drive default values column
            string duty;
            if(cmbDrvDuty.SelectedIndex == 0)
                duty = "ND";
            else
                duty = "HD";
            string param_col = "DEF_" + drv_num + "_" + duty;

            // Get the parameter list
            DataTable tbl = new DataTable();
            string cols = "REG_ADDR, PARAM_NUM, PARAM_NAME, MULTIPLIER, NUM_BASE, UNITS, " + param_col;
            dB.Query(ref dBConn, ref tbl, param_tbl, cols, p_OrderBy:"PARAM_NUM");
            GetParamListSQL(tbl, ref Param_List);
            SetDriveParamConsts(drv_fam);

            // Get the parameter grouping list
            cmbDrvParamGrp.Items.Clear();
            GrpInf.Clear();
            tbl.Dispose();
            tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, grp_tbl, "*", p_OrderBy:"DRV_GRP");
            foreach(DataRow dr in tbl.Rows)
            {
                ParamGrpInfo inf = new ParamGrpInfo();
                inf.GrpID = dr["DRV_GRP"].ToString();
                inf.GrpDesc = dr["DRV_GRP_DESC"].ToString();
                inf.IDX = Convert.ToUInt16(dr["DRV_LIST_IDX"].ToString());

                GrpInf.Add(inf);
                cmbDrvParamGrp.Items.Add(string.Format("{0} - {1}", inf.GrpID, inf.GrpDesc));
            }

            // Enable buttons, comboboxes, and text boxes after reading all the drive setting information
            if(CommPort)
                SetVFDCommBtnEnable(0x03);  // Turn on the VFD communication buttons

            RefreshParamViews();
            cmbDrvParamGrp.Enabled = true;
            cmbDrvParamGrp.SelectedIndex = 0;
            cmbDrvDuty.Enabled = true;
            msFile_LoadParamList.Enabled = true;                // Allow a parameter update spreadsheet to be loaded
            //grpSetMotor.Enabled = true;
            btnMtrSetVals.Enabled = true;
            grpSetMach.Enabled = true;
        }

        private void GetParamListSQL(DataTable p_Tbl, ref List<V1000_Param_Data> p_List)
        {
            p_List.Clear();
            foreach(DataRow dr in p_Tbl.Rows)
            {
                V1000_Param_Data data = new V1000_Param_Data();
                data.RegAddress = Convert.ToUInt16(dr[0].ToString());
                data.ParamNum = dr[1].ToString();
                data.ParamName = dr[2].ToString();
                data.Multiplier = Convert.ToUInt16(dr[3].ToString());
                data.NumBase = Convert.ToByte(dr[4].ToString());
                data.Units = dr[5].ToString();
                data.DefVal = Convert.ToUInt16(dr[6].ToString());

                p_List.Add(data);
            }
        }

        private void cmbDrvDuty_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the Param_List list object to point to the appropriate list based on the drive duty selection
            if(cmbDrvDuty.SelectedIndex == 0)
                Param_List = Param_List_ND;
            else
                Param_List = Param_List_HD;

            if(dgvParamViewFull.Rows.Count > 0)
                cmbDrvList_SelectedIndexChanged(sender, e);
        }

        private void cmbDrvParamGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GrpInf[cmbDrvParamGrp.SelectedIndex].IDX;

            dgvParamViewFull.ClearSelection();
            dgvParamViewFull.Rows[index].Selected = true;
            dgvParamViewFull.FirstDisplayedScrollingRowIndex = index;
        }


        public void LoadDriveList()
        {
            DataTable tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, "DRV_LIST", "*", p_OrderBy:"DRV_NUM");
            
            foreach(DataRow dr in tbl.Rows)
            {
                VFDInfo inf = new VFDInfo();
                inf.Info.PartNum = dr["DRV_NUM"].ToString();
                inf.Info.PartDesc = dr["DRV_DESC"].ToString();
                inf.Info.Mfr = dr["DRV_MFR"].ToString();
                inf.Info.MfrNum = dr["DRV_MFR_NUM"].ToString();
                inf.DrvFam = dr["DRV_FAM"].ToString();
                inf.ParamTbl = dr["DRV_PARAM_LIST"].ToString();
                inf.GrpDescTbl = dr["DRV_GRP_DESC"].ToString();
                    
                string cmb_item = string.Format("{0} - {1}", inf.Info.PartNum, inf.Info.PartDesc);
                cmbDrvList.Items.Add(cmb_item);

                DrvInf.Add(inf);
            }
        }

        #endregion

        #region Textbox Functions

        /*
        private void txtSlaveAddr_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == (int)Keys.Enter) || (e.KeyValue == (int)Keys.Tab))
            {
                // Check if the value in the textbox is hex or base 10. If the  
                // value is invalid temp_val will be 0 and we just set the value 
                // back to the default 0x1F
                byte temp_val = Hex2Byte(txtSlaveAddr.Text);
                if (temp_val > 0)
                    VFDSlaveAddr = temp_val;
                else
                    VFDSlaveAddr = 0x1F;

                // Reformat the the text to be displayed as standard hexadecimal format.
                txtSlaveAddr.Text = "0x" + VFDSlaveAddr.ToString("X2");

                // Set the focus elsewhere and reload the parameter list
                if (btnVFDRead.Enabled)
                {
                    cmbDrvList_SelectedIndexChanged(sender, e);
                    btnVFDRead.Focus();
                }
                else if (cmbDrvList.SelectedIndex == -1)
                    cmbDrvList.Focus();
                else
                    cmbDrvList_SelectedIndexChanged(sender, e);

            }
        }
        */

        #endregion

        #region Datagridview Functions

        private void dgvParamViewFull_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Single chng_val = 0;
            Single def_val;

            // try to get default and changed cell values in a version that can be compared
            try
            {
                def_val = Cell2Single((String)dgvParamViewFull.Rows[e.RowIndex].Cells[3].Value, Param_List[e.RowIndex]);
                chng_val = Cell2Single((String)dgvParamViewFull.Rows[e.RowIndex].Cells[4].Value, Param_List[e.RowIndex]);
            }
            // if an exception is thrown, then just reset the cell value back
            // to what it was before the edit took place
            catch
            {
                MessageBox.Show("Entry Error!");
                dgvParamViewFull.Rows[e.RowIndex].Cells[4].Value = dgvCellVal;
                return;
            }

            // We multiply the temporary decimal value by the parameters standard multiplier.
            // and we convert the result of the multiplication to a 16-bit register value 
            // that both Modbus RTU and the V1000 require.
            Single temp_float = (chng_val * Param_List[e.RowIndex].Multiplier);
            ushort chng_param_val = (ushort)temp_float;

            UpdateParamViews(chng_param_val, e.RowIndex);
        }

        

        private void dgvParamViewFull_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dgvCellVal = (string)(dgvParamViewFull.Rows[e.RowIndex].Cells[4].Value);
        }

        #endregion

        #region Command Button Enable/Disable Functions

        private void SetVFDCommBtnEnable(bool p_ReadEn, bool p_InitEn, bool p_ModEnd, bool p_VerEn)
        {
            btnVFDRead.Enabled = p_ReadEn;
            btnVFDReset.Enabled = p_InitEn;
            btnVFDMod.Enabled = p_ModEnd;
            btnVFDVer.Enabled = p_VerEn;
        }

        private void SetVFDCommBtnEnable(int p_Val)
        {
            if ((p_Val & 0x0001) > 0)
                btnVFDRead.Enabled = true;
            else
                btnVFDRead.Enabled = false;

            if ((p_Val & 0x0002) > 0)
                btnVFDReset.Enabled = true;
            else
                btnVFDReset.Enabled = false;

            if ((p_Val & 0x0004) > 0)
                btnVFDMod.Enabled = true;
            else
                btnVFDMod.Enabled = false;

            if ((p_Val & 0x0008) > 0)
                btnVFDVer.Enabled = true;
            else
                btnVFDVer.Enabled = false;
        }

        private int GetVFDCommBtnStat()
        {
            int RetVal = 0x0000;

            if (btnVFDRead.Enabled)
                RetVal |= 0x0001;
            if (btnVFDReset.Enabled)
                RetVal |= 0x0002;
            if (btnVFDMod.Enabled)
                RetVal |= 0x0004;
            if (btnVFDVer.Enabled)
                RetVal |= 0x0008;

            return RetVal;
        }

        #endregion

        #region VFD Parameter Read Functions

        private void btnReadVFD_Click(object sender, EventArgs e)
        {
            if (!bwrkReadVFDVals.IsBusy)
            {
                VFDReadRegCnt = 0;
                dgvParamViewFull.Columns[4].ReadOnly = true;
                Param_Mod.Clear();
                dgvParamViewMisMatch.Rows.Clear();
                ProgressArgs.ClearVFDReadVals();    // Initialize the progress flags for a VFD read
                bwrkReadVFDVals.RunWorkerAsync();   // Start the separate thread for reading the current VFD parameter settings

                // Configure status bar for displaying VFD parameter read progress
                SetStatusBar(true, "VFD Parameter Value Read Progress: ");

                lblParamMismatch.Text = "Drive Modified Parameters:";
                cmMisMatchDefVal.HeaderText = "Default Value";
                
                // disable the VFD communication buttons while a read is in progress.
                SetVFDCommBtnEnable(0x00);
            }
        }

        private void bwrkReadVFDVals_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = 0;
            V1000_ModbusRTU_Comm comm = new V1000_ModbusRTU_Comm();
            ModbusRTUMsg msg = new ModbusRTUMsg(VFDAddr);
            ModbusRTUMaster modbus = new ModbusRTUMaster();
            List<ushort> tmp = new List<ushort>();

            // proceed further only if opening of communication port is successful
            if (comm.OpenCommPort(ref spVFD) == 0x0001)
            {
                ProgressArgs.VFDRead_Total_Units = Param_List.Count;

                for (int i = 0; i < ProgressArgs.VFDRead_Total_Units; i++)
                {
                    ProgressArgs.VFDRead_Unit = i;
                    ProgressArgs.VFDRead_Progress = (byte)(((float)i / ProgressArgs.VFDRead_Total_Units) * 100);
                    bwrkReadVFDVals.ReportProgress(ProgressArgs.VFDRead_Progress);

                    msg.Clear();
                    msg = modbus.CreateMessage(msg.SlaveAddr, ModbusRTUMaster.ReadReg, Param_List[i].RegAddress, 1, tmp);

                    status = comm.DataTransfer(ref msg, ref spVFD);
                    if (status == 0x0001)
                    {
                        VFDReadRegCnt++;
                        Param_List[i].ParamVal = msg.Data[0];
                    }
                    else
                        Param_List[i].ParamVal = 0;
                }

                ProgressArgs.VFDRead_Progress = 100;
                ProgressArgs.VFDRead_Stat = 0x02;
                e.Result = 0x02;
                comm.CloseCommPort(ref spVFD);
                bwrkReadVFDVals.ReportProgress(100);
            }
        }

        private void bwrkReadVFDVals_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First check and see if there was any data received to even process
            if (VFDReadRegCnt > 0)
            {
                // populate the VFD Value column on the VFD Parameter Values datagridview
                for (int i = 0; i < dgvParamViewFull.RowCount; i++)
                {
                    dgvParamViewFull.Rows[i].Cells[4].Value = Param_List[i].ParamValDisp;
                    dgvParamViewFull.Rows[i].Cells[4].ReadOnly = false;

                    // Check if the read value from the VFD differs from the default parameter setting.
                    // If it does add it to the modified parameter list and modified parameters datagridview.
                    if (Param_List[i].ParamVal != Param_List[i].DefVal)
                    {
                        Param_Mod.Add(Param_List[i]);
                        dgvParamViewMisMatch.Rows.Add(CloneRow(dgvParamViewFull, i));
                        dgvParamViewFull.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    // Otherwise just turn the full parameter view row back to white in case it was previously changed.
                    else
                        dgvParamViewFull.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            else
            {
                cmbDrvList_SelectedIndexChanged(sender, e);
                MessageBox.Show("Error Reading Parameter Values from the VFD, Check the connection, and drive slave address and try again!");
            }

            // clear all the status bar values and set them as invisible
            SetStatusBar(false);
            SetVFDCommBtnEnable(0x0F);
        }
        #endregion

        #region VFD Reset Drive Back to Their Default Settings

        private void btnVFDReset_Click(object sender, EventArgs e)
        {
            V1000_ModbusRTU_Comm comm = new V1000_ModbusRTU_Comm();
            ModbusRTUMsg msg = new ModbusRTUMsg(VFDAddr);
            ModbusRTUMaster modbus = new ModbusRTUMaster();
            List<ushort> val = new List<ushort>();
            int oldbtnset = 0;

            SetStatusBar(true, "Clearing VFD Custom Parameter Settings");
            msg.Clear();
            val.Clear();
            val.Add(2220);
            msg = modbus.CreateMessage(msg.SlaveAddr, ModbusRTUMaster.WriteReg, 0x0103, 1, val);

            if (comm.OpenCommPort(ref spVFD) == 0x0001)
            {
                oldbtnset = GetVFDCommBtnStat();
                SetVFDCommBtnEnable(false, false, false, false);
                int status = comm.DataTransfer(ref msg, ref spVFD);
                if (status != 0x0001)
                {
                    MessageBox.Show("VFD Parameter Reset to Default Failure!!");
                    goto VFDResetReturn;
                }
                else
                {
                    // Reset was successful, close the communication port before proceeding.
                    // The ReadVFD thread will handle its own needs for the comm port.
                    comm.CloseCommPort(ref spVFD);

                    // click the Read VFD button to refresh the datagridview for the full parameter 
                    // list and clear the datagridview for the modified parameter list 
                    //btnReadVFD_Click(sender, e);
                }
            }

            SetVFDCommBtnEnable(oldbtnset);
            SetStatusBar(false);
            
            VFDResetReturn:
            return;
        }

        #endregion

        #region VFD Write Scheduled Parameter Changes

        private void btnModVFD_Click(object sender, EventArgs e)
        {
            if (!bwrkModVFD.IsBusy)
            {
                // Check and see if there has been an entry for motor current in the change parameter
                // list. If there isn't verify with the user that they would like to proceed without
                // setting up the motor.
                int idx = GetParamIndex(Mtr1RatedCurrParamNum, Param_Chng);
                if(idx < 0)
                {
                    string msg = "The motor setup parameters have not been entered, do you wish to continue without setting up the motor parameters?";
                    string cap = "Motor Entry Missing";
                    if(MsgBox.YN(msg, cap) == DialogResult.No)
                        return;
                }

                ProgressArgs.ClearVFDWriteVals();
                ProgressArgs.VFDWrite_Stat = ThreadProgressArgs.Stat_Running;
                bwrkModVFD.RunWorkerAsync();
                
                SetStatusBar(true, "VFD Parameter Modification Progress: ");    // Configure status bar for displaying VFD parameter read progress
                //btnVFDMod.Enabled = false;                                      // disable the Modify VFD button while a write is in progress.
                SetVFDCommBtnEnable(0x00);
            }
        }

        private void bwrkModVFD_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = 0;
            V1000_ModbusRTU_Comm comm = new V1000_ModbusRTU_Comm();
            ModbusRTUMsg msg = new ModbusRTUMsg(VFDAddr);
            ModbusRTUMaster modbus = new ModbusRTUMaster();
            List<ushort> val = new List<ushort>();
            List<V1000_Param_Data> tmp_list = new List<V1000_Param_Data>();
            int idx_init = 0;

            // Need to check and see if a re-initialize drive parameter exists, if so mark its index number for later
            for(int i=0;i<Param_Chng.Count;i++)
            {
                if(Param_Chng[i].RegAddress == InitRegAddr)
                {
                    idx_init = i;
                    break;
                }
            }

            // Need to check and see if there are terminal parameters that are duplicates. If so
            // then set those parameter that will conflict as 0x0F so that a fault doesn't occur
            for(int i=0;i<Param_Chng.Count;i++)
            {
                switch(Param_Chng[i].RegAddress)
                {
                    case 0x0400: // H1-03
                    case 0x0401: // H1-04
                    case 0x0402: // H1-05
                    case 0x0403: // H1-06
                    case 0x0404: // H1-07
                    case 0x0438: // H1-01
                    case 0x0439: // H1-02
                        int idx = GetParamIndex("H1-01", Param_List);
                        for(int z=0;z<7;z++)
                        {
                            if(Param_Chng[i].ParamVal == Param_List[idx + z].DefVal)
                            {
                                tmp_list.Add((V1000_Param_Data)Param_List[idx + z].Clone());
                                tmp_list[tmp_list.Count-1].ParamVal = 0x0F;
                            }
                        }
                        break;
                }
            }
           
            for(int i = 0;i<tmp_list.Count;i++)
            {
                Param_Chng.Insert(idx_init+i+1, (V1000_Param_Data)tmp_list[i].Clone());
            }

            // Send the motor 2 parameters, if they exist, to the back of the list. Entering
            // Motor 2 parameters before enabling it in the H1 terminal parameters causes an
            // OPE02 fault.
            ParamListSend2Back(Mtr2RngLow, Mtr2RngHi, ref Param_Chng);

            // Send the frequency reference parameters to the back of the list of updates
            // because if not then the max and min frequency ranges won't write
            ParamListSend2Back(FreqRefRngLow, FreqRefRngHi, ref Param_Chng);

            // Send the access level parameter to the back otherwise the operator mode parameter won't write
            ParamListSend2Back(AccLvlRegAddr, AccLvlRegAddr, ref Param_Chng);
            
            // proceed further only if opening of communication port is successful
            if (comm.OpenCommPort(ref spVFD) == 0x0001)
            {
                ProgressArgs.VFDWrite_Total_Units = Param_Chng.Count;

                for (int i = 0; i < ProgressArgs.VFDWrite_Total_Units; i++)
                {
                    ProgressArgs.VFDWrite_Unit = i;
                    ProgressArgs.VFDWrite_Progress = (byte)(((float)i / ProgressArgs.VFDWrite_Total_Units) * 100);
                    bwrkModVFD.ReportProgress(ProgressArgs.VFDWrite_Progress);
                    
                    msg.Clear();
                    val.Clear();
                    val.Add(Param_Chng[i].ParamVal);
                    msg = modbus.CreateMessage(msg.SlaveAddr, ModbusRTUMaster.WriteReg, Param_Chng[i].RegAddress, 1, val);

                    status = comm.DataTransfer(ref msg, ref spVFD);
                    if (status != 0x0001)
                    {
                        MessageBox.Show("VFD Parameter Update Failure!!");
                        e.Cancel = true;
                        ProgressArgs.VFDWrite_Stat = ThreadProgressArgs.Stat_Error;
                        bwrkModVFD.ReportProgress(0);
                        break;
                    }
                }

                if (status == 0x0001)
                {
                    // Update all the progress and status flags
                    ProgressArgs.VFDWrite_Progress = 100;
                    ProgressArgs.VFDWrite_Stat = ThreadProgressArgs.Stat_Complete;
                    e.Result = 0x02;

                    // Save the parameter changes in the VFD
                    status = comm.SaveParamChanges(VFDAddr, ref spVFD);
                    if (status != 0x0001)
                        MessageBox.Show("VFD Modified Parameter Save Failure!!");
                    bwrkModVFD.ReportProgress(100);
                }

                // Close the communication port and report the thread as complete
                comm.CloseCommPort(ref spVFD);
            }
        }

        private void bwrkModVFD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // clear all the status bar values and set them as invisible
            SetStatusBar(false);

            SetVFDCommBtnEnable(0x0F);
            //SetVFDCommBtnEnable(GetVFDCommBtnStat() | 0x08);
            //btnVFDMod.Enabled = true; // re-enable the VFD read button

            if (ProgressArgs.VFDWrite_Stat == ThreadProgressArgs.Stat_Complete)
            {
                Param_Chng.Clear();
                RefreshParamViews();
                cmbDrvParamGrp_SelectedIndexChanged(sender, (EventArgs) e);
                MessageBox.Show("VFD Programming Complete!!");
            }
            else
                MessageBox.Show("VFD Programming Failed!!");
       }


        #endregion

        #region VFD Verify Parameter Settings

        private void btnVFDVer_Click(object sender, EventArgs e)
        {
            if (!bwrkVFDVerify.IsBusy)
            {
                Param_Vrfy.Clear();
                ProgressArgs.ClearVFDVerVals();
                ProgressArgs.VFDVer_Stat = ThreadProgressArgs.Stat_Running;
                bwrkVFDVerify.RunWorkerAsync();

                // Configure status bar for displaying VFD modified parameter verification progress
                SetStatusBar(true, "VFD Parameter Parameter Setting Verification Progress:");

                lblParamMismatch.Text = "Drive Mismatched Parameter Values";
                cmMisMatchDefVal.HeaderText = "Specified Value";

                dgvParamViewMisMatch.Rows.Clear(); // clear the mismatch datagridview
                SetVFDCommBtnEnable(0x00);
                //btnVFDVer.Enabled = false; // disable the Modify VFD button while a write is in progress.
            }
        }

        private void bwrkVFDVerify_DoWork(object sender, DoWorkEventArgs e)
        {
            int status = 0;
            V1000_ModbusRTU_Comm comm = new V1000_ModbusRTU_Comm();
            ModbusRTUMsg msg = new ModbusRTUMsg(VFDAddr);
            ModbusRTUMaster modbus = new ModbusRTUMaster();
            List<ushort> val = new List<ushort>();

            // proceed further only if opening of communication port is successful
            if (comm.OpenCommPort(ref spVFD) == 0x0001)
            {
                ProgressArgs.VFDVer_Total_Units = Param_List.Count;

                for (int i = 0; i < ProgressArgs.VFDVer_Total_Units; i++)
                {
                    //Set progress reporting values and check for cancellation of the thread.
                    ProgressArgs.VFDVer_Unit = i;
                    ProgressArgs.VFDVer_Progress = (byte)(((float)i / ProgressArgs.VFDVer_Total_Units) * 100);
                    bwrkVFDVerify.ReportProgress(ProgressArgs.VFDVer_Progress);
                    
                    msg.Clear();
                    val.Clear();
                    val.Add(Param_List[i].ParamVal);
                    msg = modbus.CreateMessage(msg.SlaveAddr, ModbusRTUMaster.ReadReg, Param_List[i].RegAddress, 1, val);

                    status = comm.DataTransfer(ref msg, ref spVFD);
                    if (status != 0x0001)
                    {
                        MessageBox.Show("VFD Parameter Verification Failed!!");
                        e.Cancel = true;
                        ProgressArgs.VFDVer_Stat = ThreadProgressArgs.Stat_Error;
                        bwrkVFDVerify.ReportProgress(0);
                        break;
                    }
                    else
                    {
                        Param_Vrfy.Add((V1000_Param_Data)Param_List[i].Clone());
                        Param_Vrfy[i].ParamVal = msg.Data[0];
                    }
                }

                // Close the communication port
                comm.CloseCommPort(ref spVFD);

                // Update all the progress and status flags
                ProgressArgs.VFDVer_Progress = 100;
                ProgressArgs.VFDVer_Stat = ThreadProgressArgs.Stat_Complete;
                e.Result = 0x02;
                bwrkVFDVerify.ReportProgress(100);
            }
        }

        private void bwrkVFDVerify_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            SetStatusBar(false);        // clear all the status bar values and set them as invisible
            SetVFDCommBtnEnable(0x0F);
            //btnVFDVer.Enabled = true;   // re-enable the VFD read button

            if (ProgressArgs.VFDVer_Stat == ThreadProgressArgs.Stat_Complete)
            {
                // First make an exact copy of the master parameter list and then alter the 
                // parameter values of the ones that we are verifying should have been modified. 
                List<V1000_Param_Data> param_chk = new List<V1000_Param_Data>();
                for (int i = 0; i < Param_List.Count; i++)
                {
                    param_chk.Add((V1000_Param_Data)Param_List[i].Clone());
                    if (Param_List[i].ParamVal == 0)
                        param_chk[i].ParamVal = param_chk[i].DefVal;
                }

                // Alter the verification list to have the changed parameter values
                for (int i = 0; i < Param_Chng.Count; i++)
                {
                    int idx = GetParamIndex(Param_Chng[i].RegAddress, Param_List);
                    if (param_chk[idx].RegAddress == CtrlMethodRegAddr)
                        param_chk[idx].ParamVal = 0;
                    else
                        param_chk[idx].ParamVal = Param_Chng[i].ParamVal;
                }

                if (param_chk.Count != Param_Vrfy.Count)
                    MessageBox.Show("Parameter verification failed! Number of parameters read from drive does not match total number of parameters!");
                else
                {
                    for (int i = 0; i < param_chk.Count; i++)
                    {
                        if (Param_Vrfy[i].ParamVal != param_chk[i].ParamVal)
                        {
                            // Clone the row with the parameter that differs from the default value and add it to 
                            // the Datagridview for modified parameters. 
                            dgvParamViewMisMatch.Rows.Add(CloneRow(dgvParamViewFull, i));
                            int idx = dgvParamViewMisMatch.RowCount - 1;
                            dgvParamViewMisMatch.Rows[idx].Cells[3].Value = param_chk[i].ParamValDisp;
                            dgvParamViewMisMatch.Rows[idx].Cells[4].Value = Param_Vrfy[i].ParamValDisp;

                            ProgressArgs.VFDVer_ParamMismatch_Cnt++; // Increment parameter mismatch count
                        }
                    }

                    if (ProgressArgs.VFDVer_ParamMismatch_Cnt > 0)
                        MessageBox.Show("VFD parameter setting verification failed!. See mismatch parameter list for details.");
                    else
                        MessageBox.Show("VFD parameter setting verification successful!");
                }

            }
        }

        #endregion

        #region Text Manipulation Functions

        private Single Cell2Single(string p_CellVal, V1000_Param_Data p_Param)
        {
            Single RetVal = 0;


            // First check if the default parameter is a hex value so we can trim off the "0x" from the beginning
            if (p_Param.NumBase == 16)
            {
                // Now check and see if the value is actually a hex value
                if ((p_CellVal.IndexOf('x') > 0) || (p_CellVal.IndexOf('X') > 0))
                {
                    ushort temp_val = Convert.ToUInt16(p_CellVal.Substring(2), 16);
                    RetVal = Convert.ToSingle(temp_val);
                }
                // If not just convert it to a single and treat it as a base 10 value
                else
                    RetVal = Convert.ToSingle(p_CellVal);
            }
            // Otherwise we need to trim off any units from the default cell value
            else
            {
                RetVal = Cell2Single(p_CellVal);
            }

            return RetVal;
        }

        private Single Cell2Single(string p_CellVal)
        {
            Single RetVal = -1;

            int unit_index = p_CellVal.IndexOf(' ');
            if (unit_index > 0)
            {
                p_CellVal = p_CellVal.Substring(0, unit_index);
                RetVal = Convert.ToSingle(p_CellVal);
            }
            // If there are no units then just convert the cell value to a single
            else
                RetVal = Convert.ToSingle(p_CellVal);

            return RetVal;
        }

        private Double Cell2Double(string p_CellVal, V1000_Param_Data p_Param)
        {
            Double RetVal = 0;


            // First check if the default parameter is a hex value so we can trim off the "0x" from the beginning
            if (p_Param.NumBase == 16)
            {
                // Now check and see if the value is actually a hex value
                if ((p_CellVal.IndexOf('x') > 0) || (p_CellVal.IndexOf('X') > 0))
                {
                    ushort temp_val = Convert.ToUInt16(p_CellVal.Substring(2), 16);
                    RetVal = Convert.ToDouble(temp_val);
                }
                // If not just convert it to a single and treat it as a base 10 value
                else
                    RetVal = Convert.ToDouble(p_CellVal);
            }
            // Otherwise we need to trim off any units from the default cell value
            else
            {
                RetVal = Cell2Double(p_CellVal);
            }

            return RetVal;
        }

        private Double Cell2Double(string p_CellVal, byte p_RoundVal = 2)
        {
            Double RetVal = -1;

            int unit_index = p_CellVal.IndexOf(' ');
            if (unit_index > 0)
            {
                p_CellVal = p_CellVal.Substring(0, unit_index);
                RetVal = Math.Round(Convert.ToDouble(p_CellVal), p_RoundVal);
            }
            // If there are no units then just convert the cell value to a single
            else
                RetVal = Math.Round(Convert.ToDouble(p_CellVal), p_RoundVal);

            return RetVal;
        }

        private ushort Cell2RegVal(string p_CellVal, V1000_Param_Data p_Param)
        {
            double val;

            val = Cell2Double(p_CellVal, GetRoundCnt(p_Param.Multiplier));
            val = Math.Round((val * Convert.ToDouble(p_Param.Multiplier)), 0);

            return (ushort)val;
        }

        private byte GetRoundCnt(ushort p_Multiplier)
        {
            byte RoundCnt = 0;

            switch (p_Multiplier)
            {
                case 1:
                    RoundCnt = 0;
                    break;
                case 10:
                    RoundCnt = 1;
                    break;
                case 100:
                    RoundCnt = 2;
                    break;
                case 1000:
                    RoundCnt = 3;
                    break;
            }

            return RoundCnt;
        }

        private byte Hex2Byte(string p_CellVal)
        {
            byte RetVal = 0;

            try
            {
                // Check and see if the value is actually a hex value
                if ((p_CellVal.IndexOf('x') > 0) || (p_CellVal.IndexOf('X') > 0))
                {
                    byte temp_val = Convert.ToByte(p_CellVal.Substring(2), 16);
                    RetVal = Convert.ToByte(temp_val);
                }
                // If not just convert it to a single and treat it as a base 10 value
                else
                    RetVal = Convert.ToByte(p_CellVal);
            }
            catch
            {
                MessageBox.Show("Entry Error!!");
            }

            return RetVal;
        }

        #endregion

        #region ToolStrip and Context Menu Functions

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctxtDriveMod_Opening(object sender, CancelEventArgs e)
        {
            if (Param_Mod.Count > 0)
            {
                ctxtDriveMod.Enabled = true;
                //ctxtDriveMod_Save.Enabled = true;
                //ctxtDriveMod_Clear.Enabled = true;
            }
            else
            {
                ctxtDriveMod.Enabled = false;
                //ctxtDriveMod_Save.Enabled = false;
                //ctxtDriveMod_Clear.Enabled = false;
            }
        }

        private void ctxtSchedChng_Opening(object sender, CancelEventArgs e)
        {
            if (msFile_LoadParamList.Enabled)
                ctxtSchedChng_Load.Enabled = true;
            else
                ctxtSchedChng_Load.Enabled = false;

            if (Param_Chng.Count > 0)
            {
                ctxtSchedChng_Save.Enabled = true;
                ctxtSchedChng_Clear.Enabled = true;
                ctxtSchedChng_Remove.Enabled = true;
            }
            else
            {
                ctxtSchedChng_Save.Enabled = false;
                ctxtSchedChng_Clear.Enabled = false;
                ctxtSchedChng_Remove.Enabled = false;
            }
        }

        private void ctxtSchedChng_Remove_Click(object sender, EventArgs e)
        {
            int idx = dgvParamViewChng.CurrentCell.RowIndex;

            dgvParamViewChng.Rows.RemoveAt(idx);
            Param_Chng.RemoveAt(idx);

            RefreshParamViews();
        }

        private void clearScheduledChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClrSchedChng();
            /*
            Param_Chng.Clear();
            RefreshParamViews();
            SetVFDCommBtnEnable(0x03);
            */
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearParamMismatch();
            RefreshParamViews();
        }

        private void SetStatusBar(bool p_Vis, string p_Str = "", int p_Val = 0)
        {
            statProgLabel.Visible = p_Vis;
            statProgress.Visible = p_Vis;
            statProgLabel.Text = p_Str;
            statProgress.Value = p_Val;
        }

        private void bwrkDGV_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statProgress.Value = e.ProgressPercentage;
        }

        #endregion

        #region Parameter File Reading and Writing Functions
        private void SaveParams(object sender, EventArgs e)
        {
            XL.Application xlApp = new XL.Application();
            XL.Workbook xlWorkbook = xlApp.Workbooks.Add();
            XL._Worksheet xlWorksheet = xlWorkbook.Worksheets["Sheet1"];
            SaveFileDialog svfd = new SaveFileDialog();
            List<V1000_Param_Data> param_save = new List<V1000_Param_Data>();

            ToolStripMenuItem owner = (ToolStripMenuItem)sender;
            if (owner.Name == "ctxtDriveMod_Save")
                param_save = Param_Mod;
            else if (owner.Name == "ctxtSchedChng_Save")
                param_save = Param_Chng;

            svfd.Filter = "Excel 2007 Workbook (*.xlsx)|*.xlsx";
            svfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (svfd.ShowDialog() == DialogResult.OK)
            {
                string filename = svfd.FileName;


                xlWorksheet.Cells[1, 1].Value2 = "PARAMETER NUMBER";
                xlWorksheet.Cells[1, 2].Value2 = "PARAMETER NAME";
                xlWorksheet.Cells[1, 3].Value2 = "PARAMETER VALUE";
                xlWorksheet.Cells[1, 4].Value2 = "PARAMETER UNITS";

                for (int i = 0; i < param_save.Count; i++)
                {
                    xlWorksheet.Cells[(i + 2), 1].Value2 = param_save[i].ParamNum;
                    xlWorksheet.Cells[(i + 2), 2].Value2 = param_save[i].ParamName;
                    xlWorksheet.Cells[(i + 2), 3].Value2 = ((float)param_save[i].ParamVal / param_save[i].Multiplier);
                    xlWorksheet.Cells[(i + 2), 4].Value2 = param_save[i].Units;
                }
            
                GC.Collect();
                GC.WaitForPendingFinalizers();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(filename, ConflictResolution: XL.XlSaveConflictResolution.xlLocalSessionChanges);
                xlWorkbook.Close();
                xlApp.Quit();

                // release COM objects
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private void LoadParams(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            List<V1000_File_Data> file_list = new List<V1000_File_Data>();

            // Clear scheduled change list and datagridview
            Param_Chng.Clear();
            dgvParamViewChng.Rows.Clear();

            opfd.Filter = "Excel 2007 Workbook (*.xlsx)|*.xlsx";
            //opfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            opfd.InitialDirectory = @"N:\ELECTRICAL DATA\APPLICATIONS\VFD Programmer\data";
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                XL.Application xlApp = new XL.Application();
                XL._Workbook xlWorkbook = xlApp.Workbooks.Open(opfd.FileName);
                XL._Worksheet xlWorksheet = xlWorkbook.Worksheets["Sheet1"];
                XL.Range xlRange = xlWorksheet.UsedRange;

                int cnt = xlRange.Rows.Count;
                // Get all the parameter values from the Excel spreadsheet
                
                for (int i = 2; i <= cnt; i++)
                {
                    V1000_File_Data file_data = new V1000_File_Data();

                    //if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                    //    file_data.ParamNum = xlRange.Cells[i, 1].Value2.ToString();
                    //else
                    //    file_data.ParamNum = "0";

                    if(xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null)
                        file_data.ParamNum = xlRange.Cells[i, 2].Value2.ToString();
                    else
                        file_data.ParamNum = "0";

                    if (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null)
                        file_data.Value = xlRange.Cells[i, 3].Value2.ToString();
                    else
                        file_data.ParamNum = "0";
                    file_list.Add(file_data);
                }

                // find the full parameter information from the master list for each
                // of the changed parameters acquired from the Excel spreadsheet
                for (int i = 0; i < file_list.Count; i++)
                {
                    // Need to check potentially every single parameter in the master list
                    // for a match
                    for (int j = 0; j < Param_List.Count; j++)
                    {
                        // See if the parameter numbers match
                        if (Param_List[j].ParamNum == file_list[i].ParamNum)
                        {
                            //double val = Math.Round(Convert.ToDouble(file_list[i].Value), 2);
                            //ushort chng_val = (ushort)(val / Param_List[j].Multiplier);
                            //UpdateParamViews(chng_val, j);
                            UpdateParamViews(Convert.ToUInt16(file_list[i].Value), j);
                            break;
                        }
                    }
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                xlWorkbook.Close();
                xlApp.Quit();

                // release COM objects
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                // Now search the master parameter list and find all the full parameter
                // information for each item that was in the spreadsheet.
            }
        }

        #endregion
        
        #region Parameter View Functions

        private void ClrSchedChng()
        {
            Param_Chng.Clear();
            RefreshParamViews();
            SetVFDCommBtnEnable(0x03);
        }

        private void UpdateParamViews(ushort p_NewParamVal, int p_Index)
        {
            bool val_chng = false;

            //if (VFDReadRegCnt > 0)
            //{
            //    if (p_NewParamVal != Param_List[p_Index].ParamVal)
            //        val_chng = true;
            //}
            //else
            //{
            //    if (p_NewParamVal != Param_List[p_Index].DefVal)
            //        val_chng = true;
            //}

            if(p_NewParamVal != Param_List[p_Index].DefVal)
                val_chng = true;


            // Check and see if the parameter value actually changed. Just double-clicking on the cell and 
            // hitting enter will cause this event to trigger even if the value does not change.
            if(val_chng)
            {
                // Check and see if this parameter is already scheduled to be changed. 
                V1000_Param_Data param = new V1000_Param_Data();
                param = (V1000_Param_Data)Param_List[p_Index].Clone();

                int chng_index = -1;
                for (int i = 0; i < Param_Chng.Count; i++)
                {
                    // If there is a register address match then the parameter was scheduled for change
                    if (Param_Chng[i].RegAddress == param.RegAddress)
                    {
                        chng_index = i;                         // Set the change index
                        Param_Chng[i].ParamVal = p_NewParamVal; // Update the Param_Chng parameter value

                        // Update the both the Full List and Scheduled Change datagridviews
                        dgvParamViewChng.Rows[i].Cells[4].Value = Param_Chng[i].ParamValDisp;
                        dgvParamViewFull.Rows[p_Index].Cells[4].Value = Param_Chng[i].ParamValDisp;
                        break;
                    }
                }

                // If the change index is less then 0 then this parameter is not already scheduled to be 
                // changed. We add it to the Param_Chng list as well as to the Scheduled Change datagridview
                if (chng_index < 0)
                {

                    Param_Chng.Add((V1000_Param_Data)Param_List[p_Index].Clone());  // Copy the full parameter data to a list that contains scheduled changed values.
                    Param_Chng[Param_Chng.Count - 1].ParamVal = p_NewParamVal; // Overwrite the copied current parameter value with new changed value
                    Param_Chng.Sort(); // Sort parameter change list in ascending order based on the parameter number

                    // Clone the row with the changed value and add it to the Datagridview for scheduled parameter changes.
                    dgvParamViewChng.Rows.Add(CloneRow(dgvParamViewFull, p_Index));

                    // Get the parameter number from the master index
                    string param_num = Param_List[p_Index].ParamNum;
                    int idx_chng = GetParamIndex(param_num, Param_Chng);
                    dgvParamViewChng.Rows[dgvParamViewChng.RowCount - 1].Cells[4].Value = Param_Chng[idx_chng].ParamValDisp;
                    //dgvParamViewChng.Rows[dgvParamViewChng.RowCount - 1].Cells[4].Value = Param_Chng[Param_Chng.Count - 1].ParamValDisp;

                    // Fix the user entry to be the properly formatted string from any inaccuracies in formatting by the user.
                    dgvParamViewFull.Rows[p_Index].Cells[4].Value = Param_Chng[idx_chng].ParamValDisp;

                    // Highlight the scheduled changed parameter in the default parameter and current VFD parameter 
                    // in Green-Yellow to signify that a change is scheduled for that particular parameter.
                    dgvParamViewFull.Rows[p_Index].DefaultCellStyle.BackColor = Color.GreenYellow;

                    dgvParamViewChng.Sort(dgvParamViewChng.Columns[1], ListSortDirection.Ascending);

                    // If there is more than one modified parameter enable the Modify VFD Parameters button.
                    if ((Param_Chng.Count > 0) && (VFDReadRegCnt > 0))
                        btnVFDMod.Enabled = true;
                }
            } // if(val_chng)
            else
            {
                // First check and see if the VFD has been read or not. 
                if (VFDReadRegCnt > 0)
                {
                    // If it has the set the VFD value back to what the display formatted  value
                    // was when it was originally read.
                    dgvParamViewFull.Rows[p_Index].Cells[4].Value = Param_List[p_Index].ParamValDisp;

                    // Check and see if that VFD value was the same as the default value or not.
                    // If it was different than the default value set the row color to yellow,
                    // if it was the same as the default value set the row color back to white.
                    if (Param_List[p_Index].ParamVal != Param_List[p_Index].DefVal)
                        dgvParamViewFull.Rows[p_Index].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        dgvParamViewFull.Rows[p_Index].DefaultCellStyle.BackColor = Color.White;
                }
                else
                // If the VFD has not been read then set the value back to blank and set the 
                // row color back to white because it may have been changed previously.
                {
                    dgvParamViewFull.Rows[p_Index].Cells[4].Value = Param_List[p_Index].DefValDisp;
                    dgvParamViewFull.Rows[p_Index].DefaultCellStyle.BackColor = Color.White;
                }

                // Check and see if this value was scheduled to be changed
                V1000_Param_Data param = new V1000_Param_Data();
                param = (V1000_Param_Data)Param_List[p_Index].Clone();
                for (int i = 0; i < Param_Chng.Count; i++)
                {
                    // We determine if the parameter was scheduled to change by the register 
                    // address. If we find a match we remove it from the list of scheduled
                    // changes as well as the Schedule Change datagridview.
                    if (Param_Chng[i].RegAddress == param.RegAddress)
                    {
                        Param_Chng.RemoveAt(i);
                        dgvParamViewChng.Rows.RemoveAt(i);
                        break;
                    }
                }
            } // else if (val_change)

            if (Param_Chng.Count > 0)
                SetVFDCommBtnEnable((GetVFDCommBtnStat() | (byte)0x0C)); // Turn on Modify VFD and Verify VFD buttons by turning on bits 2 & 3
            else
                SetVFDCommBtnEnable((GetVFDCommBtnStat() & (byte)0xF3)); // Turn off Modify VFD and Verify BFD buttons by turning off bits 2 & 3
        }

        private void RefreshParamViews()
        {
            string ReadVal = "";

            dgvParamViewFull.Rows.Clear();  // Clear the Full Parameter List datagridview

            // Populate the Full Parameter List datagridview 
            for (int i = 0; i < Param_List.Count; i++)
            {
                if (VFDReadRegCnt > 0)
                    ReadVal = Param_List[i].ParamValDisp;

                dgvParamViewFull.Rows.Add(new string[]
                    {
                            ("0x" + Param_List[i].RegAddress.ToString("X4")),
                            Param_List[i].ParamNum,
                            Param_List[i].ParamName,
                            Param_List[i].DefValDisp,
                            ReadVal
                    });

                // Clear the read-only flag for each populated datagridview row
                dgvParamViewFull.Rows[i].Cells[4].ReadOnly = false;
            }

            // Update row colors to green-yellow based on any scheduled changes
            if (Param_Chng.Count > 0)
            {
                for (int i = 0; i < Param_Chng.Count; i++)
                {
                    int idx = GetParamIndex(Param_Chng[i].RegAddress, Param_List);
                    dgvParamViewFull.Rows[idx].Cells[4].Value = Param_Chng[i].ParamValDisp;
                    dgvParamViewFull.Rows[idx].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
            else
                dgvParamViewChng.Rows.Clear();

            // Update row colors to yellow based on any parameters read from the VFD that don't match default values
            if (Param_Mod.Count > 0)
            {
                for (int i = 0; i < Param_Mod.Count; i++)
                {
                    int idx = GetParamIndex(Param_Mod[i].RegAddress, Param_List);
                    dgvParamViewFull.Rows[idx].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            else
                dgvParamViewMisMatch.Rows.Clear();
        }

        private DataGridViewRow CloneRow(DataGridView p_DGV, int p_Idx)
        {
            DataGridViewRow row = new DataGridViewRow();

            row = (DataGridViewRow)p_DGV.Rows[p_Idx].Clone();   // Copy the row

            // Copy the contents of each column
            for (int i = 0; i < p_DGV.ColumnCount; i++)
                row.Cells[i].Value = p_DGV.Rows[p_Idx].Cells[i].Value;

            row.DefaultCellStyle.BackColor = Color.White;       // Reset the row color as white

            return row;
        }

        #endregion

        #region Parameter List Functions

        private void ParamListCopy(ref List<V1000_Param_Data> p_Mstr, ref List<V1000_Param_Data> p_Copy)
        {
            p_Copy.Clear();
            for (int i = 0; i < p_Mstr.Count; i++)
                p_Copy.Add((V1000_Param_Data)p_Mstr[i].Clone());
        }

        private void ParamListUpdate(ref List<V1000_Param_Data> p_Mstr, ref List<V1000_Param_Data> p_NewVals, byte p_Mode)
        {
            // Mode 1 - Default Value
            // Mode 2 - Parameter Value
            // Mode 3 - Both Values
            for (int i = 0; i < p_NewVals.Count; i++)
            {
                int index = GetParamIndex(p_NewVals[i].RegAddress, p_Mstr);  // Find the index of the parameter 
                switch (p_Mode)
                {
                    case 0x01:
                        p_Mstr[index].DefVal = p_NewVals[i].DefVal;
                        break;
                    case 0x02:
                        p_Mstr[index].ParamVal = p_NewVals[i].ParamVal;
                        break;
                    case 0x03:
                        p_Mstr[index].DefVal = p_NewVals[i].DefVal;
                        p_Mstr[index].DefVal = p_NewVals[i].ParamVal;
                        break;
                }
            }
        }

        private void ClearParamMismatch()
        {
            Param_Mod.Clear();
            for (int i = 0; i < Param_List.Count; i++)
                Param_List[i].ParamVal = 0;
        }

        private int GetParamIndex(string p_ParamNum, List<V1000_Param_Data> p_List)
        {
            int idx = -1;

            for (int i = 0; i < p_List.Count; i++)
            {
                if (p_List[i].ParamNum == p_ParamNum)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }

        private int GetParamIndex(ushort p_RegAddr, List<V1000_Param_Data> p_List)
        {
            int Index = -1;

            for (int i = 0; i < p_List.Count; i++)
            {
                if (p_List[i].RegAddress == p_RegAddr)
                {
                    Index = i;
                    break;
                }
            }

            return Index;
        }

        void ParamListSend2Back(int p_RngLo, int p_RngHi, ref List<V1000_Param_Data> p_List)
        {
            int idx = 0;

            for (int i = 0; i < Param_Chng.Count; i++)
            {
                if ((p_List[idx].RegAddress >= p_RngLo) && (p_List[idx].RegAddress <= p_RngHi))
                {
                    V1000_Param_Data param_temp = new V1000_Param_Data();
                    param_temp = (V1000_Param_Data)p_List[idx].Clone();
                    p_List.RemoveAt(idx);
                    p_List.Add(param_temp);
                }
                else
                {
                    if (++idx >= Param_List.Count)
                        break;
                }
            }
        }

        #endregion

        #region VFD Specific Functions
        public void SetDriveParamConsts(byte p_DriveType)
        {
            switch (p_DriveType)
            {
                case VFD_V1000:
                    AccLvlRegAddr = V1000_Param_Data.AccLvlReg;
                    CtrlMethodRegAddr = V1000_Param_Data.RegCtrlMethod;
                    InitRegAddr = V1000_Param_Data.InitReg;

                    FreqRefRngLow = V1000_Param_Data.FreqRefRngLow;
                    FreqRefRngHi = V1000_Param_Data.FreqRefRngHi;

                    Mtr2RngLow = V1000_Param_Data.Mtr2RngLow;
                    Mtr2RngHi = V1000_Param_Data.Mtr2RngHi;

                    VoltSupplyParamNum = V1000_Param_Data.VoltSuppParam;
                    Mtr1VoltMaxOutParamNum = V1000_Param_Data.Mtr1VoltMaxOutParam;
                    Mtr1FreqBaseParamNum = V1000_Param_Data.Mtr1FreqBaseParam;
                    Mtr1RatedCurrParamNum = V1000_Param_Data.Mtr1RatedCurrParam;

                    Mtr2VoltMaxOutParamNum = V1000_Param_Data.Mtr2VoltMaxOutParam;
                    Mtr2FreqBaseParamNum = V1000_Param_Data.Mtr2FreqBaseParam;
                    Mtr2RatedCurrParamNum = V1000_Param_Data.Mtr2RatedCurrParam;

                    break;
            }
        }

        public void SetDriveParamConsts(string p_DrvFam)
        {
            switch(p_DrvFam)
            {
                case "V1000":
                    SetDriveParamConsts(VFD_V1000);
                    break;
            }
        }

        #endregion

        #region Machine Specific Functions

        private void MachSelReset()
        {
            cmbMachChrtNum.Items.Clear();
            cmbMachChrtNum.Text = "";
            txtMachChrtCnt.Clear();
            txtMachDrvCnt.Clear();
            cmbMachDrvNum.Items.Clear();
            txtMachDrvName.Clear();
        }

        private void cmbMachSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // First clear all machine entry items strip off the machine code from the combo box
            MachSelReset();
            string mach_code = GetMachCode(cmbMachSel.SelectedItem);    

            // next query the database for the number of VFDs the machine selection has
            DataTable tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, "MACH_DATA", "*", "MACH_CODE", dB.StringConv(mach_code));
            int drv_cnt = Convert.ToInt32(tbl.Rows[0]["DRV_CNT"].ToString());
            txtMachDrvCnt.Text = drv_cnt.ToString();

            // Populate drive selection comboboxes with drive selection options
            for(int i=0;i<drv_cnt;i++)
                cmbMachDrvNum.Items.Add((i + 1).ToString());
            cmbMachDrvNum.SelectedIndex = 0;
            
            UpdMachChrtInf(mach_code);
            SetDefDriveSel();
            SetMachBtnEnable(0x07);

            if(mach_code.Equals("MDCA"))
                grpMtr2Set.Visible = true;
            else
                grpMtr2Set.Visible = false;
        }

        private void cmbMachDrvNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            
            // Form column name for stored drive name in the database
            string drv_col_name = "DRV" + cmbMachDrvNum.GetItemText(cmbMachDrvNum.SelectedItem) + "_NAME";
            
            // Form the machine code for searching in the database
            string mach_code = GetMachCodeSQL(cmbMachSel.SelectedItem);

            dB.Query(ref dBConn, ref tbl, "MACH_DATA", drv_col_name, "MACH_CODE", mach_code);
            txtMachDrvName.Text = tbl.Rows[0][0].ToString();
            SetDefDriveSel();

        }

        private void btnMachListLoad_Click(object sender, EventArgs e)
        {
            if(cmbMachSel.SelectedIndex < 0)
            {
                MsgBox.Err("No machine selected!");
                goto ChrtLoadReturn;
            }

            MachInfo info = new MachInfo(GetMachInfo(GetMachCode(cmbMachSel.Text)));

            if(!VerChrtInf(info.mach_code, info.chrt_num, info.drv_num.ToString()))
                goto ChrtLoadReturn;

            ClrSchedChng(); // Clear any existing changes

            // load the chart
            string chrt_tbl = GetMachChrtTbl(info.chrt_num_drv);
            string chrt_col = string.Format("CHRT_{0}", info.chrt_num_drv);
            DataTable tbl = new DataTable();
            if(dB.QueryNull(ref dBConn, ref tbl, 0, chrt_tbl, "PARAM_NUM, " + chrt_col, chrt_col, "PARAM_NUM") > 0)
            {
                foreach(DataRow dr in tbl.Rows)
                {
                    int idx = GetParamIndex(dr["PARAM_NUM"].ToString(), Param_List);
                    UpdateParamViews(Convert.ToUInt16(dr[chrt_col].ToString()), idx);
                }
            }

            ChrtLoadReturn:
            return;
        }

        private void btnMachListStore_Click(object sender, EventArgs e)
        {
            if (cmbMachSel.SelectedIndex < 0)
            {
                MsgBox.Err("No machine selected!");
                return;
            }

            // First make sure that all the machine data is filled in
            if((cmbMachChrtNum.Text == "") || (cmbMachDrvNum.Text == ""))
            {
                MsgBox.Err("Storing a machine VFD parameter chart requires information filled out!");
                return;
            }
            
            // Next make sure that there are even parameters to save
            if(Param_Chng.Count < 1)
            {
                MsgBox.Err("No parameters to store!!");
                return;
            }
            
            // Get the mach code, chart count, and specific chart number info
            string mach_code = GetMachCode(cmbMachSel.Text);
            int chrt_cnt = GetMachChrtCnt(mach_code);

            string chrt_num = cmbMachChrtNum.Text;
            string chrt_num_drv = string.Format("{0}_{1}", cmbMachChrtNum.Text, cmbMachDrvNum.Text);

            // Check and see if the chart for this specific drive already exists
            DataTable tbl = new DataTable();
            if(dB.Query(ref dBConn, ref tbl, "CHRT_LST", "IDX", "CHRT_NUM_DRV", dB.StringConv(chrt_num_drv)) > 0)
            {
                // If it does check if overwrite is desired 
                if(MsgBox.YN("This chart already exists, do you wish to overwrite?", "VFD Chart Overwrite") == DialogResult.No)
                    return;
                // if it is then delete the chart column from the parameter change list
                string chrt_col = "CHRT_" + chrt_num_drv;
                dB.AlterTbl(ref dBConn, 0, "CHRT_V1000", chrt_col);

                // Also delete the entry from the master chart list.
                dB.Delete(ref dBConn, "CHRT_LST", "CHRT_NUM_DRV", dB.StringConv(chrt_num_drv));
            }

            tbl.Dispose();
            tbl = new DataTable();
            
            // Check and see if this is a completely new chart or just an additional drive
            if(dB.Func(ref dBConn, ref tbl, "COUNT", "CHRT_LST", "CHRT_NUM", dB.StringConv(chrt_num)))
            {
                int cnt = Convert.ToInt32(tbl.Rows[0][0].ToString());
                if(cnt == 0)
                    chrt_cnt++;
            }

            // Create the new chart column in the chart table
            string new_chrt_col = string.Format("CHRT_{0}", chrt_num_drv);
            dB.AlterTbl(ref dBConn, 1, "CHRT_V1000", new_chrt_col);
            
            // Add all the row entries for the parameter chart
            for(int i=0;i<Param_Chng.Count;i++)
                dB.Update(ref dBConn, "CHRT_V1000", new_chrt_col, Param_Chng[i].ParamVal.ToString(), "PARAM_NUM", dB.StringConv(Param_Chng[i].ParamNum));
           
            // Add chart data to the master chart list
            string InsCols = "CHRT_NUM_DRV, CHRT_NUM, MACH_CODE";
            string InsVals = string.Format("{0}, {1}, {2}", dB.StringConv(chrt_num_drv), dB.StringConv(chrt_num), dB.StringConv(mach_code));
            dB.Insert(ref dBConn, "CHRT_LST", InsCols, InsVals);

            // Update the chart count in the machine info data table
            dB.Update(ref dBConn, "MACH_DATA", "CHRT_CNT", chrt_cnt.ToString(), "MACH_CODE", dB.StringConv(mach_code));

            // Update the machine chart information area
            UpdMachChrtInf(mach_code);

            // Let the user know the parameters were stored
            MsgBox.Info("Parameter chart was successfully stored.");
        }

        private void btnMachListDel_Click(object sender, EventArgs e)
        {
            // Form the machine code 
            string mach_code = GetMachCode(cmbMachSel.SelectedItem);
            string chrt_num = cmbMachChrtNum.Text;
            string chrt_num_drv = string.Format("{0}_{1}", chrt_num, cmbMachDrvNum.Text);
            if(!VerChrtInf(mach_code, chrt_num, cmbMachDrvNum.Text))
                goto ChrtDelReturn;

            string chrt_col = string.Format("CHRT_{0}", chrt_num_drv);
            string chrt_tbl = GetMachChrtTbl(chrt_num_drv);

            // Delete the column from the master parameter chart 
            dB.AlterTbl(ref dBConn, 0, chrt_tbl, chrt_col);

            // Delete the entry in the master chart list
            dB.Delete(ref dBConn, "CHRT_LST", "CHRT_NUM_DRV", dB.StringConv(chrt_num_drv));

            // Check and see if there are any other drives remaining for that chart part number
            DataTable tbl = new DataTable();
            if(dB.QueryDist(ref dBConn, ref tbl, "CHRT_LST", "CHRT_NUM", "CHRT_NUM", dB.StringConv(chrt_num)) <= 0)
            {
                tbl.Dispose();
                tbl = new DataTable();

                // if there are no more charts left for that number then query the machine info
                // table, get the chart count, subtract one and store the updated value.
                string mach_sql = dB.StringConv(mach_code);
                dB.Query(ref dBConn, ref tbl, "MACH_DATA", "CHRT_CNT", "MACH_CODE", mach_sql);
                int chrt_cnt = Convert.ToInt32(tbl.Rows[0][0].ToString()) - 1;
                dB.Update(ref dBConn, "MACH_DATA", "CHRT_CNT", chrt_cnt.ToString(), "MACH_CODE", mach_sql);
                UpdMachChrtInf(mach_code);
            }

            MsgBox.Info("Parameter chart was successfully deleted.");
            
            ChrtDelReturn:
            return;
        }

        private MachInfo GetMachInfo(string p_MachCode)
        {
            MachInfo info = new MachInfo();

            info.supply_volt = Convert.ToInt32(cmbMachSupplyVolt.Text.Substring(0, 3));
            info.supply_freq = Convert.ToInt32(cmbMachSupplyFreq.Text.Substring(0, 2));
            info.mach_code = p_MachCode;
            info.chrt_num = cmbMachChrtNum.Text;
            info.chrt_cnt = GetMachChrtCnt(info.mach_code);
            info.drv_cnt = Convert.ToInt32(txtMachDrvCnt.Text);
            info.drv_num = Convert.ToInt32(cmbMachDrvNum.Text);
            info.drv_name = txtMachDrvName.Text;
            info.chrt_num_drv = string.Format("{0}_{1}", info.chrt_num, info.drv_num.ToString());

            return info;
        }

        private string GetMachCode(object p_cmbItem)
        {
            string str = p_cmbItem.ToString();
            int idx = str.IndexOf(' ');
            string mach_code = str.Substring(0, idx);

            return mach_code;
        }

        private string GetMachCode(string p_Text)
        {
            int idx = p_Text.IndexOf(' ');
            return p_Text.Substring(0, idx);
        }

        private string GetMachCodeSQL(object p_cmbItem)
        {
            string str = p_cmbItem.ToString();
            int idx = str.IndexOf(' ');
            string mach_code = string.Format("'{0}'", str.Substring(0, idx));

            return mach_code;
        }

        private string GetDriveChrtNum(string p_Entry)
        {
            int idx = p_Entry.IndexOf('_');
            string chart_num = p_Entry.Substring(0, idx);
            return chart_num;
        }

        private int GetMachChrtCnt(string p_MachCode)
        {
            int cnt = -1;

            string mach_code = string.Format("'{0}'", p_MachCode);
            DataTable tbl = new DataTable();
            if(dB.Query(ref dBConn, ref tbl, "MACH_DATA", "CHRT_CNT", "MACH_CODE", mach_code) >=0)
                cnt = Convert.ToInt32(tbl.Rows[0]["CHRT_CNT"].ToString());
            tbl.Dispose();

            return cnt;
        }

        private string GetMachChrtTbl(string p_ChrtNumDrv)
        {
            string chrt_tbl = "";

            DataTable tbl = new DataTable();
            if(dB.Query(ref dBConn, ref tbl, "CHRT_LST", "CHRT_TBL", "CHRT_NUM_DRV", dB.StringConv(p_ChrtNumDrv)) >= 0)
                chrt_tbl = tbl.Rows[0]["CHRT_TBL"].ToString();

            return chrt_tbl;
        }

        private List<string> GetMachChrtList(string p_MachCode)
        {
            List<string> list = new List<string>();

            DataTable tbl = new DataTable();
            if(dB.QueryDist(ref dBConn, ref tbl, "CHRT_LST", "CHRT_NUM", "MACH_CODE", dB.StringConv(p_MachCode)) >= 0)
            {
                foreach(DataRow dr in tbl.Rows)
                    list.Add(dr[0].ToString());
            }

            return list;
        }

        private void UpdMachChrtInf(string p_MachCode)
        {
            // Get the VFD chart count for the particular machine
            int chrt_cnt = GetMachChrtCnt(p_MachCode);
            txtMachChrtCnt.Text = chrt_cnt.ToString();

            // If the chart count is greater than zero then populate the Chart Part Number combobox.
            if(chrt_cnt > 0)
            {
                //string chrt_tbl = GetMachChrtTbl(mach_code);

                List<string> chrt_list = new List<string>();
                chrt_list = GetMachChrtList(p_MachCode);
                for(int i=0;i<chrt_list.Count;i++)
                    cmbMachChrtNum.Items.Add(chrt_list[i]);
                
            }
        }

        private bool VerChrtInf(string p_MachCode, string p_ChrtNum, string p_DrvNum)
        {
            bool state = false;

            // First make sure that all the machine data is filled in
            if((cmbMachChrtNum.Text == "") || (cmbMachDrvNum.Text == ""))
            {
                MsgBox.Err("A valid chart number entry and drive number selection is required.");
                goto VerChrtReturn;
            }

            // See if any charts exist for the machine
            DataTable tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, "MACH_DATA", "CHRT_CNT", "MACH_CODE", dB.StringConv(p_MachCode));
            int chart_cnt = Convert.ToInt32(tbl.Rows[0][0].ToString());
            if(chart_cnt < 1)
            {
                MsgBox.Err("No parameter charts are stored for this machine!");
                goto VerChrtReturn;
            }
            tbl.Dispose();
            tbl = new DataTable();

            // Check and see if the chart part number exists in the master chart list
            if(dB.QueryDist(ref dBConn, ref tbl, "CHRT_LST", "CHRT_NUM", "CHRT_NUM", dB.StringConv(p_ChrtNum)) <= 0)
            {
                MsgBox.Err("Parameter Chart Number " + p_ChrtNum + " does not exist for machine model " + p_MachCode);
                goto VerChrtReturn;
            }
            tbl.Dispose();
            tbl = new DataTable();

            string chrt_num_drv = string.Format("{0}_{1}", p_ChrtNum, p_DrvNum);
            if(dB.Query(ref dBConn, ref tbl, "CHRT_LST", "CHRT_NUM_DRV, CHRT_TBL", "CHRT_NUM_DRV", dB.StringConv(chrt_num_drv)) <= 0)
            {
                MsgBox.Err("A parameter chart for drive number " + cmbMachDrvNum.Text + " does not exist for parameter chart " + p_DrvNum + " for the " + p_MachCode + " machine.");
                goto VerChrtReturn;
            }

            state = true;

            VerChrtReturn:
            return state;
        }

        private void SetMachBtnEnable(bool p_DelEn, bool p_StoreEn, bool p_LoadEn)
        {
            btnMachListDel.Enabled = p_DelEn;
            btnMachListStore.Enabled = p_StoreEn;
            btnMachListLoad.Enabled = p_LoadEn;
        }

        private void SetMachBtnEnable(int p_Val)
        {
            if((p_Val & 0x0001) > 0)
                btnMachListDel.Enabled = true;
            else
                btnMachListDel.Enabled = false;

            if((p_Val & 0x0002) > 0)
                btnMachListStore.Enabled = true;
            else
                btnMachListStore.Enabled = false;

            if((p_Val & 0x0004) > 0)
                btnMachListLoad.Enabled = true;
            else
                btnMachListLoad.Enabled = false;
        }

        private int GetMachBtnEnStat()
        {
            int RetVal = 0x0000;

            if(btnMachListDel.Enabled)
                RetVal |= 0x0001;
            if(btnMachListStore.Enabled)
                RetVal |= 0x0002;
            if(btnMachListLoad.Enabled)
                RetVal |= 0x0004;

            return RetVal;
        }

        private int GetMachBtnVisStat()
        {
            int RetVal = 0x0000;

            if(btnMachListDel.Visible == true)
                RetVal |= 0x0001;
            if(btnMachListStore.Visible == true)
                RetVal |= 0x0002;
            if(btnMachListLoad.Visible == true)
                RetVal |= 0x0004;

            return RetVal;
        }

        // Load list of machine codes with their description
        public void LoadMachComboboxes()
        {
            DataTable tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, "MACH_DATA", "MACH_CODE, MACH_DESC", p_OrderBy:"MACH_CODE");

            foreach(DataRow dr in tbl.Rows)
            {
                string cmb_item = string.Format("{0} - {1}", dr["MACH_CODE"].ToString(), dr["MACH_DESC"].ToString());
                cmbMachSel.Items.Add(cmb_item);
            }
        }

        private void SetDefDriveSel()
        {
            // Get all the machine selection settings
            MachInfo inf = new MachInfo(GetMachInfo(GetMachCode(cmbMachSel.Text)));

            // Add the drive number to the database column name
            string db_col_name = string.Format("DEF_DRV{0}_", inf.drv_num.ToString());

            // Set the column code for the drive based on voltage
            if(inf.supply_volt >= 380)
                db_col_name += "HV";
            else
                db_col_name += "LV";

            // Get the drive number
            DataTable tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, "MACH_DATA", db_col_name, "MACH_CODE", dB.StringConv(inf.mach_code));
            string drive_num = tbl.Rows[0][0].ToString();

            // Find the index in the drive list for the drive selection
            int idx = -1;
            for(int i=0;i<DrvInf.Count;i++)
            {
                if(DrvInf[i].Info.PartNum.Equals(drive_num))
                {
                    idx = i;
                    break;
                }
            }

            if(idx >= 0)
                cmbDrvList.SelectedIndex = idx;
        }

        private void cmbMachSupplyVolt_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMtrVoltMax.SelectedIndex = cmbMachSupplyVolt.SelectedIndex;
            cmbMtr2VoltMax.SelectedIndex = cmbMachSupplyVolt.SelectedIndex;

            if((cmbMachSupplyVolt.SelectedItem.ToString() == "400 V") || (cmbMachSupplyVolt.SelectedItem.ToString() == "415 V"))
            {
                cmbMachSupplyFreq.SelectedIndex = 0;
                cmbMachSupplyFreq.Enabled = false;
            }
            else if(cmbMachSupplyVolt.SelectedItem.ToString() == "460 V")
            {
                cmbMachSupplyFreq.SelectedIndex = 1;
                cmbMachSupplyFreq.Enabled = false;
            }
            else
                cmbMachSupplyFreq.Enabled = true;

            if(cmbMachSel.SelectedIndex >= 0)
                SetDefDriveSel();
        }

        private void cmbMachSupplyFreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMtrFreqBase.SelectedIndex = cmbMachSupplyFreq.SelectedIndex;
            cmbMtr2FreqBase.SelectedIndex = cmbMachSupplyFreq.SelectedIndex;
        }

        #endregion

        #region Motor Specific Functions

        private void MtrVoltMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbMtrVolt, cmbMtrFreq, cmbMtrNum;
            TextBox txtFLC;

            if(((ComboBox)sender).Name == "cmbMtrVoltMax")
            {
                cmbMtrVolt = cmbMtrVoltMax;
                cmbMtrFreq = cmbMtrFreqBase;
                cmbMtrNum = cmbMtrPartNum;
                txtFLC = txtMtrFLC;
            }
            else
            {
                cmbMtrVolt = cmbMtr2VoltMax;
                cmbMtrFreq = cmbMtr2FreqBase;
                cmbMtrNum = cmbMtr2PartNum;
                txtFLC = txtMtr2FLC;
            }

            if(cmbMtrNum.SelectedIndex < 0)
                return;

            txtFLC.Text = GetMtrFLC(cmbMtrNum.Text, cmbMtrVolt.Text, cmbMtrFreq.Text);
        }

        private void MtrFreqBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbMtrVolt, cmbMtrFreq, cmbMtrNum;
            TextBox txtFLC;

            if(((ComboBox)sender).Name == "cmbMtrFreqBase")
            {
                cmbMtrVolt = cmbMtrVoltMax;
                cmbMtrFreq = cmbMtrFreqBase;
                cmbMtrNum = cmbMtrPartNum;
                txtFLC = txtMtrFLC;
            }
            else
            {
                cmbMtrVolt = cmbMtr2VoltMax;
                cmbMtrFreq = cmbMtr2FreqBase;
                cmbMtrNum = cmbMtr2PartNum;
                txtFLC = txtMtr2FLC;
            }
            if(cmbMtrNum.SelectedIndex < 0)
                return;

            txtFLC.Text = GetMtrFLC(cmbMtrNum.Text, cmbMtrVolt.Text, cmbMtrFreq.Text);
        }

        private void MtrPartNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbMtrVolt, cmbMtrFreq, cmbMtrNum;
            TextBox txtFLC;

            if(((ComboBox)sender).Name == "cmbMtrPartNum")
            {
                cmbMtrVolt = cmbMtrVoltMax;
                cmbMtrFreq = cmbMtrFreqBase;
                cmbMtrNum = cmbMtrPartNum;
                txtFLC = txtMtrFLC;
            }
            else
            {
                cmbMtrVolt = cmbMtr2VoltMax;
                cmbMtrFreq = cmbMtr2FreqBase;
                cmbMtrNum = cmbMtr2PartNum;
                txtFLC = txtMtr2FLC;
            }

            txtFLC.Text = GetMtrFLC(cmbMtrNum.Text, cmbMtrVolt.Text, cmbMtrFreq.Text);

            if((grpMtr2Set.Visible == true) && (cmbMtrPartNum.SelectedIndex >= 0) && cmbMtrNum.Name.Equals("cmbMtrPartNum"))
                cmbMtr2PartNum.SelectedIndex = cmbMtrPartNum.SelectedIndex;
        }

        private void MtrPartNum_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cmbMtrVolt, cmbMtrFreq, cmbMtrNum;
            TextBox txtFLC;

            if(((ComboBox)sender).Name == "cmbMtrPartNum")
            {
                cmbMtrVolt = cmbMtrVoltMax;
                cmbMtrFreq = cmbMtrFreqBase;
                cmbMtrNum = cmbMtrPartNum;
                txtFLC = txtMtrFLC;
            }
            else
            {
                cmbMtrVolt = cmbMtr2VoltMax;
                cmbMtrFreq = cmbMtr2FreqBase;
                cmbMtrNum = cmbMtr2PartNum;
                txtFLC = txtMtr2FLC;
            }

            if(e.KeyValue == (int)Keys.Enter)
                txtFLC.Text = GetMtrFLC(cmbMtrNum.Text, cmbMtrVolt.Text, cmbMtrFreq.Text);
        }

        private void btnSetMotorVals(object sender, EventArgs e)
        {
            ushort volt_supply = 0, volt_out = 0, freq_base = 0, fla = 0;

            if ((cmbMachSupplyVolt.SelectedIndex == -1) || (cmbMtrFreqBase.SelectedIndex == -1) || (txtMtrFLC.Text == ""))
            {
                MessageBox.Show("Machine supply voltage, supply frequency, and motor FLA must have valid entries!");
                return;
            }

            // Get all the index values in the full parameter list for each of these parameters
            int idx_volt_supply = GetParamIndex(VoltSupplyParamNum, Param_List);
            int idx_volt_out = GetParamIndex(Mtr1VoltMaxOutParamNum, Param_List);
            int idx_freq_base = GetParamIndex(Mtr1FreqBaseParamNum, Param_List);
            int idx_fla = GetParamIndex(Mtr1RatedCurrParamNum, Param_List);

            if ((idx_volt_supply > 0) && (idx_volt_out > 0) && (idx_freq_base > 0) && (idx_fla > 0))
            {
                try
                {
                    volt_supply = Cell2RegVal((string)cmbMachSupplyVolt.SelectedItem, Param_List[idx_volt_supply]);
                    volt_out = Cell2RegVal((string)cmbMtrVoltMax.SelectedItem, Param_List[idx_volt_out]);
                    freq_base = Cell2RegVal((string)cmbMtrFreqBase.SelectedItem, Param_List[idx_freq_base]);
                    fla = Cell2RegVal(txtMtrFLC.Text, Param_List[idx_fla]);
                }
                catch
                {
                    MessageBox.Show("Entry Error!!");
                    return;
                }

                UpdateParamViews(volt_supply, idx_volt_supply); // Set supply voltage parameter
                UpdateParamViews(volt_out, idx_volt_out);       // Set the maximum output voltage parameter
                UpdateParamViews(freq_base, idx_freq_base);     // Set the base frequency parameter
                UpdateParamViews(fla, idx_fla);                 // Set the motor rated current parameter
            }
            else
            {
                MessageBox.Show("Parameter Location Error!!");
            }
        }

        private void btnMtr2SetVals_Click(object sender, EventArgs e)
        {
            ushort mtr2_volt_out = 0, mtr2_freq_base = 0, mtr2_fla = 0;

            if((cmbMachSupplyVolt.SelectedIndex == -1) || (cmbMtr2FreqBase.SelectedIndex == -1) || (txtMtr2FLC.Text == ""))
            {
                MessageBox.Show("Machine supply voltage, supply frequency, and motor FLA must have valid entries!");
                return;
            }

            // Get all the index values in the full parameter list for each of these parameters
            int idx_volt_out = GetParamIndex(Mtr2VoltMaxOutParamNum, Param_List);
            int idx_freq_base = GetParamIndex(Mtr2FreqBaseParamNum, Param_List);
            int idx_fla = GetParamIndex(Mtr2RatedCurrParamNum, Param_List);

            if((idx_volt_out > 0) && (idx_freq_base > 0) && (idx_fla > 0))
            {
                try
                {
                    mtr2_volt_out = Cell2RegVal((string)cmbMtr2VoltMax.SelectedItem, Param_List[idx_volt_out]);
                    mtr2_freq_base = Cell2RegVal((string)cmbMtr2FreqBase.SelectedItem, Param_List[idx_freq_base]);
                    mtr2_fla = Cell2RegVal(txtMtr2FLC.Text, Param_List[idx_fla]);
                }
                catch
                {
                    MessageBox.Show("Entry Error!!");
                    return;
                }

                UpdateParamViews(mtr2_volt_out, idx_volt_out);       // Set the maximum output voltage parameter
                UpdateParamViews(mtr2_freq_base, idx_freq_base);     // Set the base frequency parameter
                UpdateParamViews(mtr2_fla, idx_fla);                 // Set the motor rated current parameter
            }
            else
            {
                MessageBox.Show("Parameter Location Error!!");
            }

        }

        private void btnMtrStore_Click(object sender, EventArgs e)
        {
            if((cmbMachSupplyVolt.SelectedIndex == -1) || (cmbMachSupplyFreq.SelectedIndex == -1))
            {
                MsgBox.Err("Storing motor values requires a setting for supply voltage and supply frequency!");
                return;
            }

            if(cmbMtrPartNum.Text == "")
            {
                MsgBox.Err("Storing motor values requires an Urschel assigned motor part number!");
                return;
            }

            if(txtMtrFLC.Text == "")
            {
                MsgBox.Err("Storing motor values requires a full load current entry!");
                return;
            }

            // Check and see if motor exists, if not, verify user is wanting to add the motor
            string mtr_num = cmbMtrPartNum.Text;
            DataTable tbl = new DataTable();
            if(dB.Query(ref dBConn, ref tbl, "MTR_DATA", "IDX", "MTR_NUM", dB.StringConv(mtr_num)) < 1)
            {
                if(MsgBox.YN("Motor part number " + mtr_num + " does not exist in the database, would you like to add?", "Motor Does Not Exist") == DialogResult.Yes)
                    dB.Insert(ref dBConn, "MTR_DATA", "MTR_NUM", dB.StringConv(mtr_num));
                else
                    goto MtrStoreReturn;
            }

            string col_name = BuildMtrColName(cmbMtrVoltMax.Text, cmbMtrFreqBase.Text);

            tbl.Dispose();
            tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, "MTR_DATA", col_name, "MTR_NUM", dB.StringConv(mtr_num));
            string flc = tbl.Rows[0][0].ToString();
            if(flc.Equals("") == false)
            {
                string txt = "A FLC value already exists for motor part number " + mtr_num +
                             " at a voltage of " + cmbMachSupplyVolt.Text + "AC @ " + cmbMachSupplyFreq.Text +
                             " Hz.\nDo you wish to overwrite this value?";
                if(MsgBox.YN(txt, "FLC Overwrite") == DialogResult.No)
                    goto MtrStoreReturn;
            }

            flc = txtMtrFLC.Text;
            dB.Update(ref dBConn, "MTR_DATA", col_name, flc, "MTR_NUM", dB.StringConv(mtr_num));

            MsgBox.Info("Motor FLC data successfully stored.");

            MtrStoreReturn:
            return;
        }

        private void btnMtrDel_Click(object sender, EventArgs e)
        {
            if(cmbMtrPartNum.Text == "")
            {
                MsgBox.Err("A motor part number is required to delete any record information!");
                goto MtrDelReturn;
            }

            string mtr_num = cmbMtrPartNum.Text;

            DataTable tbl = new DataTable();
            if(dB.Query(ref dBConn, ref tbl, "MTR_DATA", "IDX", "MTR_NUM", dB.StringConv(mtr_num)) < 1)
            {
                MsgBox.Err("Motor part number " + mtr_num + " does not exist in the database!");
                goto MtrDelReturn;
            }

            string flc = txtMtrFLC.Text;

            if(MsgBox.YN("Would you like to erase the entire motor information from the database?", "Motor Erase Option") == DialogResult.Yes)
            {

                if(dB.Delete(ref dBConn, "MTR_DATA", "MTR_NUM", dB.StringConv(mtr_num)))
                {
                    MsgBox.Info("Motor part successfully deleted");
                    cmbMtrPartNum.Text = "";
                    txtMtrFLC.Text = "";
                    LoadMtrPartNums();
                }
                else
                    MsgBox.dBErr("Error deleting motor part number " + mtr_num + " from the database!");
            }
            /*
            if(MsgBox.YN("Would you like to erase the FLC value of " + flc + "for motor part number " + mtr_num + "?") == DialogResult.Yes)
            {
                string col_name = BuildMtrColName(cmbMtrVoltMax.Text, cmbMtrFreqBase.Text);
                if(dB.Update(ref dBConn, "MTR_DATA", col_name, "NULL", "MTR_NUM", dB.StringConv(mtr_num)))
                    MsgBox.Info("FLC value for motor part number " + mtr_num + " was successfully cleared.");
                else
                    MsgBox.dBErr("Error updating FLC for motor part number " + mtr_num + "!");
            }
            */

            MtrDelReturn:
            return;
        }

        private string GetMtrFLC(string p_Mtr, string p_Volt, string p_Freq)
        {
            string flc = "";

            // form the start of the column header string for the motor data table
            string col_name = BuildMtrColName(p_Volt, p_Freq);

            // Make sure column name is valid)
            if(ValidateColFLC(col_name))
            {
                // Get motor FLC data from the database
                DataTable tbl = new DataTable();
                if(dB.Query(ref dBConn, ref tbl, "MTR_DATA", col_name, "MTR_NUM", dB.StringConv(p_Mtr)) > 0)
                    flc = tbl.Rows[0][0].ToString();
            }

            return flc;
        }

        public string BuildMtrColName(string p_Volt, string p_Freq)
        {
            // form the start of the column header string for the motor data table
            string col_name = "FLC_";

            // First get motor voltage combo box selection
            col_name += p_Volt.Substring(0, p_Volt.IndexOf(' ')) + "_";

            // Next get motor frequency combo box selection
            col_name += p_Freq.Substring(0, p_Freq.IndexOf(' '));

            return col_name;
        }

        private bool ValidateColFLC(string p_ColName)
        {
            bool state = true;

            if(p_ColName.Equals("FLC_400_60") || p_ColName.Equals("FLC_415_60") || p_ColName.Equals("FLC_460_50") || p_ColName.Equals("FLC_575_50"))
                state = false;

            return state;
        }

        // load the list of motors 
        public void LoadMtrPartNums()
        {
            DataTable tbl = new DataTable();
            dB.Query(ref dBConn, ref tbl, "MTR_DATA", "MTR_NUM", p_OrderBy:"MTR_NUM");
            foreach(DataRow dr in tbl.Rows)
            {
                cmbMtrPartNum.Items.Add((string)dr["MTR_NUM"]);
                cmbMtr2PartNum.Items.Add((string)dr["MTR_NUM"]);
            }
        }

        private string BuildMtrColID()
        {
            string flc_volt = cmbMachSupplyVolt.Text.Substring(0, cmbMachSupplyVolt.Text.IndexOf(' '));
            string flc_f = cmbMachSupplyFreq.Text.Substring(0, cmbMachSupplyFreq.Text.IndexOf(' '));
            string col_id = "FLC_" + flc_volt + "_" + flc_f;

            return col_id;
        }

        #endregion

        private void ctxtDriveMod_UpdDefParam_Click(object sender, EventArgs e)
        {
            if(MsgBox.YN("Updates to the default parameter list are permenant! Do you wish to continue?", "Database Defaults Update") == DialogResult.No)
                return;

            // First build the column name
            string def_col = "DEF_"; // default column prefix
            def_col += DrvInf[cmbDrvList.SelectedIndex].Info.PartNum + "_";
            if(cmbDrvDuty.SelectedIndex == 0)
                def_col += "ND";
            else
                def_col += "HD";

            // update the database
            for(int i=0;i<Param_Vrfy.Count;i++)
            {
                if(!dB.Update(ref dBConn, "DRV_V1000_PARAM", def_col, Param_Vrfy[i].ParamVal.ToString(), "PARAM_NUM", dB.StringConv(Param_Vrfy[i].ParamNum)))
                {
                    MsgBox.dBErr("Database update error!");
                    break;
                }
            }
        }

        private void ctxtDriveMod_StoreParamList_Click(object sender, EventArgs e)
        {

        }
    }

    public class ThreadProgressArgs : EventArgs
    {
        // Mode Legend:
        public const byte VFDReadMode = 0x00;
        public const byte VFDWriteMode = 0x01;
        public const byte VFDVerMode = 0x02;

        public byte Mode_Sel = 0;

        // status legend:
        public const byte Stat_NotRunning = 0x00;
        public const byte Stat_Running = 0x01;
        public const byte Stat_Complete = 0x02;
        public const byte Stat_Canceled = 0x03;
        public const byte Stat_Error = 0xFF;

        public byte     VFDRead_Stat = 0;
        public byte     VFDRead_ErrCode = 0;
        public int      VFDRead_Unit = 0;
        public int      VFDRead_Total_Units = 0;
        public byte     VFDRead_Progress = 0;

        public byte     VFDWrite_Stat = 0;
        public byte     VFDWrite_ErrCode = 0;
        public int      VFDWrite_Unit = 0;
        public int      VFDWrite_Total_Units = 0;
        public byte     VFDWrite_Progress = 0;

        public byte     VFDVer_Stat = 0;
        public byte     VFDVer_ErrCode = 0;
        public int      VFDVer_Unit = 0;
        public int      VFDVer_Total_Units = 0;
        public byte     VFDVer_Progress = 0;
        public int      VFDVer_ParamMismatch_Cnt = 0;

        public ThreadProgressArgs() { }

        public void ClearAll()
        {
            VFDRead_Stat = 0;
            VFDRead_ErrCode = 0;
            VFDRead_Unit = 0;
            VFDRead_Total_Units = 0;
            VFDRead_Progress = 0;

            VFDWrite_Stat = 0;
            VFDWrite_ErrCode = 0;
            VFDWrite_Unit = 0;
            VFDWrite_Total_Units = 0;
            VFDWrite_Progress = 0;

            VFDVer_Stat = 0;
            VFDVer_ErrCode = 0;
            VFDVer_Unit = 0;
            VFDVer_Total_Units = 0;
            VFDVer_Progress = 0;
            VFDVer_ParamMismatch_Cnt = 0;
    }

        public void ClearVFDReadVals()
        {
            VFDRead_Stat = 0;
            VFDRead_ErrCode = 0;
            VFDRead_Unit = 0;
            VFDRead_Total_Units = 0;
            VFDRead_Progress = 0;
        }

        public void ClearVFDWriteVals()
        {
            VFDWrite_Stat = 0;
            VFDWrite_ErrCode = 0;
            VFDWrite_Unit = 0;
            VFDWrite_Total_Units = 0;
            VFDWrite_Progress = 0;
        }

        public void ClearVFDVerVals()
        {
            VFDVer_Stat = 0;
            VFDVer_ErrCode = 0;
            VFDVer_Unit = 0;
            VFDVer_Total_Units = 0;
            VFDVer_Progress = 0;
            VFDVer_ParamMismatch_Cnt = 0;
        }
    } // Class ThreadProgressArgs

    public class VFDInfo
    {
        public PartInfo Info = new PartInfo();
        public string DrvFam;
        public string ParamTbl;
        public string GrpDescTbl;

        public VFDInfo()
        {
            Info.Clear();
            DrvFam = "";
            ParamTbl = "";
            GrpDescTbl = "";
        }

        public void Clear()
        {
            Info.Clear();
            DrvFam = "";
            ParamTbl = "";
            GrpDescTbl = "";
        }
    }

    public class ParamGrpInfo
    {
        public string GrpID;
        public string GrpDesc;
        public int IDX; 

        public void Clear()
        {
            GrpID = "";
            GrpDesc = "";
            IDX = 0;
        }

    }

    public class MachInfo
    {
        public int supply_volt;
        public int supply_freq;
        public string mach_code;
        public string chrt_num;
        public int chrt_cnt;
        public int drv_cnt;
        public int drv_num;
        public string drv_name;
        public string chrt_num_drv;

        public MachInfo() { }

        public MachInfo(MachInfo p_Info)
        {
            this.supply_volt = p_Info.supply_volt;
            this.supply_freq = p_Info.supply_freq;
            this.mach_code = p_Info.mach_code;
            this.chrt_num = p_Info.chrt_num;
            this.chrt_cnt = p_Info.chrt_cnt;
            this.drv_cnt = p_Info.drv_cnt;
            this.drv_num = p_Info.drv_num;
            this.drv_name = p_Info.drv_name;
            this.chrt_num_drv = p_Info.chrt_num_drv;
        }

        public void Clear()
        {
            mach_code = "";
            chrt_num = "";
            chrt_cnt = 0;
            drv_cnt = 0;
            drv_num = 0;
            drv_name = "";
        }
    }

} // Namespace V1000_Prog_SQL
