using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonu.DAL;
using KutuphaneOtomasyonuentities.DAL;
using KutuphaneOtomasyonuentities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KullaniciRolleriController : Controller
    {
        private readonly KutuphaneContext context = new KutuphaneContext();
        private readonly KullanıcıRolleriDAL kullaniciRolleriDAL = new KullanıcıRolleriDAL();

        // GET: KullaniciRolleri/Ekle/5
        [HttpGet]
        public ActionResult Ekle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400, "Kullanıcı Id zorunludur."); // Bad Request
            }

            var kullanici = context.kullanıcılars.Find(id.Value);
            if (kullanici == null)
            {
                return HttpNotFound("Kullanıcı bulunamadı.");
            }

            // Rol listesini ViewBag'e gönder
            var rollerListesi = context.rollers
                .Select(r => new { r.Id, r.rol })
                .ToList();

            ViewBag.Liste = rollerListesi.Select(r => new SelectListItem
            {
                Text = r.rol,
                Value = r.Id.ToString()
            }).ToList();

            ViewBag.KullaniciAdi = kullanici.adısoyadı ?? "Bilinmeyen Kullanıcı";

            // Boş model oluştur, kullanıcıId setli
            var model = new Kullanıcırolleri
            {
                kullanıcıId = id.Value
            };

            return View(model);
        }

        // POST: KullaniciRolleri/Ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Kullanıcırolleri model)
        {
            if (!ModelState.IsValid)
            {
                // Model doğrulama başarısızsa rol listesini tekrar ekle
                var rollerListesi = context.rollers
                    .Select(r => new { r.Id, r.rol })
                    .ToList();

                ViewBag.Liste = rollerListesi.Select(r => new SelectListItem
                {
                    Text = r.rol,
                    Value = r.Id.ToString()
                }).ToList();

                var kullanici = context.kullanıcılars.Find(model.kullanıcıId);
                ViewBag.KullaniciAdi = kullanici?.adısoyadı ?? "Bilinmeyen Kullanıcı";

                return View(model);
            }

            // Veri tabanında aynı kullanıcı-rol ikilisi var mı kontrol et
            bool varMi = context.kullanıcırolleris.Any(x => x.kullanıcıId == model.kullanıcıId && x.rolId == model.rolId);
            if (varMi)
            {
                ModelState.AddModelError("", "Bu kullanıcı için seçilen rol zaten tanımlanmış.");

                var rollerListesi = context.rollers
                    .Select(r => new { r.Id, r.rol })
                    .ToList();

                ViewBag.Liste = rollerListesi.Select(r => new SelectListItem
                {
                    Text = r.rol,
                    Value = r.Id.ToString()
                }).ToList();

                var kullanici = context.kullanıcılars.Find(model.kullanıcıId);
                ViewBag.KullaniciAdi = kullanici?.adısoyadı ?? "Bilinmeyen Kullanıcı";

                return View(model);
            }

            // Yeni kullanıcı rolü ekle
            kullaniciRolleriDAL.InsertOrUpdate(context, model);

            // Kaydet
            context.SaveChanges();

            // Başarılı ise, kullanıcı rolleri listesine yönlendir (örneğin index sayfasına)
            return RedirectToAction("Index2", "Kullanıcılar", new { id = model.kullanıcıId });
        }

        // GET: KullaniciRolleri/Index/5  - kullanıcı rolleri listesi
        [HttpGet]

        public ActionResult Index(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400, "Kullanıcı Id zorunludur.");

            var model = kullaniciRolleriDAL.GetByFilter(context, x => x.kullanıcıId == id.Value, new[] { "Roller" }).ToList();

            if (model == null) // Bu kontrol eklenmeli
            {
                model = new List<Kullanıcırolleri>();
            }

            ViewBag.KullaniciId = id.Value;
            var kullanici = context.kullanıcılars.Find(id.Value);
            ViewBag.KullaniciAdi = kullanici?.adısoyadı ?? "Bilinmeyen Kullanıcı";

            return View(model);
        }
        public ActionResult Sil(int? id)
        {

            kullaniciRolleriDAL.delete(context, x => x.Id == id);
            kullaniciRolleriDAL.save(context);
            return RedirectToAction("Index2", "Kullanıcılar");


        }
      
        // GET: KullaniciRolleri/Duzenle/5
        [HttpGet]
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(400, "Rol atama ID zorunludur.");

            var model = context.kullanıcırolleris.Find(id.Value);

            if (model == null)
                return HttpNotFound("Kullanıcı rol bilgisi bulunamadı.");

            // ViewBag için kullanıcı adı ve rol listesi ekleniyor
            var kullanici = context.kullanıcılars.Find(model.kullanıcıId);
            ViewBag.KullaniciAdi = kullanici?.adısoyadı ?? "Bilinmeyen Kullanıcı";

            var rollerListesi = context.rollers
                .Select(r => new { r.Id, r.rol })
                .ToList();

            ViewBag.Liste = rollerListesi.Select(r => new SelectListItem
            {
                Text = r.rol,
                Value = r.Id.ToString(),
                Selected = r.Id == model.rolId
            }).ToList();

            return View(model);
        }

        // POST: KullaniciRolleri/Duzenle/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kullanıcırolleri model)
        {
            if (!ModelState.IsValid)
            {
                var rollerListesi = context.rollers
                    .Select(r => new { r.Id, r.rol })
                    .ToList();

                ViewBag.Liste = rollerListesi.Select(r => new SelectListItem
                {
                    Text = r.rol,
                    Value = r.Id.ToString(),
                    Selected = r.Id == model.rolId
                }).ToList();

                var kullanici = context.kullanıcılars.Find(model.kullanıcıId);
                ViewBag.KullaniciAdi = kullanici?.adısoyadı ?? "Bilinmeyen Kullanıcı";

                return View(model);
            }

            // Güncelleme
            kullaniciRolleriDAL.InsertOrUpdate(context, model);
            context.SaveChanges();

            return RedirectToAction("Index2", "Kullanıcılar", new { id = model.kullanıcıId });

        }

    }
}
