using QlPhongTro.Database;
using QlPhongTro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlPhongTro.formWindow
{
   

    public partial class FormXuly : Form
    {
        private string idphong;
        DatabaseConnect db;
        DataTable dt;
        PhongTroDatabase ph;
        
        public FormXuly(string idphong)
        {
            this.idphong = idphong;
            InitializeComponent();
        }

        private void FormXuly_Load(object sender, EventArgs e)
        {
            db = new DatabaseConnect("DESKTOP-IV5V35S\\SQLEXPRESS01", "QuanLyPhongTro");
            if (string.IsNullOrEmpty(idphong))
            {
                this.label1.Text = "Thêm phòng";
                
            }
            else { this.label1.Text = "Cập nhật phòng";
                
                var phong = db.Getdata("select * from tbPhongTro where ID = " + idphong).Rows[0];
            
              

                comboBox1.SelectedValue = phong["IDLoaiPhong"].ToString();
                this.textBox1.Text = phong["TenPhong"].ToString();
                this.textBox2.Text = phong["CoSoVatChat"].ToString();
                if (phong["TrangThai"].ToString() == "1")
                {
                    checkBox1.Checked = true;

                }
                else
                {
                    checkBox1.Checked = true;
                }

            }
           
            loadLoaiPhong(); // day du lieu len combobox
        }
        private void loadLoaiPhong()
        {
            dt =  db.GetTable("tbLoaiPhong");
            this.comboBox1.DataSource  = dt;
            this.comboBox1.DisplayMember = "TenLoaiPhong";
            this.comboBox1.ValueMember = "ID";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void themPhong(string tenphong, int trangthai,int idLoaiPhong,string cosovatchat)
        {
            ph = new PhongTroDatabase("DESKTOP-IV5V35S\\SQLEXPRESS01", "QuanLyPhongTro");
            PhongTro p = new PhongTro(tenphong, trangthai, idLoaiPhong,cosovatchat);
            if (ph.Add(p))
            {
                MessageBox.Show("Them thanh cong");

            }
            else
            {

                MessageBox.Show("Them that bại");
            }
        }
        private void capnhatPhong (int id,string tenphong,int trangthai,int idLoaiphong,string cosovatchat)
        {
            ph = new PhongTroDatabase("DESKTOP-IV5V35S\\SQLEXPRESS01", "QuanLyPhongTro");
            PhongTro p = new PhongTro(id,tenphong, trangthai, idLoaiphong, cosovatchat);
            if (ph.capnhat(p))
            {
                MessageBox.Show("sua thanh cong");

            }
            else
            {

                MessageBox.Show("Sua that bại");
            }
        }
       
        

        private void button5_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex < 0) {
                MessageBox.Show("Vui lòng chọn loại phòng!!!");
                return;
            }
            var idLoaiPhong = int.Parse(this.comboBox1.SelectedValue.ToString());
            var tenphong = this.textBox1.Text.Trim();
            var trangthai = this.checkBox1.Checked ? 1 : 0;
            string cosovatchat = this.textBox2.Text.Trim();
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!!!");
                return;
            }
            if (string.IsNullOrEmpty(idphong))  // them moi phong
            {
                themPhong(tenphong, trangthai, idLoaiPhong,cosovatchat);

            }
            else  // cap nhat phong
            {
                
                var idloaiphong = int.Parse(this.comboBox1.SelectedValue.ToString());
                var tenphongsua = this.textBox1.Text.Trim();
                var trangthaisua = this.checkBox1.Checked ? 1 : 0;
                string cosovatchatsua = this.textBox2.Text.Trim();
                capnhatPhong(int.Parse(idphong), tenphongsua, trangthaisua, idloaiphong, cosovatchatsua);
                
            }
        }

    }
    }

