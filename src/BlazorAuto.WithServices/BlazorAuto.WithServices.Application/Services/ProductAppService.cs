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
        public async ValueTask<ProductReponse> CreateProduct(CreateOrUpdateProductRequest productRequest)
        {
            var result = await _createProductHandler.Handle(productRequest);
            return result;
        }

        public ValueTask DeleteProductById(int id)
        {
            return _productDomainService.Delete(id);
        }

        public async ValueTask<ProductReponse?> GetProductById(int id)
        {
            var product = await _productDomainService.Read(id);
            if (product != null)
            {
                return new ProductReponse(product.Id, product.Name, product.Description ?? string.Empty, product.Price, new ProductCategoryResponse(product.CategoryId, product.Category?.Title ?? string.Empty));
            }

            return null;
        }

        public async ValueTask<IEnumerable<ProductReponse>> ReadAllProduct()
        {
            var allItems = await _productDomainService.ReadAll();
            var allItemsResponse = allItems
                .Select(x => 
                    new ProductReponse(x.Id, x.Name, x.Description ?? string.Empty, x.Price, 
                        new ProductCategoryResponse(x.CategoryId, x.Category?.Title ?? string.Empty)));

            return allItemsResponse;
        }

        public async ValueTask<ProductReponse> UpdateProduct(CreateOrUpdateProductRequest productRequest)
        {
            var result = await _createProductHandler.Handle(productRequest);
            return result;
        }
    }
}
