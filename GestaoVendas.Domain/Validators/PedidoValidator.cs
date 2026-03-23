using FluentValidation;
using GestaoVendas.Domain.Entitieis;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(c => c.ClienteId)
               .NotEmpty().WithMessage("Cliente é obrigatrio");

            RuleFor(x => x.Valor)
              .GreaterThan(0)
              .WithMessage("O valor deve ser maior que zero");

        }
    }
}
