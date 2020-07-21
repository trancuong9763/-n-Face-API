using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace FaceAPI
{
    public partial class DanhSachSV : Form
    {
        public DanhSachSV()
        {
            InitializeComponent();
            LoadDSSV();
        }
        void LoadDSSV()
        {
            string query = "Select *  from ThongTinSV";
            dgvDSSV.DataSource = DataProvider.Instance.ExecuteQuery(query);  
        }
    }
}
