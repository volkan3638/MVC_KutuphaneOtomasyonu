using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.model;

namespace KutuphaneOtomasyonuentities.DAL
{
    public class YayınEviDAL
    {
        public class YayıneviDAL
        {
            public List<Yayınevi> GetAll()
            {
                using (var context = new KutuphaneContext())
                {
                    return context.yayınevis.ToList();
                }
            }

            public Yayınevi GetById(int id)
            {
                using (var context = new KutuphaneContext())
                {
                    return context.yayınevis.Find(id);
                }
            }

            public void Add(Yayınevi yayınevi)
            {
                using (var context = new KutuphaneContext())
                {
                    context.yayınevis.Add(yayınevi);
                    context.SaveChanges();
                }
            }

            public void Update(Yayınevi yayınevi)
            {
                using (var context = new KutuphaneContext())
                {
                    var existing = context.yayınevis.Find(yayınevi.Id);
                    if (existing != null)
                    {
                        existing.Adı = yayınevi.Adı;
                        existing.Adres = yayınevi.Adres;
                        context.SaveChanges();
                    }
                }
            }

            public void Delete(int id)
            {
                using (var context = new KutuphaneContext())
                {
                    var yayınevi = context.yayınevis.Find(id);
                    if (yayınevi != null)
                    {
                        context.yayınevis.Remove(yayınevi);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
