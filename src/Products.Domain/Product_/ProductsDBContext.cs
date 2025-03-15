using Microsoft.EntityFrameworkCore;

namespace Products.Domain.Entities
{
    public class ProductsDBContext(DbContextOptions<ProductsDBContext> options) : DbContext(options) 
    {
        public DbSet<Product_> Products { get; set; }
    }
}
