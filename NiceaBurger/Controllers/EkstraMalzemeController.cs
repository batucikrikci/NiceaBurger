using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NiceaBurger.Areas.Identity.Data;

namespace NiceaBurger.Controllers
{
    [Authorize(Roles = "Yonetici")]

    public class EkstraMalzemeController : Controller
    {
        private readonly UygulamaDbContext _context;

        public EkstraMalzemeController(UygulamaDbContext context)
        {
            _context = context;
        }

        // GET: EkstraMalzeme
        public async Task<IActionResult> Index()
        {
              return View(await _context.EkstraMalzeme.ToListAsync());
        }

        // GET: EkstraMalzeme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EkstraMalzeme == null)
            {
                return NotFound();
            }

            var ekstraMalzeme = await _context.EkstraMalzeme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ekstraMalzeme == null)
            {
                return NotFound();
            }

            return View(ekstraMalzeme);
        }

        // GET: EkstraMalzeme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EkstraMalzeme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Fiyat")] EkstraMalzeme ekstraMalzeme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ekstraMalzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ekstraMalzeme);
        }

        // GET: EkstraMalzeme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EkstraMalzeme == null)
            {
                return NotFound();
            }

            var ekstraMalzeme = await _context.EkstraMalzeme.FindAsync(id);
            if (ekstraMalzeme == null)
            {
                return NotFound();
            }
            return View(ekstraMalzeme);
        }

        // POST: EkstraMalzeme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Fiyat")] EkstraMalzeme ekstraMalzeme)
        {
            if (id != ekstraMalzeme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ekstraMalzeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EkstraMalzemeExists(ekstraMalzeme.Id))
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
            return View(ekstraMalzeme);
        }

        // GET: EkstraMalzeme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EkstraMalzeme == null)
            {
                return NotFound();
            }

            var ekstraMalzeme = await _context.EkstraMalzeme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ekstraMalzeme == null)
            {
                return NotFound();
            }

            return View(ekstraMalzeme);
        }

        // POST: EkstraMalzeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EkstraMalzeme == null)
            {
                return Problem("Entity set 'UygulamaDbContext.EkstraMalzeme'  is null.");
            }
            var ekstraMalzeme = await _context.EkstraMalzeme.FindAsync(id);
            if (ekstraMalzeme != null)
            {
                _context.EkstraMalzeme.Remove(ekstraMalzeme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EkstraMalzemeExists(int id)
        {
          return _context.EkstraMalzeme.Any(e => e.Id == id);
        }
    }
}
