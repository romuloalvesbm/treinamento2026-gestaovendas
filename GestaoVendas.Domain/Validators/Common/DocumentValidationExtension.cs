using FluentValidation;

namespace GestaoVendas.Domain.Validators.Common
{
    public static class DocumentValidationExtension
    {
        public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.Must(cpf => CpfValidator.IsValid(cpf))
                       .WithMessage("CPF inválido");
        }        
    }
}
