using GestaoVendas.Domain.Exceptions;
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
            if (ClienteId < 0)
            {
                throw new ClienteNaoEncontradoException();
            }

            if (Valor < 0)
            {
                throw new Exception("Valor inválido.");
            }
        }
    }
}
