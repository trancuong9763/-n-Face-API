using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        public static bool KTDangNhap(string tenTK, string mk)
        {
            if (!TaiKhoanDAO.KTTKTonTai(tenTK))
            {
                return false;
            }
            else
            {
                return mk == TaiKhoanDAO.LayMatKhau(tenTK);
            }
        }
        public static List<TaiKhoanDTO> LayDSTaiKhoan()
        {
            return TaiKhoanDAO.LayDSTaiKhoan();
        }
        public static bool ThemTK(TaiKhoanDTO tk)
        {
            if (TaiKhoanDAO.KTTKTonTai(tk.Ten_QTV))
                return false;
            else
            {
                return TaiKhoanDAO.ThemTK(tk);
            }
        }
        public static TaiKhoanDTO LayThongTinTaiKhoan(string tenTK)
        {
            if (!TaiKhoanDAO.KTTKTonTai(tenTK))
            {
                return null;
            }
            else
            {
                return TaiKhoanDAO.LayThongTinTaiKhoan(tenTK);
            }
        }
        public static bool SuaTK(TaiKhoanDTO tk)
        {
            if (!TaiKhoanDAO.KTTKTonTai(tk.Ten_QTV))
            {
                return false;
            }
            else
            {
                return TaiKhoanDAO.SuaTK(tk);
            }
        }
        public static bool XoaTK(TaiKhoanDTO tk)
        {
            if (!TaiKhoanDAO.KTTKTonTai(tk.Ten_QTV))
            {
                return false;
            }
            else
            {
                return TaiKhoanDAO.XoaTK(tk);
            }
        }
    }
}
