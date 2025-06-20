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
    public class EmanetKitaplarMap:EntityTypeConfiguration<EmanetKitaplar>
    {
        public EmanetKitaplarMap()
        {
            this.ToTable("Emanet Kitaplar");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            this.HasRequired(x=>x.Kitaplar).WithMany(x=>x.EmanetKitaplars).HasForeignKey(x=>x.KitapId);
            this.HasRequired(x => x.uyeler).WithMany(x => x.EmanetKitaplars).HasForeignKey(x => x.UyeId);
        }
    }
}
