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
    public class KullanıcıHareketleriMap:EntityTypeConfiguration<KullanıcıHareketleri>
    {
        public KullanıcıHareketleriMap()
        {
            this.ToTable("Kullanıcı Hareketleri");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Acıklama).HasMaxLength(5000);

            this.HasRequired(x => x.kullanıcılar).WithMany(x => x.KullanıcıHareketleris).HasForeignKey(x=>x.kullanıcıId);
        }
    }
}
