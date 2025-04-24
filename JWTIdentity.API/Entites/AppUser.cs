using Microsoft.AspNetCore.Identity;

namespace JWTIdentity.API.Entites
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
