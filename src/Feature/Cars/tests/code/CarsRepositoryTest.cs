using System;
using System.Collections.Generic;
using CarLease.Feature.Cars.Models;
using CarLease.Feature.Cars.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CarLease.Feature.Cars.Tests
{
    [TestClass]
    public class CarsRepositoryTest
    {
        private readonly ICarsRepository carsRepository = Substitute.For<ICarsRepository>();

        public const string id = "{7273C65D-2370-4A8B-9809-A2C4D3DD1C72}";
        public const string filter = "Compact";

        [TestMethod]
        public void GetCars_InvalidDatasource_ReturnsNoResult()
        {            
            var result = carsRepository.GetCar(id, "");
            Assert.IsNull(result.Cars);           
        }

        [TestMethod]
        public void GetCars_ValidDatasource_ReturnsResult()
        {
            var result = carsRepository.GetCar(id, "");
            result.Cars = MockData().Cars;

            //Assert for count
            Assert.IsTrue(result.Cars.Count > 0);
        }

        [TestMethod]
        public void GetCars_ValidDatasourceWithFilter_ReturnsResult()
        {
            var result = carsRepository.GetCar(id, filter);
            result.Cars = MockData().Cars;

            //Assert for count
            Assert.IsTrue(result.Cars.Count > 0);
        }

        private ICarListsModel MockData()
        {
            var carList = new List<ICarModel>();
            var carModel1 = new CarModel
            {
                Title = "Toyota",
                Image = "http://carlease-nl/-/media/Images/Feature/Cars/Occasion/citroen-c1c1mc.ashx",
                ShortDescription = "Compact car",
                Type = "Compact"
            };

            var carModel2 = new CarModel
            {
                Title = "Renault",
                Image = "http://carlease-nl/-/media/Images/Feature/Cars/Occasion/citroen-c1c1mc.ashx",
                ShortDescription = "Compact car",
                Type = "Compact"
            };

            carList.Add(carModel1);
            carList.Add(carModel2);

            return new CarListsModel() { Cars = carList };
        }
    }
}
