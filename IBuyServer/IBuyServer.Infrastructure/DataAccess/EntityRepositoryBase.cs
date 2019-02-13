using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public List<TEntity> GetAll()
        {
            return GetAll(null);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            var query = EntitiesDbSet.AsNoTracking();
            if (filter == null)
            {
                return query.ToList<TEntity>();
            }
            return query.Where<TEntity>(filter).ToList<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            TEntity entity = EntitiesDbSet.Find(id);
            if (entity == null)
            {
                throw new ResourceNotFoundException(id);
            }
            return entity;
        }

        public TEntity Add(TEntity entity)
        {
            EntitiesDbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity updated)
        {
            TEntity current = GetById(updated.Id);
            Context.Entry(current).CurrentValues.SetValues(updated);
            Context.SaveChanges();
            return updated;
        }

        public Guid Delete(Guid id)
        {
            TEntity entity = GetById(id);
            EntitiesDbSet.Remove(entity);
            Context.SaveChanges();
            return id;
        }

    }
}
