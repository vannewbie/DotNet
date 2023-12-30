using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlPhongTro.Model
{
    internal class PhongTro
    {
        private int _id = 0;
        private string nameRoom;
        private int idLoaiPhong;
        private int trangthai;
        private string cosovatchat;
        public PhongTro( string nameRoom, int trangthai,int idLoaiPhong,string cosovatchat)
        {
            this.Id++;
            this.NameRoom = nameRoom;
            this.Trangthai = trangthai;
            this.IdLoaiPhong = idLoaiPhong;
            this.Cosovatchat = cosovatchat;

        }
        public PhongTro(int id,string nameRoom, int trangthai, int idLoaiPhong, string cosovatchat)
        { 
            this.Id = id;
            this.NameRoom = nameRoom;
            this.Trangthai = trangthai;
            this.IdLoaiPhong = idLoaiPhong;
            this.Cosovatchat = cosovatchat;

        }

        public int Id { get => _id; set => _id = value; }
        public string NameRoom { get => nameRoom; set => nameRoom = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
        public int IdLoaiPhong { get => idLoaiPhong; set => idLoaiPhong = value; }
        public string Cosovatchat { get => cosovatchat; set => cosovatchat = value; }
    }
}
