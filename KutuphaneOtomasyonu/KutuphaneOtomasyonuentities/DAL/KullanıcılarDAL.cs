using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using KutuphaneOtomasyonuentities.Repository;
using Kütüphaneotomasyonu.entities.Model.context;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.DAL
{
    public class KullanıcılarDAL : GecericReposoriy<KutuphaneContext, Kullanıcılar>
    {
        public static void InsertOrUpdate(KutuphaneContext context, Kullanıcılar entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (entity.Id == 0)
            {
                // Yeni kayıt
                context.kullanıcılars.Add(entity);
            }
            else
            {
                // Güncelleme için önce veritabanından eski kayıt alınır
                var mevcut = context.kullanıcılars.Find(entity.Id);

                if (mevcut == null)
                    throw new Exception("Güncellenecek kullanıcı bulunamadı.");

                // Değerleri eski kayıt üzerine kopyala
                context.Entry(mevcut).CurrentValues.SetValues(entity);
            }
        }


        public static void Save(KutuphaneContext context)
        {
            context.SaveChanges();
        }

       

    }
}
