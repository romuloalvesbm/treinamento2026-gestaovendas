using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Exceptions
{
    public class ClienteNaoEncontradoException : Exception
    {
        public override string Message 
        {
            get
            {
                return "Cliente não encontrado.";
            }
        }
    }
}
