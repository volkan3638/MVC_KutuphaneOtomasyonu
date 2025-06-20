using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonu.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonu.Controllers
{
    public class DuyurularController : Controller
    {
        private readonly KutuphaneContext _context;
        private readonly DuyurularDAL _duyurularDal;

        public DuyurularController()
        {
            _context = new KutuphaneContext();
            _duyurularDal = new DuyurularDAL(_context);
        }
        [AllowAnonymous]

        public ActionResult Index()
        {
            var model = _duyurularDal.GetAll();
            return View(model); // View tarafında model listesi ile çalışabilirsin
        }

        [AllowAnonymous]
        public JsonResult DuyuruList()
        {
            try
            {
                var model = _duyurularDal.GetAll();
                return Json(new { success = true, data = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [AllowAnonymous]

        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult DuyuruEkle(Duyurular entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _duyurularDal.InsertOrUpdate(entity);
                    return Json(new { success = true, message = "Duyuru başarıyla kaydedildi." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Hata oluştu: " + ex.Message });
                }
            }
            return Json(new { success = false, message = "Geçersiz veri." });
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult DuyuruDuzenle(int id)
        {
            var duyuru = _duyurularDal.GetById(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult DuyuruDuzenle(Duyurular entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _duyurularDal.InsertOrUpdate(entity); // Güncelleme işlemi
                    return Json(new { success = true, message = "Duyuru başarıyla güncellendi." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Hata oluştu: " + ex.Message });
                }
            }
            return Json(new { success = false, message = "Geçersiz veri." });
        }

        // Diğer actionlar...

        [AllowAnonymous]

        [HttpPost]
        public JsonResult DuyuruSil(int id)
        {
            try
            {
                _duyurularDal.Delete(id);
                return Json(new { success = true, message = "Silindi" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult TopluSil(List<int> ids)
        {
            try
            {
                _duyurularDal.DeleteMultiple(ids);
                return Json(new { success = true, message = "Toplu silme başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [AllowAnonymous]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _duyurularDal.Dispose();
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}