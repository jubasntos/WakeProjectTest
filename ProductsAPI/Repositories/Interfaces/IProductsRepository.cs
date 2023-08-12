using ProductsAPI.Models;

namespace ProductsAPI.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();

        Task<List<Product>> SortedByPrice();

        Task<Product> GetById(int id);

        Task<Product> GetByName(string name);

        Task<Product> Create(Product product);

        Task<Product> Update(Product product, int id);

        Task<bool> Delete(int id);  

    }
}
