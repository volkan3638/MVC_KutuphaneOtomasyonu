using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Drawing;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;
using KutuphaneOtomasyonuentities.Mapping;
using System.Data.Entity;


namespace KutuphaneOtomasyonu.Controllers
{
    public class EmanetKitaplarController : Controller
    {
        
        KutuphaneContext context= new KutuphaneContext();
        EmanetKitaplarDal emanetKitaplarDal =new EmanetKitaplarDal();
        KitaplarDAL KitaplarDAL =new KitaplarDAL();
        KitapHareketleriDAL kitapHareketleriDAL = new KitapHareketleriDAL();
        // GET: EmanetKitaplar
        //[AllowAnonymous]

        public ActionResult Index(string kitapAdi, string uyeAdi)
        {
            var emanetler = context.emanetKitaplars
                                  .Include(e => e.Kitaplar)
                                  .Include(e => e.uyeler)
                                  .AsQueryable();

            if (!string.IsNullOrEmpty(kitapAdi))
            {
                emanetler = emanetler.Where(e => e.Kitaplar.Kitapadı.Contains(kitapAdi));
            }

            if (!string.IsNullOrEmpty(uyeAdi))
            {
                emanetler = emanetler.Where(e => e.uyeler.adısoyadı.Contains(uyeAdi));
            }

            return View(emanetler.ToList());
        }


        public ActionResult Yazdir()
        {
            var model = emanetKitaplarDal.GetAll(context, x => x.kitapiadetarihi == null, "Kitaplar", "Uyeler");
            return new Rotativa.ActionAsPdf("EmanetListesi", model)
            {
                FileName = "EmanetKitaplarListesi.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                CustomSwitches = "--disable-smart-shrinking"
            };
        }
        public ActionResult EmanetListesi()
        {
            var model = emanetKitaplarDal.GetAll(context, x => x.kitapiadetarihi == null, "Kitaplar", "Uyeler");
            return View(model);
        }





        //[AllowAnonymous]
        public ActionResult EmanetKitapVer()
        {

            ViewBag.UyeListe = new SelectList(context.uyelers.ToList(), "Id", "adısoyadı");
            ViewBag.KitapListe = new SelectList(context.kitaplars.ToList(), "Id", "Kitapadı");
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult EmanetKitapVer(EmanetKitaplar entity)
        {
            if (ModelState.IsValid)
            {

                var Email =User.Identity.Name;
                var kullanıcımodel = context.kullanıcılars.FirstOrDefault(k=>k.email==Email);
                
               emanetKitaplarDal.InsertOrUpdate(context,entity);

                var kitaphareket = new kitaphareketleri
                {
                    kullanıciId = kullanıcımodel.Id,
                    KitapId = entity.KitapId,
                    UyeId = entity.UyeId,
                    yapılanislem = "Emanet Kitap Verildi",
                    tarih = DateTime.Now,
                };
                kitapHareketleriDAL.InsertOrUpdate(context,kitaphareket);
                    
                   
                emanetKitaplarDal.save(context);

               return RedirectToAction("Index");
            }

            ViewBag.UyeListe = new SelectList(context.uyelers.ToList(), "Id", "adısoyadı");
            ViewBag.KitapListe = new SelectList(context.kitaplars.ToList(), "Id", "Kitapadı");
            return View(entity);
        }
         public ActionResult Duzenle(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var model =emanetKitaplarDal.GetByFilter(context,x=>x.Id== id,"Uyeler","Kitaplar");
            ViewBag.UyeListe = new SelectList(context.uyelers.ToList(), "Id", "adısoyadı");
            ViewBag.KitapListe = new SelectList(context.kitaplars.ToList(), "Id", "Kitapadı");
            return View(model);
        }
       // [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Duzenle(EmanetKitaplar entity)
        {
            if (ModelState.IsValid)
            {
              

                if (ModelState.IsValid)
                {
                   
                    emanetKitaplarDal.InsertOrUpdate(context, entity);
                    return RedirectToAction("Index");
                }

              
            }

            ViewBag.UyeListe = new SelectList(context.uyelers.ToList(), "Id", "adısoyadı");
            ViewBag.KitapListe = new SelectList(context.kitaplars.ToList(), "Id", "Kitapadı");
            return View(entity);
        }
        public ActionResult Sil (int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            emanetKitaplarDal.delete(context, x=>x.Id== id);
            emanetKitaplarDal.save(context);
            return RedirectToAction("Index");
        }
        public ActionResult TeslimAl(int? id)
        {
            var model =emanetKitaplarDal.GetByFilter(context ,x=> x.Id== id);
            model.kitapiadetarihi=DateTime.Now;

            var kitaplar =KitaplarDAL.GetByFilter(context,x=> x.Id== model.KitapId);
            kitaplar.stokadedi=kitaplar.stokadedi+model.kitapsayiyi;
            emanetKitaplarDal.save(context);
            return RedirectToAction("Index");
        }


    }
}
