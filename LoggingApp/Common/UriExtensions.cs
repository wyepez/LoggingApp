using System;

namespace LoggingApp.Common
{
    public static class UriExtensions
    {
        public static Uri Append(this Uri uri, string otherUri)
        {
            if ((otherUri?.Length ?? 0) == 0)
            {
                return uri;
            }

            var sUri = $"{uri}".TrimEnd('/', '\\');
            otherUri = otherUri.TrimStart('/', '\\');

            return new Uri($"{sUri}/{otherUri}");
        }
    }
}
