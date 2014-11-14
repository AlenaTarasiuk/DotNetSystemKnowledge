using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetSystemKnowledge.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Select", action = "Select" }
            );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Technology", action = "List"}
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "User", action = "Register" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Nav", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}