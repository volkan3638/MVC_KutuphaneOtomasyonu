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

    public class UyelerDAL : GecericReposoriy<KutuphaneContext, Uyeler>
    {
        KutuphaneContext context = new KutuphaneContext();

        public string EnCokUye;
        public string EnAzUye;
        public int EnCokSayi;
        public int EnAzSayi;
       
        public object UyeKitapIslemleri()
        {
            var enCokOkuyan = context.uyelers.OrderByDescending(x => x.OkunanKitapsayisi).FirstOrDefault();
            var enAzOkuyan = context.uyelers.OrderBy(x => x.OkunanKitapsayisi).FirstOrDefault();

            EnCokUye = enCokOkuyan?.adısoyadı;
            EnAzUye = enAzOkuyan?.adısoyadı;

            EnCokSayi = enCokOkuyan?.OkunanKitapsayisi ?? 0;
            EnAzSayi = enAzOkuyan?.OkunanKitapsayisi ?? 0;

            double toplamkitap = context.uyelers.Sum(x => x.OkunanKitapsayisi);

            var top3 = context.uyelers
                .OrderByDescending(x => x.OkunanKitapsayisi)
                .Take(3)
                .Select(x => new
                {
                    adısoyadı = x.adısoyadı,
                    okunankitapsayisi = x.OkunanKitapsayisi,
                    yuzde = Math.Round((double)x.OkunanKitapsayisi / toplamkitap * 100, 2)
                })
                .ToList();

            return top3;
        }


        public void InsertOrUpdate(Uyeler uye)
        {
            using (var context = new KutuphaneContext())
            {
                var existingUye = context.uyelers.FirstOrDefault(u => u.Id == uye.Id);
                if (existingUye != null)
                {
                    // Güncelle
                    context.Entry(existingUye).CurrentValues.SetValues(uye);
                }
                else
                {
                    // Ekle
                    context.uyelers.Add(uye);
                }
                context.SaveChanges();
            }
        }
    }
}
