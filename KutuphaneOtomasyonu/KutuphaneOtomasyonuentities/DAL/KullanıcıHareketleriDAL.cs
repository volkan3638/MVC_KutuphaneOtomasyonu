using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneOtomasyonuentities.Repository;
using Kütüphaneotomasyonu.entities.Model.context;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.Mapping
{
    public class KullanıcıHareketleriDAL : GecericReposoriy<KutuphaneContext, KullanıcıHareketleri>
    {
        KutuphaneContext context = new KutuphaneContext();
        public object AylikVeriler;
        public object ToplamKHGSayisi;
        public object AltiAylikToplamKHGSayisi;
        public object KullanicilarHareketleriGozlemleme()
        {
            DateTime altiAyOnce = DateTime.Now.AddMonths(-6);
            AylikVeriler = context.kullanıcıHareketleris.Where(x => x.tarih >= altiAyOnce)
                .GroupBy(a => new
                {
                    Ay = a.tarih.Month,
                    Yil = a.tarih.Year
                }).Select(b => new
                {
                    Ay = b.Key.Ay,
                    Yil = b.Key.Yil,
                    HareketSayisi = b.Count()
                }).OrderBy(a => a.Yil).ThenBy(y => y.Ay).ToList();

            ToplamKHGSayisi = context.kullanıcıHareketleris.Count();
            AltiAylikToplamKHGSayisi = context.kullanıcıHareketleris.Count(x => x.tarih >= altiAyOnce);

            return AylikVeriler;
        }

        public (string KullanıcıAdı,int GirisSayısı) Kullanıcıgirissayilari()
        {
            var result = context.Set<KullanıcıHareketleri>().GroupBy(x => new { x.kullanıcıId, x.kullanıcılar.Kullanıcıadı }).
                Select(y => new
                {
                    KullanıcıAdi=y.Key.Kullanıcıadı,
                    GirisSayısı=y.Count()
 
                }).OrderByDescending(w=>w.GirisSayısı).FirstOrDefault();
            if(result != null)
            {
                return (result.KullanıcıAdi, result.GirisSayısı);
            }
            return (null, 0);//varsayılan değer
        }
        

        public void InsertOrUpdate(KullanıcıHareketleri entity)
        {
            using (var context = new KutuphaneContext())
            {
                var existing = context.kullanıcıHareketleris.FirstOrDefault(x => x.Id == entity.Id);
                if (existing == null)
                {
                    context.kullanıcıHareketleris.Add(entity);
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
