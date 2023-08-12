using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data.Map;
using ProductsAPI.Models;

namespace ProductsAPI.Data
{
    public class ProductsDBContext: DbContext
    {
        public ProductsDBContext(DbContextOptions<ProductsDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } 

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
