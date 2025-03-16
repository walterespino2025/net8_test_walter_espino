using MediatR;
using Products.Application.Abstractions.Messaging;

namespace Products.Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductResponse>;

