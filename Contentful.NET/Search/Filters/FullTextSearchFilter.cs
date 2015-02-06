namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to perform a full text search on Content
    /// </summary>
    public sealed class FullTextSearchFilter : ISearchFilter
    {
        /// <summary>
        /// The name of the property to compare to
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// The value of the equality comparison to use
        /// </summary>
        public string Comparison { get; private set; }

        /// <summary>
        /// The value to test equality against
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new filter instance with the given equality criteria. If a propertyName is provided,
        /// the full text search will only apply to that property name. If it is omitted, the full text
        /// search will search across all properties
        /// </summary>
        /// <param name="equalityValue">The String value to compare against</param>
        /// <param name="propertyName">The name of the Content property to test against</param>
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
