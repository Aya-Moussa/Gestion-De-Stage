using DOMAIN.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return "Add succeeded";
            }
            catch (Exception ex)
            {
                return $"Add failed: {ex.Message}";
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                query = includes(query);

            return condition != null
                ? await query.FirstOrDefaultAsync(condition)
                : await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(
            Expression<Func<T, bool>> condition = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                query = includes(query);

            return condition != null
                ? await query.Where(condition).ToListAsync()
                : await query.ToListAsync();
        }

        public async Task<string> UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return "Update succeeded";
            }
            catch (Exception ex)
            {
                return $"Update failed: {ex.Message}";
            }
        }

        public async Task<string> UpdatePartialAsync(Guid id, Action<T> updateAction)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
                return "Entity not found";

            updateAction(entity); // appliquer les modifications

            await _context.SaveChangesAsync();
            return "Partial update succeeded";
        }


        public async Task<string> RemoveAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
                return "Entity not found";

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return "Remove succeeded";
        }

        public async Task<string> RemoveAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return "Remove succeeded";
            }
            catch (Exception ex)
            {
                return $"Remove failed: {ex.Message}";
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity != null ? new List<T> { entity } : new List<T>();
        }

        public Task<IEnumerable<T>> ExecuteStoreQueryAsync(string commandText, params object[] parameters)
        {
            // Optional: Implement raw SQL if needed
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ExecuteStoreQueryAsync(
            string commandText,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            // Optional: Implement raw SQL with includes if needed
            throw new NotImplementedException();
        }
    }
}