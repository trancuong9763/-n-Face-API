using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
   public class DangNhapBUS
    {
        public static bool KTDangNhap(string tenDN, string matKhau)
        {
            if (!DangNhapDAO.KTTKTonTai(tenDN))
            {
                return false;
            }
            else
            {
                return matKhau == DangNhapDAO.LayMatKhau(tenDN);
            }
        }
    }
}
