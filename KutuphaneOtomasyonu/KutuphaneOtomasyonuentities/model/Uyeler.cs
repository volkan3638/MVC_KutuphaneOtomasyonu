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
    [Validator(typeof(ÜyelerValidation))]
    public class Uyeler
    {
        public int Id { get; set; }
        public string adısoyadı { get; set; }
        public string telefon { get; set; }
        public string adres { get; set; }
        public string email { get; set; }
        public string Resim { get; set; }
        public int OkunanKitapsayisi { get; set; }
        public DateTime kayıttarihi { get; set; }
        public List<EmanetKitaplar> EmanetKitaplars { get; set; }
    }
}
