using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarLease.Feature.Cars.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace CarLease.Feature.Cars
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(FiltersController));
            serviceCollection.AddTransient(typeof(CarsController));
        }
    }
}