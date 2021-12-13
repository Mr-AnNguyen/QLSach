using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SachModel
    {
        public string MaSach { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string NhaXB { get; set; }
        public int NamXB { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public DateTime? NgayNhap { get; set; }
        public long? TrangThai { get; set; }
    }
}
