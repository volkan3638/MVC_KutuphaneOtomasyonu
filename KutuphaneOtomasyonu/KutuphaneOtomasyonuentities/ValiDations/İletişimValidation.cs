using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class İletişimValidation : AbstractValidator<İletişim>
    {
        public İletişimValidation()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("Email Alanı Boş Bırakılamaz. "); 
            RuleFor(x => x.email).MaximumLength(150).WithMessage("Email Alanı En Fazla 150 Karakter olmalı . ");
            RuleFor(x => x.email).EmailAddress().WithMessage("Lüten Bir Mail Afresi Formatı Giriniz. ");



            RuleFor(x => x.adsoyad).NotEmpty().WithMessage("AdıSoyadı Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.adsoyad).MaximumLength(100).WithMessage("AdıSoyadı Alanı En Fazla 100 Karakter Olabilir. ");
            RuleFor(x => x.baslık).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.baslık).MaximumLength(200).WithMessage("Başlık Alanı En Fazla 200 Karakter Olabilir. ");
            RuleFor(x => x.mesaj).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.mesaj).MaximumLength(500).WithMessage("Mesaj Alanı En Fazla 500 Karakter Olabilir. ");
        }
    }
}
