using Products.Domain.ValueObjects;

namespace Products.Application.Products.Queries.GetAllProducts;


public record AllProductResponse(
    Guid Id,
    string Name
    );