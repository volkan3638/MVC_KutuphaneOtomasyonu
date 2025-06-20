using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class KitapTurleriValidation :AbstractValidator<KitapTürleri>
    {
        public KitapTurleriValidation()
        {
            RuleFor(x => x.Kitapturu).NotEmpty().WithMessage("Kitap Türü Alanı Boş Geçilemez. ");
            RuleFor(x => x.Kitapturu).MinimumLength(5).WithMessage("Kitap Türü Alanı 5 Karakterden Az Olmamalıdır. ");
            RuleFor(x => x.Kitapturu).MaximumLength(150).WithMessage("Kitap Türü  Alanı En fazla 150 Karakter Olabilir. ");
        }
    }
}
