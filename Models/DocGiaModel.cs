﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DocGiaModel
    {
        public int MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string CCCD { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public long? TrangThai { get; set; }

    }
}
