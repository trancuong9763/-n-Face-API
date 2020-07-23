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
using BUS;
namespace FaceAPI
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            
            InitializeComponent();
        }
        public static string taiKhoan = "";
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenDN.Text;
            string matKhau = txtMK.Text;
            if(TaiKhoanBUS.KTDangNhap(tenTK, matKhau))
            {
                taiKhoan = tenTK;
                Menu m = new Menu();
                this.Hide();
                m.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }

        }

        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
