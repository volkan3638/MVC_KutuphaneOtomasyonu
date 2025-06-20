using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FluentValidation.Attributes;
using KutuphaneOtomasyonuentities.ValiDations;

namespace Kütüphaneotomasyonu.entities.Model
{
    [Validator(typeof(EmanetKitaplarValidator))]
    public class EmanetKitaplar
    {
        
        public int Id { get; set; }
        public int UyeId { get; set; }
        public int KitapId { get; set; }
        public int kitapsayiyi { get; set; }
        public DateTime Kitapaldıgıtarih { get; set; }
        public DateTime? kitapiadetarihi { get; set; }


        public Kitaplar Kitaplar { get; set; }
        public Uyeler uyeler { get; set; }
    }
}
