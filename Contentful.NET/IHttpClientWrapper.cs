using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Contentful.NET
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken);
    }
}
