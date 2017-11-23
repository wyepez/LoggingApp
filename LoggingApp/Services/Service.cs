using LoggingApp.Common;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace LoggingApp.Services
{
    public abstract class Service
    {
        protected async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            using (var httpClient = HttpClientFactory.Create())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync(SettingsService.Instance.WebApiUri.Append(requestUri));
                //if (response.StatusCode == HttpStatusCode.Unauthorized)
                //    Views.Shell.Instance.ViewModel.ShowLogin = true;
                return response;
            }
        }

        protected async Task<HttpResponseMessage> PostAsync(string requestUri, object content)
        {
            using (var httpClient = HttpClientFactory.Create())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                var httpContent = new HttpStringContent(content == null ? string.Empty : JsonConvert.SerializeObject(content), UnicodeEncoding.Utf8, "application/json");
                var response = await httpClient.PostAsync(SettingsService.Instance.WebApiUri.Append(requestUri), httpContent);
                //if (response.StatusCode == HttpStatusCode.Unauthorized)
                //    Views.Shell.Instance.ViewModel.ShowLogin = true;
                return response;
            }
        }

        protected async Task<HttpResponseMessage> PutAsync(string requestUri, object content)
        {
            using (var httpClient = HttpClientFactory.Create())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                var httpContent = new HttpStringContent(content == null ? string.Empty : JsonConvert.SerializeObject(content), UnicodeEncoding.Utf8, "application/json");
                var response = await httpClient.PutAsync(SettingsService.Instance.WebApiUri.Append(requestUri), httpContent);
                //if (response.StatusCode == HttpStatusCode.Unauthorized)
                //    Views.Shell.Instance.ViewModel.ShowLogin = true;
                return response;
            }
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            using (var httpClient = HttpClientFactory.Create())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.DeleteAsync(SettingsService.Instance.WebApiUri.Append(requestUri));
                //if (response.StatusCode == HttpStatusCode.Unauthorized)
                //    Views.Shell.Instance.ViewModel.ShowLogin = true;
                return response;
            }
        }
    }
}
