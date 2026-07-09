using GestaoVendas.Domain.Entities;
using GestaoVendas.Domain.Exceptions;
using GestaoVendas.Domain.Exceptions.Base;
using GestaoVendas.Domain.Models;
using GestaoVendas.Domain.Ports.Repositories;
using GestaoVendas.Domain.Ports.Services;
using Mapster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestaoVendas.Domain.Services
{
    public class ClienteService(IUnitOfWork unitOfWork) : IClienteService
    {
        public async Task<List<ClienteOut>> ConsultarAsync(int pagina, int tamanho)
        {
            var clientes = await unitOfWork.ClienteRepository.GetAllAsync(pagina, tamanho, c => c.Ativo);
            return clientes.Adapt<List<ClienteOut>>();
        }

        public async Task<ClienteOut?> ObterPorIdAsync(int id)
        {
            var cliente = await unitOfWork.ClienteRepository.GetByIdAsync(id);

            return cliente == null ? throw new ClienteNaoEncontradoException() : cliente.Adapt<ClienteOut>();
        }

        public async Task<ClienteOut> CriarAsync(ClienteIn input)
        {
            if (await unitOfWork.ClienteRepository.AnyAsync(c => c.Cpf.Equals(input.Cpf)))
                throw new CpfJaCadastradoException(input.Cpf);

            if (await  unitOfWork.ClienteRepository.AnyAsync(c => c.Email.Equals(input.Email)))
                throw new EmailJaCadastradoException(input.Email);
            
            var cliente = input.Adapt<Cliente>();

            foreach (var item in input.Pedidos)
            {
                cliente.AdicionarPedido(item.Valor);
            }

            await unitOfWork.ClienteRepository.AddAsync(cliente);
            await unitOfWork.SaveChanges();

            return cliente.Adapt<ClienteOut>();
        }

        public async Task<ClienteOut> AtualizarAsync(int id, ClienteIn input)
        {
            var cliente = await unitOfWork.ClienteRepository.GetByIdAsync(id) ?? throw new ClienteNaoEncontradoException();
            var hasCliente = await unitOfWork.ClienteRepository.AnyAsync(x => (x.Cpf == input.Cpf || x.Email == input.Email) && x.Id != id);

            if (hasCliente)
                throw new DomainValidationException(["Já existe um cliente com este CPF ou Email"]);

            cliente.Update(input.Nome, input.Cpf, input.Email);

            var pedidosInput = input.Pedidos.Adapt<ICollection<Pedido>>();

            if(pedidosInput.Count > 0)
                cliente.SincronizarPedidos(pedidosInput);

            await unitOfWork.ClienteRepository.UpdateAsync(cliente);

            await unitOfWork.SaveChanges();
            return cliente.Adapt<ClienteOut>();
        }

        public async Task<ClienteOut> InativarAsync(int id)
        {
            var cliente = await unitOfWork.ClienteRepository.GetByIdAsync(id) ?? throw new ClienteNaoEncontradoException();
            cliente.Inactive(false);

            await unitOfWork.ClienteRepository.UpdateAsync(cliente);
            await unitOfWork.SaveChanges();
            return cliente.Adapt<ClienteOut>();
        }

        public async Task<ClienteOut?> ObterPorCpfAsync(string cpf)
        {
            var cliente = await unitOfWork.ClienteRepository.GetAsync(x => x.Cpf == cpf);

            return cliente == null ? throw new ClienteNaoEncontradoException() : cliente.Adapt<ClienteOut>();
        }

        public async Task<ClienteOut?> ObterPorEmailAsync(string email)
        {
            var cliente = await unitOfWork.ClienteRepository.GetAsync(x => x.Email == email);

            return cliente == null ? throw new ClienteNaoEncontradoException() : cliente.Adapt<ClienteOut>();
        }        
    }
}
