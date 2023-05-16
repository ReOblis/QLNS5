using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class ChamCongsController : Controller
    {
        private readonly QLNSContext _context;

        public ChamCongsController(QLNSContext context)
        {
            _context = context;
        }

        // GET: ChamCongs
        public async Task<IActionResult> Index()
        {
              return _context.ChamCong != null ? 
                          View(await _context.ChamCong.ToListAsync()) :
                          Problem("Entity set 'QLNSContext.ChamCong'  is null.");
        }

        
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChamCongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCC,MaNV,NgayChamCong,SoGioLamViec")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chamCong);
        }

        // GET: ChamCongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChamCong == null)
            {
                return NotFound();
            }

            var chamCong = await _context.ChamCong.FindAsync(id);
            if (chamCong == null)
            {
                return NotFound();
            }
            return View(chamCong);
        }

        // POST: ChamCongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCC,MaNV,NgayChamCong,SoGioLamViec")] ChamCong chamCong)
        {
            if (id != chamCong.MaCC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamCongExists(chamCong.MaCC))
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
            return View(chamCong);
        }

        // GET: ChamCongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChamCong == null)
            {
                return NotFound();
            }

            var chamCong = await _context.ChamCong
                .FirstOrDefaultAsync(m => m.MaCC == id);
            if (chamCong == null)
            {
                return NotFound();
            }

            return View(chamCong);
        }

        // POST: ChamCongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChamCong == null)
            {
                return Problem("Entity set 'QLNSContext.ChamCong'  is null.");
            }
            var chamCong = await _context.ChamCong.FindAsync(id);
            if (chamCong != null)
            {
                _context.ChamCong.Remove(chamCong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamCongExists(int id)
        {
          return (_context.ChamCong?.Any(e => e.MaCC == id)).GetValueOrDefault();
        }
    }
}
