using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LoggingApp.Common
{
    public static class HttpUtility
    {
        public enum InitialCharacter
        {
            QuestionMark,
            Ampersand
        }

        public static string ToQueryString(Dictionary<string, object> parameters)
        {
            return ToQueryString(parameters, InitialCharacter.QuestionMark);
        }

        public static string ToQueryString(Dictionary<string, object> parameters, InitialCharacter initialCharacter)
        {
            var queryString = parameters
                .Where(pair => pair.Value != null)
                .Select(pair =>
                {
                    switch (pair.Value)
                    {
                        case DateTime date:
                            return $"{pair.Key}={Uri.EscapeDataString($"{date.ToString("yyyy-MM-ddTHH:mm:ss.fff")}")}";
                        case IEnumerable enumerable when !(enumerable is string):
                            return $"{pair.Key}={Uri.EscapeDataString($"{string.Join(",", enumerable.Cast<object>())}")}";
                        default:
                            return $"{pair.Key}={Uri.EscapeDataString($"{pair.Value}")}";
                    }
                });
            string init;
            switch (initialCharacter)
            {
                case InitialCharacter.QuestionMark:
                    init = "?";
                    break;
                case InitialCharacter.Ampersand:
                    init = "&";
                    break;
                default:
                    throw new NotImplementedException();
            }
            return queryString.Count() > 0 ? init + string.Join("&", queryString) : string.Empty;
        }
    }
}
