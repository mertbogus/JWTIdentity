using JWTIdentity.API.Entites;
using JWTIdentity.API.Models;
using JWTIdentity.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace JWTIdentity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, IJwtTokenService _jwtTokenService, 
        RoleManager<AppRole> roleManager ) : ControllerBase
    {
        [HttpPost("Register")]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Surname = registerDto.Surname,
                UserName = registerDto.UserName,

            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Olayı uzatmamak için böyle yapıldı.

            var roleExists = await roleManager.RoleExistsAsync("Admin");
            if (!roleExists)
            {
                var role = new AppRole
                {
                    Name = "Admin"
                };

                await roleManager.CreateAsync(role);
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            return Ok("Kullanıcı Kaydı Başarılı.");
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user==null)
            {
                return BadRequest("Kullanıcı Bulunamadı.");
            }

            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!result)
            {
                return BadRequest("Şifre Hatalı.");
            }

            var token= await _jwtTokenService.CreateTokenAsync(user);

            return Ok(token);
        }
    }
}
