using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLNS.Data;
using System;
using System.Linq;
namespace QLNS.Models;
public static class SeedData2
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new QLNSContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<QLNSContext>>()))
        {
            if (context.HopDongLaoDong.Any())
            {
                return;   // DB has been seeded
            }
            context.HopDongLaoDong.AddRange(
                new HopDongLaoDong
                {
                    MaHDLD = "HDT1",
                    MaNV = "NV0001",
                    LoaiHDLD = "Hợp đồng thời vụ",
                    ThoiHan = 3,
                    DiaDiemLamViec = "Chi nhánh 1",
                    MaLuong = "LB1",
                    PhuCap = 1000000,
                },
            new HopDongLaoDong
            {
                MaHDLD = "HDT2",
                MaNV = "NV0002",
                LoaiHDLD = "Hợp đồng thử việc",
                ThoiHan = 2,
                DiaDiemLamViec = "Chi nhánh 2",
                MaLuong = "LB2",
                PhuCap = 1200000,
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT3",
                MaNV = "NV0003",
                LoaiHDLD = "Hợp đồng hợp tác",
                ThoiHan = 8,
                DiaDiemLamViec = "Chi nhánh 2",
                MaLuong = "LB4",
                PhuCap = 1900000
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT4",
                MaNV = "NV0004",
                LoaiHDLD = "Hợp đồng xác định thời hạn",
                ThoiHan = 12,
                DiaDiemLamViec = "Chi nhánh 3",
                MaLuong = "LB3",
                PhuCap = 1500000
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT5",
                MaNV = "NV0005",
                LoaiHDLD = "Hợp đồng xác định thời hạn",
                ThoiHan = 12,
                DiaDiemLamViec = "Chi nhánh 2",
                MaLuong = "LB3",
                PhuCap = 1700000
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT6",
                MaNV = "NV0006",
                LoaiHDLD = "Hợp đồng học việc",
                ThoiHan = 6,
                DiaDiemLamViec = "Chi nhánh 1",
                MaLuong = "LB1",
                PhuCap = 1200000
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT7",
                MaNV = "NV0007",
                LoaiHDLD = "Hợp đồng thử việc",
                ThoiHan = 2,
                DiaDiemLamViec = "Chi nhánh 1",
                MaLuong = "LB1",
                PhuCap = 1000000
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT8",
                MaNV = "NV0008",
                LoaiHDLD = "Hợp đồng thời vụ",
                ThoiHan = 3,
                DiaDiemLamViec = "Chi nhánh 1",
                MaLuong = "LB3",
                PhuCap = 1500000
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT9",
                MaNV = "NV0009",
                LoaiHDLD = "Hợp đồng thời vụ",
                ThoiHan = 3,
                DiaDiemLamViec = "Chi nhánh 1",
                MaLuong = "LB3",
                PhuCap = 1500000
            },
            new HopDongLaoDong
            {
                MaHDLD = "HDT10",
                MaNV = "NV0010",
                LoaiHDLD = "Hợp đồng thời vụ",
                ThoiHan = 3,
                DiaDiemLamViec = "Chi nhánh 1",
                MaLuong = "LB3",
                PhuCap = 1500000
            }
            );
            if (context.ChamCong.Any())
            {
                return;   // DB has been seeded
            }
            context.ChamCong.AddRange(
                new ChamCong { MaCC = 331, MaNV = "NV0001", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 8 },
                new ChamCong { MaCC = 332, MaNV = "NV0002", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 7 },
                new ChamCong { MaCC = 333, MaNV = "NV0003", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 6 },
                new ChamCong { MaCC = 334, MaNV = "NV0004", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 8 },
                new ChamCong { MaCC = 335, MaNV = "NV0005", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 7 },
                new ChamCong { MaCC = 336, MaNV = "NV0006", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 6 },
                new ChamCong { MaCC = 337, MaNV = "NV0007", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 8 },
                new ChamCong { MaCC = 338, MaNV = "NV0008", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 7 },
                new ChamCong { MaCC = 339, MaNV = "NV0009", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 6 },
                new ChamCong { MaCC = 340, MaNV = "NV0010", NgayChamCong = new DateTime(2023, 5, 1), SoGioLamViec = 8 },
                new ChamCong { MaCC = 341, MaNV = "NV0001", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 7 },
                new ChamCong { MaCC = 342, MaNV = "NV0002", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 8 },
                new ChamCong { MaCC = 343, MaNV = "NV0003", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 8 },
                new ChamCong { MaCC = 344, MaNV = "NV0004", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 7 },
                new ChamCong { MaCC = 345, MaNV = "NV0005", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 6 },
                new ChamCong { MaCC = 346, MaNV = "NV0006", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 7 },
                new ChamCong { MaCC = 347, MaNV = "NV0007", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 8 },
                new ChamCong { MaCC = 348, MaNV = "NV0008", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 8 },
                new ChamCong { MaCC = 349, MaNV = "NV0009", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 8 },
                new ChamCong { MaCC = 350, MaNV = "NV0010", NgayChamCong = new DateTime(2023, 5, 2), SoGioLamViec = 8 },
                new ChamCong { MaCC = 351, MaNV = "NV0001", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 7 },
                new ChamCong { MaCC = 352, MaNV = "NV0002", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 8 },
                new ChamCong { MaCC = 353, MaNV = "NV0003", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 6 },
                new ChamCong { MaCC = 354, MaNV = "NV0004", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 8 },
                new ChamCong { MaCC = 355, MaNV = "NV0005", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 5 },
                new ChamCong { MaCC = 356, MaNV = "NV0006", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 8 },
                new ChamCong { MaCC = 357, MaNV = "NV0007", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 7 },
                new ChamCong { MaCC = 358, MaNV = "NV0008", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 8 },
                new ChamCong { MaCC = 359, MaNV = "NV0009", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 6 },
                new ChamCong { MaCC = 360, MaNV = "NV0010", NgayChamCong = new DateTime(2023, 5, 3), SoGioLamViec = 8 }
            );
            if (context.LuongNhanVien.Any())
            {
                return;   // DB has been seeded
            }
            context.LuongNhanVien.AddRange(
                new LuongNhanVien
                {
                    MaLuong = "LB1",
                    MaNV = "NV0001",
                    LCBan = 4500000
                },
    new LuongNhanVien
    {
        MaLuong = "LB4",
        MaNV = "NV0002",
        LCBan = 4500000
    },
    new LuongNhanVien
    {
        MaLuong = "LB2",
        MaNV = "NV0003",
        LCBan = 4500000
    },
    new LuongNhanVien
    {
        MaLuong = "LB3",
        MaNV = "NV0004",
        LCBan = 4500000
    },
    new LuongNhanVien
    {
        MaLuong = "LB5",
        MaNV = "NV0005",
        LCBan = 4500000
    },
    new LuongNhanVien
    {
        MaLuong = "LB6",
        MaNV = "NV0006",
        LCBan = 4500000
    },
    new LuongNhanVien
    {
        MaLuong = "LB7",
        MaNV = "NV0007",
        LCBan = 4500000
    },
    new LuongNhanVien
    {
        MaLuong = "LB8",
        MaNV = "NV0008",
        LCBan = 4500000
    },
    new LuongNhanVien
    {
        MaLuong = "LB9",
        MaNV = "NV0009",
        LCBan = 4500000
    },
     new LuongNhanVien
     {
         MaLuong = "LB10",
         MaNV = "NV0010",
         LCBan = 4500000
     });
            // Thêm dữ liệu cho bảng ChamCong
            context.SaveChanges();
        }
    }
}