using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuto.WithServices.DataEF.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Product> DefaultIncludes(IQueryable<Product> query)
        {
            return query.Include(x => x.Category);
        }
    }
}
