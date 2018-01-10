using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Contentful.NET.DataModels;
using Contentful.NET.Exceptions;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using Newtonsoft.Json;

namespace Contentful.NET
{
    /// <summary>
    /// Implemenation of the Contentful API Client
    /// </summary>
    public class ContentfulClient : IContentfulClient
    {
		private readonly bool _preview;
        private readonly string _space;
        public readonly IHttpClientWrapper HttpClient;

        /// <summary>
        /// Creates a new instance of the Contentful Client API
        /// </summary>
        /// <param name="accessToken">The access token for the provided space</param>
        /// <param name="space">The Space ID to query against</param>
		/// /// <param name="preview">Whether to use the preview API, false by default</param>
		public ContentfulClient(string accessToken, string space, bool preview = false)
        {
			_preview = preview;
            _space = space;
            if(string.IsNullOrEmpty(accessToken)) throw new ArgumentException("Access Token cannot be null or empty", "accessToken");
            HttpClient = BuildHttpClient(accessToken);
        }

        /// <summary>
        /// Internal constructor for unit testing
        /// </summary>
        /// <param name="space">The Space ID to query against</param>
        /// <param name="configuredHttpClient">The HTTP Client to use, must be preconfigured with Authorization header</param>
        public ContentfulClient(string space, IHttpClientWrapper configuredHttpClient)
        {
            _space = space;
            HttpClient = configuredHttpClient;
        }

        /// <summary>
        /// Retrieve a single IContentItem by specifying its ID.
        /// </summary>
        /// <typeparam name="T">The type of item expected to be returned</typeparam>
        /// <param name="cancellationToken">The cancellation token for the request</param>
        /// <param name="id">The ID of the content item</param>
        /// <returns>A new instance of the type T, populated with the data returned by Contentful</returns>
        /// <exception cref="ContentfulException">Thrown if the request to Contentful returned a status code other than 200 (OK)</exception>
        public async Task<T> GetAsync<T>(CancellationToken cancellationToken, string id) where T : IContentfulItem, new()
        {
			var endpointUrl = RestEndpointResolver.GetEndpointUrl<T>(_space, _preview);
            var requestUrl = GetRequestUrl(endpointUrl, id);
            var result = await MakeGetRequestAsync(requestUrl, cancellationToken);
            return await GetItemAsync<T>(result);
        }

        /// <summary>
        /// Search for a range of IContentItems, given the provided filters & sorting
        /// </summary>
        /// <typeparam name="T">The type of item expected to be returned</typeparam>
        /// <param name="cancellationToken">The cancellation token for the request</param>
        /// <param name="searchFilters">(Optional) A collection of ISearchFilter implementations which specify what content to retrieve from the space</param>
        /// <param name="orderByProperty">(Optional) The name of the property to order the results on</param>
        /// <param name="orderByDirection">(Optional) The direction in which to sort the results</param>
        /// <param name="skip">(Optional) The number of results to skip</param>
        /// <param name="limit">(Optional) The number of results to return</param>
        /// <param name="includeLevels">(Optional) The number of levels of included Content to return</param>
        /// <returns>A SearchResult object containing the content items, a list of includes (if applicable) and the total number of results for the query</returns>
        /// <exception cref="ContentfulException">Thrown if the request to Contentful returned a status code other than 200 (OK)</exception>
        public async Task<SearchResult<T>> SearchAsync<T>(CancellationToken cancellationToken, IEnumerable<ISearchFilter> searchFilters = null, string orderByProperty = null, OrderByDirection? orderByDirection = null, int? skip = null, int? limit = null, int? includeLevels = null) where T : IContentfulItem, new()
        {
            var endpointUrl = RestEndpointResolver.GetEndpointUrl<T>(_space, _preview);
            var requestUrl = GetRequestUrl(endpointUrl, null, searchFilters, orderByProperty, orderByDirection, skip, limit);
            var result = await MakeGetRequestAsync(requestUrl, cancellationToken);
            return await GetItemAsync<SearchResult<T>>(result);
        }

