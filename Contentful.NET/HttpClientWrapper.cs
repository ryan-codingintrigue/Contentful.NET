using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Contentful.NET
{
    /// <summary>
    /// Internal HTTPClient Wrapper for unit testing GET requests
    /// </summary>
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _baseClient;

        public HttpClientWrapper(HttpClient baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return await _baseClient.GetAsync(requestUri, cancellationToken);
        }
    }
}