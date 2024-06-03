using BlazorAuto.WithServices.Application.Handlers;
using BlazorAuto.WithServices.ApplicationShared.Handlers;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using BlazorAuto.WithServices.Core.Interfaces.Services;

namespace BlazorAuto.WithServices.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IRequestHandler<CreateOrUpdateProductRequest, ProductReponse> _createProductHandler;
        private readonly IProductDomainService _productDomainService;

        public ProductAppService(
            IRequestHandler<CreateOrUpdateProductRequest, ProductReponse> createProductHandler,
            IProductDomainService productDomainService)
        {
            _createProductHandler = createProductHandler;
            _productDomainService = productDomainService;
        }
        public Task<ProductReponse> CreateProduct(CreateOrUpdateProductRequest productRequest)
        {
            return _createProductHandler.Handle(productRequest);
        }

        public Task DeleteProductById(int id)
        {
            return _productDomainService.Delete(id);
        }

        public Task<ProductReponse> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductReponse>> ReadAllProduct()
        {
            var allItems = await _productDomainService.ReadAll();
            var allItemsResponse = allItems
                .Select(x => 
                    new ProductReponse(x.Id, x.Name, x.Description ?? string.Empty, x.Price, 
                        new ProductCategoryResponse(x.CategoryId, x.Category?.Title ?? string.Empty)));

            return allItemsResponse;
        }

        public Task<ProductReponse> UpdateProduct(CreateOrUpdateProductRequest productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
