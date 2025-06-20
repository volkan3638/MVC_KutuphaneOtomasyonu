using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kütüphaneotomasyonu.entities.Model;
using Kütüphaneotomasyonu.entities.Model.context;
using KutuphaneOtomasyonuentities.DAL;
using KutuphaneOtomasyonuentities.model.viewModel;
using KutuphaneOtomasyonuentities.Mapping;

namespace KutuphaneOtomasyonu.Controllers
{
    [AllowAnonymous]
    public class KullanıcılarController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KullanıcılarDAL KullanıcılarDAL = new KullanıcılarDAL();
        KullanıcıRolleriDAL kullanıcıRolleriDAL = new KullanıcıRolleriDAL();
        RollerDAL rollerDAL = new RollerDAL();
        KullanıcıHareketleriDAL kullanıcıHareketleriDAl = new KullanıcıHareketleriDAL();

        public void KullanıcıHareketleri(int id, int islemyapanid, string acıklama)
        {
            var model = new KullanıcıHareketleri
            {
                Acıklama = acıklama,
                islemyapan = islemyapanid,
                kullanıcıId = id,
                tarih = DateTime.Now,
            };
            kullanıcıHareketleriDAl.InsertOrUpdate(model);
            kullanıcıHareketleriDAl.save(context);

        }
        // GET: Kullanıcılar
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = KullanıcılarDAL.GetAll(context);

            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Ekle()
        {

            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle(Kullanıcılar entity)
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse formu tekrar göster
                return View(entity);
            }

