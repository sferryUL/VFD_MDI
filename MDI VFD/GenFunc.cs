using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XL = Microsoft.Office.Interop.Excel;

namespace GenFunc
{
    public static class MsgBox
    {
        public static DialogResult Err(string p_Msg, string p_Caption = "Entry Error")
        {
            DialogResult result = MessageBox.Show(p_Msg, p_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return result;
        }

        public static DialogResult YN(string p_Msg, string p_Caption = "")
        {
            DialogResult result = MessageBox.Show(p_Msg, p_Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result;
        }

        public static DialogResult Info(string p_Msg, string p_Caption = "Information")
        {
            DialogResult result = MessageBox.Show(p_Msg, p_Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return result;
        }

        public static DialogResult dBErr(string p_Msg, string p_Caption = "Database Error")
        {
            DialogResult result = MessageBox.Show(p_Msg, p_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return result;
        }

    }

    public static class xlFunc
    {
        public static void xlClose(ref XL.Application p_App, ref XL._Workbook p_WB, ref XL._Worksheet p_WS, ref XL.Range p_Rng)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            p_WB.Close();
            p_App.Quit();

            // release COM objects
            Marshal.ReleaseComObject(p_Rng);
            Marshal.ReleaseComObject(p_WS);
            Marshal.ReleaseComObject(p_WB);
            Marshal.ReleaseComObject(p_App);
        }
    }

    public static class xlDB
    {
        
    }

    public class PartInfo
    {
        public string PartNum = "";
        public string PartDesc = "";
        public string Mfr = "";
        public string MfrNum = "";

        public PartInfo() { }

        public void Clear()
        {
            PartNum = "";
            PartDesc = "";
            Mfr = "";
            MfrNum = "";
        }
    }

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

    public static class NumFunc
    {

        public static byte Hex2Byte(string p_CellVal)
        {
            byte RetVal = 0;

            try
            {
                // Check and see if the value is actually a hex value
                if((p_CellVal.IndexOf('x') > 0) || (p_CellVal.IndexOf('X') > 0))
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

    }
}
