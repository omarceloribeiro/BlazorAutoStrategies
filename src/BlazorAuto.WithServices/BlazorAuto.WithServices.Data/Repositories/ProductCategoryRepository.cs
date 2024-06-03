using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public Task<ProductCategory> Create(ProductCategory model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductCategory>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> Update(ProductCategory model)
        {
            throw new NotImplementedException();
        }
    }
}
