using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;

namespace KutuphaneOtomasyonu.Controllers
{
    [AllowAnonymous]
    public class UyelerController : Controller
    {
        KutuphaneContext context= new KutuphaneContext();
        UyelerDAL uyeler = new UyelerDAL();
        // GET: Uyeler
        public ActionResult Index()
        {
            var model = uyeler.GetAll(context);
            return View(model);
        } 
        public ActionResult Ekle()
        {
            
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Ekle(Uyeler entity,HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid) 
            {
                if(Resim!=null && Resim.ContentLength>0)
                {
                    var image=Path.GetFileName(Resim.FileName);
                    string path = Path.Combine(Server.MapPath("~/İmages/"),image);
                    if (System.IO.File.Exists(path) == false) 
                    { 
                        Resim.SaveAs(path);
                    }
                    entity.Resim = "/İmages/" + image;
                }
                uyeler.InsertOrUpdate(entity);
                uyeler.save(context);    
                
                return RedirectToAction("Index");
            }
            return View(entity);
            
           
        }
        public ActionResult Duzenle(int? id)
        {
           if(id == null)
            {
                return HttpNotFound();
            }
            var model = uyeler.GetAll(context, x => x.Id == id).FirstOrDefault(); // ✅ Tek eleman
            return View(model); // ✅ Artık model: Uyeler nesnesi
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Uyeler entity, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                var model = uyeler.GetAll(context, x => x.Id == entity.Id).FirstOrDefault();
                entity.Resim = model.Resim;
                if (Resim != null && Resim.ContentLength > 0)
                {
                    var image = Path.GetFileName(Resim.FileName);
                    string path = Path.Combine(Server.MapPath("~/İmages/"), image);
                    if (System.IO.File.Exists(path) == false)
                    {
                        Resim.SaveAs(path);
                    }
                    entity.Resim = "/İmages/" + image;
                }
                uyeler.InsertOrUpdate(entity);
                uyeler.save(context);

                return RedirectToAction("Index");
            }
            return View(entity);


        }
        public ActionResult Sil (int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            uyeler.delete(context,x=>x.Id == id);
            uyeler.save(context);
            return RedirectToAction("Index");
        }
    }
}