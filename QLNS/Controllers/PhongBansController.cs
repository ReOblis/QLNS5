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
    public class PhongBansController : Controller
    {
        private readonly QLNSContext _context;

        public PhongBansController(QLNSContext context)
        {
            _context = context;
        }

        // GET: PhongBans
        public async Task<IActionResult> Index()
        {
              return _context.PhongBan != null ? 
                          View(await _context.PhongBan.ToListAsync()) :
                          Problem("Entity set 'QLNSContext.PhongBan'  is null.");
        }

        // GET: PhongBans/Details/5
        public async Task<IActionResult> Details(string id, string CV, string NV)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongBan = await _context.PhongBan.FindAsync(id);
            if (phongBan == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVu.FirstOrDefaultAsync(h => h.MaChucVu == CV);

            var nhanVienList = await _context.NhanVien.Where(h => h.MaPB == id).ToListAsync();

            var viewModelList = new List<NhanVienDetailViewModel>();

            foreach (var nhanVien in nhanVienList)
            {
                var viewModel = new NhanVienDetailViewModel
                {
                    NhanVien = nhanVien,
                    ChucVu = chucVu,
                    PhongBan = phongBan
                };

                viewModelList.Add(viewModel);
            }

            foreach (var nhanVienDetail in viewModelList)
            {
                // Thực hiện quy ước mã chức vụ dựa trên nhanVienDetail.ChucVu.MaChucVu và lưu vào nhanVienDetail.TenQuyUocMaChucVu
                switch (nhanVienDetail.NhanVien.MaChucVu)
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
            return View(viewModelList);
        }


        // GET: NhanViens/Delete/5
        public async Task<IActionResult> Deletenv(string id, string PB)
        {
            if (id == null || PB == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            // Cập nhật mã phòng ban của nhân viên thành "Không"
            nhanVien.MaPB = "Không";

            await _context.SaveChangesAsync();

            // Chuyển hướng lại trang "Details" của phòng ban
            return RedirectToAction("Details", "PhongBans", new { id = PB });
        }




        // POST: NhanViens/Delete/5
        [HttpPost]
public async Task<IActionResult> AddNhanVien(string id, string maNhanVien, string maChucVu)
{
    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maChucVu))
    {
        return NotFound();
    }

    var phongBan = await _context.PhongBan.FindAsync(id);
    if (phongBan == null)
    {
        return NotFound();
    }

    var nhanVien = await _context.NhanVien.FirstOrDefaultAsync(nv => nv.MaNV == maNhanVien);
    if (nhanVien == null)
    {
        return NotFound();
    }

    var chucVu = await _context.ChucVu.FirstOrDefaultAsync(cv => cv.MaChucVu == maChucVu);
    if (chucVu == null)
    {
        return NotFound();
    }

    nhanVien.MaPB = phongBan.MaPB;
    nhanVien.MaChucVu = chucVu.MaChucVu;
    _context.Update(nhanVien);
    await _context.SaveChangesAsync();

    return RedirectToAction("Details", new { id });
}


        // GET: PhongBans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhongBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPB,TenPB,DiaChi")] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phongBan);
        }

        // GET: PhongBans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PhongBan == null)
            {
                return NotFound();
            }

            var phongBan = await _context.PhongBan.FindAsync(id);
            if (phongBan == null)
            {
                return NotFound();
            }
            return View(phongBan);
        }

        // POST: PhongBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPB,TenPB,DiaChi")] PhongBan phongBan)
        {
            if (id != phongBan.MaPB)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongBanExists(phongBan.MaPB))
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
            return View(phongBan);
        }

        // GET: PhongBans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PhongBan == null)
            {
                return NotFound();
            }

            var phongBan = await _context.PhongBan
                .FirstOrDefaultAsync(m => m.MaPB == id);
            if (phongBan == null)
            {
                return NotFound();
            }

            // Xoá phòng ban
            _context.PhongBan.Remove(phongBan);

            // Tìm và cập nhật mã phòng ban của tất cả nhân viên trong phòng đó thành "Không"
            var nhanViens = await _context.NhanVien.Where(nv => nv.MaPB == id).ToListAsync();
            foreach (var nhanVien in nhanViens)
            {
                nhanVien.MaPB = "Không";
            }

            await _context.SaveChangesAsync();

            // Chuyển hướng lại trang "Index" của phòng ban
            return RedirectToAction("Index");
        }


        // POST: PhongBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PhongBan == null)
            {
                return Problem("Entity set 'QLNSContext.PhongBan'  is null.");
            }
            var phongBan = await _context.PhongBan.FindAsync(id);
            if (phongBan != null)
            {
                _context.PhongBan.Remove(phongBan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongBanExists(string id)
        {
          return (_context.PhongBan?.Any(e => e.MaPB == id)).GetValueOrDefault();
        }
    }
}
