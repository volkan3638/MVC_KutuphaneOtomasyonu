using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class KitaplarValidator :AbstractValidator<Kitaplar>
    {
        public KitaplarValidator()
        {
            RuleFor(x => x.BarkodId).MaximumLength(30).WithMessage("BarkodId Alanı En fazla 30 Karakter Olabilir. ");
            RuleFor(x => x.BarkodId).NotEmpty().WithMessage("BarkodId Alanı Boş Geçilemez. ");
            RuleFor(x => x.Kitapadı).MaximumLength(100).WithMessage("KitapAdı Alanı En fazla 100 Karakter Olabilir. ");
            RuleFor(x => x.Kitapadı).NotEmpty().WithMessage("KitapId Alanı Boş Geçilemez. ");
            RuleFor(x => x.yazarı).MaximumLength(100).WithMessage("Yazarı Alanı En fazla 100 Karakter Olabilir. ");
            RuleFor(x => x.yazarı).NotEmpty().WithMessage("Yazarı Alanı Boş Geçilemez. ");
            RuleFor(x => x.yayınevi).MaximumLength(150).WithMessage("Yayınevi Alanı En fazla 150 Karakter Olabilir. ");
            RuleFor(x => x.yayınevi).NotEmpty().WithMessage("Yayınevi Alanı Boş Geçilemez. ");

        }
    }
}
