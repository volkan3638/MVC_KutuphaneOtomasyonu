using DocumentFormat.OpenXml.Spreadsheet;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KutuphaneOtomasyonu.Controllers
{
   
    public class KitaplarController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KitaplarDAL kitaplarDAL = new KitaplarDAL();
        KitapKayıtHareketleriDAL kitapKayıtHareketleriDAL= new KitapKayıtHareketleriDAL();
        KullanıcılarDAL kullanıcılarDAL = new KullanıcılarDAL();
        public void kitapkayıthareketleri(int kullanıcıid, int kitapid, string yapılanislem, string acıklama)
        {
            var model = new KitapKayıtHareketleri
            {
                acıklama=acıklama,
                KullanıcıId = kullanıcıid,
                KitapId = kitapid,
                yapılanislem =yapılanislem,
                tarih = DateTime.Now,



            };
            kitapKayıtHareketleriDAL.InsertOrUpdate(model);
            kitapKayıtHareketleriDAL.save(context);
        }



        // GET: Kitaplar
        [Authorize(Roles = "Admin, Patron")]

        public ActionResult Index()
        {
            {
                // Kitapları veritabanından çekiyoruz
                var model = kitaplarDAL.GetAll(context, null, new string[] { "KitapTürleri" });

                // Eğer kitaplar boşsa, hata yerine bir mesaj gösterebiliriz
                if (model == null)
                {
                    return View("Error"); // Hata görünümü
                }

                return View(model); // Kitaplar listesini döndürüyoruz
            }
        }
        
       
        public ActionResult Detay(int? Id)
        {
            var model = kitaplarDAL.GetByFilter(context, x => x.Id == Id, new string[] { "KitapTürleri" });
            return View(model);
        }
       
        
        [HttpGet]
        // GET: Ekle
        [AllowAnonymous]
        [Authorize(Roles = "Çaycı")]

        public ActionResult Ekle()
        {
            ViewBag.Liste = new SelectList(context.kitapTürleris.ToList(), "Id", "Kitapturu");

            return View(new Kitaplar());
        }

       
        // POST: Ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public ActionResult Ekle(Kitaplar kitap)

        {
            if (ModelState.IsValid)
            {
                context.kitaplars.Add(kitap);
                context.SaveChanges();
                int KitapId = context.kitaplars.Max(x => x.Id);
                var UserName = User.Identity.Name;
                var modelkullanıcı = kullanıcılarDAL.GetByFilter(context, x => x.email == UserName);
                int kullanıcıid = modelkullanıcı.Id;

                kitapkayıthareketleri(kullanıcıid, KitapId, modelkullanıcı.Kullanıcıadı + " yeni bir kitap ekledi", "Kitap Ekleme İşlemi");

                return RedirectToAction("Index"); // veya başka bir sayfa
                
            }

            ViewBag.Liste = new SelectList(context.kitapTürleris.ToList(), "Id", "Kitapturu");

            return View(kitap); // Hatalıysa aynı form geri dönsün
        }
    
        // GET: Duzenle
        [HttpGet]
        [AllowAnonymous]

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var model = kitaplarDAL.GetByFilter(context, x => x.Id == id, new string[] { "KitapTürleri" });
            if (model == null)
            {
                return HttpNotFound();
            }

            ViewBag.Liste = new SelectList(context.kitapTürleris, "Id", "Kitapturu", model.kitapturuId);
            return View(model);
        }


        // POST: Kitaplar/Duzenle
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Duzenle(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                // Hatalıysa dropdown list yeniden atanmalı
                ViewBag.Liste = new SelectList(context.kitapTürleris, "Id", "Kitapturu", entity.kitapturuId);
                return View(entity);
            }

            // Güncelleme işlemi
            kitaplarDAL.update(context, entity);
            kitaplarDAL.save(context);

            // Kullanıcı bilgisi ile kayıt
            int kitapid = entity.Id;
            var username = User.Identity.Name;
            var modelkullanıcı = kullanıcılarDAL.GetByFilter(context, x => x.email == username);

            if (modelkullanıcı != null)
            {
                var kullanıcıid = modelkullanıcı.Id;
                kitapkayıthareketleri(
                    kullanıcıid,
                    kitapid,
                    modelkullanıcı.Kullanıcıadı + " kullanıcısı kitap güncelledi",
                    "Kitap Düzenleme İşlemi"
                );
            }

            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public ActionResult sil(int? id)

        {
            if (id == null)
            {
                return HttpNotFound();
            }
            kitaplarDAL.delete(context, x=>x.Id==id);
            kitaplarDAL.save(context);
            return RedirectToAction("index");
        }


        
    }
}