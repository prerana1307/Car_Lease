using System.Collections.Generic;

namespace CarLease.Feature.Cars.Models
{
    public interface ICarListsModel
    {
        List<ICarModel> Cars { get; set; }
    }
}