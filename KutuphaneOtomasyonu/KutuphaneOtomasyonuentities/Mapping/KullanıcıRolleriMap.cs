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
    public class KullanıcıRolleriMap:EntityTypeConfiguration<Kullanıcırolleri>
    {
        public KullanıcıRolleriMap()
        {
            this.ToTable("Kullanıcı Rolleri");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(x => x.kullanıcılar).WithMany(x => x.Kullanıcırolleris).HasForeignKey(x => x.kullanıcıId);
            this.HasRequired(x => x.Roller).WithMany(x => x.Kullanıcırolleris).HasForeignKey(x => x.rolId);
        }
    }
}
