using GestaoVendas.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace GestaoVendas.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(JwtTokenHelper jwtTokenHelper) : ControllerBase
    {
        [HttpPost]
        [MapToApiVersion("1.0")]        
        public IActionResult Post([FromBody] string nome)
        {  
            return Ok(jwtTokenHelper.GenerateToken("Romulo", "romulo@gmail.com"));
        }

    }
}
