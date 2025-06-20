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
    public class UyelerMap:EntityTypeConfiguration<Uyeler>
    {
        public UyelerMap()
        {
            this.ToTable("Uyeler");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.adısoyadı).IsRequired().HasMaxLength(60);
            this.Property(x => x.email).IsRequired().HasMaxLength(60);
            this.Property(x => x.telefon).IsRequired().HasMaxLength(60);
            this.Property(x => x.adres).HasMaxLength(500);

        }
    }
}
