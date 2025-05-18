using Microsoft.AspNetCore.Mvc;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
