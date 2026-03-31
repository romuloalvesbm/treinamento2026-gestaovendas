using GestaoVendas.Domain.Models;
using GestaoVendas.Domain.Ports.Repositories;
using GestaoVendas.Domain.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Services
{
    public class ClienteService(IUnitOfWork unitOfWork) : IClienteService
    {
        public Task<ClienteOut> AtualizarAsync(int id, ClienteIn input)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClienteOut>> ConsultarAsync(int pagina, int tamanho)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteOut> CriarAsync(ClienteIn input)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteOut> InativarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteOut?> ObterPorCpfAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteOut?> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteOut?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
