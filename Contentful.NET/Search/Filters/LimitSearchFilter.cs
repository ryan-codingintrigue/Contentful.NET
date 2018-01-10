using System;

namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to limit the number of search results returned
    /// </summary>
    public class LimitSearchFilter : ISearchFilter
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
        /// Creates a new filter instance with the given results limit
        /// </summary>
        /// <param name="limit">The number of results to limit the search query to</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the value passed for limit is not in the expected range: [0-Int32.MaxValue]</exception>
        public LimitSearchFilter(int limit)
        {
            if(limit < 0) throw new ArgumentOutOfRangeException("limit", limit, "Limit must be greater than or equal to zero");
            Field = "limit";
            Comparison = "=";
            Value = limit.ToString();
        }
    }
}
