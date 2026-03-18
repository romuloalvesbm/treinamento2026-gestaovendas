using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Entitieis
{
    public class Pedido
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public decimal Valor { get; private set; }

        public Cliente Cliente { get; private set; } = new Cliente();
    }
}
