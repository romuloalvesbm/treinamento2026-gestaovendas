using GestaoVendas.Domain.Exceptions;
using GestaoVendas.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; } = false;

        public Cliente? Cliente { get; private set; }

        public Pedido()
        {
            
        }

        private Pedido(decimal valor, bool ativo) 
        {           
            Valor = valor;
            Ativo = ativo;

            Validate();
        }

        public static Pedido Create(decimal valor, bool ativo)
        {
            return new Pedido(valor, ativo);
        }

        public void Update(decimal valor, bool ativo) 
        {            
            Valor = valor;
            Ativo = ativo;

            Validate();
        }

        private void Validate() 
        {
            var errors = new List<string>();
                       
            if (Valor <= 0)
            {
                errors.Add("Valor inválido.");
            }

            if (errors.Any())
                throw new DomainValidationException(errors);
        }
    }
}
