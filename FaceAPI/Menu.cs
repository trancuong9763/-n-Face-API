using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace FaceAPI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(4000);// đặt thời gian chạy xong
            t.Abort();
            
        }
        public void SplashStart()
        {
            
            Application.Run(new ManHinhKhoiDong());// gọi form Welcome 
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.ShowDialog();
            this.Show();
        }

        private void btnDSSV_Click(object sender, EventArgs e)
        {
            DanhSachSV m = new DanhSachSV();
            m.ShowDialog();
            this.Show();
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            qlLopHoc m = new qlLopHoc();
            m.ShowDialog();
            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
       
        //private void btnTaiKhoan_Click(object sender, EventArgs e)
        //{
        //    QlTaiKhoan m = new QlTaiKhoan();
        //    m.ShowDialog();
        //    this.Show();
        //}
        //string taiKhoan = "";
        //private void Menu_Load(object sender, EventArgs e)
        //{
        //    taiKhoan = DangNhap.taiKhoan;
        //    lblTenTK.Text = taiKhoan;
        //    if(lblTenTK.Text == "admin")
        //    {
        //        btnLopHoc.Enabled = true;
        //    }
        //    else
        //    {
        //        btnLopHoc.Enabled = false;
        //    }
        //}
    }
}
