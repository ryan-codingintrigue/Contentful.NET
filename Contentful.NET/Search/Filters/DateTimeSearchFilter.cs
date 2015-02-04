using System;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    public sealed class DateTimeSearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public DateTimeSearchFilter(string propertyName, DateTime equalityValue, NumericEquality equality)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            switch (equality)
            {
                    case NumericEquality.LessThan:
                    Comparison = SearchFilterComparer.LessThan.ToString(); break;
                    case NumericEquality.LessThanEqualTo:
                        Comparison = SearchFilterComparer.LessThanEqual.ToString(); break;
                    case NumericEquality.GreaterThan:
                        Comparison = SearchFilterComparer.GreaterThan.ToString(); break;
                    case NumericEquality.GreaterThanEqualTo:
                        Comparison = SearchFilterComparer.GreaterThanEqual.ToString(); break;
            }
            Value = equalityValue.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }
    }
}
