using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories.Base
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DbServiciotecnicoContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbServiciotecnicoContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Create
        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Create List
        public virtual async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        // Update
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Update List
        public virtual async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.AttachRange(entities);
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        // Get by ID
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Get by filter
        public virtual async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>>? filter = null)
        {
            if(filter is null)
                return await _dbSet.AsNoTracking().ToListAsync();

            return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).AsNoTracking().SingleOrDefaultAsync();
        }

        // Delete
        public virtual async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Delete List
        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<int> GetTableCount()
        {
            return await _dbSet.AsNoTracking().CountAsync();
        }
    }
}
