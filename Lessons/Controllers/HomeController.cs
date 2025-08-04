using DersProgramiMvc.Data;
using DersProgramiMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DersProgramiMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // ---------------------
        // DERSLERİ LİSTELE
        // ---------------------
        public async Task<IActionResult> Index()
        {
            var dersler = await _context.Dersler.ToListAsync();
            return View(dersler);
        }

        // ---------------------
        // DERS EKLE (GET)
        // ---------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ---------------------
        // DERS EKLE (POST)
        // ---------------------
        [HttpPost]
        public async Task<IActionResult> Create(Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Dersler.Add(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ders);
        }

        // ---------------------
        // DERS DÜZENLE (GET)
        // ---------------------
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        // ---------------------
        // DERS DÜZENLE (POST)
        // ---------------------
        [HttpPost]
        public async Task<IActionResult> Edit(Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Dersler.Update(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ders);
        }

        // ---------------------
        // DERS SİL (GET)
        // ---------------------
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        // ---------------------
        // DERS SİL (POST)
        // ---------------------
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders != null)
            {
                _context.Dersler.Remove(ders);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // ---------------------
        // GÜNE GÖRE DERS BUL
        // ---------------------
        [HttpGet]
        public IActionResult GunSec()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GunSec(string gun)
        {
            if (string.IsNullOrWhiteSpace(gun))
            {
                ViewBag.Hata = "Lütfen bir gün giriniz.";
                return View();
            }

            var ders = await _context.Dersler
                .FirstOrDefaultAsync(d => d.Gun.ToLower() == gun.ToLower());

            if (ders == null)
            {
                ViewBag.Hata = "Geçersiz gün girdiniz veya o gün için ders bulunamadı.";
                return View();
            }

            ViewBag.Ders = ders;
            ViewBag.Gun = ders.Gun;

            return View();
        }
    }
}
