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
                new Product("Walter"),
                new Product("Ale"),
                new Product("Lucy")
            );
        }


    }

}
