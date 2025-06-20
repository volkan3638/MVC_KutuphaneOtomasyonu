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
    public class KitaplarMap:EntityTypeConfiguration<Kitaplar>
    {
        public KitaplarMap()
        {
            this.ToTable("Kitaplar");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.BarkodId).IsRequired().HasMaxLength(30);
            this.Property(x => x.Kitapadı).IsRequired().HasMaxLength(100);
            this.Property(x => x.yazarı).IsRequired().HasMaxLength(100);
            this.Property(x => x.yayınevi).IsRequired().HasMaxLength(100);
            this.Property(x => x.acıklama).HasMaxLength(5000);


            this.HasRequired(x=>x.KitapTürleri).WithMany(x=>x.Kitaplars).HasForeignKey(x=>x.kitapturuId);
        }
    }
}
