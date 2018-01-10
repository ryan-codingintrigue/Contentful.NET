using System;

namespace Contentful.NET.Search.Filters
{
    /// <summary>
    /// Filter which is used to skip a number of search results
    /// </summary>
    public class SkipSearchFilter : ISearchFilter
    {
        /// <summary>
        /// Always 'skip' for this filter
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// Always '=' for this filter
        /// </summary>
        public string Comparison { get; private set; }

        /// <summary>
        /// The number of search results to skip
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new filter instance with the given skip amount
        /// </summary>
        /// <param name="skip">The number of search results to skip</param>
        /// <exception cref="System.ArgumentException">Thrown if the number of results to skip is less than or equal to zero</exception>
        public SkipSearchFilter(int skip)
        {
            if(skip < 0) throw new ArgumentException("Skip must be greater than or equal to zero");
            Field = "skip";
            Comparison = "=";
            Value = skip.ToString();
        }
    }
}
