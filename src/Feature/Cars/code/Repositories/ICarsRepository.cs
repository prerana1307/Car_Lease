using CarLease.Feature.Cars.Models;

namespace CarLease.Feature.Cars.Repositories
{
    public interface ICarsRepository
    {
        ICarListsModel GetCar(string currentSite, string filterName);
    }
}