using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Products.Domain.Entities;
using Products.Domain.Primitives;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Persistence.ProductDBContext
{

    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext(DbContextOptions<ProductsDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasData(
                new Product("Pen",5.5,5),
                new Product("Car",12.500,1),
                new Product("Nintendo Switch",200.2,4)
            );
        }


    }

}
