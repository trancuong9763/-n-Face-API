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
    public class LopHocDAO
    {
        public static LopHocDTO ConvertToDTO(DataRow dr)
        {
            LopHocDTO lh = new LopHocDTO();
            lh.Ma_Lop = dr["Ma_Lop"].ToString();
            lh.SoSinhVien = Convert.ToInt32(dr["SoSinhVien"]);
            lh.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
            return lh;
        }
        public static List<LopHocDTO> LayDSLopHoc()
        {
            string query = " SELECT * FROM LopHoc";
            SqlParameter[] param = new SqlParameter[0];
            DataTable dtbKetQua = DataProvider.ExecuteSelectQuery(query, param);
            List<LopHocDTO> lstLopHoc = new List<LopHocDTO>();
            foreach (DataRow dr in dtbKetQua.Rows)
            {
                lstLopHoc.Add(ConvertToDTO(dr));
            }
            return lstLopHoc;
        }

        public static bool KTLopTonTai(string maLop)
        {
            string query = "SELECT COUNT(*) FROM LopHoc WHERE Ma_Lop = @MaLop";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MaLop", maLop);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, param).Rows[0][0]) == 1;
        }
        public static bool ThemLopHoc(LopHocDTO lh)
        {
            string query = "INSERT INTO LopHoc (Ma_Lop,SoSinhVien,TrangThai) VALUES (@Ma_Lop,@SoSinhVien,@TrangThai)";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Ma_Lop",lh.Ma_Lop);
            param[1] = new SqlParameter("@SoSinhVien", lh.SoSinhVien);
            param[2] = new SqlParameter("@TrangThai", lh.TrangThai);
            return DataProvider.ExecuteInsertQuery(query, param) == 1;
        }
        public static bool CapNhatLop(LopHocDTO lh)
        {
            string query = "UPDATE LopHoc SET TrangThai = @TrangThai WHERE Ma_Lop=@MaLop";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MaLop", lh.Ma_Lop);
            param[1] = new SqlParameter("@TrangThai", lh.TrangThai);
            return DataProvider.ExecuteUpdateQuery(query, param) == 1;

        }
        public static DataTable LayDSLopHoc(LopHocDTO lh)
        {
            string query = "SELECT Ma_Lop FROM LopHoc";
            SqlParameter[] param = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, param);
        }
        public static bool CapNhatSinhVien(LopHocDTO lh)
        {
            string query = "UPDATE LopHoc SET SoSinhVien = @SoSinhVien WHERE Ma_Lop=@MaLop";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MaLop", lh.Ma_Lop);
            param[1] = new SqlParameter("@SoSinhVien", lh.SoSinhVien);
            return DataProvider.ExecuteUpdateQuery(query, param) == 1;
        }
        public static bool XoaLop(LopHocDTO lh)
        {
            string query = "DELETE FROM LopHoc WHERE Ma_Lop=@Ma_Lop AND SoSinhVien = 0";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ma_Lop", lh.Ma_Lop);
            return DataProvider.ExecuteDeleteQuery(query, param) == 1;
        }
        public static bool CapNhatSoSinhVienKhiThem(LopHocDTO lh)
        {
            string query = "UPDATE LopHoc SET SoSinhVien = SoSinhVien + @SoSinhVien WHERE Ma_Lop = @Ma_Lop ";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Ma_Lop", lh.Ma_Lop);
            param[1] = new SqlParameter("@SoSinhVien", lh.SoSinhVien);
            return DataProvider.ExecuteUpdateQuery(query, param) == 1;
        }
        public static bool CapNhatSoSinhVienKhiXoa(LopHocDTO lh)
        {
            string query = "UPDATE LopHoc SET SoSinhVien = SoSinhVien - @SoSinhVien WHERE Ma_Lop = @Ma_Lop ";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Ma_Lop", lh.Ma_Lop);
            param[1] = new SqlParameter("@SoSinhVien", lh.SoSinhVien);
            return DataProvider.ExecuteUpdateQuery(query, param) == 1;
        }
        public static bool CapNhatSoSinhVienKhiLamMoi(LopHocDTO lh)
        {
            string query = "UPDATE LopHoc SET SoSinhVien = 0 WHERE Ma_Lop = @Ma_Lop ";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ma_Lop", lh.Ma_Lop);
            return DataProvider.ExecuteUpdateQuery(query, param) == 1;
        }
    } 
}
