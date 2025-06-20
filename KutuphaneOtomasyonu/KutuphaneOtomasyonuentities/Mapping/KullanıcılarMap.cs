using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kütüphaneotomasyonu.entities.Model;

namespace KutuphaneOtomasyonuentities.Mapping
{
    public class KullanıcılarMap:EntityTypeConfiguration<Kullanıcılar>
    {
        public KullanıcılarMap()
        {
            this.ToTable("Kullanıcılar");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Kullanıcıadı).IsRequired().HasMaxLength(100);
            this.Property(x => x.sifre).IsRequired().HasMaxLength(150);
            this.Property(x => x.email).IsRequired().HasMaxLength(100);
            this.Property(x => x.adısoyadı).IsRequired().HasMaxLength(100);
            this.Property(x => x.telefon).IsRequired().HasMaxLength(500);
            this.Property(x => x.adres).HasMaxLength(5000);

            
        }
    }
}
