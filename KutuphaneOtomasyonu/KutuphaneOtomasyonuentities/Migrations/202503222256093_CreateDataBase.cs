 namespace KutuphaneOtomasyonuentities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Duyurulars",
                c => new
                    {
                        İd = c.Int(nullable: false, identity: true),
                        Baslık = c.String(),
                        Duyuru = c.String(),
                        Acıklama = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.İd);
            
            CreateTable(
                "dbo.EmanetKitaplars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UyeId = c.Int(nullable: false),
                        KitapId = c.Int(nullable: false),
                        kitapsayiyi = c.Int(nullable: false),
                        Kitapaldıgıtarih = c.DateTime(nullable: false),
                        kitapiadetarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hakkımızda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        icerik = c.String(),
                        acıklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.İletişim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        adsoyad = c.String(),
                        email = c.String(),
                        baslık = c.String(),
                        mesaj = c.String(),
                        acıklama = c.String(),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.kitaphareketleris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kullanıciId = c.Int(nullable: false),
                        UyeId = c.Int(nullable: false),
                        KitapId = c.Int(nullable: false),
                        yapılanislem = c.String(),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitapKayıtHareketleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullanıcıId = c.Int(nullable: false),
                        KitapId = c.Int(nullable: false),
                        yapılanislem = c.String(),
                        acıklama = c.String(),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitaplars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarkodId = c.Int(nullable: false),
                        kitapturuId = c.Int(nullable: false),
                        Kitapadı = c.String(),
                        yazarı = c.String(),
                        yayınevi = c.String(),
                        stokadedi = c.Int(nullable: false),
                        sayfasayısı = c.Int(nullable: false),
                        acıklama = c.String(),
                        eklenmetarihi = c.DateTime(nullable: false),
                        guncellemetarihi = c.DateTime(nullable: false),
                        silindimi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitapTürleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kitapturu = c.String(maxLength: 50),
                        Acıklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KullanıcıHareketleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kullanıcıId = c.Int(nullable: false),
                        Acıklama = c.String(),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kullanıcılar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kullanıcıadı = c.String(),
                        sifre = c.String(),
                        adısoyadı = c.String(),
                        telefon = c.String(),
                        adres = c.String(),
                        email = c.String(),
                        kayıttarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kullanıcırolleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kullanıcıId = c.Int(nullable: false),
                        rolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rollers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        rol = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Uyelers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        adısoyadı = c.String(),
                        telefon = c.String(),
                        adres = c.String(),
                        email = c.String(),
                        Resim = c.String(),
                        OkunanKitapsayisi = c.Int(nullable: false),
                        kayıttarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uyelers");
            DropTable("dbo.Rollers");
            DropTable("dbo.Kullanıcırolleri");
            DropTable("dbo.Kullanıcılar");
            DropTable("dbo.KullanıcıHareketleri");
            DropTable("dbo.KitapTürleri");
            DropTable("dbo.Kitaplars");
            DropTable("dbo.KitapKayıtHareketleri");
            DropTable("dbo.kitaphareketleris");
            DropTable("dbo.İletişim");
            DropTable("dbo.Hakkımızda");
            DropTable("dbo.EmanetKitaplars");
            DropTable("dbo.Duyurulars");
        }
    }
}


