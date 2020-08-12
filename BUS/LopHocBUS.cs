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
    public class LopHocBUS
    {
        public static List<LopHocDTO> LayDSLop()
        {
            return LopHocDAO.LayDSLopHoc();
        }
        public static bool KTLopHoc(string maLop)
        {
            return LopHocDAO.KTLopTonTai(maLop);

            
        }
        public static bool ThemLop(LopHocDTO lh)
        {
            if (LopHocDAO.KTLopTonTai(lh.Ma_Lop))
            {
                return false;
            }
            else
            {
                return LopHocDAO.ThemLopHoc(lh);
            }
        }
        public static bool CapNhatLopHoc(LopHocDTO lh)
        {
            if (LopHocDAO.KTLopTonTai(lh.Ma_Lop))
            {
                return LopHocDAO.CapNhatLop(lh);
            }
            else
            {
                return false;
            }
        }
        public static DataTable LayDSLop(LopHocDTO lh)
        {
            
            return LopHocDAO.LayDSLopHoc(lh);

        }
        public static bool CapNhatSoLuongSinhVien(LopHocDTO lh)
        {
            if(LopHocDAO.KTLopTonTai(lh.Ma_Lop))
            {
                return LopHocDAO.CapNhatSinhVien(lh);
            }
            else
            {
                return false;
            }
        }
        public static bool XoaLopHoc(LopHocDTO lh)
        {
            if (!LopHocDAO.KTLopTonTai(lh.Ma_Lop))
            {
                return false;
            }
            else
            {
                return LopHocDAO.XoaLop(lh);
            }
        }
        public static bool CapNhatSoSinhVienKhiThem(LopHocDTO lh)
        {
            if (!LopHocDAO.KTLopTonTai(lh.Ma_Lop))
            {
                return false;
            }
            else
            {
                return LopHocDAO.CapNhatSoSinhVienKhiThem(lh);
            }
        }
        public static bool CapNhatSoSinhVienKhiXoa(LopHocDTO lh)
        {
            if (!LopHocDAO.KTLopTonTai(lh.Ma_Lop))
            {
                return false;
            }
            else
            {
                return LopHocDAO.CapNhatSoSinhVienKhiXoa(lh);
            }
        }

        public static bool CapNhatSoSinhVienKhiLamMoi(LopHocDTO lh)
        {
            if (!LopHocDAO.KTLopTonTai(lh.Ma_Lop))
            {
                return false;
            }
            else
            {
                return LopHocDAO.CapNhatSoSinhVienKhiLamMoi(lh);
            }
        }
    }
}
