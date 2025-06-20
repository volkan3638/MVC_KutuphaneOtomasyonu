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
    public class EmanetKitaplarDal:GecericReposoriy<KutuphaneContext,EmanetKitaplar>
    {
        public void InsertOrUpdate(KutuphaneContext context, EmanetKitaplar entity)
        {
            var existingEntity = context.emanetKitaplars.FirstOrDefault(x => x.Id == entity.Id);

            if (existingEntity == null)
            {
                context.emanetKitaplars.Add(entity); // Insert
            }
            else
            {
                context.Entry(existingEntity).CurrentValues.SetValues(entity); // Update
            }

            context.SaveChanges();
        }
    }
}
