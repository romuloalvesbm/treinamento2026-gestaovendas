using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Validators.Common
{
    public static class DocumentoValidator
    {
        public static bool IsValid(string document) 
        {
            if (string.IsNullOrEmpty(document))
                return false;

            //Remove tudo que não for número da string
            var digits = new string([..document.Where(char.IsDigit)]);

            return digits.Length switch
            {
                11 => CpfValidator.IsValid(digits),
              //14 => //TODO case precise incluir outro documento
                _ => false
            };
        }
    }
}
