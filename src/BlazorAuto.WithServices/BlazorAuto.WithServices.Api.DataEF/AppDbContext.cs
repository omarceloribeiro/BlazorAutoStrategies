using BlazorAuto.WithServices.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuto.WithServices.Api.DataEF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
