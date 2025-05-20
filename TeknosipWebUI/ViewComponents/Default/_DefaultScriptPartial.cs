using Microsoft.AspNetCore.Mvc;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}