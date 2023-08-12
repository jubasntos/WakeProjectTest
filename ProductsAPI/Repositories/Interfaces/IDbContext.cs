using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace Products.API.Repositories.Interfaces
{
    public interface IDbContext
    {
        DbSet<Product> Products { get; }
        int SaveChanges();
    }
}
