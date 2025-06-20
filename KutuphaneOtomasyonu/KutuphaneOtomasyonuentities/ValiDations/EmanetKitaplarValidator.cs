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
    public class EmanetKitaplarValidator : AbstractValidator<EmanetKitaplar>
    {
        public EmanetKitaplarValidator()
        {
            
        }
    }
}
