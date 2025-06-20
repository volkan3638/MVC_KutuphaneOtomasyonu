using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kütüphaneotomasyonu.entities.Model;
using System.Web.Mvc;



namespace KutuphaneOtomasyonuentities.model.viewModel
{
    public class Kitapekleviewmodel
    {
       
            public Kitaplar Kitap { get; set; }

            public List<int> SecilenTurler { get; set; } // Seçilen türlerin Id'leri

            public MultiSelectList Turler { get; set; } // Çoklu seçim listesi
        

    }
}
