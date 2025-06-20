using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model.context;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class DuyurularValidation:AbstractValidator<Duyurular>
    {
        public DuyurularValidation()
        {
            RuleFor(x => x.Başlık).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez");
            RuleFor(x => x.Duyuru).NotEmpty().WithMessage("Duyuru Alanı Boş Geçilemez");
            RuleFor(x => x.Tarih).NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez");
            RuleFor(x => x.Başlık).Length(5, 150).WithMessage("Başlık alanı 5-150 Karakter Arasında olmalıdır");
            RuleFor(x => x.Başlık).MaximumLength(500).WithMessage("Duyuru alanı en fazla 500 karakter olmalı ");
            RuleFor(x => x.Acıklama).MaximumLength(5000).WithMessage("Açıklama alanı en fazla 5000 karakter olmalı ");
      
        }
    }
}
