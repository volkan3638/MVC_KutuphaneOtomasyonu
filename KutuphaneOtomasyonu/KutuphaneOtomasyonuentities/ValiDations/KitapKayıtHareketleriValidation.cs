using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    internal class KitapKayıtHareketleriValidation:AbstractValidator<KitapKayıtHareketleri>
    {
        public KitapKayıtHareketleriValidation()
        {
            RuleFor(x => x.yapılanislem).NotEmpty().WithMessage("Yapılan İşlem En Fazla 150 Karakter Olabilir. ");
        }
    }
}
