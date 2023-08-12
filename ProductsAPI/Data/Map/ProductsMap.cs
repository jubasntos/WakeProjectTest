using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsAPI.Models;

namespace ProductsAPI.Data.Map
{
    public class ProductsMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Estoque).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
        }
    }
}
