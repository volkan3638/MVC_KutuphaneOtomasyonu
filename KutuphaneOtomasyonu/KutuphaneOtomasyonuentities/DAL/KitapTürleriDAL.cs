using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.Repository;

namespace KutuphaneOtomasyonuentities.DAL
{
    public class KitapTürleriDAL : GecericReposoriy<KutuphaneContext, KitapTürleri>
    {
        public static void InstertorUpdate(KutuphaneContext context, KitapTürleri kitapTürleri)
        {
            throw new NotImplementedException();
        }
    }
}
