using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLease.Feature.Cars.Models.FilterModel
{
    public class FilterModel : IFilterModel
    {       
        public List<string> Filter { get; set; }
    }
}