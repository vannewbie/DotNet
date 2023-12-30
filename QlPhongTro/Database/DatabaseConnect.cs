using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlPhongTro
{   
    internal class DatabaseConnect
    {
        // thuoc tinh
        public SqlConnection conn;
        public SqlCommand cmd;
        string conntring;
        public DatabaseConnect()
        {
            // tuy cug co the co lenh mac dinh
        }
        public DatabaseConnect(String srname, String dabaseName, String user = "", String password = "")
        {
            conntring = "Data Source =" + srname + ";Initial Catalog = " + dabaseName + ";Integrated security = True";
            conn = new SqlConnection(conntring);
            conn.Open();

        }

        public DatabaseConnect(SqlConnection conn, SqlCommand cmd, string conntring)
        {
            this.conn = conn;
            this.cmd = cmd;
            this.conntring = conntring;
        }

        // phuong thuc ho tro kiem tra thanh cong
        public bool checkConnection()
        {
            if (conn.State != ConnectionState.Open)
            {
                return false;
            }
            return true;
        }
        // phuong thuc lay du lieu
        public DataTable GetTable(String tablename)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter("select * from " + tablename, this.conn);
            adt.Fill(dt);
            return dt;

        }
        public DataTable Getdata(String sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(sql, this.conn);
            adt.Fill(dt);
            return dt;

        }
        // phuong thuc cau lenh truy van insert, update,delte....
        public bool excuteSql(String sql)
        {
            cmd = new SqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            return false;
        }
        // phuong thuc thuc thi truy van qua thu tuc
        public bool excuteProcudure(String namePro, SqlParameter[] para)
        {
            cmd = new SqlCommand(namePro);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter param in para)
            {
                cmd.Parameters.AddWithValue(param.ParameterName,param.Value);
                cmd.Parameters[param.ParameterName].Direction = ParameterDirection.Input;
            }
            cmd.Connection = this.conn;
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
