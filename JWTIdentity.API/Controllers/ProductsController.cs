using JWTIdentity.API.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTIdentity.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(AppDbContext appDbContext) : ControllerBase
    {
        
        [HttpGet("GettAll")]

        public async Task<IActionResult> GetAll()
        {
            var products = await appDbContext.Products.ToListAsync();
            return Ok(products);
        }
    }
}
