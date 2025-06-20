using System.Web.Mvc;
using KutuphaneOtomasyonuentities.DAL;
using KutuphaneOtomasyonuentities.Mapping;
using KutuphaneOtomasyonuentities.model;
using static KutuphaneOtomasyonuentities.DAL.YayınEviDAL;

namespace KutuphaneOtomasyonu.Controllers
{
    public class YayıneviController : Controller
    {
        private readonly YayıneviDAL yayıneviDal = new YayıneviDAL();

        // GET: Yayınevi
        public ActionResult Index()
        {
            var yayınevleri = yayıneviDal.GetAll();
            return View(yayınevleri);
        }

        // GET: Yayınevi/Ekle
        public ActionResult Ekle()
        {
            return View();
        }

        // POST: Yayınevi/Ekle
        [HttpPost]
        public ActionResult Ekle(Yayınevi model)
        {
            if (ModelState.IsValid)
            {
                yayıneviDal.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Yayınevi/Guncelle/5
        public ActionResult Guncelle(int id)
        {
            var yayınevi = yayıneviDal.GetById(id);
            if (yayınevi == null)
                return HttpNotFound();

            return View(yayınevi);
        }

        // POST: Yayınevi/Guncelle/5
        [HttpPost]
        public ActionResult Guncelle(Yayınevi model)
        {
            if (ModelState.IsValid)
            {
                yayıneviDal.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Yayınevi/Sil/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sil(int id)
        {
            yayıneviDal.Delete(id);
            return RedirectToAction("Index");
        }



    }
}
