using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QlPhongTro.Model
{
    internal class KhachHangDatabase
    {
        public DatabaseConnect oDB = null;
        DataTable dt = null;
        public KhachHangDatabase()
        {
            oDB = new DatabaseConnect("DESKTOP-IV5V35S\\SQLEXPRESS0", "QuanLyPhongTro");
        }
        public KhachHangDatabase(string sername, string dbname, string user = "", string pass = "")
        {
            oDB = new DatabaseConnect(sername, dbname);


        }
        public DataTable getTable()
        {
            dt = new DataTable();
            dt = oDB.GetTable("tbKhachHang");
            return dt;
        }
        public bool Add(KhachHang obj)
        {

            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@Ten", SqlDbType.VarChar, 20);
            para[0].Value = obj.Name;
            para[1] = new SqlParameter("@CCCD", SqlDbType.VarChar, 15);
            para[1].Value = obj.CMND1;
            para[2] = new SqlParameter("@SDT", SqlDbType.VarChar, 12);
            para[2].Value = obj.Sdt;
            para[3] = new SqlParameter("@QueQuan", SqlDbType.VarChar, 15);
            para[3].Value = obj.Quequan;
            para[4] = new SqlParameter("@gioitinh", SqlDbType.VarChar, 10);
            para[4].Value = obj.GioiTinh1;

            return oDB.excuteProcudure("ThemKhachHang", para);



        }
        public DataTable selectByid(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter("select * from " + "tbKhachHang" +" where ID = "+id,this.oDB.conn);
            adt.Fill(dt);
            return dt;

        }
        public bool Sua(KhachHang obj)
        {

            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@Id", SqlDbType.Int);
            para[0].Value = obj.Id;
            para[1] = new SqlParameter("@Ten", SqlDbType.VarChar, 20);
            para[1].Value = obj.Name;
            para[2] = new SqlParameter("@CCCD", SqlDbType.VarChar, 15);
            para[2].Value = obj.CMND1;
            para[3] = new SqlParameter("@SDT", SqlDbType.VarChar, 12);
            para[3].Value = obj.Sdt;
            para[4] = new SqlParameter("@QueQuan", SqlDbType.VarChar, 15);
            para[4].Value = obj.Quequan;
            para[5] = new SqlParameter("@gioitinh", SqlDbType.VarChar, 10);
            para[5].Value = obj.GioiTinh1;

            return oDB.excuteProcudure("CapNhatKhachHang", para);



        }
    }
}
