using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.Models
{
    public class HopDongLaoDong
    {
        [Key]
        public string MaHDLD { get; set; }
        public string MaNV { get; set; }
        [ForeignKey("MaNV")]

        public string LoaiHDLD { get; set; }
        public double ThoiHan { get; set; }
        public string DiaDiemLamViec { get; set; }  
        public string MaLuong { get; set; }
        public double PhuCap { get; set; }  
    }
}
