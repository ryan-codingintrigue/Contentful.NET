using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Contentful.NET.DataModels;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using Newtonsoft.Json;

namespace Contentful.NET
{
    public class ContentfulClient : IContentfulClient
    {
        private readonly string _space;
        private readonly HttpClient _httpClient;

        public ContentfulClient(string accessToken, string space)
        {
            _space = space;
            if(string.IsNullOrEmpty(accessToken)) throw new ArgumentException("Access Token cannot be null or empty", "accessToken");
            _httpClient = BuildHttpClient(accessToken);
        }

        internal ContentfulClient(HttpClient configuredHttpClient)
        {
            _httpClient = configuredHttpClient;
        }

        public async Task<T> GetAsync<T>(CancellationToken cancellationToken, string id) where T : IContentfulItem, new()
        {
            var endpointUrl = RestEndpointResolver.GetEndpointUrl<T>(_space);
            var requestUrl = GetRequestUrl(endpointUrl, id);
            var result = await MakeGetRequestAsync(requestUrl, cancellationToken);
            return await GetItemAsync<T>(result);
        }

        public async Task<SearchResult<T>> SearchAsync<T>(CancellationToken cancellationToken, IEnumerable<ISearchFilter> searchFilters = null, string orderByProperty = null, OrderByDirection? orderByDirection = null, int? skip = null, int? limit = null, int? includeLevels = null) where T : IContentfulItem, new()
        {
            var endpointUrl = RestEndpointResolver.GetEndpointUrl<T>(_space);
            var requestUrl = GetRequestUrl(endpointUrl, null, searchFilters, orderByProperty, orderByDirection, skip, limit);
            var result = await MakeGetRequestAsync(requestUrl, cancellationToken);
            return await GetItemAsync<SearchResult<T>>(result);
        }

        internal async Task<HttpResponseMessage> MakeGetRequestAsync(string url, CancellationToken cancellationToken)
        {
            var result = await _httpClient.GetAsync(url, cancellationToken);
            if (!result.IsSuccessStatusCode) throw new Exception("Server returned response");
            return result;
        }

        internal static string GetRequestUrl(string baseUri, string id = null, IEnumerable<ISearchFilter> filters = null, string orderByProperty = null, OrderByDirection? orderByDirection = null, int? skip = null, int? limit = null, int? includeLevels = null)
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

        internal static bool AreAllNull(params object[] properties)
        {
            return properties.All(p => p == null);
        }

        internal static string GetQueryStringFromSearchFilters(IEnumerable<ISearchFilter> filters)
        {
            if (filters == null) return null;
            return string.Join("&",
                filters.Select(
                    filter =>
                        string.Format("{0}{1}{2}", Uri.EscapeDataString(filter.Field), filter.Comparison,
                            Uri.EscapeDataString(filter.Value))));
        }

        internal static HttpClient BuildHttpClient(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            return httpClient;
        }

        internal static async Task<T> GetItemAsync<T>(HttpResponseMessage responseMessage)
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