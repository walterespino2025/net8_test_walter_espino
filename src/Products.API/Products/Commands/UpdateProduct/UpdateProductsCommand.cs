using MediatR;
using Products.Application.Abstractions.Messaging;

namespace Products.Application.Products.Commands.CreateProduct;

public sealed record UpdateProductsCommand(Guid Id,
    string Name, double Price, int Stock) : IRequest<Guid>;