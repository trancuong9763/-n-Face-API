using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TaiKhoanDAO
    {
        public static List<TaiKhoanDTO> LayDSTaiKhoan()
        {
            string query = "SELECT * FROM QuanTriVien";
            SqlParameter[] param = new SqlParameter[0];
            DataTable dtbTaiKhoan = DataProvider.ExecuteSelectQuery(query, param);
            List<TaiKhoanDTO> lstTaiKhoan = new List<TaiKhoanDTO>();
            foreach (DataRow dr in dtbTaiKhoan.Rows)
            {
                lstTaiKhoan.Add(ConvertToDTO(dr));
            }
            return lstTaiKhoan;
        }

        public static string LayMatKhau(string tenTK)
        {
            string query = "SELECT Mat_Khau FROM QuanTriVien WHERE Ten_QTV = @Ten_QTV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ten_QTV", tenTK);
            return DataProvider.ExecuteSelectQuery(query, param).Rows[0][0].ToString();
        }

        public static bool KTTKTonTai(string tenTK)
        {
            string query = "SELECT COUNT(*) FROM QuanTriVien WHERE Ten_QTV = @Ten_QTV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ten_QTV", tenTK);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 1;
        }
        public static TaiKhoanDTO ConvertToDTO(DataRow dr)
        {
            TaiKhoanDTO tk = new TaiKhoanDTO();
            tk.Ten_QTV = dr["Ten_QTV"].ToString();
            tk.Mat_Khau = dr["Mat_Khau"].ToString();
            tk.Ten_GV = dr["Ten_GV"].ToString();
            tk.SDT = dr["SDT"].ToString();
            tk.Email = dr["Email"].ToString();
            tk.DiaChi = dr["DiaChi"].ToString();

            return tk;
        }
        public static TaiKhoanDTO LayThongTinTaiKhoan(string tenTK)
        {
            string query = "SELECT * FROM QuanTriVien WHERE Ten_QTV = @Ten_QTV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ten_QTV", tenTK);
            return ConvertToDTO(DataProvider.ExecuteSelectQuery(query, param).Rows[0]);
        }   

        public static bool ThemTK(TaiKhoanDTO tk)
        {
            string query = "INSERT INTO QuanTriVien (Ten_QTV, Mat_Khau,Ten_GV,SDT,Email,DiaChi) VALUES (@Ten_QTV,@Mat_Khau,@Ten_GV,@SDT,@Email,@DiaChi)";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Ten_QTV", tk.Ten_QTV);
            param[1] = new SqlParameter("@Mat_Khau", tk.Mat_Khau);
            param[2] = new SqlParameter("@Ten_GV", tk.Ten_GV);
            param[3] = new SqlParameter("@SDT", tk.SDT);
            param[4] = new SqlParameter("@Email", tk.Email);
            param[5] = new SqlParameter("@DiaChi", tk.DiaChi);
            return DataProvider.ExecuteInsertQuery(query, param) == 1;
        }
        public static bool SuaTK(TaiKhoanDTO tk)
        {
            string query = "UPDATE QuanTriVien SET  Mat_Khau=@Mat_Khau,Ten_GV=@Ten_GV,SDT=@SDT,Email=@Email,DiaChi=@DiaChi WHERE Ten_QTV=@Ten_QTV";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Ten_QTV", tk.Ten_QTV);
            param[1] = new SqlParameter("@Mat_Khau", tk.Mat_Khau);
            param[2] = new SqlParameter("@Ten_GV", tk.Ten_GV);
            param[3] = new SqlParameter("@SDT", tk.SDT);
            param[4] = new SqlParameter("@Email", tk.Email);
            param[5] = new SqlParameter("@DiaChi", tk.DiaChi);

            return DataProvider.ExecuteUpdateQuery(query, param) == 1;
        }
        public static bool XoaTK(TaiKhoanDTO tk)
        {
            string query = "DELETE FROM QuanTriVien WHERE Ten_QTV=@Ten_QTV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ten_QTV", tk.Ten_QTV);
            return DataProvider.ExecuteDeleteQuery(query, param) == 1;
        }
        
    }
}
