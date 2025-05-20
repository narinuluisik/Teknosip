using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknosipEntityLayer.Concrete;

namespace TeknosipWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RegisterController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Roles = _roleManager.Roles.Select(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser model, string password, string selectedRole)
        {
            
            var result = await _userManager.CreateAsync(model, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(model, selectedRole);
                return RedirectToAction("Index", "Login");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            ViewBag.Roles = _roleManager.Roles.Select(x => x.Name).ToList();
            return View(model);
        }
    }
}
