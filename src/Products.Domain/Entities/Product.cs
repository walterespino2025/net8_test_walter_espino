using Products.Domain.Primitives;
using Products.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities;

public class Product
{
    private Product() { }
    public Product(string Name) 
    {
        Id=Guid.NewGuid();
        Name = Name;
    }

    public Guid Id { get; set; }
    [NotMapped]
    public string Name { get; set; }
}

