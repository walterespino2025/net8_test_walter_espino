using Products.Domain.Primitives;
using Products.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
     public double Price { get; set; }
    public int Stock { get; set; }

    // Parameterless constructor for EF Core
    private Product() { }
    public Product(string name, double price, int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Stock = stock;
    }
}

