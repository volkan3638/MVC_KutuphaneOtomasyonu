using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using KutuphaneOtomasyonuentities.ValiDations;

namespace Kütüphaneotomasyonu.entities.Model
{
    [Validator(typeof(HakkımızdaValidator))]
    public class Hakkımızda
    {
        public int Id { get; set; }
        public string icerik { get; set; }
        public string acıklama { get; set; }
    }
}
