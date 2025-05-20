using Microsoft.AspNetCore.Mvc;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultFooterPartial    :         ViewComponent
    {
        public IViewComponentResult Invoke()
    {
        return View();
    }
}
}