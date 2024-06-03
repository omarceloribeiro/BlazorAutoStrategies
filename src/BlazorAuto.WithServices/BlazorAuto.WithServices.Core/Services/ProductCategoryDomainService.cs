using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Interfaces.Services;
using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Core.Services
{
    public class ProductCategoryDomainService : CrudDomainServiceBase<ProductCategory>, IProductCategoryDomainService
    {
        public ProductCategoryDomainService(IProductCategoryRepository repository) : base(repository)
        {
        }
    }
}
