using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.Repository;

namespace KutuphaneOtomasyonuentities.DAL
{
    public class İletişimDAL : GecericReposoriy<KutuphaneContext, İletişim>
    {
        public void InsertOrUpdate(İletişim entity)
        {
            using (var context = new KutuphaneContext())
            {
                var existingEntity = context.iletişims.Find(entity.Id); // ID'ye göre kontrol
                if (existingEntity == null)
                {
                    context.iletişims.Add(entity); // Yeni kayıt
                }
                else
                {
                    context.Entry(existingEntity).CurrentValues.SetValues(entity); // Güncelleme
                }
                context.SaveChanges();
            }
        }
    }
}
