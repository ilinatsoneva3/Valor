using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IT.Valor.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IT.Valor.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationDbContext Context => _dbContext as ApplicationDbContext;

        public async Task<TEntity> GetByIdAsync(string id)
            => await Context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> GetByIdAsync(Guid id)
           => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await Context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
            => await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await Context.Set<TEntity>().Where(predicate).ToListAsync();

        public void Add(TEntity entity)
            => Context.Set<TEntity>().Add(entity);

        public void Update(TEntity entity)
            => Context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
            => Context.Set<TEntity>().Remove(entity);

        public void AddRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AddRange(entities);

        public void UpdateRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().UpdateRange(entities);

        public void DeleteRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().RemoveRange(entities);

        public async Task SaveChangesAsync()
            => await Context.SaveChangesAsync();
    }
}
