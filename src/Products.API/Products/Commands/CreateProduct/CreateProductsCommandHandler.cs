using MediatR;
using Products.Application.Abstractions.Messaging;
using Products.Domain.Entities;
using Products.Domain.Repositories;
using Products.Domain.Shared;
using Products.Domain.ValueObjects;
using Products.Persistence.ProductDBContext;

namespace Products.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, Guid>
{
    private readonly ProductsDBContext _dbContext;
    public CreateProductsCommandHandler(ProductsDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        
        var _product = new Product(
            request.Name, request.Price, request.Stock);

        _dbContext.Add(_product);

        _dbContext.SaveChangesAsync(cancellationToken);

        return _product.Id;
    }
}