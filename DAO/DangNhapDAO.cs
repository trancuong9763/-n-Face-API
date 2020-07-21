using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DangNhapDAO
    {
        public static string LayMatKhau(string tenDN)
        {
            string query = "SELECT Mat_Khau FROM QuanTriVien WHERE Ten_QTV = @Ten_QTV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ten_QTV", tenDN);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }

        public static bool KTTKTonTai(string tenDN)
        {
            string query = "SELECT COUNT(*) FROM QuanTriVien WHERE Ten_QTV = @Ten_QTV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ten_QTV", tenDN);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 1;
        }
        public static QuanTriVien ConvertToDTO(DataRow dr)
        {
            QuanTriVien tk = new QuanTriVien();
            tk.Ten_QTV = dr["Ten_QTV"].ToString();
            tk.Mat_Khau = dr["Mat_Khau"].ToString();
            return tk;
        }
    }
}
