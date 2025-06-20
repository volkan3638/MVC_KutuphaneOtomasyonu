using System;
using System.Linq;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.Repository;

namespace KutuphaneOtomasyonuentities.DAL
{
    public class KitapKayıtHareketleriDAL : GecericReposoriy<KutuphaneContext, KitapKayıtHareketleri>
    {
        public void InsertOrUpdate(KitapKayıtHareketleri entity)
        {
            using (var context = new KutuphaneContext())
            {
                var existing = context.kitapKayıtHareketleris.FirstOrDefault(x => x.Id == entity.Id);
                if (existing == null)
                {
                    context.kitapKayıtHareketleris.Add(entity);
                }
                else
                {
                    context.Entry(existing).CurrentValues.SetValues(entity);
                }

                context.SaveChanges();
            }
        }
    }
}
