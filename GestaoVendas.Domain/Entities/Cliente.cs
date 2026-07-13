using GestaoVendas.Domain.Exceptions.Base;
using GestaoVendas.Domain.Validators.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public bool Ativo { get; private set; } = false; 

        //public ICollection<Pedido> Pedidos { get; set; } = [];

        // Encapsulamento da lista
        private readonly List<Pedido> _pedidos = [];
        public IReadOnlyCollection<Pedido> Pedidos => _pedidos.AsReadOnly();

        public Cliente()
        {

        }

        private Cliente(string nome, string email, string cpf)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Ativo = true;

            Validate();
        }

        public static Cliente Create(string nome, string email, string cpf)
        {
            return new Cliente(nome, email, cpf);
        }

        public void Update(string nome, string cpf, string email)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;           

            Validate();
        }

        public void Inactive(bool ativo) 
        {
            Ativo = ativo;
        }
        public void AdicionarPedido(decimal valor)
        {
            _pedidos.Add(Pedido.Create(valor, true));
        }

        public void SincronizarPedidos(IEnumerable<Pedido> pedidos)
        {
            if (pedidos == null)
                return;          

            var idsInput = pedidos.Where(p => p.Id > 0)
                                  .Select(p => p.Id).ToList();

            var remover = _pedidos.Where(p => !idsInput.Contains(p.Id))
                                  .ToList();

            foreach (var item in remover)
                _pedidos.Remove(item);

            foreach (var item in pedidos)
            {
                if (item.Id == 0)
                {
                    _pedidos.Add(Pedido.Create(item.Valor, item.Ativo));
                }
                else
                {
                    var pedido = _pedidos.FirstOrDefault(p => p.Id == item.Id) ?? throw new DomainValidationException(["Pedido não encontrado"]);
                    pedido.Update(item.Valor, item.Ativo);
                }
            }
        }

        private void Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(Nome))
            {
                errors.Add("Nome não encontrado.");
            }

            if (string.IsNullOrEmpty(Email) || !EmailValidator.IsValid(Email))
            {
                errors.Add("Email inválido.");
            }

            if (string.IsNullOrEmpty(Cpf) || !CpfValidator.IsValid(Cpf)) 
            {
                errors.Add("Cpf inválido.");
            }

            if (errors.Any())
                throw new DomainValidationException(errors);
        }

    }
}
