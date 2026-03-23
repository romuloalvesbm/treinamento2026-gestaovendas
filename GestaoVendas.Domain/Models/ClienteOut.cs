using GestaoVendas.Domain.Entitieis;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Models
{
    public class ClienteOut
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public ICollection<PedidoResumoOut> Pedidos { get; set; } = [];
    }
}
