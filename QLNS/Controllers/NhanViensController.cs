using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;
using QLNS.ViewModels;

namespace QLNS.Controllers
{
    public class NhanViensController : Controller
    {
        private readonly QLNSContext _context;

        public NhanViensController(QLNSContext context)
        {
            _context = context;
        }

        // GET: NhanViens
        public async Task<IActionResult> Index()
        {
            var nhanVienDetailList = await _context.NhanVien
                .Select(nv => new NhanVienDetailViewModel
                {
                    NhanVien = nv,
                    HopDongLaoDong = _context.HopDongLaoDong.FirstOrDefault(hd => hd.MaNV == nv.MaNV),
                    PhongBan = _context.PhongBan.FirstOrDefault(pb => pb.MaPB == nv.MaPB),
                    ChucVu = _context.ChucVu.FirstOrDefault(cv => cv.MaChucVu == nv.MaChucVu),
                    Sogio = _context.ChamCong.Where(cc => cc.MaNV == nv.MaNV).Sum(cc => cc.SoGioLamViec)
                })
                .ToListAsync();

            foreach (var nhanVienDetail in nhanVienDetailList)
            {
                // Thực hiện quy ước mã chức vụ dựa trên nhanVienDetail.ChucVu.MaChucVu và lưu vào nhanVienDetail.TenQuyUocMaChucVu
                switch (nhanVienDetail.ChucVu.MaChucVu)
                {
                    case "CV1":
                        nhanVienDetail.TenQuyUocMaChucVu = "Trưởng phòng";
                        break;
                    case "CV2":
                        nhanVienDetail.TenQuyUocMaChucVu = "Phó phòng";
                        break;
                    case "CV3":
                        nhanVienDetail.TenQuyUocMaChucVu = "Nhân viên marketing";
                        break;
                    case "CV4":
                        nhanVienDetail.TenQuyUocMaChucVu = "Nhân viên giám sát";
                        break;
                    case "CV5":
                        nhanVienDetail.TenQuyUocMaChucVu = "Kế toán";
                        break;
                    case "CV6":
                        nhanVienDetail.TenQuyUocMaChucVu = "Dev";
                        break;
                    default:
                        nhanVienDetail.TenQuyUocMaChucVu = "Không xác định"; // Nếu không tìm thấy mã chức vụ trong quy ước
                        break;
                }
            }

            return View(nhanVienDetailList);
        }



        // GET: NhanViens/Details/5
        public async Task<IActionResult> Details(string id, string PB, string CV)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            var hopDongLaoDong = await _context.HopDongLaoDong
                .FirstOrDefaultAsync(h => h.MaNV == id);
            var phongBan = await _context.PhongBan
                .FirstOrDefaultAsync(h => h.MaPB == PB);
            var chucVu = await _context.ChucVu
                .FirstOrDefaultAsync(h => h.MaChucVu == CV);

            var viewModel = new NhanVienDetailViewModel
            {
                NhanVien = nhanVien,
                HopDongLaoDong = hopDongLaoDong,
                ChucVu = chucVu,
                PhongBan = phongBan

            };

            return View(viewModel);
        }


        // GET: NhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,TenNV,GioiTinh,NgaySinh,DiaChi,MaNganh,MaBac,HeSoLuong,PhuCap,MaChucVu,MaPB")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,TenNV,GioiTinh,NgaySinh,DiaChi,MaNganh,MaBac,HeSoLuong,PhuCap,MaChucVu,MaPB")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNV))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhanVien == null)
            {
                return Problem("Entity set 'QLNSContext.NhanVien'  is null.");
            }
            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(string id)
        {
          return (_context.NhanVien?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }
    }
}
