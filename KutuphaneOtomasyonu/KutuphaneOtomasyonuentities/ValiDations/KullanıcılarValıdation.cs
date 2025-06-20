using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class KullanıcılarValıdation:AbstractValidator<Kullanıcılar>
    {
        public KullanıcılarValıdation()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("Email Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.email).MaximumLength(150).WithMessage("Email Alanı En Fazla 150 Karakter olmalı . ");
            RuleFor(x => x.email).EmailAddress().WithMessage("Lüten Bir Mail Afresi Formatı Giriniz. ");



            RuleFor(x => x.adısoyadı).NotEmpty().WithMessage("AdıSoyadı Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.adısoyadı).MaximumLength(100).WithMessage("AdıSoyadı Alanı En Fazla 100 Karakter Olabilir. ");
            RuleFor(x => x.Kullanıcıadı).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.Kullanıcıadı).MaximumLength(200).WithMessage("Kullanıcı Adı  Alanı En Fazla 200 Karakter Olabilir. ");
            RuleFor(x => x.sifre).NotEmpty().WithMessage("Şifre Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.sifre).MaximumLength(500).WithMessage("Şifre Alanı En Fazla 500 Karakter Olabilir. ");
            RuleFor(x => x.telefon).NotEmpty().WithMessage("Telefon Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.telefon).MaximumLength(20).WithMessage("Telefon Alanı En Fazla 20 Karakter Olabilir. ");
            RuleFor(x => x.adres).NotEmpty().WithMessage("Adres Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.adres).MaximumLength(500).WithMessage("Adres Alanı En Fazla 500 Karakter Olabilir. ");
        }
    }
}
