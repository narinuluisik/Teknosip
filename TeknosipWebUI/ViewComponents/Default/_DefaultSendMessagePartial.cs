using Microsoft.AspNetCore.Mvc;
using TeknosipDataAccessLayer.Concrete;

namespace TeknosipWebUI.ViewComponents.Default
{
    public class _DefaultSendMessagePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Default.cshtml'e model gönder
        }
    }
}
