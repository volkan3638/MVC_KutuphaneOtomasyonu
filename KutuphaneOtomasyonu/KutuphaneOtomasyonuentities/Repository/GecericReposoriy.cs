using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using KutuphaneOtomasyonuentities.InterFaces;
using System.Text;
using System.Threading.Tasks;



namespace KutuphaneOtomasyonuentities.Repository
{
    public class GecericReposoriy<TContext, TEntity> : IGenericRepository<TContext, TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        public void delete(TContext ccontext, Expression<Func<TEntity, bool>> filter)
        {
            var model = ccontext.Set<TEntity>().FirstOrDefault(filter);
            if (model != null)
            {
                ccontext.Set<TEntity>().Remove(model);
            }
        }

        // GetAll metodu, belirtilen property'leri include eder.
        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null, params string[] tbl)
        {
            IQueryable<TEntity> query = context.Set< TEntity > ();
            foreach (var item in tbl)
            {
                if (filter != null)
                {
                    query = query.Where(filter).Include(item);
                }
                else
                {
                    query = query.Include(item);
                }
                  
            }
            return query.ToList ();

                
        }

        // GetByFilter metodu, belirtilen filtreyi uygular ve sonuçları döner.
        public TEntity GetByFilter(TContext ccontext, Expression<Func<TEntity, bool>> filter, params string[] tbl)
        {
            IQueryable<TEntity> query = ccontext.Set<TEntity>();

           foreach (var item in tbl)
            {
                query=query.Include(item);
            }
           return query.FirstOrDefault(filter);
            return query.FirstOrDefault(filter);
        }

        public TEntity GetById(TContext ccontext, int? id)
        {
            return ccontext.Set<TEntity>().Find(id);
        }

        public void insert(TContext ccontext, TEntity entity)
        {
            ccontext.Set<TEntity>().AddOrUpdate(entity);
        }

        public void update(TContext ccontext, TEntity entity)
        {
            ccontext.Entry(entity).State = EntityState.Modified;
        }

        public void save(TContext ccontext)
        {
            try
            {
                ccontext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
