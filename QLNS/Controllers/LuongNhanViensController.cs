
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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;




namespace QLNS.Controllers
{
    public class LuongNhanViensController : Controller
    {
        private readonly QLNSContext _context;

        public LuongNhanViensController(QLNSContext context)
        {
            _context = context;
        }

        // GET: LuongNhanViens
        public async Task<IActionResult> Index()
        {
            var luongNhanVienList = await _context.LuongNhanVien.ToListAsync();

            if (luongNhanVienList == null)
            {
                return Problem("Entity set 'QLNSContext.LuongNhanVien' is null.");
            }

            var viewModelList = new List<NhanVienDetailViewModel>();

            foreach (var luongNhanVien in luongNhanVienList)
            {
                var nhanVien = await _context.NhanVien.FirstOrDefaultAsync(nv => nv.MaNV == luongNhanVien.MaNV);
                if (nhanVien != null)
                {
                    var chamCongNhanVienList = await _context.ChamCong.Where(cc => cc.MaNV == nhanVien.MaNV).ToListAsync();
                    var soGioLamViec = chamCongNhanVienList.Sum(cc => cc.SoGioLamViec);

                    var viewModel = new NhanVienDetailViewModel
                    {
                        MaLuong = luongNhanVien.MaLuong,
                        MaNV = nhanVien.MaNV,
                        LCBan = luongNhanVien.LCBan,
                        LuongDuKien = luongNhanVien.LCBan * soGioLamViec // Tính lương dự kiến
                    };

                    viewModelList.Add(viewModel);
                }
            }

            return View(viewModelList);
        }





        public async Task<IActionResult> ExportToPdf(string maNV)
        {
            var nhanVien = await _context.NhanVien.FirstOrDefaultAsync(nv => nv.MaNV == maNV);
            var luongNhanVien = await _context.LuongNhanVien.FirstOrDefaultAsync(lnv => lnv.MaNV == maNV);

            if (nhanVien == null || luongNhanVien == null)
            {
                return NotFound();
            }

            var chamCongNhanVienList = await _context.ChamCong.Where(cc => cc.MaNV == maNV).ToListAsync();
            var soGioLamViec = chamCongNhanVienList.Sum(cc => cc.SoGioLamViec);
            var luongDuKien = luongNhanVien.LCBan * soGioLamViec;

            // Tạo tài liệu PDF
            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Thêm nội dung vào tài liệu
            Paragraph header = new Paragraph("thong tin luong du kien", FontFactory.GetFont("Arial", 18, Font.BOLD));
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            Paragraph employeeInfo = new Paragraph($"Nhan vien : {nhanVien.MaNV} - {nhanVien.TenNV}", FontFactory.GetFont("Arial", 12));
            document.Add(employeeInfo);

            Paragraph salaryInfo = new Paragraph($"Luong du kien: {luongDuKien.ToString("N0")} VND", FontFactory.GetFont("Arial", 12, Font.BOLD));
            document.Add(salaryInfo);

            // Thêm thông tin mô tả chi tiết
            Paragraph description = new Paragraph("Chi tiet tinh uong du kien:", FontFactory.GetFont("Arial", 12, Font.BOLD));
            document.Add(description);

            Paragraph descriptionContent = new Paragraph();
            descriptionContent.Add("Luong co ban: ");
            descriptionContent.Add(new Chunk(luongNhanVien.LCBan.ToString("N0"), FontFactory.GetFont("Arial", 12)));
            descriptionContent.Add("\n");
            descriptionContent.Add("So gio lam: ");
            descriptionContent.Add(new Chunk(soGioLamViec.ToString(), FontFactory.GetFont("Arial", 12)));
            descriptionContent.Add("\n");
            descriptionContent.Add("Luong du kien: ");
            descriptionContent.Add(new Chunk(luongDuKien.ToString("N0"), FontFactory.GetFont("Arial", 12, Font.BOLD)));
            document.Add(descriptionContent);

            document.Close();

            // Chuyển MemoryStream thành byte array
            byte[] fileBytes = memoryStream.ToArray();
            memoryStream.Close();

            // Trả về file PDF để tải về
            return File(fileBytes, "application/pdf", $"LuongDuKien_{nhanVien.MaNV}.pdf");
        }




        // GET: LuongNhanViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LuongNhanVien == null)
            {
                return NotFound();
            }

            var luongNhanVien = await _context.LuongNhanVien
                .FirstOrDefaultAsync(m => m.MaLuong == id);
            if (luongNhanVien == null)
            {
                return NotFound();
            }

            return View(luongNhanVien);
        }

        // GET: LuongNhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LuongNhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLuong,MaNV,LCBan")] LuongNhanVien luongNhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(luongNhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(luongNhanVien);
        }

        // GET: LuongNhanViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LuongNhanVien == null)
            {
                return NotFound();
            }

            var luongNhanVien = await _context.LuongNhanVien.FindAsync(id);
            if (luongNhanVien == null)
            {
                return NotFound();
            }
            return View(luongNhanVien);
        }

        // POST: LuongNhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLuong,MaNV,LCBan")] LuongNhanVien luongNhanVien)
        {
            if (id != luongNhanVien.MaLuong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(luongNhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuongNhanVienExists(luongNhanVien.MaLuong))
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
            return View(luongNhanVien);
        }

        // GET: LuongNhanViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LuongNhanVien == null)
            {
                return NotFound();
            }

            var luongNhanVien = await _context.LuongNhanVien
                .FirstOrDefaultAsync(m => m.MaLuong == id);
            if (luongNhanVien == null)
            {
                return NotFound();
            }

            return View(luongNhanVien);
        }

        // POST: LuongNhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LuongNhanVien == null)
            {
                return Problem("Entity set 'QLNSContext.LuongNhanVien'  is null.");
            }
            var luongNhanVien = await _context.LuongNhanVien.FindAsync(id);
            if (luongNhanVien != null)
            {
                _context.LuongNhanVien.Remove(luongNhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuongNhanVienExists(string id)
        {
          return (_context.LuongNhanVien?.Any(e => e.MaLuong == id)).GetValueOrDefault();
        }
    }
}
