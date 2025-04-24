using JWTIdentity.API.Entites;
using JWTIdentity.API.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTIdentity.API.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtTokenOptions _options;
        private readonly UserManager<AppUser> _userManager;

        public JwtTokenService(IOptions<JwtTokenOptions> options, UserManager<AppUser> userManager)
        {
            _options = options.Value;
            _userManager = userManager;
        }
        public async Task<string> CreateTokenAsync(AppUser user)
        {
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_options.Key));

            var userRole= await _userManager.GetRolesAsync(user);

            List<Claim> Claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, userRole.FirstOrDefault()),
                new Claim("FullName", string.Join(" ", user.Name, user.Surname)),
            };

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: Claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_options.ExpireInMunites),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)

                );


            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            return token;
   
        }
    }
}
