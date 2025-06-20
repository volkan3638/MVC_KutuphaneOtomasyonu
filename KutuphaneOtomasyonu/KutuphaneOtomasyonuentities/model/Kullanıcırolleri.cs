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
    [Validator(typeof(KullanıcıRolleriValidation))]
    public class Kullanıcırolleri
    {
        public int Id { get; set; }
        public int kullanıcıId { get; set; }
        public int rolId { get; set; }

        public Kullanıcılar kullanıcılar { get; set; }

        public Roller Roller { get; set; }

    }
}
