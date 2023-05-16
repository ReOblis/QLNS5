using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNS.Models
{
    public class NhanVien
    {

        [Key]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        [DataType(DataType.Date)]
        public string MaHDLD { get; set; }
        [ForeignKey("MaHDLD")]
        public HopDongLaoDong HopDongLaoDong { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string MaNganh { get; set; }
        public string MaBac { get; set; }
        public double HeSoLuong { get; set; }
        public double PhuCap { get; set; }
        public string MaChucVu { get; set; }
        public string MaPB { get; set; }
    }
}


