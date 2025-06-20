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
    [Validator(typeof(KitapKayıtHareketleriValidation))]
    public class KitapKayıtHareketleri
    {
        public int Id { get; set; }
        public int KullanıcıId { get; set; }
        public int KitapId { get; set; }
        public string yapılanislem { get; set; }
        public string acıklama { get; set; }
        public DateTime tarih { get; set; }
        public Kitaplar Kitaplar { get; set; }
    }
}
