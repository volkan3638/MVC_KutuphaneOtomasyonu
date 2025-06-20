using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace KutuphaneOtomasyonu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Mevcut rotayı engelleme
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Kitaplar rotası
            routes.MapRoute(
                name: "Kitaplar_Duzenle", // Route adı
                url: "Kitaplar/Duzenle/{id}", // URL yapısı
                defaults: new { controller = "Kitaplar", action = "Duzenle", id = UrlParameter.Optional } // Varsayılan controller ve action
            );

            // Duyurular rotası
            routes.MapRoute(
                name: "Duyurular_Index", // Rota adı
                url: "Duyurular/Index", // URL yapısı
                defaults: new { controller = "Duyurular", action = "Index" } // Varsayılan controller ve action
            );

            // Varsayılan rota
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            // DuyurularList rotası
            routes.MapRoute(
                name: "DuyurularList",
                url: "Duyurular/DuyurularList", // URL yapısı
                defaults: new { controller = "Duyurular", action = "DuyurularList" } // Varsayılan controller ve action
            );

            // DuyuruEkle rotası
            routes.MapRoute(
                name: "DuyuruEkle",
                url: "Duyurular/DuyuruEkle", // URL yapısı
                defaults: new { controller = "Duyurular", action = "DuyuruEkle" } // Varsayılan controller ve action
            );

        }
    }
}
