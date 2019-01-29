using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using GenFunc;
using System.Windows.Forms;

namespace ULdB
{
    public class dBClient
    {
        private SqlConnection Conn;
        private DataTable DT;

        public dBClient()
        {
            Conn = new SqlConnection();
            DT =  new DataTable();
        }

        public ConnectionState State => Conn.State;
        public DataTable Table => DT;

        #region Database Connection Functions

        public bool Open(string p_Srv, string p_dB, bool p_IntSec, string p_Usr = "user", string p_Pass = "pass")
        {
            bool stat = false;
            string IntSec;

            if(p_IntSec)
                IntSec = "True";
            else
                IntSec = "False";

            string conn_str = String.Format("Server = {0};Database = {1}; Integrated Security = {2};User ID = {3}; Password = {4}; ", p_Srv, p_dB, IntSec, p_Usr, p_Pass);
            Conn.ConnectionString = conn_str;
            
            try
            {
                Conn.Open();
            }
            catch(Exception ex)
            {
                MsgBox.dBErr("Error opening database!\n" + ex.Message);
            }

            if(Conn.State == ConnectionState.Open)
                stat = true;

            return stat;
        }

        public void Close()
        {
            if(Conn.State == ConnectionState.Open)
                Conn.Close();
        }

        #endregion

        #region Non-query commands

        public bool Insert(string p_Tbl, string p_Cols, string p_Vals)
        {
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", p_Tbl, p_Cols, p_Vals);
            return ExCmd(sql);
        }

        public bool UpdSglColStr(string p_Tbl, string p_Col, string p_Val, string p_CondItem, string p_Cond)
        {
            p_Cond = string.Format("'{0}'", p_Cond);
            return UpdSglCol(p_Tbl, p_Col, p_Val, p_CondItem, p_Cond);
        }
        
        public bool UpdSglCol(string p_Tbl, string p_Col, string p_Val, string p_CondItem, string p_Cond)
        {
            string sql = string.Format("UPDATE {0} SET {1} = {2} WHERE {3} = {4};", p_Tbl, p_Col, p_Val, p_CondItem, p_Cond);
            return ExCmd(sql);
        }

        public bool UpdateStr(string p_Table, List<string> p_Cols, List<string> p_Vals, string p_CondItem, string p_Cond, CondCode p_OpCode = CondCode.Equal)
        {
            p_Cond = String.Format("'{0}'", p_Cond);
            return Update(p_Table, p_Cols, p_Vals, p_CondItem, p_Cond, p_OpCode);
        }
        public bool Update(string p_Table, List<string> p_Cols, List<string> p_Vals, string p_CondItem, string p_Cond, CondCode p_OpCode = CondCode.Equal)
        {
            // Need to make sure there are actually values present and that there are the
            // same number of columns and values, otherwise an exception will be thrown.
            if((p_Cols.Count != p_Vals.Count) || (p_Cols.Count == 0) || (p_Vals.Count == 0))
                return false;

            // Setup the initial start to the SQL Update string
            string sql = String.Format("UPDATE {0} SET ", p_Table);

            // Add in all the SQL update values to the string
            for(int i=0;i<p_Cols.Count;i++)
            {
                sql += String.Format("{0} = {1}, ", p_Cols[i], p_Vals[i]);
            }

            // We end up with an extra comma followed by a space at the end of the update 
            sql = sql.Substring(0, sql.Length - 2);

            // Add in the column to match based on the condition and the 
            // type of operation i.e. MTR_NUM = '13752';
            sql += String.Format(" WHERE {0} {1} {2};", p_CondItem, ConvCondCode(p_OpCode),p_Cond);

            return ExCmd(sql);
        }

        public bool DeleteStr(string p_Tbl, string p_CondItem, string p_Cond, string p_CondItem2 = "", string p_Cond2 = "")
        {
            if(p_Cond != "")
                p_Cond = string.Format("'{0}'", p_Cond);

            if(p_Cond2 != "")
                p_Cond2 = string.Format("'{0}'", p_Cond2);

            return Delete(p_Tbl, p_CondItem, p_Cond, p_CondItem2, p_Cond2);
        }

