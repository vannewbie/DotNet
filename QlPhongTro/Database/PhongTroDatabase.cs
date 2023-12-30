using QlPhongTro.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlPhongTro.Database
{
    internal class PhongTroDatabase
    {
        public DatabaseConnect oDB = null;
        DataTable dt = null;
        public PhongTroDatabase()
        {
            oDB = new DatabaseConnect("DESKTOP-IV5V35S\\SQLEXPRESS0", "QuanLyPhongTro");
        }
        public PhongTroDatabase(string sername, string dbname, string user = "", string pass = "")
        {
            oDB = new DatabaseConnect(sername, dbname);


        }
        public DataTable loadDuLieu(String namepro,SqlParameter[] para)
        {
           
            oDB = new DatabaseConnect("DESKTOP-IV5V35S\\SQLEXPRESS01", "QuanLyPhongTro");
            oDB.cmd = new SqlCommand(namepro, oDB.conn);
            oDB.cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
                 foreach (SqlParameter param in para)
            {
                oDB.cmd.Parameters.Add(param);
            }
            dt = new DataTable();
            SqlDataAdapter ads = new SqlDataAdapter(oDB.cmd);
            ads.Fill(dt);


            return  dt;

        
        }
        
        public bool Add(PhongTro obj)
        {

            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@idLoaiPhong", SqlDbType.Int);
            para[0].Value = obj.IdLoaiPhong;
            para[1] = new SqlParameter("@tenphong", SqlDbType.VarChar,50);
            para[1].Value = obj.NameRoom;
            para[2] = new SqlParameter("@trangthai", SqlDbType.Int);
            para[2].Value = obj.Trangthai;
            para[3] = new SqlParameter("@cosovatchar", SqlDbType.NVarChar,50);
            para[3].Value = obj.Cosovatchat;


            return oDB.excuteProcudure("ThemPhong", para);



        }
        public bool capnhat(PhongTro obj)
        {

            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@id", SqlDbType.Int);
            para[0].Value = obj.Id;
            para[1] = new SqlParameter("@idLoaiPhong", SqlDbType.Int);
            para[1].Value = obj.IdLoaiPhong;
            para[2] = new SqlParameter("@tenphong", SqlDbType.VarChar, 50);
            para[2].Value = obj.NameRoom;
            para[3] = new SqlParameter("@trangthai", SqlDbType.Int);
            para[3].Value = obj.Trangthai;
            para[4] = new SqlParameter("@cosovatchat", SqlDbType.NVarChar, 50);
            para[4].Value = obj.Cosovatchat;

            return oDB.excuteProcudure("capnhatPhong", para);



        }
      


    }
}
