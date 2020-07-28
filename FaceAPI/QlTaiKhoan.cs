using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        static string EncodeMD5(string value)

        {

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.Ten_QTV = txtTaiKhoan.Text.Trim();
            
            tk.Mat_Khau = EncodeMD5(txtMatKhau.Text.Trim());
            

            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống");
            }
            else
            {
                if (TaiKhoanBUS.ThemTK(tk))
                {
                    XoaForm();
                    LayDSTaiKhoan();
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
                if (TaiKhoanBUS.XoaTK(tk))
                {
                    XoaForm();
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

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
                
               
            }
           

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = TaiKhoanBUS.LayThongTinTaiKhoan(txtTaiKhoan.Text);
            tk.Mat_Khau = txtMatKhau.Text;
            txtTaiKhoan.Enabled = false ;

            if (TaiKhoanBUS.SuaTK(tk))
            {
                XoaForm();
                LayDSTaiKhoan();
                GiaoDienThem(true);
            }
            else
            {
                MessageBox.Show("Sửa Thất bại");
            }
        }

        private void lblQLTK_Click(object sender, EventArgs e)
        {

        }

        
        
    }
}
