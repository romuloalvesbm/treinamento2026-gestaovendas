using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Domain.Ports.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChanges();

        IClienteRepository ClienteRepository { get; }
        IPedidoRepository PedidoRepository { get; }
    }
}
