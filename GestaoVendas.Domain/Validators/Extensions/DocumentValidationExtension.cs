using FluentValidation;

namespace GestaoVendas.Domain.Validators.Extensions
{
    public static class DocumentValidationExtension
    {
        public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.Must(cpf => Common.CpfValidator.IsValid(cpf))
                       .WithMessage("CPF inválido");
        }        
    }
}
