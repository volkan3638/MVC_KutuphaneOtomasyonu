using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneOtomasyonuentities.Repository;
using Kütüphaneotomasyonu.entities.Model.context;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.DAL
{
    public class RollerDAL: GecericReposoriy<KutuphaneContext, Roller>
    {
        public void InsertOrUpdate(Roller entity)
        {
            using (var context = new KutuphaneContext())
            {
                var existing = context.rollers.FirstOrDefault(r => r.Id == entity.Id);

                if (existing == null)
                {
                    // Kayıt yoksa ekle
                    context.rollers.Add(entity);
                }
                else
                {
                    // Kayıt varsa güncelle
                    context.Entry(existing).CurrentValues.SetValues(entity);
                }

                context.SaveChanges();
            }
        }
    }
}
