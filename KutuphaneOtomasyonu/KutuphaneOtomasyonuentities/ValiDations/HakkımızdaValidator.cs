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
    public class HakkımızdaValidator : AbstractValidator<Hakkımızda>
    {
        public HakkımızdaValidator()
        {
            RuleFor(x => x.icerik).NotEmpty().WithMessage("İçerik Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.icerik).MaximumLength(500).WithMessage("İçerik Alanı En Fazla 500 Karakter olmalı . ");
        }
    }
}
