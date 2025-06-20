using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; // Eğer EF kullanıyorsan
using KutuphaneOtomasyonuentities.Repository;
using Kütüphaneotomasyonu.entities.Model.context;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.DAL
{
    public class KullanıcıRolleriDAL : GecericReposoriy<KutuphaneContext, Kullanıcırolleri>
    {
        public void InsertOrUpdate(KutuphaneContext context, Kullanıcırolleri entity)
        {
            var mevcut = this.GetAll(context)
                             .FirstOrDefault(x => x.kullanıcıId == entity.kullanıcıId && x.rolId == entity.rolId);

            if (mevcut == null)
            {
                this.insert(context, entity);
            }
            else
            {
                mevcut.rolId = entity.rolId;
                this.update(context, mevcut);
            }
        }

        public List<Kullanıcırolleri> GetByFilter(KutuphaneContext context, Func<Kullanıcırolleri, bool> filter, string[] includes = null)
        {
            IQueryable<Kullanıcırolleri> query = context.kullanıcırolleris;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter).AsQueryable();
            }

            return query.ToList();
        }
    }
}
