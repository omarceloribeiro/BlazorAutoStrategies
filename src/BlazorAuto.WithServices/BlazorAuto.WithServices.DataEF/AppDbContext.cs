using BlazorAuto.WithServices.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuto.WithServices.DataEF
{
    public class AppDbContext : DbContext
    {
        // parameterless construcutor for the scaffold to work
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) 
            : base (dbContextOptions)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // required for the scaffold to work
                optionsBuilder.UseSqlServer("scaffold");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
