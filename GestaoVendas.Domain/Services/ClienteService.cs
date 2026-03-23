using GestaoVendas.Domain.Models;
using GestaoVendas.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Services
{
    public class ClienteService : BaseService<ClienteIn, ClienteOut>, IClienteService
    {
        public override Task<ClienteOut> CriarAsync(ClienteIn input)
        {
            return base.CriarAsync(input);
        }

        public Task<ClienteOut?> ObterPorCpfAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteOut?> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
