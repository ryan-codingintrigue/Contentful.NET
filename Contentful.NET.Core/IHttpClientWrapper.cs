using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Contentful.NET
{
    internal interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken);
    }
}
