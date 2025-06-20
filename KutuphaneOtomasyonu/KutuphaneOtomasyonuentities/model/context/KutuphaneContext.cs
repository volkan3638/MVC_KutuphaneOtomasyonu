using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using KutuphaneOtomasyonuentities.Mapping;
using KutuphaneOtomasyonuentities.model;
using KutuphaneOtomasyonuentities.Migrations;

namespace Kütüphaneotomasyonu.entities.Model.context
{
    public class KutuphaneContext:DbContext
    {
        public KutuphaneContext():base("Kutuphaneotomasyonu")
        {
            
        }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<EmanetKitaplar> emanetKitaplars { get; set; }
        public DbSet<Hakkımızda> hakkımızdas { get; set; }
        public DbSet<İletişim> iletişims { get; set; }
        public DbSet<kitaphareketleri> kitaphareketleris { get; set; }
        public DbSet<KitapKayıtHareketleri> kitapKayıtHareketleris { get; set; }
        public DbSet<Kitaplar> kitaplars { get; set; }
        public DbSet<KitapTürleri> kitapTürleris { get; set; }
        public DbSet<KullanıcıHareketleri> kullanıcıHareketleris { get; set; }
        public DbSet<Kullanıcılar> kullanıcılars { get; set; }
        public DbSet<Kullanıcırolleri> kullanıcırolleris { get; set; }
        public DbSet<Roller> rollers { get; set; }
        public DbSet<Uyeler> uyelers { get; set; }
        public DbSet<Yayınevi> yayınevis { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DuyurularMap());
            modelBuilder.Configurations.Add(new EmanetKitaplarMap());
            modelBuilder.Configurations.Add(new HakkımızdaMap());
            modelBuilder.Configurations.Add(new İletişimMap());
            modelBuilder.Configurations.Add(new KitapHareketleriMap());
            modelBuilder.Configurations.Add(new KitapKayıtHareketlerMap());
            modelBuilder.Configurations.Add(new KitaplarMap());
            modelBuilder.Configurations.Add(new KitapTurleriMap());
            modelBuilder.Configurations.Add(new KullanıcıHareketleriMap());
            modelBuilder.Configurations.Add(new KullanıcılarMap());
            modelBuilder.Configurations.Add(new KullanıcıRolleriMap());
            modelBuilder.Configurations.Add(new RollerMap());
            modelBuilder.Configurations.Add(new UyelerMap());
            modelBuilder.Configurations.Add(new YayıneviMap());
        }
    }
}
