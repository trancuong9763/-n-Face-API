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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenDN.Text;
            string matKhau = txtMK.Text;
            if(TaiKhoanBUS.KTDangNhap(tenTK, matKhau))
            {
                Main m = new Main();
                this.Hide();
                m.ShowDialog();
                this.Show();
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
