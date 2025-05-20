using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeknosipDataAccessLayer.Concrete;
using TeknosipEntityLayer.Concrete;

namespace TeknosipWebUI.Controllers
{
    public class ProblemSahibiController : Controller
    {
        Context _Context = new Context();

        public IActionResult SorunlarPartial()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var sorunlar = _Context.Problems
                .Where(p => p.AppUserId == userId)
                .OrderByDescending(p => p.OlusturmaTarihi)
                .ToList();

            return PartialView("_SorunlarPartial", sorunlar);
        }


        // Index sayfası (ana sayfa)
        public IActionResult Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var sorunlar = _Context.Problems
                            .Include(p => p.Sector) // Sektör bilgisini yüklemek için
                            .Where(p => p.AppUserId == userId)
                            .OrderByDescending(p => p.OlusturmaTarihi)
                            .ToList();

            return View(sorunlar); // Model olarak listeyi gönder
        
        }
        [HttpPost]
        public IActionResult YeniProblem(string Title, string Description, string Price, int SectorId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Price) || SectorId == 0)
            {
                TempData["Hata"] = "Lütfen tüm alanları eksiksiz doldurun.";
                return RedirectToAction("Index");
            }

            var yeniProblem = new Problem
            {
                Title = Title,
                Description = Description,
                Price = Price,
                SectorId = SectorId,
                Status = "Yeni",
                OlusturmaTarihi = DateTime.Now,
                AppUserId = userId
            };

            _Context.Problems.Add(yeniProblem);
            _Context.SaveChanges();

            TempData["Basari"] = "Sorununuz başarıyla eklendi.";
            return RedirectToAction("Index");
        }
    }
}