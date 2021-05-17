using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLease.Feature.Cars.Models
{
    public class CarListsModel : ICarListsModel
    {
        public List<ICarModel> Cars { get; set; }
    }
}