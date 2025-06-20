using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class RollerValidation:AbstractValidator<Roller>
    {
        public RollerValidation()
        {
           

           
            RuleFor(x => x.rol).NotEmpty().WithMessage("Rol Alanı Boş Bırakılamaz. ");
            RuleFor(x => x.rol).MaximumLength(20).WithMessage("Rol Alanı En Fazla 20 Karakter Olabilir. ");
        }
    }
}
