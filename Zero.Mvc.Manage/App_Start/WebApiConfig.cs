using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Zero.Mvc.Manage
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = "id" }
            );
        }
    }
}
