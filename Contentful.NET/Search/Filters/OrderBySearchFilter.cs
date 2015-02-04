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
            Field = "order";
            Comparison = direction == OrderByDirection.Ascending ? "=" : "=-";
            Value = propertyName;
        }
    }
}
