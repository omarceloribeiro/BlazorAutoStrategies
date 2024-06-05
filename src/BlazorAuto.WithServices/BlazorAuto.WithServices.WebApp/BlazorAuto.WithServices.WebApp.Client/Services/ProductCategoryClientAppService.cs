using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;

namespace BlazorAuto.WithServices.WebApp.Client.Services
{
    public class ProductCategoryClientAppService : ClientAppServiceBase, IProductCategoryAppService
    {
        public ProductCategoryClientAppService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async ValueTask<IEnumerable<ProductCategoryResponse>> ReadAll()
        {
            return await ExecuteGetEnumerableAsync<ProductCategoryResponse>("/api/productcategories");
        }
    }
}
