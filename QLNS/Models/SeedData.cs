using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLNS.Data;
using System;
using System.Linq;
namespace QLNS.Models;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new QLNSContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<QLNSContext>>()))
        {
            // Look for any movies.
            if (context.NhanVien.Any())
            {
                return;   // DB has been seeded
            }
            context.NhanVien.AddRange(
                new NhanVien
                {
                    MaNV = "NV0001",
                    MaHDLD = "HDT1",
                    TenNV = "Tran Thi B",
                    GioiTinh = "Nu",
                    NgaySinh = new System.DateTime(1998, 2, 2),
                    DiaChi = "Ho Chi Minh",
                    MaNganh = "Marketing",
                    MaBac = "Bac2",
                    HeSoLuong = 2.0,
                    PhuCap = 2000000,
                    MaChucVu = "CV2",
                    MaPB = "PB2"
                },
            new NhanVien
            {
                MaNV = "NV0002",
                MaHDLD = "HDT2",
                TenNV = "Nguyen Van A",
                GioiTinh = "Nam",
                NgaySinh = new System.DateTime(1995, 1, 1),
                DiaChi = "Ha Noi",
                MaNganh = "IT",
                MaBac = "Bac1",
                HeSoLuong = 1.5,
                PhuCap = 1000000,
                MaChucVu = "CV1",
                MaPB = "PB1"
            },
            new NhanVien
            {
                MaNV = "NV0003",
                MaHDLD = "HDT3",
                TenNV = "Tran Van D",
                GioiTinh = "Nam",
                NgaySinh = new System.DateTime(1993, 4, 15),
                DiaChi = "Da Nang",
                MaNganh = "Kinh doanh",
                MaBac = "Bac2",
                HeSoLuong = 2.5,
                PhuCap = 2500000,
                MaChucVu = "CV2",
                MaPB = "PB2"
            },
            new NhanVien
            {
                MaNV = "NV0004",
                MaHDLD = "HDT4",
                TenNV = "Nguyen Thi E",
                GioiTinh = "Nu",
                NgaySinh = new System.DateTime(1994, 3, 12),
                DiaChi = "Hai Phong",
                MaNganh = "IT",
                MaBac = "Bac1",
                HeSoLuong = 1.5,
                PhuCap = 1500000,
                MaChucVu = "CV1",
                MaPB = "PB1"
            },
            new NhanVien
            {
                MaNV = "NV0005",
                MaHDLD = "HDT5",
                TenNV = "Pham Van F",
                GioiTinh = "Nam",
                NgaySinh = new System.DateTime(1995, 2, 19),
                DiaChi = "Ha Noi",
                MaNganh = "Marketing",
                MaBac = "Bac2",
                HeSoLuong = 2.0,
                PhuCap = 2000000,
                MaChucVu = "CV2",
                MaPB = "PB3"
            },
            new NhanVien
            {
                MaNV = "NV0006",
                MaHDLD = "HDT6",
                TenNV = "Tran Thi G",
                GioiTinh = "Nu",
                NgaySinh = new System.DateTime(1996, 1, 25),
                DiaChi = "Ho Chi Minh",
                MaNganh = "Ke toan",
                MaBac = "Bac3",
                HeSoLuong = 3.0,
                PhuCap = 3000000,
                MaChucVu = "CV3",
                MaPB = "PB1"
            },
            new NhanVien
            {
                MaNV = "NV0007",
                MaHDLD = "HDT7",
                TenNV = "Le Van H",
                GioiTinh = "Nam",
                NgaySinh = new System.DateTime(1997, 2, 28),
                DiaChi = "Da Nang",
                MaNganh = "Kinh doanh",
                MaBac = "Bac2",
                HeSoLuong = 2.5,
                PhuCap = 2500000,
                MaChucVu = "CV2",
                MaPB = "PB2"
            },
            new NhanVien
            {
                MaNV = "NV0008",
                MaHDLD = "HDT8",
                TenNV = "Nguyen Van I",
                GioiTinh = "Nam",
                NgaySinh = new System.DateTime(1994, 5, 15),
                DiaChi = "Da Nang",
                MaNganh = "Sales",
                MaBac = "Bac2",
                HeSoLuong = 2.2,
                PhuCap = 2200000,
                MaChucVu = "CV2",
                MaPB = "PB3"
            },
            new NhanVien
            {
                MaNV = "NV0009",
                MaHDLD = "HDT9",
                TenNV = "Tran Van J",
                GioiTinh = "Nam",
                NgaySinh = new System.DateTime(1992, 9, 25),
                DiaChi = "Ha Noi",
                MaNganh = "IT",
                MaBac = "Bac3",
                HeSoLuong = 3.0,
                PhuCap = 3000000,
                MaChucVu = "CV3",
                MaPB = "PB1"
            },
            new NhanVien
            {
                MaNV = "NV0010",
                MaHDLD = "HDT10",
                TenNV = "Tran Thi O",
                GioiTinh = "Nu",
                NgaySinh = new System.DateTime(1999, 12, 3),
                DiaChi = "Can Tho",
                MaNganh = "Marketing",
                MaBac = "Bac1",
                HeSoLuong = 1.8,
                PhuCap = 1800000,
                MaChucVu = "CV1",
                MaPB = "PB2"
            }
            );

            
            if (context.PhongBan.Any())
            {
                return;   // DB has been seeded
            }
            context.PhongBan.AddRange(
                new PhongBan
                {
                    MaPB = "PB1",
                    TenPB = "Ban Giám Đốc",
                    DiaChi = "Công ty TNHH Vạn Phát chi nhánh 1"
                },
            new PhongBan
            {
                MaPB = "PB2",
                TenPB = "Ban Quản Lý",
                DiaChi = "Công ty TNHH Vạn Phát chi nhánh 2"
            },
            new PhongBan
            {
                MaPB = "PB3",
                TenPB = "Phòng Marketing",
                DiaChi = "Công ty TNHH Vạn Phát chi nhánh 2"
            }
            );
            
            
            if (context.ChucVu.Any())
            {
                return;   // DB has been seeded
            }
            context.ChucVu.AddRange(
                new ChucVu
                {
                    MaChucVu = "CV1",
                    TenChucVu = "Trưởng phòng"
                },
            new ChucVu
            {
                MaChucVu = "CV2",
                TenChucVu = "Phó phòng"
            },
            new ChucVu
            {
                MaChucVu = "CV3",
                TenChucVu = "Nhân viên marketing"
            },
            new ChucVu
            {
                MaChucVu = "CV4",
                TenChucVu = "Nhân viên giám sát"
            },
            new ChucVu
            {
                MaChucVu = "CV5",
                TenChucVu = "Kế toán"
            },
            new ChucVu
            {
                MaChucVu = "CV6",
                TenChucVu = "Dev"
            }
            );
            
            // Thêm dữ liệu cho bảng ChamCong
            context.SaveChanges();
        }
    }
}










