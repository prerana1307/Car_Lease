using CarLease.Feature.Cars.Models.FilterModel;

namespace CarLease.Feature.Cars.Repositories
{
    public interface IFiltersRepository
    {
        FilterModel GetFilters();
    }
}