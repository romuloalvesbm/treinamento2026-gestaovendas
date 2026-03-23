using GestaoVendas.Domain.Entitieis;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Ports.Repositories
{
    public interface IPedidoRepository : IBaseRepository<Pedido, int>
    {
    }
}
