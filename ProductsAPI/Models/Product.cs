using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ?Nome { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
