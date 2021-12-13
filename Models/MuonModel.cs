using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MuonModel
    {
        public int MaMuonTra { get; set; }
        public int MaSach { get; set; }
        public int MaDocGia { get; set; }
        public int TienCoc { get; set; }
        public int SoLuong { get; set; }
        public DateTime? NgayMuon { get; set; }
        public DateTime? NgayTra { get; set; }

        public long? TrangThai { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string NhaXB { get; set; }
        public int NamXB { get; set; }
        public string TenDocGia { get; set; }
        public string SDT { get; set; }

    }
}
