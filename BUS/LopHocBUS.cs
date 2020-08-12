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
    }
}
