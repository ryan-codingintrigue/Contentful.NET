using System;

namespace Contentful.NET.Search.Filters
{
    internal class SkipSearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public SkipSearchFilter(int skip)
        {
            if(skip < 0) throw new ArgumentException("Skip must be greater than or equal to zero");
            Field = "skip";
            Comparison = "=";
            Value = skip.ToString();
        }
    }
}
