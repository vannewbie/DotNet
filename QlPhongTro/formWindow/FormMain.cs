using QlPhongTro.formWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlPhongTro
{
    public partial class FormMain : Form
    {
        DatabaseConnect odb = new DatabaseConnect("DESKTOP-IV5V35S\\SQLEXPRESS01","phongtro1");
       
        formLoaiPhong f = null;
        FormKhachHang k = null;
        FormPhong p = null;
        public FormMain()
        {
            InitializeComponent();
        }
        private void Addform(Form f)
        {
            this.groupBox1.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.groupBox1.Controls.Add(f);
            f.Show();
        }

        private void loạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = new formLoaiPhong();
            Addform(f);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
             k = new FormKhachHang();
            Addform(k);
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p = new FormPhong();
            Addform(p);
        }
    }
}
