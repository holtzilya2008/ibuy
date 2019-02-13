using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IBuyServer.Infrastructure.DataAccess
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(Guid id);

        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        Guid Delete(Guid id);
    }
}
