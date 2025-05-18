using Microsoft.AspNetCore.Mvc;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultHeroPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
