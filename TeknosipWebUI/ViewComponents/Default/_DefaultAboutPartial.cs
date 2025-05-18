using Microsoft.AspNetCore.Mvc;
using TeknosipDataAccessLayer.Concrete;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultAboutPartial      :ViewComponent
    {
        Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            var values= _context.Abouts.ToList();
            return View(values);
        }
    }
}
