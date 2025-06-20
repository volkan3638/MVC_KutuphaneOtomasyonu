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
    [Validator(typeof(KullanıcıHareketleriValidatior))]
    public class KullanıcıHareketleri
    {
        public int Id { get; set; }
        public int kullanıcıId { get; set; }
        public string Acıklama { get; set; }
        public DateTime tarih { get; set; }
        public int islemyapan { get; set; }

        public Kullanıcılar kullanıcılar { get; set; }
    }
}
