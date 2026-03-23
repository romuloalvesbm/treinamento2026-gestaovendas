using GestaoVendas.Domain.Models;
using GestaoVendas.Domain.Ports.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Ports.Services
{
    public interface IClienteService : IBaseService<ClienteIn, ClienteOut>
    {
        Task<ClienteOut?> ObterPorCpfAsync(string cpf);
        Task<ClienteOut?> ObterPorEmailAsync(string email);
    }
}