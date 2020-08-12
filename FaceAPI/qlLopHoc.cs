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
    public partial class qlLopHoc : Form
    {
        int dem = 0;
        System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]");

        public qlLopHoc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LopHocDTO lh = new LopHocDTO();
            lh.Ma_Lop = txtLop.Text.ToUpper();
            if (dem == 1)
            {
                txtLop.Enabled = true;
                txtLop.Text = "";
                cbTrangThai.Checked = false;
                dem = 0;
            }
            else
            {
                if (cbTrangThai.Checked)
                {
                    lh.TrangThai = true;
                }
                else
                {
                    lh.TrangThai = false;
                }
                if (txtLop.Text == "" || r.IsMatch(txtLop.Text))
                {
                    MessageBox.Show("Bạn chưa nhập mã lớp hoặc mã lớp không hợp lệ");
                }
                else if (LopHocBUS.ThemLop(lh))
                {
                    MessageBox.Show("Thêm Lớp Mới Thành Công");
                    LoadDSLOP();
                }
                else
                {
                    MessageBox.Show("Thêm Lớp Mới Thất Bại");
                    txtLop.Text = "";
                }
            }
           
        }

        private void qlLopHoc_Load(object sender, EventArgs e)
        {
            LoadDSLOP();
            
        }
        public void LoadDSLOP()
        {
            dgvDSLOP.DataSource = LopHocBUS.LayDSLop();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LopHocDTO lh = new LopHocDTO();
            lh.Ma_Lop = txtLop.Text;
            if (cbTrangThai.Checked)
            {
                lh.TrangThai = true;
            }
            else
            {
                lh.TrangThai = false;
            }
            if (LopHocBUS.CapNhatLopHoc(lh))
            {
                MessageBox.Show("Sửa Lớp Thành Công");
                LoadDSLOP();
            }
            else
            {
                MessageBox.Show("Sửa Lớp Thất Bại");
                txtLop.Text = "";
            }
        }

        private void dgvDSLOP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1 && dgvDSLOP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                dgvDSLOP.CurrentRow.Selected = true;
                txtLop.Text = dgvDSLOP.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                cbTrangThai.Checked = Convert.ToBoolean(dgvDSLOP.Rows[e.RowIndex].Cells[1].FormattedValue);
               
            }
            txtLop.Enabled = false;
            dem = 1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            // ko cho phep nhap dau .
             if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') == -1))
            {
                e.Handled = true;
            }
            else if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {

            }

            else
            {
                e.Handled = false;
            }
        }
    }
}
