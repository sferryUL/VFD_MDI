using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using GenFunc;

namespace dBFunc
{
    public static class dB
    {
        public static bool Open(ref SqlConnection p_Conn, string p_Srv, string p_dB, bool p_IntSec, string p_Usr = "user", string p_Pass = "pass")
        {
            bool stat = false;
            string IntSec;

            if(p_IntSec)
                IntSec = "True";
            else
                IntSec = "False";

            string conn_str = String.Format("Server = {0};Database = {1}; Integrated Security = {2};User ID = {3}; Password = {4}; ", p_Srv, p_dB, IntSec, p_Usr, p_Pass);
            p_Conn.ConnectionString = conn_str;
            
            try
            {
                p_Conn.Open();
            }
            catch(Exception ex)
            {
                MsgBox.dBErr("Error opening database!\n" + ex.Message);
            }

            if(p_Conn.State == ConnectionState.Open)
                stat = true;

            return stat;
        }

        public static void Close(ref SqlConnection p_Conn)
        {
            if(p_Conn.State == ConnectionState.Open)
                p_Conn.Close();
        }

        public static int Query(ref SqlConnection p_Conn, ref DataTable p_DT, string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
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

            return ExQuery(ref p_Conn, ref p_DT, sql);
        }

        public static int QueryNull(ref SqlConnection p_Conn, ref DataTable p_DT, int p_CmdType, string p_Tbl, string p_Cols, string p_CondItem = "", string p_OrderBy = "", bool p_Asc = true)
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

            return ExQuery(ref p_Conn, ref p_DT, sql);
        }

        public static int QueryLike(ref SqlConnection p_Conn, ref DataTable p_DT, string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
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

            return ExQuery(ref p_Conn, ref p_DT, sql);
        }

        public static int QueryDist(ref SqlConnection p_Conn, ref DataTable p_DT, string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
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

            return ExQuery(ref p_Conn, ref p_DT, sql);
        }

        public static bool Insert(ref SqlConnection p_Conn, string p_Tbl, string p_Cols, string p_Vals)
        {
            bool result = false; 

            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", p_Tbl, p_Cols, p_Vals);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            int cnt = cmd.ExecuteNonQuery();
            if(cnt > 0)
                result = true;

            return result;
        }

        public static bool Update(ref SqlConnection p_Conn, string p_Tbl, string p_Col, string p_Val, string p_CondItem, string p_Cond)
        {
            bool result = false;

            string sql = string.Format("UPDATE {0} SET {1} = {2} WHERE {3} = {4};", p_Tbl, p_Col, p_Val, p_CondItem, p_Cond);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            int cnt = cmd.ExecuteNonQuery();
            if(cnt > 0)
                result = true;

            return result;
        }

        public static bool Delete(ref SqlConnection p_Conn, string p_Tbl, string p_CondItem, string p_Cond)
        {
            bool result = false; 

            string sql = string.Format("DELETE FROM {0} WHERE {1} = {2};", p_Tbl, p_CondItem, p_Cond);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            int cnt = cmd.ExecuteNonQuery();
            if(cnt > 0)
                result = true;

            return result;
        }

        public static void TblClone(ref SqlConnection p_Conn, string p_TblTmplt, string p_TblNew)
        {
            string sql = string.Format("SELECT TOP 0 * INTO {0} FROM {1};", p_TblNew, p_TblTmplt);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            cmd.ExecuteNonQuery();
        }

        public static void TblDrop(ref SqlConnection p_Conn, string p_Tbl)
        {
            string sql = string.Format("DROP TABLE {0};", p_Tbl);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            cmd.ExecuteNonQuery();
        }

        public static void TblTrunc(ref SqlConnection p_Conn, string p_Tbl)
        {
            string sql = string.Format("TRUNCATE TABLE {0};", p_Tbl);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            cmd.ExecuteNonQuery();
        }

        public static void TblAlterColAdd(ref SqlConnection p_Conn, string p_Tbl, string p_ColName, string p_DataType)
        {
            string sql = string.Format("ALTER TABLE {0} ADD {1} {2}", p_Tbl, p_ColName, p_DataType);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            cmd.ExecuteNonQuery();
        }

        public static void TblAlterColDrop(ref SqlConnection p_Conn, string p_Tbl, string p_ColName)
        {
            string sql = string.Format("ALTER TABLE {0} DROP {1}", p_Tbl, p_ColName);
            SqlCommand cmd = new SqlCommand(sql, p_Conn);
            cmd.ExecuteNonQuery();
        }

        public static bool AlterTbl(ref SqlConnection p_Conn, int p_CmdType, string p_Tbl, string p_ColName, string p_DataType = "INT")
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

            if(ExecuteCmd(ref p_Conn, sql))
                result = true;

            AlterTblRes:
            return result;

        }

        public static bool Func(ref SqlConnection p_Conn, ref DataTable p_DT, string p_Func, string p_Tbl, string p_CondItem, string p_Cond, string p_Col = "IDX")
        {
            bool result = false;

            string sql = string.Format("SELECT {0} ({1}) FROM {2} WHERE {3} = {4}", p_Func, p_Col, p_Tbl, p_CondItem, p_Cond);

            SqlCommand cmd = new SqlCommand(sql, p_Conn);
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

            p_DT.Load(rdr);
            rdr.Close();
            result = true;

            QueryReturn:
            return result;

        }

        public static string StringConv(string p_Str)
        {
            return string.Format("'{0}'", p_Str);
        }

        private static bool ExecuteCmd(ref SqlConnection p_Conn, string p_SQL)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand(p_SQL, p_Conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MsgBox.dBErr("Error executing database command!\n" + ex.Message);
                goto CmdResult;
            }

            result = true;

            CmdResult:
            return result;
        }

        private static int ExQuery(ref SqlConnection p_Conn, ref DataTable p_DT, string p_SQL)
        {
            int row_cnt = -1;

            if(p_Conn.State != ConnectionState.Open)
                goto QueryReturn;

            SqlCommand cmd = new SqlCommand(p_SQL, p_Conn);
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

            p_DT.Load(rdr);
            rdr.Close();

            row_cnt = p_DT.Rows.Count;

            QueryReturn:
            return row_cnt;
        }
    }

    
}

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

        public int QueryLikeStr(string p_Tbl, string p_Cols, string p_CondItem = "", string p_Cond = "", string p_OrderBy = "", bool p_Asc = true)
        {
            string sql = String.Format("SELECT {0} FROM {1}", p_Cols, p_Tbl);

            if(p_CondItem != "")
                sql += String.Format(" WHERE {0} LIKE '%{1}%';", p_CondItem, p_Cond);

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

        public int QueryStr(string p_SQL)
        {
            return ExQuery(p_SQL);
        }

        private int ExQuery(string p_SQL)
        {
            int row_cnt = -1;

            if(Conn.State != ConnectionState.Open)
                goto QueryReturn;

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
    }
}

