using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using GenFunc;

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

        public bool UpdateStr(string p_Tbl, string p_Col, string p_Val, string p_CondItem, string p_Cond)
        {
            p_Cond = string.Format("'{0}'", p_Cond);
            return Update(p_Tbl, p_Col, p_Val, p_CondItem, p_Cond);
        }
        
        public bool Update(string p_Tbl, string p_Col, string p_Val, string p_CondItem, string p_Cond)
        {
            string sql = string.Format("UPDATE {0} SET {1} = {2} WHERE {3} = {4};", p_Tbl, p_Col, p_Val, p_CondItem, p_Cond);
            return ExCmd(sql);
        }

        public bool DeleteStr(string p_Tbl, string p_CondItem, string p_Cond)
        {
            p_Cond = string.Format("'{0}'", p_Cond);
            return Delete(p_Tbl, p_CondItem, p_Cond);
        }

        public bool Delete(string p_Tbl, string p_CondItem, string p_Cond)
        {
            string sql = string.Format("DELETE FROM {0} WHERE {1} = {2};", p_Tbl, p_CondItem, p_Cond);
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

        public int QueryStr(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
        {
            p_Cond = string.Format("'{0}'", p_Cond);
            return Query(p_Tbl, p_Cols, p_CondItem, p_Cond, p_OrderBy, p_Asc);
        }
        
        public int Query(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
        {
            string sql = String.Format("SELECT {0} FROM {1}", p_Cols, p_Tbl);

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

        public int QueryStr1(string p_Tbl, string p_Cols, string p_CondItem = "", string p_CondVal = "", string p_CondCodes = "", string p_CondOps = "", string p_OrderBy = "", bool p_Asc = true)
        {
            int ret_val = -1;
            List<string> conds = new List<string>();
            List<string> cond_vals = new List<string>();
            List<string> cond_codes = new List<string>();
            List<string> cond_ops = new List<string>();

            SplitItems(p_CondItem, ref conds);
            SplitItems(p_CondVal, ref cond_vals);
            SplitItems(p_CondCodes, ref cond_codes);
            SplitItems(p_CondOps, ref cond_ops);

            if((conds.Count != cond_vals.Count) || (conds.Count != cond_codes.Count) || (conds.Count != (cond_ops.Count+1)))
            {
                goto QueryStr1Return;
            }

            string where = "";
            for(int i=0;i<conds.Count-1;i++)
            {
                where += conds[i] + ConvCondCode(cond_codes[i]) + cond_vals[i] + ConvOpCode(cond_ops[i]);
            }
            where += conds[conds.Count-1] + ConvCondCode(cond_codes[conds.Count - 1]) + cond_vals[conds.Count - 1];
            //return Query(p_Tbl, p_Cols, p_CondItem, p_Cond, p_OrderBy, p_Asc);

            //string sql = "";
            //ret_val = ExQuery(sql);

            QueryStr1Return:
            return ret_val;
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

        private string ConvCondCode(string p_Code)
        {
            string ret_val = "";

            switch(p_Code)
            {
                case "1":
                    ret_val = " LIKE ";
                    break;
                case "0":
                default:
                    ret_val = " = ";
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
    }
}

