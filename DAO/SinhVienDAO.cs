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
    public class SinhVienDAO
    {
        public static SinhVienDTO ConvertToDTO(DataRow dr) {
            SinhVienDTO sv = new SinhVienDTO();
            sv.Ma_SV = dr["Ma_SV"].ToString();
            sv.Ten_SV = dr["Ten_SV"].ToString();            
            sv.Ma_Lop = dr["MaLop"].ToString();
            sv.SoNgayHoc = Convert.ToInt32(dr["SoNgayHoc"]);
            sv.SoNgayVang = Convert.ToInt32(dr["SoNgayVang"]);
            sv.TrangThai = Convert.ToBoolean(dr["TrangThai"]);

            return sv;
         }
        public static List<SinhVienDTO> LayDSSV()
        {
            string query = " SELECT * FROM ThongTinSV";
            SqlParameter[] param = new SqlParameter[0];
            DataTable dtbKetQua = DataProvider.ExecuteSelectQuery(query,param);
            List<SinhVienDTO> lstSinhVien = new List<SinhVienDTO>();
            foreach(DataRow dr in dtbKetQua.Rows)
            {
                lstSinhVien.Add(ConvertToDTO(dr));
            }
            return lstSinhVien;
        }
        
        public static bool KTTKTonTai(string maSV)
        {
            string query = "SELECT COUNT(*) FROM ThongTinSV WHERE Ma_SV = @Ma_SV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ma_SV", maSV);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 1;
        }
        public static bool ThemSV(SinhVienDTO sv)
        {
            string query = "INSERT INTO ThongTinSV (Ma_SV, Ten_SV,MaLop,SoNgayHoc,SoNgayVang,TrangThai) VALUES (@Ma_SV, @Ten_SV,@MaLop,@SoNgayHoc,@SoNgayVang,@TrangThai)";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Ma_SV", sv.Ma_SV);
            param[1] = new SqlParameter("@Ten_SV", sv.Ten_SV);
            param[2] = new SqlParameter("@MaLop", sv.Ma_Lop);
            param[3] = new SqlParameter("@SoNgayHoc", sv.SoNgayHoc);
            param[4] = new SqlParameter("@SoNgayVang", sv.SoNgayVang);
            param[5] = new SqlParameter("@TrangThai", sv.TrangThai);
            return DataProvider.ExecuteInsertQuery(query, param) == 1;
        }
        //public static bool SuaSV(SinhVienDTO sv)
        //{
        //    string query = "UPDATE ThongTinSV SET Ma_SV=@Ma_SV,Ten_SV=@Ten_SV,MaLop=@MaLop,SoNgayHoc=@SoNgayHoc,SoNgayVang=@SoNgayVang";
        //    SqlParameter[] param = new SqlParameter[5];
        //    param[0] = new SqlParameter("@Ma_SV", sv.Ma_SV);
        //    param[1] = new SqlParameter("@Ten_SV", sv.Ten_SV);
        //    param[2] = new SqlParameter("@MaLop", sv.Ma_Lop);
        //    param[3] = new SqlParameter("@SoNgayHoc", sv.SoNgayHoc);
        //    param[4] = new SqlParameter("@SoNgayVang", sv.SoNgayVang);
        //    return DataProvider.ExecuteUpdateQuery(query, param) == 1;
        //}
        public static SinhVienDTO LayThongTinSV(string maSV)
        {
            string query = "SELECT * FROM ThongTinSV WHERE Ma_SV = @Ma_SV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ma_SV", maSV);
            return ConvertToDTO(DataProvider.ExecuteSelectQuery(query, param).Rows[0]);
        }
        public static DataTable ChonLop(SinhVienDTO sv)
        {
            string query = "SELECT DISTINCT MaLop FROM ThongTinSV";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static List<SinhVienDTO> TimKiemMaSV(string maSV)
        {
            string query = "SELECT * FROM ThongTinSV WHERE Ma_SV = @Ma_SV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ma_SV", maSV);
            DataTable dtbKetQua = DataProvider.ExecuteSelectQuery(query, param);
            List<SinhVienDTO> lstSinhVien = new List<SinhVienDTO>();
            foreach (DataRow dr in dtbKetQua.Rows)
            {
                lstSinhVien.Add(ConvertToDTO(dr));
            }
            return lstSinhVien;
        }
        public static List<SinhVienDTO> LayDSLop(string maLop)
        {
            string query = "SELECT * FROM ThongTinSV WHERE MaLop=@MaLop";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaLop", maLop);
            DataTable dtbKetQua = DataProvider.ExecuteSelectQuery(query, param);
            List<SinhVienDTO> lstSinhVien = new List<SinhVienDTO>();
            foreach (DataRow dr in dtbKetQua.Rows)
            {
                lstSinhVien.Add(ConvertToDTO(dr));
            }
            return lstSinhVien;
        }
        public static SinhVienDTO LayThongTinLop(string maLop)
        {
            string query = "SELECT *  FROM ThongTinSV Where MaLop=@Malop";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaLop",maLop);
            return ConvertToDTO(DataProvider.ExecuteSelectQuery(query, param).Rows[0]);

        }
        public static bool UpdateChuyenCan(SinhVienDTO sv)
        {
            string query = "UPDATE ThongTinSV SET SoNgayHoc = SoNgayHoc + @SoNgayHoc,SoNgayVang = SoNgayVang + @SoNgayVang WHERE Ma_SV = @Ma_SV";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Ma_SV", sv.Ma_SV);
            param[1] = new SqlParameter("@SoNgayHoc", sv.SoNgayHoc);
            param[2] = new SqlParameter("@SoNgayVang", sv.SoNgayVang);
            return DataProvider.ExecuteUpdateQuery(query, param) == 1;
        }
        public static bool XoaSV(SinhVienDTO sv)
        {
            string query = "DELETE FROM ThongTinSV WHERE Ma_SV=@Ma_SV";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ma_SV", sv.Ma_SV);
            return DataProvider.ExecuteDeleteQuery(query, param) == 1;
        }
        public static bool LayTrangThai(SinhVienDTO sv)
        {
            string query = "UPDATE ThongTinSV SET TrangThai = 1 WHERE Ma_SV = @Ma_SV AND TrangThai = 0";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ma_SV", sv.Ma_SV);
            return DataProvider.ExecuteUpdateQuery(query, param) == 1;

        }
    }
}
