using LoggingApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoggingApp.Services
{
    public interface IBusinessAssociateService
    {
        Task<(bool IsSuccessful, PageResult<BusinessAssociate> Result, HttpError Error)> GetNextPageAsync(int? skip = null,
            int? top = null, IEnumerable<string> select = null, string searchText = null, string number = null, string matchcode = null, Uri nextPageLink = null);
    }
}
