using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }
        protected void XoaForm()
        {
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.Ten_QTV = txtTaiKhoan.Text;
            tk.Mat_Khau = txtMatKhau.Text;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO tk = TaiKhoanBUS.LayThongTinTaiKhoan(txtTaiKhoan.Text);
            tk.Mat_Khau = txtMatKhau.Text;
            if (TaiKhoanBUS.XoaTK(tk))
            {
                XoaForm();
                LayDSTaiKhoan();
            }
            else
            {
                MessageBox.Show("Xóa Thất bại");
            }
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvTaiKhoan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
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
    }
}
