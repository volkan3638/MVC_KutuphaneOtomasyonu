using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;

namespace KutuphaneOtomasyonu.Controllers
{
    public class RollerController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        RollerDAL rollerDAL = new RollerDAL();

        // GET: Roller
        public ActionResult Index()
        {
            var model = rollerDAL.GetAll(context);
            return View(model);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Roller entity)
        {
            if (ModelState.IsValid)
            {
                rollerDAL.InsertOrUpdate(entity);
                rollerDAL.save(context);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: Roller/Duzenle/5
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var rol = context.rollers.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Roller model)
        {
            if (ModelState.IsValid)
            {
                rollerDAL.InsertOrUpdate(model); // Güncelleme metodunu burada kullan
                rollerDAL.save(context);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Sil(int id) 
        { 
            rollerDAL.delete(context,x=>x.Id == id);
            rollerDAL.save(context);
            return RedirectToAction("Index");
        }


    }
}
