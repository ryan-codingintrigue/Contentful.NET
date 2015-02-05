using System;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    public sealed class EqualitySearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public EqualitySearchFilter(string propertyName, string equalityValue, Equality equality = Equality.Equal)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = (equality == Equality.Equal ? SearchFilterComparer.Equal : SearchFilterComparer.NotEqual).ToString();
            Value = equalityValue;
        }
    }
}
