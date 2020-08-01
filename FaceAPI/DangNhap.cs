using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        protected static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenDN.Text;
            string matKhau = MD5Hash(txtMK.Text);


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

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}
