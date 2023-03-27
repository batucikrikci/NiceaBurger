using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NiceaBurger.Areas.Identity.Data;

namespace NiceaBurger.Controllers
{
    [Authorize(Roles = "Musteri")]

    public class SiparisUrunController : Controller
    {
        private readonly UygulamaDbContext _context;

        private readonly UserManager<Kullanici> _userManager;

        public SiparisUrunController(UygulamaDbContext context, UserManager<Kullanici> userManager)
        {
            _context = context;
           _userManager = userManager;
        }

        // GET: SiparisUrun
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ViewBag.TumMenuler = await _context.Menu.ToListAsync();
            ViewBag.TumEkstralar = await _context.EkstraMalzeme.ToListAsync();
            ViewBag.SiparisUrun= await _context.SiparisUrun.Include(s => s.Kullanici).Include(s => s.Menu).Include(s => s.ekstraMalzeme).Where(od=>od.KullaniciId==userId).ToListAsync();
                        
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(SiparisUrun siparisUrun)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            siparisUrun.KullaniciId = userId;
            _context.SiparisUrun.Add(siparisUrun);
            await _context.SaveChangesAsync();
            ViewBag.Kod = 1;
            ViewBag.Durum = "Ürün Sepetinize eklenmiştir.";

            ViewBag.TumMenuler = await _context.Menu.ToListAsync();
            ViewBag.SiparisUrun = await _context.SiparisUrun.Include(s => s.Kullanici).Include(s => s.Menu).Include(s => s.ekstraMalzeme).Where(od => od.KullaniciId == userId).ToListAsync();

            return RedirectToAction("Index");

        }

               
        // GET: SiparisUrun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SiparisUrun == null)
            {
                return NotFound();
            }

            var siparisUrun = await _context.SiparisUrun
                .Include(s => s.Kullanici)
                .Include(s => s.Menu)
                .Include(s => s.ekstraMalzeme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siparisUrun == null)
            {
                return NotFound();
            }

            return View(siparisUrun);
        }

        // POST: SiparisUrun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SiparisUrun == null)
            {
                return Problem("Entity set 'UygulamaDbContext.SiparisUrun'  is null.");
            }
            var siparisUrun = await _context.SiparisUrun.FindAsync(id);
            if (siparisUrun != null)
            {
                _context.SiparisUrun.Remove(siparisUrun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparisUrunExists(int id)
        {
          return _context.SiparisUrun.Any(e => e.Id == id);
        }
    }
}
