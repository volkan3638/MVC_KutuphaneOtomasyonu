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
    public class KitapHareketleriMap:EntityTypeConfiguration<kitaphareketleri>
    {
        public KitapHareketleriMap()
        {
            this.ToTable("Kitap Hareketleri");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.yapılanislem).IsRequired().HasMaxLength(160);


            this.HasRequired(x=>x.Kitaplar).WithMany(x=>x.Kitaphareketleris).HasForeignKey(x => x.KitapId);

        }
    }
}
