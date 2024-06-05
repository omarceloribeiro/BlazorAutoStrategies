using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;

namespace BlazorAuto.WithServices.Data.Repositories
{
    public class ProductCategoryInMemoryRepository : IProductCategoryRepository
    {
        public ValueTask<ProductCategory> Create(ProductCategory model)
        {
            throw new NotImplementedException();
        }

        public ValueTask Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ProductCategory?> Read(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<ProductCategory>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public ValueTask<ProductCategory> Update(ProductCategory model)
        {
            throw new NotImplementedException();
        }
    }
}
