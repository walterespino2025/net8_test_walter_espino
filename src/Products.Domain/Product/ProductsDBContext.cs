using Microsoft.EntityFrameworkCore;

namespace Products.Domain.Product
{
    public class ProductsDBContext(DbContextOptions<ProductsDBContext> options) : DbContext(options) 
    {
        public DbSet<Product> Products { get; set; }
    }
}
