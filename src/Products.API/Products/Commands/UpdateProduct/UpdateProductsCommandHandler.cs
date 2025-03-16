using MediatR;
using Products.Application.Abstractions.Messaging;
using Products.Application.Products.Commands.CreateProduct;
using Products.Application.Products.Queries.GetProductById;
using Products.Domain.Entities;
using Products.Domain.Repositories;
using Products.Domain.Shared;
using Products.Domain.ValueObjects;
using Products.Persistence.ProductDBContext;

namespace Products.Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, Guid>
{
    private readonly ProductsDBContext _dbContext;
    public UpdateProductsCommandHandler(ProductsDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
    {
        var _product = _dbContext.Products.Where(x => x.Id.Equals(request.Id))
            .FirstOrDefault();

        _product.Update(
            request.Name,
            request.Price,
            request.Stock
            );

        _dbContext.Update(_product);

        _dbContext.SaveChangesAsync(cancellationToken);

        return _product.Id;
    }
}