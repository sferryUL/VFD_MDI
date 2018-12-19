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

    public static class CmbFunc
    {
        public static int FindIdxSubStr(ref ComboBox p_Cmb, string p_Str)
        {
            int ret_val = -1;

            if((p_Str != "") && (p_Str != null))
            {
                for(int i=0;i<p_Cmb.Items.Count;i++)
                {
                    string str_cmp = p_Cmb.Items[i].ToString();
                    if(str_cmp.Contains(p_Str))
                    {
                        ret_val = i;
                        break;
                    }
                }
            }

            return ret_val;
        }
        
    }

    public static class PartFunc
    {
        public static string Cnv2ULFrmt(string p_Num)
        {
            string ret_val = "";
            
            if(p_Num.Length == 6) // 5-digit part with leading 0, CP Part, or Raw Material
            {
                if(StrFunc.IsNumeric(p_Num))
                    ret_val = p_Num;
            }
            else if (p_Num.Length == 5) // 5-digit part with no leading 0
            {
                if(StrFunc.IsNumeric(p_Num))
                    ret_val = "0" + p_Num;
            }
            else if ((p_Num.ToUpper()).StartsWith("CP")) // CP text formatted part
            {
                p_Num = p_Num.Substring(2, p_Num.Length - 2);
                while(p_Num.IndexOf('-') >= 0)
                {
                    p_Num = p_Num.Remove(p_Num.IndexOf('-'), 1);
                }
                if(StrFunc.IsNumeric(p_Num) && (p_Num.Length == 6))
                {
                    ret_val = p_Num;
                }
            }
            else if((p_Num.ToUpper()).StartsWith("PROJECT")) // Project text formatted part
            {
                // Remove "Project" text
                int subtract = ("Project").Length;
                p_Num = p_Num.Substring(subtract, p_Num.Length - subtract);
                p_Num = p_Num.TrimStart();
                while(p_Num.IndexOf('-') >= 0)
                    p_Num = p_Num.Remove(p_Num.IndexOf('-'), 1);
                if(p_Num.Length == 7)
                {
                    if(StrFunc.IsNumeric(p_Num))
                        ret_val = String.Format("{0}-{1}", p_Num.Substring(0, 4), p_Num.Substring(4, 3));
                }
            }
            else if((p_Num.ToUpper()).StartsWith("PROJ")) // Project text formatted part
            {
                // Remove "Project" text
                int subtract = ("Proj").Length;
                p_Num = p_Num.Substring(subtract, p_Num.Length - subtract);
                p_Num = p_Num.TrimStart();
                while(p_Num.IndexOf('-') >= 0)
                    p_Num = p_Num.Remove(p_Num.IndexOf('-'), 1);
                if(p_Num.Length == 7)
                {
                    if(StrFunc.IsNumeric(p_Num))
                        ret_val = String.Format("{0}-{1}", p_Num.Substring(0, 4), p_Num.Substring(4, 3));
                }
            }
            else if(p_Num.Length == 7) // Project part with no "-"
            {
                // Project numbers are unofficial in regards to the Urschel Parts
                // management program. Project parts are 7 digits but we typically
                // format them as 8-digits with a dash. i.e. 1927-005
                if(StrFunc.IsNumeric(p_Num))
                    ret_val = String.Format("{0}-{1}", p_Num.Substring(0, 4), p_Num.Substring(4, 3));
            }
            else if(p_Num.Length == 8) // Project part with "-"
            {
                if(StrFunc.IsNumeric(p_Num.Substring(0,4))) // First for characters should be numbers
                {
                    if(p_Num.IndexOf('-') == 4) // a "-" should separate the first 4 digits from the last 3 digits
                    {
                        if(StrFunc.IsNumeric(p_Num.Substring(5, 3))) // The last 3 digits should be numbers as well
                            ret_val = p_Num;       
                    }
                }
            }
            
            return ret_val;
        }

        public static string CnvFromULFrmt(string p_Num)
        {
            string ret_val = "";

            if(p_Num.Length == 6) // CP Part or Raw Material
            {
                if(p_Num[0] == '0') // formatted with leading 0
                {
                    ret_val = p_Num.Substring(1, 5);
                }
                else if((p_Num[0] >= '1' && (p_Num[0] <= '4')) || (p_Num[0] == '8')) // CP part number
                {
                    ret_val = String.Format("CP{0}-{1}", p_Num.Substring(0, 4), p_Num.Substring(4, 2));
                }
                else
                    ret_val = p_Num;
            }
            else if(p_Num.Length == 5) // 5-digit part input as 5-digits
            {
                ret_val = p_Num;
            }
            else if(p_Num.Length == 8) // Project Part
            {
                if(StrFunc.IsNumeric(p_Num.Substring(0, 4))) // First for characters should be numbers
                {
                    if(p_Num.IndexOf('-') == 4) // a "-" should separate the first 4 digits from the last 3 digits
                    {
                        if(StrFunc.IsNumeric(p_Num.Substring(5, 3))) // The last 3 digits should be numbers as well
                            ret_val = String.Format("Project {0}-{1}", p_Num.Substring(0, 4), p_Num.Substring(5, 3));
                    }
                }
            }

            return ret_val;
        }
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

        

    } // class NumFunc

    public static class StrFunc
    {
        public static bool IsNumeric(string p_Str)
        {
            bool ret_val = true;

            foreach(Char c in p_Str.ToCharArray())
            {
                ret_val = ret_val && Char.IsNumber(c);
            }
            return ret_val;
        }

        public static bool NumCsv2List(string p_Str, ref List<String> p_List)
        {
            bool ret_val = false;
            int not_num = 0;
            
            p_List.Clear();
            if(p_Str != "")
            {
                Csv2List(p_Str, ref p_List);
                for(int i=0;i<p_List.Count;i++)
                {
                    if(!IsNumeric(p_List[i]))
                        not_num++;
                }

                if(not_num == 0)
                    ret_val = true;
                else
                    p_List.Clear();
            }
            return ret_val;
        }

        public static void Csv2List(string p_Str, ref List<String> p_List)
        {
            p_List.Clear();
            if(p_Str != "")
            {
                if(p_Str.IndexOf(',') < 0)
                {
                    p_List.Add(p_Str);
                }
                else
                {
                    while(p_Str.IndexOf(',') >= 0)
                    {
                        string str = p_Str.Substring(0, p_Str.IndexOf(','));
                        str = str.TrimEnd();
                        p_Str = p_Str.Remove(0, p_Str.IndexOf(',') + 1);
                        p_Str = p_Str.TrimStart();
                        if(str.Length > 0)
                        {
                            p_List.Add(str);
                        }
                    }
                    if(p_Str.Length > 0)
                        p_List.Add(p_Str.TrimEnd());
                }
            }
        }
    }
}
