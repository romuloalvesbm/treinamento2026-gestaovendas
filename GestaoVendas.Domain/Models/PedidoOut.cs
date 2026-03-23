using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Models
{
    public class PedidoOut
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }

        public ClienteOut Cliente { get; set; } = new ClienteOut();
    }
}