        public bool Delete(string p_Tbl, string p_CondItem, string p_Cond, string p_CondItem2 = "", string p_Cond2 = "")
        {
            string sql = string.Format("DELETE FROM {0} WHERE {1} ", p_Tbl, p_CondItem);

            if(p_Cond != "")
                sql += String.Format("= {0}", p_Cond);
            else
                sql += String.Format("{0} IS NULL", p_Cond);

            if(p_CondItem2 != "")
            {
                if(p_Cond2 != "")
                    sql += String.Format(" AND {0} = {1}", sql, p_CondItem2, p_Cond2);
                else
                    sql += String.Format(" AND {0} IS NULL", p_CondItem2);
            }

            sql += ";";

            return ExCmd(sql);
        }

        private bool ExCmd(string p_SQL)
        {
            bool result = false; 
            int cnt = -1;

            if(Conn.State != ConnectionState.Open)
            {
                MsgBox.dBErr("No active database connection!");
                goto ExCmdReturn;
            }

            SqlCommand cmd = new SqlCommand(p_SQL, Conn);
            
            try
            {
                cnt = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MsgBox.dBErr("Error updating database!\n" + ex.Message);
                goto ExCmdReturn;
            }

            if(cnt > 0)
                result = true;

            ExCmdReturn:
            return result;
        }

        #endregion

        #region Query Functions

        public int QueryStr(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true, string p_CondItem2 = "", string p_Cond2 = "")
        {
            if(p_Cond != "")
                p_Cond = string.Format("'{0}'", p_Cond);
            
            if(p_Cond2 != "")
                p_Cond2 = string.Format("'{0}'", p_Cond2);

            return Query(p_Tbl, p_Cols, p_CondItem, p_Cond, p_OrderBy, p_Asc, p_CondItem2, p_Cond2);
        }
        
        public int Query(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true, string p_CondItem2 = "", string p_Cond2 = "")
        {
            string sql = String.Format("SELECT {0} FROM {1}", p_Cols, p_Tbl);

            if(p_CondItem != "")
            {

                if(p_Cond != "")
                    sql += String.Format(" WHERE {0} = {1}", p_CondItem, p_Cond);
                else
                    sql += String.Format(" WHERE {0} IS NULL", p_CondItem, p_Cond);

                if(p_CondItem2 != "")
                {
                    if(p_Cond2 != "")
                        sql += String.Format(" AND {0} = {1}", p_CondItem2, p_Cond2);
                    else
                        sql += String.Format(" AND {0} IS NULL", p_CondItem2, p_Cond2);
                }
            }
            else

            if(p_OrderBy != "")
            {
                sql += String.Format(" ORDER BY {0}", p_OrderBy);
                if(p_Asc)
                    sql += String.Format(" ASC");
                else
                    sql += String.Format(" DESC");
            }

            sql += ";";
            return ExQuery(sql);
        }

