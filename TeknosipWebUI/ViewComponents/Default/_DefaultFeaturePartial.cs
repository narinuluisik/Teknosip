using Microsoft.AspNetCore.Mvc;
using TeknosipDataAccessLayer.Concrete;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultFeaturePartial : ViewComponent
    {
        Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            var values = _context.Features.ToList();
            return View(values);
        }
    }
}