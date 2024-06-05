using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;
using System.Collections.Generic;

namespace BlazorAuto.WithServices.Data.Repositories
{
    public class ProductInMemoryRepository : IProductRepository
    {
        public ValueTask<Product> Create(Product model)
        {
            throw new NotImplementedException();
        }

        public ValueTask Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Product?> Read(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Product>> ReadAll()
        {
            
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 5; i++)
            {
                products.Add(new() { Id = i, Name = $"Product {i}" });
            }

            return ValueTask.FromResult(products.AsEnumerable());
        }

        public ValueTask<Product> Update(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
