using MediatR;
using Products.Application.Abstractions.Messaging;
using Products.Domain.Repositories;
using Products.Domain.Shared;
using Products.Persistence.ProductDBContext;
using System.Linq;

namespace Products.Application.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse?>
{
    private readonly ProductsDBContext _dbContext;
    public GetProductByIdQueryHandler(ProductsDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductResponse?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {

        var _product = _dbContext.Products.Where(x => x.Id.Equals(request.Id)).
            Select(p => new ProductResponse(
                p.Id,
                p.Name,
                p.Price,
                p.Stock
                ))
            .FirstOrDefault();

        if (_product is null)
        {
            return null;
        }

        return new ProductResponse(_product.Id, _product.Name, _product.Price, _product.Stock);

    }
}