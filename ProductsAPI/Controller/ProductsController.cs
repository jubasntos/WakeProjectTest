using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Repositories.Interfaces;

namespace ProductsAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts() 
        {
            List<Product> products =  await _productsRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product product = await _productsRepository.GetById(id);
            return Ok(product);
        }

        [HttpGet("nome")]
        public async Task<ActionResult<Product>> GetByName(string name)
        {
            Product product = await _productsRepository.GetByName(name);
            return Ok(product);
        }

        [HttpGet("sortedByPrice")]
        public async Task<ActionResult<List<Product>>> SortedByPrice()
        {
            List<Product> products = await _productsRepository.SortedByPrice();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product products)
        {
            Product product = await _productsRepository.Create(products);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update([FromBody] Product products, int id)
        {       
            products.Id = id;
            Product product = await _productsRepository.Update(products, id);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            if(id == 0)
            {
                return NotFound(new { erro = $"O produto {id} não foi encontrado" });
            }

            bool deleted = await _productsRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
