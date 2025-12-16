using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "IndustriesDetail",
                url: "industries/{industries}",
                defaults: new { controller = "Home", action = "IndustriesDetail" }
            );
            routes.MapRoute(
                name: "knowledgeBaseDetail",
                url: "knowledge-base/{url}",
                defaults: new { controller = "Home", action = "knowledgeBaseDetail" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
