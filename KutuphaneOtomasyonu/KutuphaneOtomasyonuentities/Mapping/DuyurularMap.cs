using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kütüphaneotomasyonu.entities.Model.context;

namespace KutuphaneOtomasyonuentities.Mapping
{
    public class DuyurularMap:EntityTypeConfiguration<Duyurular>
    {
        public DuyurularMap()
        {
            this.ToTable("Duyurular");
            this.HasKey(x => x.Id);//birincil anahtar
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//Otoarttan sayı
            this.Property(x => x.Başlık).HasColumnType("varchar").HasMaxLength(50);
            this.Property(x => x.Duyuru).IsRequired().HasMaxLength(500);//max karakter sayısı
            this.Property(x => x.Acıklama).IsRequired().HasMaxLength(5000);


            this.Property(x => x.Id).HasColumnName("İd");//kolon adlandırma
            this.Property(x => x.Başlık ).HasColumnName("Başlık");
            this.Property(x => x.Duyuru).HasColumnName("Duyuru");
            this.Property(x => x.Acıklama).HasColumnName("Açıklama");
            this.Property(x => x.Tarih).HasColumnName("Tarih");

        }
    }
}
