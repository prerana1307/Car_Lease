using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarLease.Feature.Cars.Pipelines.Initialize
{
    public class RegisterRoutes
    {
        private const string ApiPrefix = "api";

        public void Process(PipelineArgs args)
        {
            RegisterMvcRoutes(RouteTable.Routes);
        }
        private static void RegisterMvcRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "CarLease.Feature.Cars",
                url: $"{ApiPrefix}/filters/{{action}}",
                defaults: new { controller = "Filters", action = "Filters" });

            routes.MapRoute(
               name: "CarLease.Feature.CarsLists",
               url: $"{ApiPrefix}/Cars/{{action}}",
               defaults: new { controller = "Cars", action = "GetCars" });
        }
    }
}