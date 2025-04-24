using JWTIdentity.API.Entites;

namespace JWTIdentity.API.Services
{
    public interface IJwtTokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
