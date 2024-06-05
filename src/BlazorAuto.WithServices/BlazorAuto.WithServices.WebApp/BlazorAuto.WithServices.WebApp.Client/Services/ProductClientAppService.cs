using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace BlazorAuto.WithServices.WebApp.Client.Services
{
    public class ProductClientAppService : IProductAppService
    {
        private readonly HttpClient _httpClient;

        public ProductClientAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async ValueTask<ProductReponse> CreateProduct(CreateOrUpdateProductRequest productRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", productRequest);
            //string jsonContent = await response.Content.ReadAsStringAsync();
            //return JsonSerializer.Deserialize<ProductReponse>(jsonContent) ?? new ProductReponse(0, "", "", 0, new ProductCategoryResponse(0, ""));
            //return await response.Content.ReadFromJsonAsync<ProductReponse>(CancellationToken.None) ?? new ProductReponse(0, "", "", 0, new ProductCategoryResponse(0, ""));
            var productResponse = await response.Content.ReadFromJsonAsync<ProductReponse>(CancellationToken.None);
            if (productResponse == null)
                throw new ServiceApiException("invalid result when creating product. product response is null");

            return productResponse;
        }

        public async ValueTask DeleteProductById(int id)
        {
            await _httpClient.DeleteAsync($"api/products/{id}");
        }

        public async ValueTask<ProductReponse?> GetProductById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ProductReponse>($"api/products/{id}");
            return response;
        }

        public async ValueTask<IEnumerable<ProductReponse>> ReadAllProduct()
        {
            var response = _httpClient.GetFromJsonAsAsyncEnumerable<ProductReponse>($"api/products");
            var responseList = await response.ToListAsync();

            //responseList!.Add(new ProductReponse(123, "HttpClient Product", "Product added from cliente service", 0, new ProductCategoryResponse(0, "")));


            return responseList!;
            
            //await foreach (var item in response)
            //{
                
            //}            
            
            //_httpClient.GetFromJsonAsAsyncEnumerable<ProductReponse>
            //return response;
        }

        public async ValueTask<ProductReponse> UpdateProduct(CreateOrUpdateProductRequest productRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", productRequest, CancellationToken.None);
            var responseResult = await response.Content.ReadFromJsonAsync<ProductReponse>();

            return responseResult!;
        }

        
    }
    public static class AsyncEnumerableExtensions
    {
        public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> asyncEnumerable)
        {
            List<T> result = new();

            await foreach (var item in asyncEnumerable)
            {
                if (item != null)
                {
                    result.Add(item);
                }

            }

            return result;
        }
    }
}
