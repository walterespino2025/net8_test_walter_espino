

using MediatR;

namespace Products.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : IRequest<Guid>;
}
