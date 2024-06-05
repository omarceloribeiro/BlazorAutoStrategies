using BlazorAuto.WithServices.ApplicationShared.Handlers;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using BlazorAuto.WithServices.Core.Interfaces.Services;
using BlazorAuto.WithServices.Core.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace BlazorAuto.WithServices.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateOrUpdateProductRequest, ProductReponse>
    {
        private readonly IProductDomainService _productDomainService;

        public CreateProductHandler(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }
        public async Task<ProductReponse> Handle(CreateOrUpdateProductRequest request)
        {
            Product product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Category = new ProductCategory()
                {
                     Title = request.CategoryTitle ?? string.Empty,
                     Id = request.CategoryId
                }
            };

            //if (request.CategoryId == 0 && !string.IsNullOrWhiteSpace(request.CategoryTitle))
            //{
            //    product.Category.Title = request.CategoryTitle;
            //}

            if (request.Id > 0)
            {

            }
            Product productSaved;

            if (request.Id > 0)
                productSaved = await _productDomainService.Update(product);
            else
                productSaved = await _productDomainService.Create(product);

            //ProductReponse productReponse = new(
            //    productCreated.Id,
            //    productCreated.Name,
            //    productCreated.Description ?? string.Empty,
            //    productCreated.Price,
            //    productCreated.CategoryId,
            //    productCreated.Category?.Title ?? string.Empty);

            ProductReponse productReponse = new(
                productSaved.Id,
                productSaved.Name,
                productSaved.Description ?? string.Empty,
                productSaved.Price,
                new ProductCategoryResponse(productSaved.CategoryId, productSaved.Category?.Title ?? string.Empty)
                );

            return productReponse;

                //Id = productCreated.Id,
                //Name = productCreated.Name,
                //CategoryId = productCreated.CategoryId,
                //CategoryTitle = productCreated.Category?.Title ?? string.Empty,
                //Description = productCreated.Description,
                //Price = productCreated.Price)

            //return new ProductReponse();
            
        }
    }
}
