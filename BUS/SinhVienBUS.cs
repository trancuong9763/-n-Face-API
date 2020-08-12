﻿using System;
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
            if (SinhVienDAO.KTSVTonTai(sv.Ma_SV))
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
            if (SinhVienDAO.KTSVTonTai(sv.Ma_SV))
            {
                return false;
            }
            else
            {
                return SinhVienDAO.ThemSV(sv);
            }
        }
        public static SinhVienDTO LayThongTinSV(string maSV)
        {
            if (!SinhVienDAO.KTSVTonTai(maSV))
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
            if (SinhVienDAO.KTSVTonTai(maSV))
            {
                return SinhVienDAO.TimKiemMaSV(maSV);
            }
            else
            {
                return null;
            }
        }
        public static List<SinhVienDTO> LayDSSVLop(string maLop)
        {
            return SinhVienDAO.LayDSSVLop(maLop);
        }
        public static DataTable ChonLop(SinhVienDTO sv)
        {

            return SinhVienDAO.ChonLop(sv);

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
            if (!SinhVienDAO.KTSVTonTai(sv.Ma_SV))
            {
                return false;
            }
            else
            {
                return SinhVienDAO.XoaSV(sv);
            }
        }
        public static bool LamMoiDSSV(SinhVienDTO sv)
        {
            return SinhVienDAO.LamMoiDanhSach(sv);
        }
        public static bool CapNhatTrangThai(SinhVienDTO sv)
        {
            if (SinhVienDAO.KTSVTonTai(sv.Ma_SV))
            {
                return SinhVienDAO.LayTrangThai(sv);
            }
            else
            {
                return false;
            }
        }
        public static bool ThemSVExcel(SinhVienDTO sv)
        {
            if (SinhVienDAO.KTSVTonTai(sv.Ma_SV))
            {
                return false;
            }
            else
            {
                return SinhVienDAO.ThemSVExcel(sv);
            }
        }
        public static DataTable LayDSLopHoc(SinhVienDTO sv)
        {

            return SinhVienDAO.LayDSLopHoc(sv);

        }
        public static int DemSinhVien(SinhVienDTO sv)
        {
            return SinhVienDAO.DemSoSinhVien(sv.Ma_Lop);
        }
    }
}
