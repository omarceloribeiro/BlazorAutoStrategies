using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;

namespace BlazorAuto.WithServices.ApplicationShared.Interfaces.Services
{
    public interface IProductAppService
    {
        ValueTask<IEnumerable<ProductReponse>> ReadAllProduct();
        ValueTask<ProductReponse> CreateProduct(CreateOrUpdateProductRequest productRequest);
        ValueTask<ProductReponse> UpdateProduct(CreateOrUpdateProductRequest productRequest);
        ValueTask<ProductReponse?> GetProductById(int id);
        ValueTask DeleteProductById(int id);
    }
}
