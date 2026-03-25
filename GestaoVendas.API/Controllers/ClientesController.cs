using GestaoVendas.API.Helpers;
using GestaoVendas.Domain.Models;
using GestaoVendas.Domain.Ports.Services;
using GestaoVendas.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoVendas.API.Controllers
{
  
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(IClienteService clienteService) : ControllerBase
    {
        [ClaimsAuthorize("CustomizePermission", "GetAll")]
        [HttpGet("obter-todos")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(List<ClienteOut>), 200)]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            return Ok(new
            {
                Autenticado = User.Identity?.IsAuthenticated,
                Nome = User.Identity?.Name,
                Tipo = User.Identity?.AuthenticationType
            });
        }

        [ClaimsAuthorize("CustomizePermission", "GetAll1")]
        [HttpGet("obter-todos")]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(typeof(List<ClienteOut>), 200)]
        public async Task<IActionResult> GetAllV2([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            //var result = await clienteService.ConsultarAsync(skip, take);
            return Ok("ok 2");
        }
    }
}
