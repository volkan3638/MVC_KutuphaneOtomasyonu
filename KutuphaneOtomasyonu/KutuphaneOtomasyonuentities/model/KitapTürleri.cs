using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Attributes;
using KutuphaneOtomasyonuentities.ValiDations;

namespace Kütüphaneotomasyonu.entities.Model
{
    [Validator(typeof(KitapTurleriValidation))]
    [Table("KitapTürleri")]
    public class KitapTürleri
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Kitapturu { get; set; }
        [StringLength(500)]
        public string Acıklama { get; set; }
        public string sınav { get; set; }
        public List<Kitaplar> Kitaplars { get; set; }

      
    }
}

