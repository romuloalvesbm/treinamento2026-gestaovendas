using GestaoVendas.Domain.Ports.Repositories;
using GestaoVendas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoVendas.Infra.Data.Repositories
{
    public class UnitOfWork(DataContext dataContext) : IUnitOfWork
    {
        private IDbContextTransaction? transaction;
       
        public async Task BeginAsync()
        {
            transaction = await dataContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (transaction is null)
                throw new InvalidOperationException("Transação não iniciada.");

            await transaction.CommitAsync();
        }
               
        public async Task RollbackAsync()
        {
            if (transaction is null)
                throw new InvalidOperationException("Transação não iniciada.");

            await transaction.RollbackAsync();
        }

        public async Task SaveChanges()
        {
            await dataContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (transaction is not null)
            {
                await transaction.DisposeAsync();
            }

            await dataContext.DisposeAsync();
            GC.SuppressFinalize(this);
        }


        public IClienteRepository ClienteRepository => new ClienteRepository(dataContext);

        public IPedidoRepository PedidoRepository => new PedidoRepository(dataContext);

    }
}
