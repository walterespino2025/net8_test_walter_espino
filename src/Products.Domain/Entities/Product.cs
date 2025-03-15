using Products.Domain.Primitives;
using Products.Domain.ValueObjects;

namespace Products.Domain.Entities;

public sealed class Product_ : Entity
{
    public Product_(Guid id, Name name)
    : base(id)
    {
        Name = name;
    }
    public Name Name { get; set; }
}

