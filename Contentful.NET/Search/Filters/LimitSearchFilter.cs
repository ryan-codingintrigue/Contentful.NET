using System;

namespace Contentful.NET.Search.Filters
{
    internal class LimitSearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public LimitSearchFilter(int limit)
        {
            if(limit < 0) throw new ArgumentException("Limit must be greater than or equal to zero");
            Field = "limit";
            Comparison = "=";
            Value = limit.ToString();
        }
    }
}
