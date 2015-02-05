using System;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    internal class OrderBySearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public OrderBySearchFilter(string propertyName, OrderByDirection direction)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = "order";
            Comparison = direction == OrderByDirection.Ascending ? "=" : "=-";
            Value = propertyName;
        }
    }
}
