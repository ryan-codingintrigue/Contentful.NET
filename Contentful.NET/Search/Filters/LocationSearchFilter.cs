using System;

namespace Contentful.NET.Search.Filters
{
    public sealed class LocationSearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public LocationSearchFilter(string propertyName, decimal latitude, decimal longitude)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = SearchFilterComparer.LocationNear.ToString();
            Value = string.Join(",", new[] { latitude, longitude });
        }

        public LocationSearchFilter(string propertyName, decimal latitude, decimal longitude, decimal radius)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = SearchFilterComparer.LocationWithin.ToString();
            Value = string.Join(",", new[] { latitude, longitude, radius });
        }

        public LocationSearchFilter(string propertyName, decimal latitude, decimal longitude, decimal latitude2, decimal longitude2)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = SearchFilterComparer.LocationWithin.ToString();
            Value = string.Join(",", new[] { latitude, longitude, latitude2, longitude2 });
        }
    }
}
