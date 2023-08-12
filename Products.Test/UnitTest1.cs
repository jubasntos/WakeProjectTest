using Microsoft.EntityFrameworkCore;
using Moq;
using Products.API.Repositories.Interfaces;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Repositories;
using ProductsAPI.Repositories.Interfaces;

namespace Products.Test
{
    public class UnitTest1
    {
        private DbContextOptions<ProductsDBContext> _options;

        [Fact]
        public void CreateProduct_AddsProductToDatabase()
        {

            _options = new DbContextOptionsBuilder<ProductsDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ProductsDBContext(_options))
            {
                var repository = new ProductsRepository(context);
                var initialCount = repository.GetAllProducts().Result.Count();

                var newProduct = new Product
                {
                    Nome = "Test Product2",
                    Valor = 10.99m,
                    Estoque = 50
                };

                repository.Create(newProduct);

                var updatedCount = repository.GetAllProducts().Result.Count();
                var addedProduct = repository.GetById(newProduct.Id);

                Assert.Equal(initialCount + 1, updatedCount);
                Assert.NotNull(addedProduct);
                Assert.Equal("Test Product2", addedProduct.Result.Nome);
            }
        }
    }
}