using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GestaoVendas.Domain.Ports.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IAsyncDisposable
    where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);        
        Task<ICollection<TEntity>> GetAllAsync(int skip, int take, Expression<Func<TEntity, bool>> where);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where);
    }
}
