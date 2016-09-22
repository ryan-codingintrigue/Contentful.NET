using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Contentful.NET
{
    /// <summary>
    /// Internal HTTPClient Wrapper for unit testing GET requests
    /// </summary>
    internal class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _baseClient;

        internal HttpClientWrapper(HttpClient baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return await _baseClient.GetAsync(requestUri, cancellationToken);
        }
    }
}