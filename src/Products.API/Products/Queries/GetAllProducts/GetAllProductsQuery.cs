using MediatR;
using Products.Application.Abstractions.Messaging;

namespace Products.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<List<AllProductResponse>>;

