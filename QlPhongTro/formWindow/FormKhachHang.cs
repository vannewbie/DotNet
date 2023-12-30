using QlPhongTro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlPhongTro.formWindow
{
    public partial class FormKhachHang : Form
    {
        DataTable dt = null;
        KhachHangDatabase khdb = null;
        private int idKh = 0;
        private int xacnhan = 0;

        public FormKhachHang()
        {
            InitializeComponent();
        }
        private void LoadDsKhachHang()
        {
            // day du lieu len bang
            khdb = new KhachHangDatabase("DESKTOP-IV5V35S\\SQLEXPRESS01","QuanLyPhongTro");
            dt = khdb.getTable();
            KhachHangdgv.DataSource = dt;
            
            
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadDsKhachHang();
            this.button4.Enabled = false;
            
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.comboBox1.Enabled = false;
        }
        private void ThemKhachHang(string name,string cmnd,string sdt,string quequan,string gioitinh)
        {
            KhachHang kh = new KhachHang(name, cmnd, sdt, quequan, gioitinh);
            if (khdb.Add(kh))
            {
                MessageBox.Show("Them thanh cong");
                LoadDsKhachHang();
            }
            else
            {
                MessageBox.Show("Them that bai");
            }

        }
        private void SuaKhachHang(int id,string name, string cmnd, string sdt, string quequan, string gioitinh)
        {
            KhachHang kh = new KhachHang(id,name, cmnd, sdt, quequan, gioitinh);
            if (khdb.Sua(kh))
            {
                MessageBox.Show("Sua thanh cong");
                LoadDsKhachHang();
              
            }
            else
            {
                MessageBox.Show("Sua that bai");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            xacnhan = 1;
            this.button4.Enabled = true;
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.comboBox1.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            xacnhan = 2;
           
            this.button4.Enabled = true;
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.comboBox1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(xacnhan == 1)
            {
                if (string.IsNullOrEmpty(this.textBox1.Text) && string.IsNullOrEmpty(this.textBox2.Text)
                    && string.IsNullOrEmpty(this.textBox3.Text)
                    && string.IsNullOrEmpty(this.textBox4.Text)
                    && string.IsNullOrEmpty(this.comboBox1.Text))
                {
                    MessageBox.Show("Nhập đầy đủ thông tin!!");
                    return;
                }
                string name = this.textBox1.Text;
                string cmnd = this.textBox2.Text;
                string sdt = this.textBox3.Text;
                string quequan = this.textBox4.Text;
                string gioitinh = this.comboBox1.Text;
                ThemKhachHang(name,cmnd,sdt,quequan,gioitinh);
                this.button4.Enabled = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.comboBox1.Text = "";
               

                this.textBox1.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.comboBox1.Enabled = false;


            }
            if(xacnhan == 2)
            {
                if(idKh == 0)
                {
                    MessageBox.Show("Chon khach hang can cap nhat thong tin");
                    return;
                }
                string name = this.textBox1.Text;
                string cmnd = this.textBox2.Text;
                string sdt = this.textBox3.Text;
                string quequan = this.textBox4.Text;
                string gioitinh = this.comboBox1.Text;
                SuaKhachHang(idKh, name, cmnd, sdt, quequan, gioitinh);
                this.button4.Enabled = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.comboBox1.Text = "";


                this.textBox1.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
                this.textBox4.ReadOnly = true;
                this.comboBox1.Enabled = false;


            }
            
        }

        private void KhachHangdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idKh = int.Parse(KhachHangdgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.textBox1.Text = KhachHangdgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.textBox2.Text = KhachHangdgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.textBox3.Text = KhachHangdgv.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.textBox4.Text = KhachHangdgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.comboBox1.Text = KhachHangdgv.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac muon xoa khach hang nay khong ?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string name = "XoaKhachHang";
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@id", SqlDbType.Int);
                parameter[0].Value = idKh;
                if (khdb.oDB.excuteProcudure("XoaKhachHang",parameter))
                {
                    MessageBox.Show("Xoa thanh cong");
                    LoadDsKhachHang();
                }
                else
                {
                    MessageBox.Show("That bai");
                }
            }
        }
        private void timkiem(int id)
        {
          
          
            
            dt = khdb.selectByid(id);
            KhachHangdgv.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            idKh = int.Parse(this.textBox5.Text);
            timkiem(idKh);
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.comboBox1.Text = "";
            LoadDsKhachHang();
           
        }
    }
}
