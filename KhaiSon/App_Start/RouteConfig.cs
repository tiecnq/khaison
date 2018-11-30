using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KhaiSon
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "quy-hoach",
               url: "quy-hoach-quan-long-bien-trung-tam-thi-moi-cua-ha-noi.html",
               defaults: new { controller = "Contents", action = "QuyHoach", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "chinh-sach-uu-dai-thang-10-du-an-khai-son-city",
              url: "chinh-sach-uu-dai-thang-10-du-an-khai-son-city.html",
              defaults: new { controller = "Contents", action = "ChinhSach", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "tien-do-xay-dung-du-an-khai-son-city-long-bien",
               url: "tien-do-xay-dung-du-an-khai-son-city-long-bien.html",
               defaults: new { controller = "Contents", action = "TienDo", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "vi-tri-du-an",
               url: "vi-tri-du-an-khai-son-city-long-bien.html",
               defaults: new { controller = "Contents", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
