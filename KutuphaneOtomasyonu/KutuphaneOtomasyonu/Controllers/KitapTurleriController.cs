using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;
using PagedList;
using System.Data.Entity;


namespace KutuphaneOtomasyonu.Controllers
{
   
    public class KitapTurleriController : Controller
    {
        // KutuphaneContext nesnesini controller'da kullanacağız.
        KutuphaneContext context = new KutuphaneContext();

        // KitapTürleriDAL nesnesini oluşturuyoruz.
        KitapTürleriDAL KitapTurleriDAL = new KitapTürleriDAL();

        // Kitap Türleri Listesi
        [AllowAnonymous]
        public ActionResult Index(string Ara, int? page)
        {
            IQueryable<KitapTürleri> kitapTurleri = context.kitapTürleris;

            if (!string.IsNullOrEmpty(Ara))
            {
                kitapTurleri = kitapTurleri.Where(k => k.Kitapturu.Contains(Ara));
            }

            int pageSize = 3;
            int pageNumber = page ?? 1;

            var model = kitapTurleri.OrderBy(k => k.Id).ToPagedList(pageNumber, pageSize);

            ViewBag.Ara = Ara;

            return View(model);
        }



        // Kitap Türü Ekleme Sayfası
        [AllowAnonymous]
        public ActionResult Ekle1()
        {
            return View();
        }
        [AllowAnonymous]
        // Kitap Türü Ekleme İşlemi (POST)
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle1(KitapTürleri KitapTurleri)
        {
            if (ModelState.IsValid) 
            {
                // Kitap türü ekleme veya güncelleme işlemi
                KitapTurleriDAL.insert(context, KitapTurleri);

                // Veritabanına kaydetme işlemi
                KitapTurleriDAL.save(context);

                // Ekleme işleminden sonra listeye yönlendiriyoruz
                return RedirectToAction("Index");
            }
            return View(KitapTurleri);

        }
        [AllowAnonymous]
        public ActionResult Duzenle(int? Id)
            
        {
            if(Id == null)
            {
                return HttpNotFound();
            }
            // Kitap türlerini veritabanından alıyoruz
            var model = KitapTurleriDAL.GetById(context,Id);

            // Listeyi View'a gönderiyoruz
            return View(model);
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Duzenle(KitapTürleri kitaptürleri)
        {
            if (ModelState.IsValid)
            {
                // Kitap türü ekleme veya güncelleme işlemi
                KitapTurleriDAL.update(context, kitaptürleri);

                // Veritabanına kaydetme işlemi
                KitapTurleriDAL.save(context);

                // Ekleme işleminden sonra listeye yönlendiriyoruz
                return RedirectToAction("Index");
            }
            return View(kitaptürleri);
        }
        [AllowAnonymous]
        public ActionResult sil(int? Id)
        {
                KitapTurleriDAL.delete(context , x=>x.Id==Id);
            KitapTurleriDAL.save(context);
                return RedirectToAction("Index");

           

        }
        
            
               
        }
    }

