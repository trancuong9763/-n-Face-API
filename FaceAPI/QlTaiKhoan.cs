using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace FaceAPI
{
    public partial class QlTaiKhoan : Form
    {
        public QlTaiKhoan()
        {
            InitializeComponent();
            LayDSTaiKhoan();
            GiaoDienThem(true);
        }

        protected void LayDSTaiKhoan()
        {
           
            dgvTaiKhoan.DataSource = TaiKhoanBUS.LayDSTaiKhoan();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected void GiaoDienThem(bool gd)
        {
            txtTaiKhoan.Enabled = gd;
            btnThem.Enabled = gd;
            btnSua.Enabled = !gd;
            btnXoa.Enabled = !gd;
        }
        protected void XoaForm()
        {
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
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


        private void btnThem_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]");
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.Ten_QTV = txtTaiKhoan.Text.Trim();
            string mkMH = MD5Hash(txtMatKhau.Text.Trim());
            tk.Mat_Khau =  Convert.ToString(mkMH);


            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống");
            }
            else if (txtMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải tối thiểu 6 ký tự");
            }
            else if (r.IsMatch(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản không hợp lệ");
            }
            else
            {
                if (TaiKhoanBUS.ThemTK(tk))
                {
                    XoaForm();
                    LayDSTaiKhoan();
                    MessageBox.Show("Thêm thành công");
                    GiaoDienThem(true);
                }
                else
                {
                    MessageBox.Show("Thêm Thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc là muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo);

            TaiKhoanDTO tk = TaiKhoanBUS.LayThongTinTaiKhoan(txtTaiKhoan.Text);
            if (dialogResult == DialogResult.Yes)
            {
                if (txtTaiKhoan.Text == "admin")
                {
                    MessageBox.Show("Tài khoản này không thể xóa");
                }
                else if (TaiKhoanBUS.XoaTK(tk))
                {
                    XoaForm();
                    MessageBox.Show("Xóa Thành công");
                    LayDSTaiKhoan();
                    GiaoDienThem(true);
                }
                
                else
                {
                    MessageBox.Show("Xóa Thất bại");
                }
               
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }

        }

        

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
             if (e.RowIndex > -1 && e.ColumnIndex > -1 &&  dgvTaiKhoan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                
                    txtTaiKhoan.Enabled = false;
                    GiaoDienThem(false);
                    dgvTaiKhoan.CurrentRow.Selected = true;
                    txtTaiKhoan.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells["Ten_QTV"].FormattedValue.ToString();
                    txtMatKhau.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells["Mat_Khau"].FormattedValue.ToString();
                    txtMatKhau.Text = "";


            }
           

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = TaiKhoanBUS.LayThongTinTaiKhoan(txtTaiKhoan.Text);
            string mkMH = MD5Hash(txtMatKhau.Text.Trim());
            tk.Mat_Khau = Convert.ToString(mkMH);
            txtTaiKhoan.Enabled = false ;
            if (taiKhoan == txtTaiKhoan.Text)
            {
                btnSua.Enabled = true;
                if (TaiKhoanBUS.SuaTK(tk))
                {
                    XoaForm();
                    LayDSTaiKhoan();
                    GiaoDienThem(true);
                    MessageBox.Show("Thay đổi mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu thất bại");
                }

            }
            else
            {
                btnSua.Enabled = false;
                MessageBox.Show("Thay đổi mật khẩu thất bại");
            }
        }

       
        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
             if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                
            }

            else
            {
                e.Handled = false;
            }
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string taiKhoan = "";
        private void QlTaiKhoan_Load(object sender, EventArgs e)
        {
            taiKhoan = DangNhap.taiKhoan;

        }
    }
}
