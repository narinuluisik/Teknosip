using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using TeknosipBusinessLayer.Abstract;
using TeknosipDataAccessLayer.Concrete;
using TeknosipEntityLayer.Concrete;
using System;
using Microsoft.EntityFrameworkCore;

namespace TeknosipWebUI.Controllers
{
    public class DestekKurumuController : Controller
    {
        private readonly IProblemService _problemService;
        private readonly ISectorService _sectorService;
        private readonly Context _context;

        // Constructor'a Context parametresini ekle
        public DestekKurumuController(IProblemService problemService, ISectorService sectorService, Context context)
        {
            _problemService = problemService;
            _sectorService = sectorService;
            _context = context;
        }

        // Bekleyen sorunları listeleyen action
        public IActionResult BekleyenSorunlar(int? sektorId)
        {
            var sektorler = _context.Sectors
                .Select(s => new { s.SectorId, s.Name })  // Kolon adların doğruysa sorun yok
                .ToList();

            // SelectList'teki alan isimleri anonim tipteki isimlerle eşleşmeli
            ViewBag.Sektorler = new SelectList(sektorler, "SectorId", "Name", sektorId);

            IQueryable<Problem> sorunlar;

            if (sektorId.HasValue && sektorId > 0)
            {
                // Sektöre göre filtrelenmiş problemleri getir
                sorunlar = _problemService.GetProblemsBySector(sektorId.Value).AsQueryable();
            }
            else
            {
                // Sektör belirtilmediyse tüm problemleri getir
                sorunlar = _problemService.TGetList().AsQueryable();
            }

            // Durumu "Bekleniyor" olan veya durumu boş olanları filtrele
            sorunlar = sorunlar.Where(p => string.IsNullOrEmpty(p.Status) || p.Status == "Bekleniyor");

            return View(sorunlar.OrderByDescending(p => p.OlusturmaTarihi).ToList());
        }

        // Destek talebi gönderme için POST metodu
        [HttpPost]
        public IActionResult DestekSun(int problemId, string mesaj)
        {
            // Örnek olarak destek kurumu ID sabit verilmiş, oturumdan veya kimlik doğrulamadan alınabilir
            int destekKurumuId = 1;

            if (string.IsNullOrWhiteSpace(mesaj))
            {
                return BadRequest("Destek mesajı boş olamaz.");
            }

            var destekTalebi = new DestekTalebi
            {
                ProblemId = problemId,
                DestekKurumuId = destekKurumuId,
                Mesaj = mesaj,
                Tarih = DateTime.Now
            };

            _context.DestekTalepleri.Add(destekTalebi);
            _context.SaveChanges();

            return Json(new { success = true, message = "Destek talebiniz başarıyla gönderildi." });
        }
        public IActionResult Desteklediklerim()
        {
              int destekKurumuId = 1; // gerçek kullanıcı id'si olmalı

                var desteklenenProblemler = _context.DestekTalepleri
                    .Where(d => d.DestekKurumuId == destekKurumuId)
                    .Select(d => d.Problem)
                    .Include(p => p.Sector)   // Sector bilgisi için
                    .Distinct()
                    .OrderByDescending(p => p.OlusturmaTarihi)
                    .ToList();

                return View(desteklenenProblemler);

            }

    }
}