        public int QueryLikeStr(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
        {
            string sql = String.Format("SELECT {0} FROM {1}", p_Cols, p_Tbl);

            if(p_CondItem != "")
                sql += String.Format(" WHERE {0} LIKE '%{1}%'", p_CondItem, p_Cond);

            if(p_OrderBy != "")
            {
                sql += String.Format(" ORDER BY {0}", p_OrderBy);
                if(p_Asc)
                    sql += String.Format(" ASC");
                else
                    sql += String.Format(" DESC");
            }

            sql += ";";

            return ExQuery(sql);
        }

        public int QueryLike(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
        {
            string sql = String.Format("SELECT {0} FROM {1}", p_Cols, p_Tbl);

            if(p_CondItem != "")
                sql += String.Format(" WHERE {0} LIKE %{1}%;", p_CondItem, p_Cond);

            if(p_OrderBy != "")
            {
                sql += String.Format(" ORDER BY {0}", p_OrderBy);
                if(p_Asc)
                    sql += String.Format(" ASC;");
                else
                    sql += String.Format(" DESC;");
            }

            return ExQuery(sql);
        }

        public int QueryNull(int p_CmdType, string p_Tbl, string p_Cols, string p_CondItem = "", string p_OrderBy = "", bool p_Asc = true)
        {
            string sql = String.Format("SELECT {0} FROM {1} WHERE {2} IS ", p_Cols, p_Tbl, p_CondItem);

            if(p_CmdType == 0)
                sql += "NOT ";

            sql += "NULL";

            if(p_OrderBy != "")
            {
                sql += String.Format(" ORDER BY {0}", p_OrderBy);
                if(p_Asc)
                    sql += String.Format(" ASC;");
                else
                    sql += String.Format(" DESC;");
            }

            return ExQuery(sql);
        }

        public int QueryDistStr(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
        {
            p_Cond = string.Format("'{0}'", p_Cond);
            return QueryDist(p_Tbl, p_Cols, p_CondItem, p_Cond, p_OrderBy, p_Asc);
        }

        public int QueryDist(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
        {
            string sql = String.Format("SELECT DISTINCT {0} FROM {1}", p_Cols, p_Tbl);

            if(p_CondItem != "")
                sql += String.Format(" WHERE {0} = {1};", p_CondItem, p_Cond);

            if(p_OrderBy != "")
            {
                sql += String.Format(" ORDER BY {0}", p_OrderBy);
                if(p_Asc)
                    sql += String.Format(" ASC;");
                else
                    sql += String.Format(" DESC;");
            }

            return ExQuery(sql);
        }

        public int QuerySQL(string p_SQL)
        {
            return ExQuery(p_SQL);
        }

        private int ExQuery(string p_SQL)
        {
            int row_cnt = -1;

            if(Conn.State != ConnectionState.Open)
            {
                MsgBox.dBErr("No active database connection!");
                goto QueryReturn;
            }

            SqlCommand cmd = new SqlCommand(p_SQL, Conn);
            SqlDataReader rdr;

            try
            {
                rdr = cmd.ExecuteReader();
            }
            catch(Exception ex)
            {
                MsgBox.dBErr("Error executing database query!\n" + ex.Message);
                goto QueryReturn;
            }

            DT.Dispose();
            DT = new DataTable();
            DT.Load(rdr);
            rdr.Close();

            row_cnt = DT.Rows.Count;

            QueryReturn:
            return row_cnt;
        }
        #endregion

        #region Alter Table Commands

        public bool AlterTbl(int p_CmdType, string p_Tbl, string p_ColName, string p_DataType = "INT")
        {
            bool result = false;
            string alter_cmd = "";

            switch(p_CmdType)
            {
                case 0:
                    alter_cmd = "DROP COLUMN";
                    break;
                case 1:
                    alter_cmd = "ADD";
                    break;
                case 2:
                    alter_cmd = "ALTER COLUMN";
                    break;
                default:
                    goto AlterTblRes;
            }

            string sql = string.Format("ALTER TABLE {0} {1} {2}", p_Tbl, alter_cmd, p_ColName);

            if(p_CmdType > 0)
                sql += string.Format(" {0}", p_DataType);

            sql += ";";

            if(ExAlt(sql))
                result = true;

            AlterTblRes:
            return result;

        }

        private bool ExAlt(string p_SQL)
        {
            bool result = false;
            int cnt = -1;

            if(Conn.State != ConnectionState.Open)
            {
                MsgBox.dBErr("No active database connection!");
                goto ExAltReturn;
            }

            SqlCommand cmd = new SqlCommand(p_SQL, Conn);
            try
            {
               cnt = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MsgBox.dBErr("Error executing database command!\n" + ex.Message);
                goto ExAltReturn;
            }

            result = true;

            ExAltReturn:
            return result;
        }

        #endregion

        #region Query Function Commands

        public int FuncStr(string p_Func, string p_Tbl, string p_CondItem, string p_Cond, string p_Col = "IDX")
        {
            p_Cond = string.Format("'{0}'", p_Cond);
            return Func(p_Func, p_Tbl, p_CondItem, p_Cond, p_Col);
        }

        public int Func(string p_Func, string p_Tbl, string p_CondItem, string p_Cond, string p_Col = "IDX")
        {
            string sql = string.Format("SELECT {0} ({1}) FROM {2} WHERE {3} = {4}", p_Func, p_Col, p_Tbl, p_CondItem, p_Cond);
            return ExQuery(sql);
        }
        #endregion

        #region SQL String Manipulation Methods

        private int SplitItems(string p_Str, ref List<string> p_List)
        {
            while(p_Str.IndexOf(',') > 0)
            {
                p_List.Add(p_Str.Substring(0, p_Str.IndexOf(',')));
                p_Str = p_Str.Substring(p_Str.IndexOf(',') + 1, p_Str.Length - p_Str.IndexOf(',') - 1);
                p_Str = p_Str.TrimStart(' ');
            }
            p_List.Add(p_Str);

            return p_List.Count;
        }

        private string ConvCondCode(CondCode p_Code)
        {
            string ret_val = "";

            switch(p_Code)
            {
                case CondCode.Equal:
                    ret_val = "=";
                    break;
                case CondCode.NotEqual:
                    ret_val = "<>";
                    break;
                case CondCode.Grtr:
                    ret_val = ">";
                    break;
                case CondCode.Lsr:
                    ret_val = "<";
                    break;
                case CondCode.GrtrEql:
                    ret_val = ">=";
                    break;
                case CondCode.LsrEql:
                    ret_val = "<=";
                    break;
                case CondCode.Btwn:
                    ret_val = "";
                    break;
                case CondCode.Like:
                    ret_val = "LIKE";
                    break;
                case CondCode.In:
                    ret_val = "IN";
                    break;
                default:
                    
                    break;
            }

            return ret_val;
        }

        private string ConvOpCode(string p_Code)
        {
            string ret_val = "";

            switch(p_Code)
            {
                case "1":
                    ret_val = " OR ";
                    break;
                case "2":
                    ret_val = " NOT ";
                    break;
                case "0":
                default:
                    ret_val = " AND ";
                    break;
            }
            
            return ret_val;
        }
        #endregion

        #region Table Information Methods

        public int GetTblColInfo(string p_Tbl, ref List<dBColInfo> p_List)
        {
            int ret_val = -1;
            
            p_List.Clear();

            string sql = String.Format("SELECT COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", p_Tbl);
            if(QuerySQL(sql) >= 0)
            {
                foreach(DataRow dr in Table.Rows)
                {
                    string name = dr[0].ToString();
                    if(name != "IDX")
                    {
                        dBColInfo inf = new dBColInfo();
                        inf.Name = name;
                        if(dr[1].ToString() == "NO")
                            inf.Nullable = false;
                        inf.DataType = dr[2].ToString();
                        if(dr[3].ToString() != "")
                            inf.CharLen = Convert.ToInt32(dr[3].ToString());
                        p_List.Add(inf);
                    }
                }
                ret_val = p_List.Count;
            }

            return ret_val;
        }

        public int GetTblColInfo(string p_Tbl, ref dBColInfCollection p_Collection)
        {
            List<dBColInfo> inf = new List<dBColInfo>();

            int ret_val = GetTblColInfo(p_Tbl, ref inf);
            if(ret_val >= 0)
            {
                for(int i=0;i<inf.Count;i++)
                {
                    p_Collection.Add(inf[i]);
                }
            }

            return ret_val;
        }

        public bool VerChrtCol(string p_Tbl, string p_ChrtCol)
        {
            bool ret_val = false;

            dBColInfCollection col_inf = new dBColInfCollection();
            GetTblColInfo(p_Tbl, ref col_inf);

            int idx = col_inf.FindIndex(p_ChrtCol);
            if(idx >= 0)
                ret_val = true;

            return ret_val;
        }

        #endregion

    } // class dBClient

    public enum CondCode { Equal, NotEqual, Grtr, Lsr, GrtrEql, LsrEql, Btwn, Like, In }

    public class dBColInfo : ICloneable
    {
        public string   Name;
        public bool     Nullable;
        public string   DataType;
        public int      CharLen;
        
        public dBColInfo()
        {
            Name = "";
            Nullable = true;
            DataType = "";
            CharLen = -1;
        }

        public dBColInfo(string p_Name, bool p_Null, string p_Type, int p_Len)
        {
            Name = p_Name;
            Nullable = p_Null;
            DataType = p_Type;
            CharLen = p_Len;
        }

        public object Clone()
        {
            return new dBColInfo(this.Name, this.Nullable, this.DataType, this.CharLen);
        }
    }

    public class dBColInfCollection : InternalDataCollectionBase
    {
        List<dBColInfo> ColList;

        public dBColInfCollection ()
        {
            ColList = new List<dBColInfo>();
        }

        public dBColInfo this[int idx]
        {
            get => ColList[idx];
            set => ColList[idx] = value;
        }

        public void Add(dBColInfo p_Val) { ColList.Add(p_Val); }
        public void Clear() { ColList.Clear(); }
        public override int Count { get => ColList.Count(); }

        public int FindIndex(string p_Name)
        {
            int ret_val = -1;

            for(int i = 0; i < ColList.Count; i++)
            {
                if(ColList[i].Name.Equals(p_Name))
                {
                    ret_val = i;
                    break;
                }
            }
            return ret_val;
        }


    }
    
    public class dBColCtrlData
    {
        public dBColInfo ColInf;
        public Control Ctrl;
        public string Value;

        public dBColCtrlData() { }

        public dBColCtrlData(dBColInfo p_ColInf, Control p_Ctrl, string p_Val)
        {
            ColInf = (dBColInfo)p_ColInf.Clone();
            Ctrl = p_Ctrl;
            Value = p_Val;
        }

        public dBColCtrlData Copy()
        {
            return new dBColCtrlData(ColInf, Ctrl, Value);
        }

    }

    public class dBRowCtrlData : InternalDataCollectionBase
    {
        // Class Variables
        public List<dBColCtrlData> ColData;

        /*********** Class Constructors ***********/
        public dBRowCtrlData() { ColData = new List<dBColCtrlData>(); }

        /*********** Class Fields ***********/
        // Indexers
        // Indexer gets and sets the list ColData values as dBColCtrlData objects
        public dBColCtrlData this[int index]
        {
            get => ColData[index];
            set => ColData[index] = value;
        }

        // Assigns the actual control object to the dBColCtrlData object
        public Control this[string index]
        {
            get
            {
                int idx = FindIndex(index);
                return ColData[idx].Ctrl;
            }
            set
            {
                int idx = FindIndex(index);
                ColData[idx].Ctrl = value;
            }
        }

        // Collection Methods
        public void Add(dBColCtrlData p_Val) { ColData.Add(p_Val); }
        public void Clear() { ColData.Clear(); }
        public override int Count { get => ColData.Count(); }

        public void Trim(int p_StrtIdx)
        {
            int rng = ColData.Count - p_StrtIdx;
            if(rng > 0)
                ColData.RemoveRange(p_StrtIdx, rng);
        }

        // Search Methods
        public int FindIndex(string p_Name)
        {
            int ret_val = -1;

            for(int i = 0; i < ColData.Count; i++)
            {
                if(ColData[i].ColInf.Name.Equals(p_Name))
                {
                    ret_val = i;
                    break;
                }
            }
            return ret_val;
        }

        // Database assistance methods
        public void SetValues()
        {
            for(int i = 0; i < ColData.Count; i++)
            {
                if(ColData[i].Ctrl.Text != "")
                {
                    switch(ColData[i].ColInf.DataType)
                    {
                        case "nchar":
                        case "nvarchar":
                        case "varchar":
                        case "char":
                            ColData[i].Value = String.Format("'{0}'", ColData[i].Ctrl.Text);
                            break;
                        default:
                            ColData[i].Value = ColData[i].Ctrl.Text;
                            break;
                    }
                }
                else
                    ColData[i].Value = "NULL";
            }
        }

        public int GetdBInsStrs(ref string p_Cols, ref string p_Vals)
        {
            int cnt = 0;

            p_Cols = ""; p_Vals = "";

            for(int i = 0; i < ColData.Count; i++)
            {
                if(ColData[i].Value != null)
                {
                    p_Cols += String.Format("{0}, ", ColData[i].ColInf.Name);
                    p_Vals += String.Format("{0}, ", ColData[i].Value);
                    cnt++;
                }
            }

            if(cnt > 0)
            {
                p_Cols = p_Cols.Substring(0, p_Cols.Length - 2);
                p_Vals = p_Vals.Substring(0, p_Vals.Length - 2);
            }

            return cnt;
        }

        /// <summary>
        /// Extracts column and update values from the dBColCtrlData list for the class instantiation.
        /// </summary>
        /// <param name="p_Idx">List of integer index values to extract from the overall dBColCtrlData list</param>
        /// <param name="p_Cols">String List object to store the column names to be updated</param>
        /// <param name="p_Vals">String List object to store the update values matched with column names</param>
        /// <returns>
        /// integer value of the number of column and value pairs added to the Column and Value string lists
        /// </returns>
        public int GetdBUpdStrs(ref List<int> p_Idx, ref List<string> p_Cols, ref List<string> p_Vals)
        {
            int cnt = 0;

            p_Cols.Clear();
            p_Vals.Clear();

            for(int i = 0; i < p_Idx.Count; i++)
            {
                if(ColData[p_Idx[i]].Value != null)
                {
                    p_Cols.Add(ColData[p_Idx[i]].ColInf.Name);
                    p_Vals.Add(ColData[p_Idx[i]].Value);
                    cnt++;
                }
            }

            return cnt;
        }
    }

    
} // namespace ULdB

