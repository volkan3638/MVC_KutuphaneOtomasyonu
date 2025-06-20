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
    public class KitapTurleriMap:EntityTypeConfiguration<KitapTürleri>
    {
        public KitapTurleriMap()
        {
            this.ToTable("Kitap Türleri");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Kitapturu).IsRequired().HasMaxLength(100);
            this.Property(x => x.Acıklama).HasMaxLength(5000);

        }
    }
}
