using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NiceaBurger.Areas.Identity.Data;

namespace NiceaBurger.Controllers
{
    [Authorize(Roles ="Yonetici")]
    public class KisiRolController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;

        public KisiRolController(UserManager<Kullanici> userManager)
        {
            _userManager = userManager;
        }
        // GET: KisiRolController
        public ActionResult Index() // Sistemde kayıtlı olan kişileri getir. Anlık kullancı hariç
        {
            // anlık kullanıcıyı getir
            var anlıkKullaniciId = _userManager.GetUserId(HttpContext.User);

            // kendisi hariç diğer kullanıcıları getir
            var kendisiHaricKullanicilar = _userManager.Users.Where(u => u.Id != anlıkKullaniciId).ToList();

            return View(kendisiHaricKullanicilar);
        }


        // GET: KisiRolController/Create
        public async Task<IActionResult> RolEkle(string id)
        {
            // Önce sayfadan gönderilen id'ye ait olan kullanıcıyı getir.
            //öğrenci yetkisi verilecek olan kullanıcıyı
            var yetkiVerilecekKullanici = await _userManager.FindByIdAsync(id);

            // Daha sonra bu kullanıcıya öğrenci rolünü EKLE.
            await _userManager.AddToRoleAsync(yetkiVerilecekKullanici, "Musteri");
            return RedirectToAction("Index");
        }


        // GET: KisiRolController/Delete/5
        public async Task<ActionResult> RolSil(string id)
        {
            // Önce sayfadan gönderilen id'ye ait olan kullanıcıyı getir.
            //öğrenci yetkisi verilecek olan kullanıcıyı
            var yetkiVerilecekKullanici = await _userManager.FindByIdAsync(id);

            // Daha sonra bu kullanıcıya öğrenci rolünü EKLE.
            await _userManager.RemoveFromRoleAsync(yetkiVerilecekKullanici, "Musteri");
            return RedirectToAction("Index");

        }
    }
}
