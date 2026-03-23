using GestaoVendas.Domain.Entitieis;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Exceptions
{
    public class CpfJaCadastradoException(string cpf) : Exception
    {      
        public override string Message
        {
            get
            {
                return $"O CPF '{cpf}' informado já está cadastrado para outro cliente.";

            }
        }
    }
}
