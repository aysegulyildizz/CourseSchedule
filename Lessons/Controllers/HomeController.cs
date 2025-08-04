using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lessons.Models;

using Microsoft.AspNetCore.Mvc;
using DersProgramiMvc.Models;

namespace DersProgramiMvc.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<Gun, DersProgrami> Program = new()
        {
            { Gun.Pazartesi, new DersProgrami { DersAdi = "Matematik", Saat = "09:00" } },
            { Gun.Sali, new DersProgrami { DersAdi = "Fizik", Saat = "10:00" } },
            { Gun.Carsamba, new DersProgrami { DersAdi = "Kimya", Saat = "11:00" } },
            { Gun.Persembe, new DersProgrami { DersAdi = "Biyoloji", Saat = "12:00" } },
            { Gun.Cuma, new DersProgrami { DersAdi = "Tarih", Saat = "13:00" } },
        };

        [HttpGet]
        public IActionResult GunSec()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GunSec(string gun)
        {
            try
            {
                Gun secilenGun = (Gun)Enum.Parse(typeof(Gun), gun, ignoreCase: true);
                var ders = Program[secilenGun];
                ViewBag.Ders = ders;
                ViewBag.Gun = secilenGun.ToString();
            }
            catch
            {
                ViewBag.Hata = "Geçersiz gün girdiniz. Lütfen doğru bir gün adı yazın.";
            }

            return View();
        }
    }
}
