using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kütüphaneotomasyonu.entities.Model;


namespace KutuphaneOtomasyonuentities.model.viewModel
{
    public class KullaniciRolDuzenleViewModel
    {
        public int KullanıcıId { get; set; }
        public string KullanıcıAdSoyad { get; set; }
        public List<int> SeciliRolIdleri { get; set; }
        public List<Roller> TumRoller { get; set; }
    }
}
