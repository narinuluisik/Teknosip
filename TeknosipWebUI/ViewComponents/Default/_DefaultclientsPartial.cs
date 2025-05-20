using Microsoft.AspNetCore.Mvc;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultclientsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}