        /// <summary>
        /// Makes a get request to a URL and handles the result from Contentful
        /// </summary>
        /// <param name="url">The URL to send the request to</param>
        /// <param name="cancellationToken">The cancellation token for the request</param>
        /// <returns>A HttpResponseMessage with the success status code & content</returns>
        /// <exception cref="ContentfulException">Thrown if the request to Contentful returned a status code other than 200 (OK)</exception>
        public async Task<HttpResponseMessage> MakeGetRequestAsync(string url, CancellationToken cancellationToken)
        {
            var result = await HttpClient.GetAsync(url, cancellationToken);
            if (result.IsSuccessStatusCode) return result;
            throw new ContentfulException((int)result.StatusCode, await result.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Helper method to generate a GET URL from a set of filter parameters
        /// </summary>
        /// <param name="baseUri">The base URI for the contentful item</param>
        /// <param name="id">(Optional) The ID of the content</param>
        /// <param name="filters">(Optional) Any ISearchFilters which should be applied to the request</param>
        /// <param name="orderByProperty">(Optional) The name of the property on which to order by</param>
        /// <param name="orderByDirection">(Optional) The direction in which to order</param>
        /// <param name="skip">(Optional) The number of content entries to skip</param>
        /// <param name="limit">(Optional) The number of content entries to take</param>
        /// <param name="includeLevels">(Optional) The number of levels of includes which should be requested</param>
        /// <returns>An absolute URL to the Contentful service with the parameters passed through as a query string</returns>
        public static string GetRequestUrl(string baseUri, string id = null, IEnumerable<ISearchFilter> filters = null, string orderByProperty = null, OrderByDirection? orderByDirection = null, int? skip = null, int? limit = null, int? includeLevels = null)
        {
            if (AreAllNull(id, filters, orderByProperty, skip, limit, includeLevels)) return baseUri;
            var mergedFilters = filters != null ? filters.ToList() : new List<ISearchFilter>();
            if (orderByProperty != null)
                mergedFilters.Add(new OrderBySearchFilter(orderByProperty,
                    orderByDirection ?? OrderByDirection.Ascending));
            if (skip.HasValue) mergedFilters.Add(new SkipSearchFilter(skip.Value));
            if (limit.HasValue) mergedFilters.Add(new LimitSearchFilter(limit.Value));
            if(includeLevels.HasValue) mergedFilters.Add(new EqualitySearchFilter("include", includeLevels.Value.ToString()));
            var newBaseUrl = baseUri + id;
            if(!mergedFilters.Any()) return newBaseUrl;
            return newBaseUrl + "?" + GetQueryStringFromSearchFilters(mergedFilters);
        }

        /// <summary>
        /// Helper method to test if all parameters passed to a method are null. Assumes all properties are of nullable type
        /// </summary>
        /// <param name="properties">A list of properties to check</param>
        /// <returns>True if all properties are null, otherwise false</returns>
        public static bool AreAllNull(params object[] properties)
        {
            return properties.All(p => p == null);
        }
        
        /// <summary>
        /// Helper method to build a querystring value from a set of ISearchFilters
        /// </summary>
        /// <param name="filters">The search filters to use for the query string</param>
        /// <returns>A string literal containing the key/value pairs for a query string</returns>
        public static string GetQueryStringFromSearchFilters(IEnumerable<ISearchFilter> filters)
        {
            if (filters == null) return null;
            return string.Join("&",
                filters.Select(
                    filter =>
                        string.Format("{0}{1}{2}", Uri.EscapeDataString(filter.Field), filter.Comparison,
                            Uri.EscapeDataString(filter.Value))));
        }

        /// <summary>
        /// Helper method to build a HTTP Client configured with the required authorization header for Contentful
        /// </summary>
        /// <param name="accessToken">The access token for the required space</param>
        /// <returns>A new instance of HttpClient</returns>
        public static IHttpClientWrapper BuildHttpClient(string accessToken)
        {
            var httpClient = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            return new HttpClientWrapper(httpClient);
        }

        /// <summary>
        /// Helper method to read a JSON object from a HttpResponseMessage Stream and convert it to the give type
        /// </summary>
        /// <typeparam name="T">The type to serialize the JSON to</typeparam>
        /// <param name="responseMessage">The HttpResponseMessage returned from the Contentful API</param>
        /// <returns>A new instance of class T, populated with the data from the JSON</returns>
        public static async Task<T> GetItemAsync<T>(HttpResponseMessage responseMessage)
        {
            using (var streamReader = new StreamReader(await responseMessage.Content.ReadAsStreamAsync()))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}