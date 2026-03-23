using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Exceptions
{
    public class EmailJaCadastradoException(string email) : Exception
    {
        public override string Message
        {
            get
            {
                return $"O endereço de email informado '{email}' já está cadastrado para outro cliente.";

            }
        }
    }
}
