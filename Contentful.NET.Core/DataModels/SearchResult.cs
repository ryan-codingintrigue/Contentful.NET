using System.Collections.Generic;

namespace Contentful.NET.DataModels
{
    /// <summary>
    /// Representation of a response from a search query of the Contentful API
    /// </summary>
    /// <typeparam name="T">The type of items as returned in the "items" field</typeparam>
    public class SearchResult<T> where T : IContentfulItem
    {
        /// <summary>
        /// The total number of records for the given query
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// The number of records skipped by this query
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// The number of records returned by this query
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// An enumerable of all items returned by the query
        /// </summary>
        public IEnumerable<T> Items { get; set; }
        /// <summary>
        /// If applicable, any included items returned by the query
        /// </summary>
        public Includes Includes { get; set; }
    }
}
