using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Entitieis
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }

    }
}
