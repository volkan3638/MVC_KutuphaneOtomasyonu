using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;

namespace KutuphaneOtomasyonuentities.InterFaces
{
    public interface IGenericRepository<TContext, TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null, params string[] tbl );
        TEntity GetByFilter(TContext ccontext, Expression<Func<TEntity, bool>> filter, params  string[]tbl);
        TEntity GetById(TContext ccontext, int? id);

        void insert(TContext ccontext, TEntity entity);
        void update(TContext ccontext, TEntity entity);
        void delete(TContext ccontext, Expression<Func<TEntity, bool>> filter);

        void save(TContext ccontext);
    }
}
