using Entity.Dtos;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.UserName);
            if (user == null)
                user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null)
            {
                TempData["errors"] = "User not found!";
                return RedirectToAction("Index", "Auth");
            }

            bool result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                var roles = await _userManager.GetRolesAsync(user);
                TempData["roles"] = roles;
                return RedirectToAction("index", "Home");
            }

            


            TempData["errors"] = "Password is wrong!";
            return RedirectToAction("Index", "Auth");
        }
    }
}
