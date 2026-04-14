using GestaoVendas.Domain.Exceptions;
using GestaoVendas.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Entitieis
{
    public class Pedido
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; } = false;

        public Cliente Cliente { get; private set; } = new Cliente();

        public Pedido()
        {
            
        }

        private Pedido(int clienteId, decimal valor, bool ativo) 
        {
            ClienteId = clienteId;
            Valor = valor;
            Ativo = ativo;

            Validate();
        }

        public static Pedido Create(int clienteId, decimal valor, bool ativo)
        {
            return new Pedido(clienteId, valor, ativo);
        }

        public void Update(int clienteId, decimal valor, bool ativo) 
        {
            ClienteId = clienteId;
            Valor = valor;
            Ativo = ativo;

            Validate();
        }

        private void Validate() 
        {
            var errors = new List<string>();

            if (ClienteId <= 0)
            {
                errors.Add("Pedido não encontrado");
            }

            if (Valor < 0)
            {
                errors.Add("Valor inválido.");
            }

            if (errors.Any())
                throw new DomainValidationException(errors);
        }
    }
}
