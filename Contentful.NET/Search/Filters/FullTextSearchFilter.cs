namespace Contentful.NET.Search.Filters
{
    public sealed class FullTextSearchFilter : ISearchFilter
    {
        public string Field { get; private set; }

        public string Comparison { get; private set; }

        public string Value { get; private set; }

        public FullTextSearchFilter(string equalityValue, string propertyName = null)
        {
            if (propertyName == null)
            {
                Field = "query";
                Comparison = SearchFilterComparer.Equal.ToString();
                Value = equalityValue;
            }
            else
            {
                Field = propertyName;
                Comparison = SearchFilterComparer.FullText.ToString();
                Value = equalityValue;
            }
        }
    }
}
