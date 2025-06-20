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
    public class İletişimMap:EntityTypeConfiguration<İletişim>
    {
        public İletişimMap()
        {
            this.ToTable("İletişim");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.adsoyad).IsRequired().HasMaxLength(100);
            this.Property(x => x.email).IsRequired().HasMaxLength(150);
            this.Property(x => x.baslık).IsRequired().HasMaxLength(100);
            this.Property(x => x.mesaj).IsRequired().HasMaxLength(500);
            this.Property(x => x.acıklama).HasMaxLength(5000);

        }
    }
}
