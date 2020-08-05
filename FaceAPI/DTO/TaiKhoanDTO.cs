using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        private String ten_GV;
        private String sDT;
        private String email;
        private String diaChi;
        public String Ten_QTV { get; set; }
        public String Mat_Khau { get; set; }
        public string Ten_GV { get => ten_GV; set => ten_GV = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
    }
}
