using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class SinhVienBUS
    {
        public static bool CapNhatChuyenCan(SinhVienDTO sv)
        {
            if (SinhVienDAO.KTTKTonTai(sv.Ma_SV))
            {
                return SinhVienDAO.UpdateChuyenCan(sv);
            }
            else
            {
                return false;
            }
        }

        public static List<SinhVienDTO> LayDSSV()
        {
            return SinhVienDAO.LayDSSV();
        }

        public static bool ThemSV(SinhVienDTO sv)
        {
            if (SinhVienDAO.KTTKTonTai(sv.Ma_SV)) {
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
        public static List<SinhVienDTO> TimKiemMaSV(string maSV)
        {
            if (SinhVienDAO.KTTKTonTai(maSV))
            {
                return SinhVienDAO.TimKiemMaSV(maSV);
            }
            else
            {
                return null;
            }
        }
        public static List<SinhVienDTO> LayDSLop(string maLop)
        {
            return SinhVienDAO.LayDSLop(maLop);
        }
        public static DataTable ChonLop(SinhVienDTO sv)
        {

            return SinhVienDAO.ChonLop(sv);

        }
        public static SinhVienDTO LayThongTinLop(string maLop)
        {

            return SinhVienDAO.LayThongTinLop(maLop);

        }
        //public static bool SuaSV(SinhVienDTO sv)
        //{
        //    if (!SinhVienDAO.KTTKTonTai(sv.Ma_SV))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return SinhVienDAO.SuaSV(sv);
        //    }
        //}

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
        public static bool KiemTraTrangThai(SinhVienDTO sv)
        {
            if (SinhVienDAO.KTTKTonTai(sv.Ma_SV))
            {
                return SinhVienDAO.CapNhatTrangThai(sv);
            }
            else
            {
                return false;
            }
        }
    }
}
