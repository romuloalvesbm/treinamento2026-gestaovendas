using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Models
{
    public class PedidoIn
    {        
        public int ClienteId { get; set; }
        public decimal Valor { get;  set; }
    }
}
