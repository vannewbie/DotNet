using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlPhongTro.formWindow
{
    public partial class formLoaiPhong : Form
    {
        DatabaseConnect odb = new DatabaseConnect("DESKTOP-IV5V35S\\SQLEXPRESS01", "QuanLyPhongTro");
        DataTable dt = null;
        formLoaiPhong f = null;
        private int maLoaiPhong=0;
        private int xacnhan = 0;
        public formLoaiPhong()
        {
            InitializeComponent();
            LoadDsLoaiPhong();

        }   
        private void LoadDsLoaiPhong()
        {
            dt = odb.GetTable("tbLoaiPhong");
            this.LoaiPhongGridview.DataSource = dt;
            this.LoaiPhongGridview.Columns[0].Width = 100;
            this.LoaiPhongGridview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.LoaiPhongGridview.Columns[2].Width = 200;
            this.LoaiPhongGridview.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.LoaiPhongGridview.Columns[0].HeaderText = "Mã loại";
            this.LoaiPhongGridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.LoaiPhongGridview.Columns[1].HeaderText = "Tên loại phòng";
            this.LoaiPhongGridview.Columns[2].HeaderText = "Đơn giá";

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        public void ThêmLoaiPhong(string tenloaiphong,int dongia)
        {
            // ham them loai phong
            string namepro = "ThemLoaiPhong";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@tenloaiphong", SqlDbType.VarChar, 20);
            parameter[0].Value = tenloaiphong;
            parameter[1] = new SqlParameter("@dongia", SqlDbType.Int);
            parameter[1].Value = dongia;
            if (odb.excuteProcudure(namepro, parameter))
            {
                MessageBox.Show("Them thanh cong!!!");
                LoadDsLoaiPhong();
            }
            else
            {
                MessageBox.Show("Khong the them");
            }
            

        }
        public void capnhatLoaiPhong(int maloaiphong, string tenloaiphong, int dongia)
        {
            // ham capnhatLoaiPhong
            string namepro = "CapNhatLoaiPhong";
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@id", SqlDbType.Int);
            parameter[0].Value = maloaiphong;
            parameter[1] = new SqlParameter("@tenloaiphong", SqlDbType.VarChar,20);
            parameter[1].Value = tenloaiphong;
            parameter[2] = new SqlParameter("@dongia", SqlDbType.Int);
            parameter[2].Value = dongia;
            if (odb.excuteProcudure(namepro, parameter))
            {
                MessageBox.Show("Cap nhat thanh cong");
                LoadDsLoaiPhong();
                this.textBox1.Text = "";
                this.textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Cap nhat that bai");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // thêm LoaiPhong
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.button4.Enabled = true;

            xacnhan = 1;
            
            
            
        }

        private void LoaiPhongGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (LoaiPhongGridview.Rows[e.RowIndex].Cells[0].Value.ToString() == "") return;
                maLoaiPhong = int.Parse(LoaiPhongGridview.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.textBox1.Text = LoaiPhongGridview.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.textBox2.Text = LoaiPhongGridview.Rows[e.RowIndex].Cells[2].Value.ToString();

                    }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
             // nut cap nhat
            xacnhan = 2;
            this.button4.Enabled = true;
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
        }

        private void formLoaiPhong_Load(object sender, EventArgs e)
        {
            this.button4.Enabled = false;

            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (xacnhan == 1)
            {
                if (string.IsNullOrEmpty(this.textBox1.Text))
                {
                    MessageBox.Show("Nhập tên loại phòng!!");
                    return;
                }
                string tenloaiPhong = this.textBox1.Text.Trim();
                var DonGia = Convert.ToInt32(this.textBox2.Text);
                if (DonGia < 500000)
                {
                    MessageBox.Show("Đơn giá tối thiểu phải từ 500000");
                    return;
                }
                string tenloaiphong = this.textBox1.Text.Trim();
                int dongia = Convert.ToInt32(this.textBox2.Text);
                ThêmLoaiPhong(tenloaiphong, dongia);
                this.button4.Enabled = false;

            }
            if (xacnhan == 2)
            {

                if (maLoaiPhong == 0)
                {
                    MessageBox.Show("Vui long chon loai phong can sua");
                }
                string tenloaiphong = this.textBox1.Text.Trim();
                int dongia = int.Parse(this.textBox2.Text);
                capnhatLoaiPhong(maLoaiPhong, tenloaiphong, dongia);
                this.button4.Enabled = false;
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            if(maLoaiPhong == 0)
            {
                MessageBox.Show("Vui long chon phong muon xoa");
                return;
            }
            else
            {
                 if(MessageBox.Show("Ban co chac muon xoa loai phong nay khong ?","Xac nhan xoa",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string name = "XoaLoaiPhong";
                    SqlParameter[] parameter = new SqlParameter[1];
                    parameter[0] = new SqlParameter("@id", SqlDbType.Int);
                    parameter[0].Value = maLoaiPhong;
                    if (odb.excuteProcudure(name, parameter))
                    {
                        MessageBox.Show("Xoa thanh cong");
                        LoadDsLoaiPhong();
                    }
                    else
                    {
                        MessageBox.Show("That bai");
                    }
                }
            }
        }
    }
    }

