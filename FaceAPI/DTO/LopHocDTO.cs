using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHocDTO
    {
        private string ma_Lop;
        private bool trangThai;
        private int soSinhVien;
        public string Ma_Lop { get => ma_Lop; set => ma_Lop = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public int SoSinhVien { get => soSinhVien; set => soSinhVien = value; }

        public LopHocDTO()
        {
            TrangThai = false;
        
        }
    }
   
}
