using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class SinhVienBUS
    {
        public static List<SinhVienDTO> LayDSSV()
        {
            return SinhVienDAO.LayDSSV();
        }
        public static bool ThemSV(SinhVienDTO sv)
        {
            if (SinhVienDAO.KTTKTonTai(sv.Ma_SV)){
                return false;
            }
            else
            {
                return SinhVienDAO.ThemSV(sv);
            }
        }
        public static SinhVienDTO LayThongTinSV(string maSV)
        {
            if (!SinhVienDAO.KTTKTonTai(maSV))
            {
                return null;
            }
            else
            {
                return SinhVienDAO.LayThongTinSV(maSV);
            }
        }
        public static bool SuaSV(SinhVienDTO sv)
        {
            if (!SinhVienDAO.KTTKTonTai(sv.Ma_SV))
            {
                return false;
            }
            else
            {
                return SinhVienDAO.SuaSV(sv);
            }
        }

        public static bool XoaSV(SinhVienDTO sv)
        {
            if (!SinhVienDAO.KTTKTonTai(sv.Ma_SV))
            {
                return false;
            }
            else
            {
                return SinhVienDAO.XoaSV(sv);
            }
        }
    }
}
