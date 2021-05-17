using CarLease.Feature.Cars.Models;
using CarLease.Feature.Cars.Models.FilterModel;
using CarLease.Feature.Cars.Repositories;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarLease.Feature.Cars.Controllers
{
    public class FiltersController : Controller
    { 
        
        private readonly IFiltersRepository _filtersRepository;

        public FiltersController(IFiltersRepository filtersRepository)
        {
           
            _filtersRepository = filtersRepository;
           
        }
        // GET: Filters
        public ActionResult Filters()
        {
            IFilterModel filterModel = null;
            
            try
            {
                filterModel = _filtersRepository.GetFilters();
            }

            catch(Exception ex)
            {
                Log.Error("CarLease.Feature.Cars.Controllers:- error while fetching filter options." + ex.Message, this);
            }

            return View(filterModel);
        }
               
    }
}