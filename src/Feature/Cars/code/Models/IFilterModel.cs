using System.Collections.Generic;

namespace CarLease.Feature.Cars.Models.FilterModel
{
    public interface IFilterModel
    {
        List<string> Filter { get; set; }
    }
}