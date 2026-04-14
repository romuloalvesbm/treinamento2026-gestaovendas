using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Exceptions.Base
{
    public class DomainValidationException : Exception
    {
        public List<string> Errors { get; }

        public DomainValidationException(List<string> errors)
            : base("Um ou mais erros de validação ocorreram.")
        {
            Errors = errors;
        }
    }
}
