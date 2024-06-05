using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using BlazorAuto.WithServices.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuto.WithServices.Application.Services
{
    public class ProductCategoryAppService : IProductCategoryAppService
    {
        private readonly IProductCategoryDomainService _productCategoryDomain;

        public ProductCategoryAppService(IProductCategoryDomainService productCategoryDomain)
        {
            _productCategoryDomain = productCategoryDomain;
        }
        public async ValueTask<IEnumerable<ProductCategoryResponse>> ReadAll()
        {
            var items = await _productCategoryDomain.ReadAll();
            return items.Select(x => new ProductCategoryResponse(x.Id, x.Title));
        }
    }
}
