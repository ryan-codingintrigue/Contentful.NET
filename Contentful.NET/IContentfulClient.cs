

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contentful.NET.DataModels;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;

namespace Contentful.NET
{
    /// <summary>
    /// Contract for a Contentful HTTP Client
    /// </summary>
    public interface IContentfulClient
    {
        /// <summary>
        /// Get a single Contentful Item from the space
        /// </summary>
        /// <typeparam name="T">The type of Contentful Item to retrieve</typeparam>
        /// <param name="cancellationToken">Cancellation Token for the async request</param>
        /// <param name="id">Queries for the given ID</param>
        /// <returns>An instance of an IContentfulItem if found</returns>
        Task<T> GetAsync<T>(CancellationToken cancellationToken, string id)
            where T : IContentfulItem, new();

        Task<SearchResult<T>> SearchAsync<T>(CancellationToken cancellationToken,
            IEnumerable<ISearchFilter> searchFilters = null, string orderByProperty = null,
            OrderByDirection? orderByDirection = null, int? skip = null, int? limit = null, int? includeLevels = null)
            where T : IContentfulItem, new();
    }
}
