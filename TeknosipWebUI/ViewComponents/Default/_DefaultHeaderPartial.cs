using Microsoft.AspNetCore.Mvc;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

