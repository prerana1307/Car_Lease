using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLease.Feature.Cars
{
    public struct Constants
    {
        public struct FieldName
        {
            public const string Title = "Title";
            public const string Filters = "Filters";
            public const string Image = "Image";
            public const string ShortDescription = "Short Description";
            public const string Type = "Type";
            public const string CarsList = "CarsList";
        }

        public struct DatasourceItems
        {
            public const string carListsDataSource = "{BB368C7F-EBE4-42E7-A3F5-3B75074E8297}";
        }
    }
}