using FluentValidation;
using GestaoVendas.Domain.Models;
using GestaoVendas.Domain.Validators.Common;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace GestaoVendas.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteIn>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente é obrigatrio")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email do cliente é obrigatório.")
                .EmailAddress().WithMessage("O email informado não é válido.")
                .MaximumLength(150).WithMessage("O email deve ter no máximo 150 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O cpf do cliente é obrigatrio")
                .IsCpf();
        }
    }
}
