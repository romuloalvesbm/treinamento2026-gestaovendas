using GestaoVendas.Domain.Validators.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Entitieis
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public bool Ativo { get; private set; } = false; 

        public ICollection<Pedido> Pedidos { get; set; } = [];

        public Cliente()
        {

        }

        private Cliente(string nome, string email, string cpf, bool ativo)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Ativo = ativo;

            Validate();
        }

        public static Cliente Create(string nome, string email, string cpf, bool ativo)
        {
            return new Cliente(nome, email, cpf, ativo);
        }

        public void Update(string nome, string email, bool ativo)
        {
            Nome = nome;
            Email = email;
            Ativo = ativo;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome não encontrado.");
            }

            if (string.IsNullOrEmpty(Email) || !EmailValidator.IsValid(Email))
            {
                throw new Exception("Email inválido.");
            }

            if (string.IsNullOrEmpty(Cpf) || !CpfValidator.IsValid(Cpf)) 
            {
                throw new Exception("Cpf inválido.");
            }
        }

    }
}
