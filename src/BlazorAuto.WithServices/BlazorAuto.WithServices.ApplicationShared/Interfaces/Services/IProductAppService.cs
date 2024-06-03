using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;

namespace BlazorAuto.WithServices.ApplicationShared.Interfaces.Services
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductReponse>> ReadAllProduct();
        Task<ProductReponse> CreateProduct(CreateOrUpdateProductRequest productRequest);
        Task<ProductReponse> UpdateProduct(CreateOrUpdateProductRequest productRequest);
        Task<ProductReponse?> GetProductById(int id);
        Task DeleteProductById(int id);
    }
}
