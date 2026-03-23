using GestaoVendas.Domain.Ports.Repositories;
using GestaoVendas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;

namespace GestaoVendas.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>(DataContext dataContext) : IBaseRepository<TEntity, TKey>
    where TEntity : class
    {
        public async Task AddAsync(TEntity entity)
        {
            await dataContext.AddAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            dataContext.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            dataContext.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<ICollection<TEntity>> GetAllAsync(int skip, int take, Expression<Func<TEntity, bool>> where)
        {
            return await dataContext.Set<TEntity>()
                                    .Where(where)
                                    .Skip(skip).Take(take)
                                    .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await dataContext.Set<TEntity>()
                                    .FindAsync(id);
        }
        
        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return dataContext.Set<TEntity>()
                              .FirstOrDefaultAsync(where);
        }        

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dataContext.Set<TEntity>()
                                    .AnyAsync(where);
        }
        public async ValueTask DisposeAsync()
        {
            await dataContext.DisposeAsync();
            GC.SuppressFinalize(this);
        }        
    }
}
