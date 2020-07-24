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
            sv.Ten_SV = dr["Ten_SV"].ToString();
            sv.Ma_SV = dr["Ma_SV"].ToString();
            sv.Ma_Lop = dr["Ma_Lop"].ToString();
            sv.SoNgayHoc = Convert.ToInt32(dr["SoNgayHoc"]);
            sv.SoNgayVang = Convert.ToInt32(dr["SoNgayVang"]);
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
                lstSinhVien.Add(ConvertToDTO(dr);
            }
            return lstSinhVien;
        }

    }
}
