using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;
        public static DangNhapDAO Instance
        {
            get { if (instance == null) instance = new DangNhapDAO(); return DangNhapDAO.instance; }
            private set { DangNhapDAO.instance = value; }
        }
        private DangNhapDAO() { }
        public bool dangNhap(string tenDN, string matKhau)
        {
            string query = "USP_QuanTriVien @tenQTV , @matKhau";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] { tenDN, matKhau });
            return result.Rows.Count>0;
        }
    }
}
