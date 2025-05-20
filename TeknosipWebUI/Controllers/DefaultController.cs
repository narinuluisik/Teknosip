using Microsoft.AspNetCore.Mvc;
using TeknosipDataAccessLayer.Concrete;
using TeknosipEntityLayer.Concrete;
using System.Linq;

namespace TeknosipWebUI.Controllers
{
    public class DefaultController : Controller
    {
        Context _context = new Context();

        public IActionResult Index()
        {
       
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {

            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.ContactMessages.Add(model);
                    _context.SaveChanges();
                    TempData["Success"] = "Mesaj gönderildi!";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Mesaj gönderilemedi: " + ex.Message;
                    // İstersen loglama yapabilirsin veya daha detaylı exception bilgisi yazdırabilirsin
                    return View("Error", ex); // Ya da hatayı görmek için direkt view döndür
                }
            }
            else
            {
                TempData["Error"] = "Form verileri geçersiz.";
            }
            return RedirectToAction("Index");
        }

    }
}
