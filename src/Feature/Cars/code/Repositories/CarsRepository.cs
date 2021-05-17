using CarLease.Feature.Cars.Models;
using CarLease.Foundation.Common.Helpers;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using Sitecore.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarLease.Feature.Cars.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        public ICarListsModel GetCar(string currentSite, string filterName)
        {
            ICarListsModel cars = null;

            if (!string.IsNullOrEmpty(currentSite) && !string.IsNullOrEmpty(filterName))
            {
                //Get the list of cars with filter option
                cars = GetFilteredCars(currentSite, filterName);
            }
            else
            {
                Item datasourceItem = filterName.IsNullOrEmpty() ? Sitecore.Context.Database.Items.GetItem(Constants.DatasourceItems.carListsDataSource) :
                            RenderingContext.Current.Rendering.Item;
                
                //Get the list of all cars
                cars = GetAllCars(datasourceItem);
                
            }
            return cars;
        }

        private ICarListsModel GetFilteredCars(string currentSite, string filterName)
        {             
          
            try
            {
                currentSite = FomartRenderingContext(currentSite);

                Item datasourceItem = currentSite.IsNullOrEmpty() ?
                                      Sitecore.Context.Database.Items.GetItem(Constants.DatasourceItems.carListsDataSource) :
                                      Sitecore.Context.Database.Items.GetItem(ID.Parse(currentSite));

                Sitecore.Data.Fields.MultilistField multiselectField = datasourceItem.Fields[Constants.FieldName.CarsList];

                var carList = new List<ICarModel>();
                if (multiselectField != null && multiselectField.Count > 0)
                {
                    var ItemList = multiselectField.GetItems().ToList();
                    var carData = ItemList.Where(c => c.Fields[Constants.FieldName.Type].Value.Contains(filterName));
                    carList = GetCars(carData);

                }
                return new CarListsModel() {Cars = carList };
            }
            catch (Exception ex)
            {
                Log.Error("Error while fetching cars list CarLease.Feature.Cars.Repositories.GetFilteredCars" + ex.Message, this);
            }
            return null;
        }

        private List<ICarModel> GetCars(IEnumerable<Item> carData)
        {
            var carList = new List<ICarModel>();
            foreach (var item in carData)
            {
                var mappedFields = MapFields(item);
                if (mappedFields != null)
                {
                    carList.Add(mappedFields);
                }
            }
            return carList;
        }

        private ICarListsModel GetAllCars(Item myItem)
        {                      
            try
            {
                Sitecore.Data.Fields.MultilistField multiselectField = myItem.Fields[Constants.FieldName.CarsList];
               
                var carList = new List<ICarModel>();
                if (multiselectField != null && multiselectField.Count > 0)
                {
                   var ItemList = multiselectField.GetItems().ToList();
                    carList = GetCars(ItemList);

                }
                return new CarListsModel() { Cars = carList};
            }
            catch (Exception ex)
            {
                Log.Error("Unable to fetch car lists CarLease.Feature.Cars.Repositories.GetAllCars" + ex.Message, this);
            }
            return null;
        }

        private ICarModel MapFields(Item carItem)
        {
            try
            {

                return new CarModel
                {
                    Title = carItem.Fields[Constants.FieldName.Title]?.Value,
                    Image = ImageHelper.GetImageUrl(carItem.Fields[Constants.FieldName.Image]),
                    ShortDescription = carItem.Fields[Constants.FieldName.ShortDescription]?.Value,
                    Type = carItem.Fields[Constants.FieldName.Type]?.Value
                };
            }
            catch(Exception ex)
            {
                Log.Error("Error while mapping car fields CarLease.Feature.Cars.Repositories.MapField" + ex.Message, this);
            }
            return null;
        }

        private static string FomartRenderingContext(string currentSite)
        {
            currentSite = currentSite.IsNullOrEmpty() ? "" : currentSite.Substring(currentSite.IndexOf('%') + 1).Remove(0, 2);
            currentSite = currentSite.IsNullOrEmpty() ? "" : currentSite.Substring(currentSite.IndexOf('=') + 1).Replace(@"""", string.Empty);
            int index = currentSite.LastIndexOf('%');
            if (index > 0)
            {
                currentSite = currentSite.Substring(0, index);
            }

            return currentSite;
        }

    }
}