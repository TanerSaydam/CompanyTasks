using CreateAQuizMVC.Dtos;
using CreateAQuizMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CreateAQuizMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null) {
                TempData["userName"] = loginDto.UserName;
                TempData["password"] = loginDto.Password;
                TempData["error"] = "Kullanıcı bulunamadı!";
                return RedirectToAction("Login", "Auth");
            }

            bool result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if(!result)
            {
                TempData["userName"] = loginDto.UserName;
                TempData["password"] = loginDto.Password;
                TempData["error"] = "Şifre yanlış!";
                return RedirectToAction("Login", "Auth");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
