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
    internal class HakkımızdaMap:EntityTypeConfiguration<Hakkımızda>
    {
        public HakkımızdaMap()
        {
            this.ToTable("Hakkımızda");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x=>x.icerik).IsRequired().HasMaxLength(500);
            this.Property(x=>x.acıklama).HasMaxLength(5000);

        }
    }
}
