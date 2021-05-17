using CarLease.Feature.Cars.Models.FilterModel;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;

namespace CarLease.Feature.Cars.Repositories
{
    public class FiltersRepository : IFiltersRepository
    {
       
        public FilterModel GetFilters()
        {
          //  var filters = new FilterModel();            

          //  var datasource = RenderingContext.Current.Rendering.Item;

            //Cast to a Sitecore item
            Sitecore.Data.Items.Item datasourceItem = RenderingContext.Current.Rendering.Item;
            Sitecore.Data.Fields.MultilistField multiselectField = datasourceItem.Fields[Constants.FieldName.Filters];

            //   List<Sitecore.Data.Items.Item> ItemList = new List<Sitecore.Data.Items.Item>();
            var filterList = new List<string>();
            if (multiselectField?.Count > 0)
            {
               // ItemList = multiselectField.GetItems();
                foreach (var item in multiselectField.GetItems())
                {
                    filterList.Add(item.Fields[Constants.FieldName.Title]?.Value);
                }
            }
          //  filters.Filter = new List<string>(filterList);
            return new FilterModel() { Filter = filterList };
        }
    }
}