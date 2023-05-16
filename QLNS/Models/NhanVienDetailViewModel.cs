using QLNS.Models;

namespace QLNS.ViewModels
{
    public class NhanVienDetailViewModel
    {
        public NhanVien NhanVien { get; set; }
        public PhongBan PhongBan { get; set; }
        public ChucVu ChucVu { get; set; }
        public String TenQuyUocMaChucVu { get; set; }
        public String MaLuong { get; set; }
        public String MaNV { get; set; }
        public double LCBan { get; set; }
        public int Sogio { get; set; }
        public double LuongDuKien { get; set; }
        public HopDongLaoDong HopDongLaoDong { get; set; }
    }
}
