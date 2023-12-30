using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QlPhongTro.Model
{
    internal class KhachHang
    {
        private int id = 0;
        
        private string name;
        private string CMND;
        private string sdt;
        private string quequan;
        private string GioiTinh;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string CMND1 { get => CMND; set => CMND = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Quequan { get => quequan; set => quequan = value; }
        public string GioiTinh1 { get => GioiTinh; set => GioiTinh = value; }

        public KhachHang (string name,string CMND,string sdt,string quequan,string gioitinh)
        {
            this.Name = name;
            this.CMND1 = CMND;
            this.Sdt = sdt;
            this.Quequan = quequan;
            this.GioiTinh1 = gioitinh;
        }
        public KhachHang(int id,string name, string CMND, string sdt, string quequan, string gioitinh)
        {
            this.Name = name;
            this.CMND1 = CMND;
            this.Sdt = sdt;
            this.Quequan = quequan;
            this.GioiTinh1 = gioitinh;
            this.id = id;
        }
        public KhachHang()
        {

        }

      
    }
}
