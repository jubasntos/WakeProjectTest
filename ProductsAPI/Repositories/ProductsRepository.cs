using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Builders;
using Products.API.Repositories.Interfaces;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Repositories.Interfaces;
using System.Globalization;

namespace ProductsAPI.Repositories
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly ProductsDBContext _dbContext;

        public ProductsRepository(ProductsDBContext productsDBContex)
        {
            _dbContext = productsDBContex;
        }
        public ProductsRepository()
        {

        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetByName(string name)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Nome.Contains(name));

            if (product == null)
            {
                throw new Exception("O Produto não foi encontrado no banco de dados.");
            }

            return product;
        }

        public async Task<List<Product>> SortedByPrice()
        {
            return await _dbContext.Products.OrderBy(p => p.Valor).ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product, int id)
        {
            Product productId = await GetById(id);

            if(productId == null){
                throw new Exception("O Produto não foi encontrado no banco de dados.");
            }

            productId.Nome = product.Nome;
            productId.Valor = product.Valor;
            productId.Estoque = product.Estoque;

            _dbContext.Products.Update(productId);
            await _dbContext.SaveChangesAsync();

            return productId;

        }

        public async Task<bool> Delete(int id)
        {
            Product productId = await GetById(id);

            if (productId == null)
            {
                throw new Exception("O Produto não foi encontrado no banco de dados.");
            }

            _dbContext.Products.Remove(productId);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
