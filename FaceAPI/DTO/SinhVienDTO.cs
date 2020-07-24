using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVienDTO
    {
        private String ma_SV;
        private String ten_SV;
        private String ma_Lop;
        private int soNgayHoc;
        private int soNgayVang;

        public string Ma_SV { get => Ma_SV; set => Ma_SV = value; }
        public string Ten_SV { get => Ten_SV; set => Ten_SV = value; }
        public string Ma_Lop { get => Ma_Lop; set => Ma_Lop = value; }
        public int SoNgayHoc { get => SoNgayHoc; set => SoNgayHoc = value; }
        public int SoNgayVang { get => SoNgayVang; set => SoNgayVang = value; }
    }
}
