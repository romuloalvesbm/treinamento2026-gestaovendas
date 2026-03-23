using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Exceptions
{
    public class PedidoNaoEncontradoException : Exception
    {
        public override string Message
        {
            get
            {
                return "Pedido não encontrado.";
            }
        }
    }
}
