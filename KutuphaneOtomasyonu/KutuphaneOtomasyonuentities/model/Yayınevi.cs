using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.model
{
    public class Yayınevi
    {
        [Key]
        public int Id { get; set; }
        public string Adı { get; set; }
        public string Adres { get; set; }

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }

    }

}

    