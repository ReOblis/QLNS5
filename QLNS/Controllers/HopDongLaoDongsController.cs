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
    public class HopDongLaoDongsController : Controller
    {
        private readonly QLNSContext _context;

        public HopDongLaoDongsController(QLNSContext context)
        {
            _context = context;
        }

        // GET: HopDongLaoDongs
        public async Task<IActionResult> Index()
        {
            var nhanVienDetailList = await _context.HopDongLaoDong
                .Select(nv => new NhanVienDetailViewModel
                {
                    HopDongLaoDong = nv,
                    NhanVien = _context.NhanVien.FirstOrDefault(n => n.MaHDLD == nv.MaHDLD),
                    PhongBan = _context.PhongBan.FirstOrDefault(pb => pb.MaPB == _context.NhanVien.FirstOrDefault(n => n.MaHDLD == nv.MaHDLD).MaPB),
                    ChucVu = _context.ChucVu.FirstOrDefault(cv => cv.MaChucVu == _context.NhanVien.FirstOrDefault(n => n.MaHDLD == nv.MaHDLD).MaChucVu),
                })
                .ToListAsync();

     
           
            return View(nhanVienDetailList);
        }

        // GET: HopDongLaoDongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HopDongLaoDong == null)
            {
                return NotFound();
            }

            var hopDongLaoDong = await _context.HopDongLaoDong
                .FirstOrDefaultAsync(m => m.MaHDLD == id);
            if (hopDongLaoDong == null)
            {
                return NotFound();
            }

            return View(hopDongLaoDong);
        }

        // GET: HopDongLaoDongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HopDongLaoDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHDLD,MaNV,LoaiHDLD,ThoiHan,DiaDiemLamViec,MaLuong,PhuCap,ChucVu")] HopDongLaoDong hopDongLaoDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopDongLaoDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopDongLaoDong);
        }

        // GET: HopDongLaoDongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HopDongLaoDong == null)
            {
                return NotFound();
            }

            var hopDongLaoDong = await _context.HopDongLaoDong.FindAsync(id);
            if (hopDongLaoDong == null)
            {
                return NotFound();
            }
            return View(hopDongLaoDong);
        }

        // POST: HopDongLaoDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHDLD,MaNV,LoaiHDLD,ThoiHan,DiaDiemLamViec,MaLuong,PhuCap,ChucVu")] HopDongLaoDong hopDongLaoDong)
        {
            if (id != hopDongLaoDong.MaHDLD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDongLaoDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongLaoDongExists(hopDongLaoDong.MaHDLD))
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
            return View(hopDongLaoDong);
        }

        // GET: HopDongLaoDongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HopDongLaoDong == null)
            {
                return NotFound();
            }

            var hopDongLaoDong = await _context.HopDongLaoDong
                .FirstOrDefaultAsync(m => m.MaHDLD == id);
            if (hopDongLaoDong == null)
            {
                return NotFound();
            }
            _context.HopDongLaoDong.Remove(hopDongLaoDong);

            return await Deletenv(hopDongLaoDong.MaNV);
        }

        public async Task<IActionResult> Deletenv(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            // Xoá nhân viên
            nhanVien.MaHDLD = "Không";
            await _context.SaveChangesAsync();

            // Chuyển hướng lại trang "Index" của hợp đồng lao động
            return RedirectToAction("Index");
        }


        // POST: HopDongLaoDongs/Delete/5
        
        private bool HopDongLaoDongExists(string id)
        {
          return (_context.HopDongLaoDong?.Any(e => e.MaHDLD == id)).GetValueOrDefault();
        }
    }
}
