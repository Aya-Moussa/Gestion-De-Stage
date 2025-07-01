using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<string> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        Task<T> GetAsync(
            Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        Task<IEnumerable<T>> GetListAsync(
            Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        Task<string> UpdateAsync(T entity);
        Task<string> UpdatePartialAsync(Guid id, Action<T> updateAction);

        Task<string> RemoveAsync(Guid id);
        Task<string> RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> ExecuteStoreQueryAsync(string commandText, params object[] parameters);
        Task<IEnumerable<T>> ExecuteStoreQueryAsync(
            string commandText,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
    }
}
