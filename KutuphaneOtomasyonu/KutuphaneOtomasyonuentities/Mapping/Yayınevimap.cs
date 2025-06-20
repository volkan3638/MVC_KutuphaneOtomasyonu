using System.Data.Entity.ModelConfiguration;
using KutuphaneOtomasyonuentities.model;

namespace KutuphaneOtomasyonuentities.Mapping
{
    public class YayıneviMap : EntityTypeConfiguration<Yayınevi>
    {
        public YayıneviMap()
        {
            ToTable("Yayınevi"); // Tablo adı

            HasKey(x => x.Id); // Primary key

            Property(x => x.Adı).IsRequired().HasMaxLength(200);
            Property(x => x.Adres).HasMaxLength(500);
        }
    }
}
