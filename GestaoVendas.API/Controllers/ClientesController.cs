using GestaoVendas.API.Common;
using GestaoVendas.API.Helpers;
using GestaoVendas.Domain.Models;
using GestaoVendas.Domain.Ports.Services;
using GestaoVendas.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GestaoVendas.API.Controllers
{

    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(IClienteService clienteService, ILogger<ClientesController> logger) : ControllerBase
    {
        // AVISO: [ClaimsAuthorize] é um modelo antigo de autorização customizada.
        // Recomenda-se usar [Authorize(Policy = "GetbyId")] ao invés.
        //[ClaimsAuthorize("CustomizePermission", "GetAll")]
        [Authorize(Policy = "Cliente.GetAll")]
        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(List<ClienteOut>), 200)]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {

            return Ok(ApiResponse<List<ClienteOut>>.Ok(await clienteService.ConsultarAsync(skip, take)));

        }

        // AVISO: [ClaimsAuthorize] é um modelo antigo de autorização customizada.
        // Recomenda-se usar [Authorize(Policy = "GetbyId")] ao invés.
        //[ClaimsAuthorize("CustomizePermission", "Cliente.GetbyId")]
        [Authorize(Policy = "Cliente.GetbyId")]
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(ClienteOut), 200)]
        public async Task<IActionResult> GetById(int id)
        {           
            return Ok(ApiResponse<ClienteOut?>.Ok(await clienteService.ObterPorIdAsync(id)));           

        }

        // AVISO: [ClaimsAuthorize] é um modelo antigo de autorização customizada.
        // Recomenda-se usar [Authorize(Policy = "CreateCliente")] ao invés.
        //[ClaimsAuthorize("CustomizePermission", "CreateCliente")]
        [Authorize(Policy = "Cliente.Create")]
        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(ClienteOut), 200)]
        public async Task<IActionResult> Create([FromBody] ClienteIn cliente)
        {
            var result = await clienteService.CriarAsync(cliente);
            logger.LogInformation("Cliente cadastrado com sucesso: {@ClienteOut}", result);
            return Ok(ApiResponse<ClienteOut?>.Ok(result)); 
        }

        // AVISO: [ClaimsAuthorize] é um modelo antigo de autorização customizada.
        // Recomenda-se usar [Authorize(Policy = "UpdateCliente")] ao invés.
        //[ClaimsAuthorize("CustomizePermission", "UpdateCliente")]
        [Authorize(Policy = "Cliente.Update")]
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(ClienteOut), 200)]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteIn cliente)
        {
            var result = await clienteService.AtualizarAsync(id, cliente);
            logger.LogInformation("Cliente atualizado com sucesso: {@ClienteOut}", result);
            return Ok(ApiResponse<ClienteOut?>.Ok(result));
        }

        // AVISO: [ClaimsAuthorize] é um modelo antigo de autorização customizada.
        // Recomenda-se usar [Authorize(Policy = "InactiveCliente")] ao invés.
        //[ClaimsAuthorize("CustomizePermission", "InactiveCliente")]
        [Authorize(Policy = "Cliente.Inactive")]
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(ClienteOut), 200)]
        public async Task<IActionResult> Inactive(int id)
        {
            var result = await clienteService.InativarAsync(id);
            logger.LogInformation("Cliente inativado com sucesso: {@ClienteOut}", result);
            return Ok(ApiResponse<ClienteOut?>.Ok(result));
        }


        // AVISO: [ClaimsAuthorize] é um modelo antigo de autorização customizada.
        // Recomenda-se usar [Authorize(Policy = "...")] ao invés. (Policy "GetAll2" não está registrada)
        //[ClaimsAuthorize("CustomizePermission", "GetAll2")]
        [Authorize(Policy = "Cliente.GetAll2")]
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
