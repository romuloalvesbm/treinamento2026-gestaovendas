using GestaoVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Ports.Services
{
    public interface IClienteService
    {
        Task<ClienteOut> CriarAsync(ClienteIn input);
        Task<ClienteOut> AtualizarAsync(int id, ClienteIn input);
        Task<ClienteOut> InativarAsync(int id);
        Task<ClienteOut?> ObterPorIdAsync(int id);
        Task<List<ClienteOut>> ConsultarAsync(int pagina, int tamanho);
        Task<ClienteOut?> ObterPorCpfAsync(string cpf);
        Task<ClienteOut?> ObterPorEmailAsync(string email);
    }
}