using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HaveYouSeenMe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "ShowMe/{id}",
                defaults: new { controller = "Pet", action = "GetPhoto", id = "Fido" },
                constraints: new { id = ".{4}" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{*MoreValues}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}