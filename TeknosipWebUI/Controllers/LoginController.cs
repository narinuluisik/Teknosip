using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknosipEntityLayer.Concrete;

namespace TeknosipWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email ve şifre gereklidir.");
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı.");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Problem Sahibi"))
                {
                    return RedirectToAction("Index", "ProblemSahibi");
                }
                else
                {
                    return RedirectToAction("Index", "Default");
                }
            }

            ModelState.AddModelError("", "Şifre hatalı.");
            return View();

        ;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}