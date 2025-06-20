using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class ÜyelerValidation :AbstractValidator<Uyeler>
    {
        public ÜyelerValidation()
        {

            RuleFor(x => x.email).NotEmpty().WithMessage("Email Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.email).MaximumLength(150).WithMessage("Email Alanı En Fazla 150 Karakter Olabilir. ");

            RuleFor(x => x.adres).NotEmpty().WithMessage("Adres Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.adres).MaximumLength(500).WithMessage("Adres Alanı En Fazla 500 Karakter Olabilir. ");

            RuleFor(x => x.telefon).NotEmpty().WithMessage("Telefon Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.telefon).MaximumLength(11).WithMessage("Telefon Alanı En Fazla 11 Karakter Olabilir. ");

            RuleFor(x => x.adısoyadı).NotEmpty().WithMessage("AdSoyad Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.adısoyadı).MaximumLength(100).WithMessage("AdSoyad Alanı En Fazla 100 Karakter Olabilir. ");
        }
    }
}
