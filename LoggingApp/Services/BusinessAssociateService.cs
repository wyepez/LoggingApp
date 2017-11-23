using LoggingApp.Common;
using LoggingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingApp.Services
{
    public class BusinessAssociateService
        : Service, IBusinessAssociateService
    {
        public async Task<(bool IsSuccessful, PageResult<BusinessAssociate> Result, HttpError Error)> GetNextPageAsync(int? skip = null,
            int? top = null, IEnumerable<string> select = null, string searchText = null, string number = null, string matchcode = null, Uri nextPageLink = null)
        {
            var parameters = new Dictionary<string, object>
            {
                { $"${nameof(skip)}", skip },
                { $"${nameof(top)}", top },
                { $"${nameof(select)}", (select == null) ? null : string.Join(",", select) },
                { $"{nameof(searchText)}", searchText },
                { $"{nameof(number)}", number },
                { $"{nameof(matchcode)}", matchcode }
            };
            var response = await GetAsync(nextPageLink?.PathAndQuery ?? $"api/business-associates{HttpUtility.ToQueryString(parameters)}");
            var (result, error) = response.IsSuccessStatusCode
                ? (JsonConvert.DeserializeObject<PageResult<BusinessAssociate>>(await response.Content.ReadAsStringAsync()), (HttpError)null)
                : ((PageResult<BusinessAssociate>)null, JsonConvert.DeserializeObject<HttpError>(await response.Content.ReadAsStringAsync()));
            return (response.IsSuccessStatusCode, result, error);
        }
    }
}
