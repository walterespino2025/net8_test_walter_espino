using Microsoft.EntityFrameworkCore;

namespace net8_test_walter_espino.data
{
    public class ProductsDBContext(DbContextOptions<ProductsDBContext> options) : DbContext(options) 
    {
        public DbSet<Product> Products { get; set; }
    }
}
