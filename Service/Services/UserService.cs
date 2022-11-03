using Application.Services;
using Entity.Dtos;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateUser(RegisterDto registerDto)
        {
            AppUser user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
           IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
        }
    }
}
