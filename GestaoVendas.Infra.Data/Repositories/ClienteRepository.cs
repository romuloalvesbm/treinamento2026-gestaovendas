using GestaoVendas.Domain.Entitieis;
using GestaoVendas.Domain.Ports.Repositories;
using GestaoVendas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GestaoVendas.Infra.Data.Repositories
{
    public class ClienteRepository(DataContext dataContext) : BaseRepository<Cliente, int>(dataContext), IClienteRepository
    {
        public override async Task<ICollection<Cliente>> GetAllAsync(int skip, int take, Expression<Func<Cliente, bool>> where)
        {
            return await dataContext.Clientes
                                    .Include(x => x.Pedidos)
                                    .Where(where)
                                    .Skip(skip).Take(take)
                                    .ToListAsync();
        }

        public override async Task<Cliente?> GetByIdAsync(int id)
        {
            return await dataContext.Clientes
                                    .Include(x => x.Pedidos)
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
