using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace LoggingApp.Common
{
    public abstract class HttpFilter : IHttpFilter
    {
        public IHttpFilter InnerFilter { get; set; }
        public HttpFilter()
        {
            InnerFilter = new HttpBaseProtocolFilter();
        }
        public abstract IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> SendRequestAsync(HttpRequestMessage request);
        public abstract void Dispose();
    }
}
