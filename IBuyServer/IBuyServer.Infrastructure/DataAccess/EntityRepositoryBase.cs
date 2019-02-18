using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IBuyServer.Infrastructure.DataAccess.Exceptions;

namespace IBuyServer.Infrastructure.DataAccess
{
    public class EntityRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : EntityBase
        where TContext : DbContext
    {
        protected TContext Context;
        protected DbSet<TEntity> EntitiesDbSet;

        public EntityRepositoryBase(TContext context)
        {
            Context = context;
            EntitiesDbSet = Context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await GetAll(null);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            var query = EntitiesDbSet.AsNoTracking();
            if (filter == null)
            {
                return query.ToList<TEntity>();
            }
            return await query.Where<TEntity>(filter).ToListAsync<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            TEntity entity = await EntitiesDbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ResourceNotFoundException(id);
            }
            return entity;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            EntitiesDbSet.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity updated)
        {
            TEntity current = await GetById(updated.Id);
            Context.Entry(current).CurrentValues.SetValues(updated);
            await Context.SaveChangesAsync();
            return updated;
        }

        public async Task<Guid> Delete(Guid id)
        {
            TEntity entity = await GetById(id);
            EntitiesDbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return id;
        }

    }
}
