using CarLease.Feature.Cars.Models;
using CarLease.Feature.Cars.Repositories;
using Sitecore.Data;
using Sitecore.Diagnostics;
using System;
using System.Web.Mvc;

namespace CarLease.Feature.Cars.Controllers
{
    public class CarsController : Controller
    {
       
        private readonly ICarsRepository _carsRepository;
        public CarsController(ICarsRepository carsRepository)
        { 
            _carsRepository = carsRepository;
            
        }
        // GET: Cars

        public ActionResult GetCars(string currentSite, string filterName)
        {
            ICarListsModel model = null;
            try
            {
                model = _carsRepository.GetCar(currentSite, filterName);
            }
            catch(Exception ex)
            {
                Log.Error("Error while fetching car details from CarLease.Feature.Cars.Controllers.CarsControllers.GetCar" + ex.Message, this);
            }
            
            return View(model);
        }
    }
}