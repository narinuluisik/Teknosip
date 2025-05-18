using Microsoft.AspNetCore.Mvc;

namespace TeknosipWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
