﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.ValiDations
{
    public class KullanıcıRolleriValidation:AbstractValidator<Kullanıcırolleri>
    {
        public KullanıcıRolleriValidation()
        {
            
        }
    }
}
