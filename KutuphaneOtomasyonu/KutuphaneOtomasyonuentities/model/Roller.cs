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
    [Validator(typeof(RollerValidation))]
    public class Roller
    {
        public int Id { get; set; }
        public string rol { get; set; }

        public List<Kullanıcırolleri> Kullanıcırolleris { get; set; }
    }
}
