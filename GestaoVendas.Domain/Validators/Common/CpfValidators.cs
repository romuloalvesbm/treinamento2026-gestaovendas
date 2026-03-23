using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Validators.Common
{
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string([..cpf.Where(char.IsDigit)]);

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] mult1 = [ 10, 9, 8, 7, 6, 5, 4, 3, 2 ];
            int[] mult2 = [ 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 ];

            var tempCpf = cpf[..9];
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (tempCpf[i] - '0') * mult1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (tempCpf[i] - '0') * mult2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