            try
            {
                KullanıcılarDAL.InsertOrUpdate(context, entity);
                KullanıcılarDAL.Save(context); // KullanıcılarDAL içindeki save metodunu kullan

                // Eğer kullanıcıRolleriDAL diye ayrı bir DAL varsa ve save yapılacaksa onu da burada çağırabilirsin,
                // ama değişken ismi büyük harfle başlamalı (C# standartları için):
                // kullanıcıRolleriDAL.Save(context);
                int kullanıcıid = context.kullanıcılars.Max(x => x.Id);
                var UserName = User.Identity.Name;
                var model = KullanıcılarDAL.GetByFilter(context, x => x.email == UserName);
                var islemyapanid = model.Id;
                string acıklama = model.Kullanıcıadı + "kullanıcısı yeni bir kullanıcı ekledi";
                KullanıcıHareketleri(kullanıcıid, islemyapanid, acıklama);




                return RedirectToAction("Index2");
            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Kayıt sırasında hata oluştu: " + ex.Message;
                return View(entity);
            }
        }
        [AllowAnonymous]
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Id değeri girilmedi");
            }

            var model = KullanıcılarDAL.GetById(context, id.Value);

            if (model == null)
            {
                return HttpNotFound("Kullanıcı bulunamadı");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Duzenle(Kullanıcılar entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity); // Form geçersizse geri dön
            }

            // Veritabanı işlemleri
            KullanıcılarDAL.InsertOrUpdate(context, entity); // Artık context null değil
            kullanıcıRolleriDAL.save(context); // Rollerle ilgili işlem
            context.SaveChanges(); // Değişiklikleri kaydet

            return RedirectToAction("Index2"); // Başarılıysa yönlendir
        }
        public ActionResult sil(int? Id)
        {
            KullanıcılarDAL.delete(context, x => x.Id == Id);
            KullanıcılarDAL.save(context);
            return RedirectToAction("Index");



        }


        [AllowAnonymous]
        public ActionResult Index2()
        {
            var kullanıcılar = KullanıcılarDAL.GetAll(context, null, new[] { "Kullanıcırolleris" });

            var roller = rollerDAL.GetAll(context);
            return View(new KullanıcıRolViewModel { Kullanıcılar = kullanıcılar, Roller = roller });
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(Kullanıcılar entity)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }

            var model = KullanıcılarDAL.GetByFilter(context, x => x.email == entity.email && x.sifre == entity.sifre);
            if (model != null)
            {
                int islemyapanid = model.Id;
                var acıklama = model.Kullanıcıadı + " kullanıcısı sisteme giriş yaptı";
                KullanıcıHareketleri(islemyapanid, islemyapanid, acıklama);

                // Kullanıcının rollerini veritabanından al
                var roller = context.kullanıcırolleris
                    .Where(x => x.kullanıcıId == model.Id)
                    .Select(x => x.Roller.rol)
                    .ToArray();

                string rollerString = string.Join(",", roller);

                // FormsAuthenticationTicket oluştur
                var ticket = new FormsAuthenticationTicket(
                    1,                      // ticket sürümü
                    model.email,            // kullanıcı adı
                    DateTime.Now,           // oluşturulma zamanı
                    DateTime.Now.AddMinutes(30),  // biletin geçerlilik süresi
                    false,                  // persistent mi?
                    rollerString,           // rol bilgisi
                    FormsAuthentication.FormsCookiePath
                );

                // Ticket şifrele
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                // Cookie oluştur
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "KitapTurleri");
            }

            ViewBag.error = "Kullanıcı Adı Veya Şifre Yanlış";
            return View();
        }

        [AllowAnonymous]
        public ActionResult KayıtOl()
        {
            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult KayıtOl(Kullanıcılar entity, string sifretekrar, bool kabul)
        {
            if (!ModelState.IsValid) // Model geçersizse, hata göster ve formu geri ver
            {
                return View(entity);
            }

            // Model geçerliyse devam et
            if (entity.sifre != sifretekrar)
            {
                ViewBag.sifreError = "Şifreler Uyuşmuyor";
                return View(entity);
            }

            if (!kabul)
            {
                ViewBag.kabulError = "Lütfen Şartları Kabul Ediniz";
                return View(entity);
            }
            else
            {
                entity.kayıttarihi = DateTime.Now;
                KullanıcılarDAL.InsertOrUpdate(context, entity);
                KullanıcılarDAL.Save(context);
                int kullanıcıid = context.kullanıcılars.Max(x => x.Id);

                string acıklama = "Yeni Kullanıcı Oluşturuldu ";
                KullanıcıHareketleri(kullanıcıid, kullanıcıid, acıklama);



                return RedirectToAction("Login");

            }





        }
        [AllowAnonymous]
        public ActionResult sifremiunuttum()
        {
            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult sifremiunuttum(Kullanıcılar entity)
        {
            var model = KullanıcılarDAL.GetByFilter(context, x => x.email == entity.email);
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.sifre = rastgele.ToString().Substring(0, 8);
                KullanıcılarDAL.Save(context);

                try
                {
                    SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    // Gönderen e-posta ve şifre
                    string senderEmail = "your_email@example.com"; // Kendi mail adresin
                    string senderPassword = "your_password";      // Mailin şifresi

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(senderEmail, "Şifre sıfırlama");
                    mail.To.Add(model.email);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Şifre Değiştirme İsteği";
                    mail.Body = $"Merhaba {model.adısoyadı}<br/> Kullanıcı Adınız: {model.Kullanıcıadı}<br/> Yeni Şifreniz: {model.sifre}";

                    NetworkCredential net = new NetworkCredential(senderEmail, senderPassword);
                    client.Credentials = net;

                    client.Send(mail);

                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    // Hata olursa kullanıcıya bildir
                    ViewBag.hata = "Mail gönderilirken bir hata oluştu: " + ex.Message;
                    return View();
                }
            }
            else if (model == null && !string.IsNullOrEmpty(entity.email))
            {
                ViewBag.hata = "Böyle bir e-mail adresi bulunamadı.";
                return View();
            }

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult KRolleri(int id)
        {
            var model = kullanıcıRolleriDAL.GetAll(context, x => x.kullanıcıId == id, new[] { "Roller" });

            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }
        public ActionResult Cıkıs()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    

    }

}





