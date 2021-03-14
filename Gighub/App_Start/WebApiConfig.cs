﻿using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Gighub
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // configure Api To Return Camel Case for javascript
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
