using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;

namespace KutuphaneOtomasyonu.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        HakkımızdaDAL hakkımızdaDAL = new HakkımızdaDAL();
        İletişimDAL iletişimDAL =new İletişimDAL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = hakkımızdaDAL.GetAll(context);
            return View(model);

        }

        public ActionResult Contact()
        {
           

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(İletişim model)
        {
            if (ModelState.IsValid) 
            {
                model.tarih=DateTime.Now;
                iletişimDAL.InsertOrUpdate(model);
                iletişimDAL.save(context); TempData["Message"] = "Mesajınız Başarıyla Gönderildi";
                return RedirectToAction("Contact");
            }

            return View(model);
        }
        public ActionResult Adminİndex()
        {
           

            return View();
        }


    }
}