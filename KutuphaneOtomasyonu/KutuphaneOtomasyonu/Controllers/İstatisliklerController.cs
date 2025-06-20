using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;
using KutuphaneOtomasyonuentities.Mapping;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace KutuphaneOtomasyonu.Controllers
{
    public class İstatisliklerController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KullanıcılarDAL kullanıcılarDAL = new KullanıcılarDAL();
        UyelerDAL uyelerDAL = new UyelerDAL();
        KullanıcıHareketleriDAL kullanıcıHareketleriDAL = new KullanıcıHareketleriDAL();
        EmanetKitaplarDal emanetKitaplarDal = new EmanetKitaplarDal();

        public ActionResult Index()
        {
            // Üye verileri
            var top3Uyeler = uyelerDAL.UyeKitapIslemleri();
            ViewBag.EnCokUye = uyelerDAL.EnCokUye;
            ViewBag.EnAzUye = uyelerDAL.EnAzUye;
            ViewBag.EnCokSayi = uyelerDAL.EnCokSayi;
            ViewBag.EnAzSayi = uyelerDAL.EnAzSayi;
            ViewBag.Top3Uyeler = top3Uyeler;

            // Kullanıcı sayısı
            var kullaniciListesi = kullanıcılarDAL.GetAll(context);
            ViewBag.Count = kullaniciListesi.Count;

            // En çok giriş yapan kullanıcı
            var model = kullanıcıHareketleriDAL.Kullanıcıgirissayilari();
            ViewBag.KullanıcıAdı = model.KullanıcıAdı;
            ViewBag.GirisSayısı = model.GirisSayısı;

            // Kullanıcı hareket verileri
            kullanıcıHareketleriDAL.KullanicilarHareketleriGozlemleme();
            ViewBag.AylikVeriler = kullanıcıHareketleriDAL.AylikVeriler; // ✅ Türkçe karakter yok!
            ViewBag.ToplamKHGSayisi = kullanıcıHareketleriDAL.ToplamKHGSayisi;
            ViewBag.AltiAylikToplamKHGSayisi = kullanıcıHareketleriDAL.AltiAylikToplamKHGSayisi;

            return View();
        }
        public ActionResult exeleaktar()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Emanet Kitaplar");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Üye";
                worksheet.Cell(1, 3).Value = "Kitap Adı";
                worksheet.Cell(1, 4).Value = "Kitap Sayısı";
                worksheet.Cell(1, 5).Value = "Kitap Aldığı Tarih";

                var model = emanetKitaplarDal.GetAll(context, x => x.kitapiadetarihi == null, "Uyeler", "Kitaplar").ToList();

                int row = 2;
                foreach (var item in model)
                {
                    worksheet.Cell(row, 1).Value = item.Id;
                    worksheet.Cell(row, 2).Value = item.uyeler.adısoyadı;
                    worksheet.Cell(row, 3).Value = item.Kitaplar.Kitapadı;
                    worksheet.Cell(row, 4).Value = item.kitapsayiyi;
                    worksheet.Cell(row, 5).Value = item.Kitapaldıgıtarih.ToString("dd.MM.yyyy");

                    row++;
                }

                worksheet.Column(5).AdjustToContents();  // 5. sütunu genişlet

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "EmanetKitaplarSeri.xlsx"
                    );
                }
            }
        }

    }
}

    


    


