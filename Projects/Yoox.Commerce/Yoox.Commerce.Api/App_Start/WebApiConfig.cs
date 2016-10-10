using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Yoox.Commerce.Api
{
    public static class WebApiConfig
    {
        // Controllers -> Gestione singola Entity
        // Action -> Gestire le operazioni CRUD sulla singola entity
        // CREATE -> POST
        // READ   -> GET
        // UPDATE -> PUT
        // DELETE -> DELETE
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
