using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class KitapHareketleriValidation:AbstractValidator<kitaphareketleri>
    {
        public KitapHareketleriValidation()
        {
            RuleFor(x => x.yapılanislem).MaximumLength(150).WithMessage("Yapılan İşlem Alanı En Fazla 150 Karakter Olabilir. ");
        }
    }
}
