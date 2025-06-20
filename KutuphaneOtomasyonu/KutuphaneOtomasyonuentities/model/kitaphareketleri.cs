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
    [Validator(typeof(KitapHareketleriValidation))]
    public class kitaphareketleri
    {
        public int Id { get; set; }
        public int kullanıciId { get; set; }
        public int UyeId { get; set; }
        public int KitapId { get; set; }
        public string yapılanislem { get; set; }
        public DateTime tarih { get; set; }

        public Kitaplar Kitaplar { get; set; }

    }
}
