using FluentValidation;
using GestaoVendas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioIn>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O usuário é obrigatrio")
                .EmailAddress().WithMessage("O email informado não é válido.");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("O senha é obrigatória.");              
        }
    }
}
