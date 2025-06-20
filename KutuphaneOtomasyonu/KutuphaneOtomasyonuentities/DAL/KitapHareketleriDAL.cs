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
    public class KitapHareketleriDAL:GecericReposoriy<KutuphaneContext,kitaphareketleri>
    {

        
    KutuphaneContext context = new KutuphaneContext();
        public object AylikVeriler;
        public object ToplamKHGSayisi;
        public object AltiAylikToplamKHGSayisi;

        public (string KullaniciAdi, int GirisSayisi) KullaniciGirisSayilari()
        {
            var result = context.Set<KullanıcıHareketleri>().GroupBy(x => new { x.kullanıcıId, x.kullanıcılar.Kullanıcıadı })
                .Select(y => new
                {
                    KullaniciAdi = y.Key.Kullanıcıadı,
                    GirisSayisi = y.Count()
                })
                .OrderByDescending(w => w.GirisSayisi).FirstOrDefault();

            if (result != null)
            {
                return (result.KullaniciAdi, result.GirisSayisi);
            }

            return (null, 0); // Varsayılan değer
        }
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



        public void InsertOrUpdate(KutuphaneContext context, kitaphareketleri entity)
        {
            var mevcut = context.kitaphareketleris.FirstOrDefault(x => x.Id == entity.Id);
            if (mevcut == null)
            {
                context.kitaphareketleris.Add(entity);
            }
            else
            {
                context.Entry(mevcut).CurrentValues.SetValues(entity);
            }
        }
    }
}
