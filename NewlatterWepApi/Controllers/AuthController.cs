using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewlatterWepApi.Context;
using NewlatterWepApi.Dtos;
using NewlatterWepApi.Models;
using NewlatterWepApi.Result;

namespace NewlatterWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly NewsLatterDb _context;

        public AuthController(NewsLatterDb context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var isUserNameExsist = await _context.Users.Where(p => p.UserName == registerDto.UserName).FirstOrDefaultAsync();
            if (isUserNameExsist != null)
            {
                return BadRequest("Bu kullanıcı daha daha önce alınmış!");
            };

            var isEmailExsist = await _context.Users.Where(p => p.Email == registerDto.Email).FirstOrDefaultAsync();
            if (isEmailExsist != null)
            {
                return BadRequest("Bu mail adresi daha daha önce alınmış!");
            };

            User user = new()
            {
                Email = registerDto.Email,
                NameLastname = registerDto.NameLastName,
                Password = registerDto.Password,
                UserName = registerDto.UserName
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            ResultModel result = new()
            {
                Message = "Register user is successful!"
            };

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _context.Users.Where(p => p.UserName == loginDto.UserName).FirstOrDefaultAsync();
            if(user == null)
                user = await _context.Users.Where(p => p.Email == loginDto.UserName).FirstOrDefaultAsync();

            if (user == null)
                return BadRequest("User name or email not found!");

            if (user.Password == loginDto.Password)
                return Ok(user);
            else
                return BadRequest("Password is wrong!");
        }
    }
}
