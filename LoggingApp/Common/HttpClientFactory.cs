using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace LoggingApp.Common
{
    public static class HttpClientFactory
    {
        public static HttpClient Create(params HttpFilter[] filters)
        {
            return Create(new HttpBaseProtocolFilter(), filters);
        }

        public static HttpClient Create(IHttpFilter innerFilter, params HttpFilter[] filters)
        {
            var pipeline = CreatePipeline(innerFilter, filters);
            return new HttpClient(pipeline);
        }

        public static IHttpFilter CreatePipeline(IHttpFilter innerFilter, IEnumerable<HttpFilter> filters)
        {
            if (innerFilter == null)
            {
                throw new ArgumentNullException(nameof(innerFilter));
            }

            if (filters == null)
            {
                return innerFilter;
            }

            IHttpFilter pipeline = innerFilter;
            foreach (HttpFilter filter in filters.Reverse())
            {
                if (filter == null)
                {
                    throw new ArgumentNullException(nameof(filters), "Http filter array contains null item.");
                }

                filter.InnerFilter = pipeline;
                pipeline = filter;
            }

            return pipeline;
        }
    }
}
