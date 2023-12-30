using QlPhongTro.Database;
using QlPhongTro.Model;
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
    public partial class FormPhong : Form
    {
        PhongTroDatabase ph;
        private int idPhongcug;
        DataTable dt;
        private int index = -1;
      
        public FormPhong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormXuly(null).ShowDialog();
            LoadDsPhong();
        }
        private void LoadDsPhong()
        {
            ph = new PhongTroDatabase("DESKTOP-IV5V35S\\SQLEXPRESS01", "QuanLyPhongTro");
            var timkiem = this.textBox1.Text;

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@timkiem", SqlDbType.NVarChar,20);
            para[0].Value = timkiem;
            this.dataGridView1.DataSource = ph.loadDuLieu("LoadDsPhong", para);
            

        }
        private void FormPhong_Load(object sender, EventArgs e)
        {
            LoadDsPhong();
            this.dataGridView1.Columns["TenPhong"].HeaderText = "Tên Phòng";
            this.dataGridView1.Columns["TenLoaiPhong"].HeaderText = "Tên Loại Phòng";
            this.dataGridView1.Columns["DonGia"].HeaderText = "Đơn Giá";
            this.dataGridView1.Columns["CoSoVatChat"].HeaderText = "Cơ sở vật chất";
            this.dataGridView1.Columns["TrangThai"].HeaderText = "Trạng Thái";
            this.dataGridView1.Columns["TenPhong"].Width = 85;
            this.dataGridView1.Columns["CoSoVatChat"].Width = 85;
            this.dataGridView1.Columns["TenLoaiPhong"].Width = 85;
            this.dataGridView1.Columns["DonGia"].Width = 85;
            this.dataGridView1.Columns["TrangThai"].Width = 95;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idphong = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            new FormXuly(idphong).ShowDialog();
            LoadDsPhong();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            idPhongcug = int.Parse(dataGridView1.Rows[index].Cells["ID"].Value.ToString());
            
        }
        private void XoaMemPhong(int id)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (index < 0)
            {
                MessageBox.Show("Vui long chọn phòng muốn xoá");
                return;
            }
            if(MessageBox.Show("Ban co chac muon xoa "+dataGridView1.Rows[index].Cells["TenPhong"].Value.ToString()+" nay khong ?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ph = new PhongTroDatabase("DESKTOP-IV5V35S\\SQLEXPRESS01", "QuanLyPhongTro");
                

                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id", SqlDbType.Int);
                para[0].Value = idPhongcug;
                if(ph.oDB.excuteProcudure("XoaMemPhong", para))
                {
                    MessageBox.Show("Xoa Thanh Cong");
                    LoadDsPhong();
                }
                
            }
        }
    }
}
