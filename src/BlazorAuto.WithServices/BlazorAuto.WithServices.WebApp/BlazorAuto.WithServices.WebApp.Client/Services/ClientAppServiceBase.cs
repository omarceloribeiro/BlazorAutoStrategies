using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorAuto.WithServices.WebApp.Client.Services
{
    public abstract class ClientAppServiceBase
    {
        protected HttpClient HttpClient { get; }

        protected ClientAppServiceBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected async Task<TResponse?> ExecuteGetAsync<TResponse>(string requestUri)
        {
            var resultContent = await HttpClient.GetFromJsonAsync<TResponse>(requestUri);
            return resultContent;
        }

        protected async Task<TResponse?> ExecutePostAsync<TRequest, TResponse>(string requestUri, TRequest model)
        {
            var resultContent = await HttpClient.PostAsJsonAsync<TRequest>(requestUri, model);

            var result = await resultContent.Content.ReadFromJsonAsync<TResponse>(CancellationToken.None);

            return result;
        }

        protected async Task<IEnumerable<TResponse>> ExecuteGetEnumerableAsync<TResponse>(string requestUri)
        {
            var response = HttpClient.GetFromJsonAsAsyncEnumerable<TResponse>(requestUri);
            if (response != null)
            {
                var responseList = await response.ToListAsync();
                if (responseList != null)
                {
                    return responseList.Where(x => x != null).AsEnumerable()!;
                }
            }

            return [];
        }
    }
}
