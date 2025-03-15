using Products.Application.Abstractions.Messaging;

namespace Products.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid id) : IQuery<ProductResponse>;