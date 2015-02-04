using System;
using Contentful.NET.Search.Enums;

namespace Contentful.NET.Search.Filters
{
    public sealed class InclusionSearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public InclusionSearchFilter(string propertyName, string equalityValue, InEquality equality = InEquality.In)
        {
            if(string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Property Name must be specified");
            Field = propertyName;
            Comparison = (equality == InEquality.In ? SearchFilterComparer.In : SearchFilterComparer.NotIn).ToString();
            Value = equalityValue;
        }
    }
}
