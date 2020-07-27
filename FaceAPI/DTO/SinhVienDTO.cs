using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVienDTO
    {
        private int sTT;
        private String ma_SV;
        private String ten_SV;
        private String ma_Lop;
        private int soNgayHoc;
        private int soNgayVang;

        public int STT { get => sTT; set => sTT = value; }
        public string Ma_SV { get => ma_SV; set => ma_SV = value; }
        public string Ten_SV { get => ten_SV; set => ten_SV = value; }
        public string Ma_Lop { get => ma_Lop; set => ma_Lop = value; }
        public int SoNgayHoc { get => soNgayHoc; set => soNgayHoc = value; }
        public int SoNgayVang { get => soNgayVang; set => soNgayVang = value; }
    }
}
