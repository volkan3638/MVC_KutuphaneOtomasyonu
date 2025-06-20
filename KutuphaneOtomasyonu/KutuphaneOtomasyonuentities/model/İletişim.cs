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
    [Validator(typeof(İletişimValidation))]
    public class İletişim
    {
        public int Id { get; set; }
        public string adsoyad { get; set; }
        public string email { get; set; }
        public string baslık { get; set; }
        public string mesaj { get; set; }
        public string acıklama { get; set; }
        public DateTime tarih { get; set; }
    }
}
