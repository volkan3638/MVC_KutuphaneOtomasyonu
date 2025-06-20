using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FluentValidation.Attributes;
using KutuphaneOtomasyonuentities.ValiDations;
using KutuphaneOtomasyonuentities.Migrations;
using KutuphaneOtomasyonuentities.model;

namespace Kütüphaneotomasyonu.entities.Model
{
    [Validator(typeof(KitaplarValidator))]
    public class Kitaplar
    {
        public int Id { get; set; }
        public string BarkodId { get; set; }
        public int kitapturuId { get; set; }
        public int? YayıneviId { get; set; }  // <-- Buraya ekleyeceksin (Kitaplar modelinde)
        public virtual Yayınevi Yayınevleri { get; set; } // Navigation property

        public string Kitapadı { get; set; }
        public string yazarı { get; set; }
        public string yayınevi { get; set; }
        public int stokadedi { get; set; }
        public int sayfasayısı { get; set; }
        public string acıklama { get; set; }
        public string sınav { get; set; }


        public DateTime eklenmetarihi { get; set; } = DateTime.Now;
        public DateTime guncellemetarihi { get; set; } = DateTime.Now;
        public bool silindimi { get; set; } = false;
        public KitapTürleri KitapTürleri { get; set; }//Tekil Adlandırma
        public List<EmanetKitaplar> EmanetKitaplars { get; set; }
        public List<kitaphareketleri> Kitaphareketleris { get; set; }
        public List<KitapKayıtHareketleri> KitapKayıtHareketleris { get; set; }
        
    }
}