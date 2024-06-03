using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;
using System.Collections.Generic;

namespace BlazorAuto.WithServices.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> Create(Product model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> ReadAll()
        {
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 5; i++)
            {
                products.Add(new() { Id = i, Name = $"Product {i}" });
            }

            return Task.FromResult(products.AsEnumerable());
        }

        public Task<Product> Update(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
