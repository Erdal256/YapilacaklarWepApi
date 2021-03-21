using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace YapilacaklarWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CustomKulYap",
                routeTemplate: "kulyap/{controller}",
                defaults: new { controller = "KullaniciYapilacaklar"}
                ); // route constraints üzerinden buradaki rpute tanımlamalarına kısıtlama getirilebilir.

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
