using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Data
{
    public class QLNSContext : DbContext
    {
        public QLNSContext (DbContextOptions<QLNSContext> options)
            : base(options)
        {
        }

        public DbSet<QLNS.Models.ChamCong> ChamCong { get; set; }
        public DbSet<QLNS.Models.NhanVien> NhanVien { get; set; } = default!;
        public DbSet<QLNS.Models.ChucVu> ChucVu { get; set; }
        public DbSet<QLNS.Models.HopDongLaoDong> HopDongLaoDong { get; set; }
        public DbSet<QLNS.Models.LuongNhanVien> LuongNhanVien { get; set; }
        public DbSet<QLNS.Models.PhongBan> PhongBan { get; set; }
    }
}
