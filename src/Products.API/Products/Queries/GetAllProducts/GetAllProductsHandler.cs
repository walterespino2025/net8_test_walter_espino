using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Repositories;
using Products.Persistence.ProductDBContext;

namespace Products.Application.Products.Queries.GetAllProducts;

internal sealed class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<AllProductResponse>>
{
    private readonly ProductsDBContext _dbContext;
    public GetAllProductsHandler(ProductsDBContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<AllProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var _product = await _dbContext
            .Products
            .Select(p => new AllProductResponse(
                p.Id,
                p.Name,
                p.Price,
                p.Stock
                )).ToListAsync();


        if (_product is null)
        {
            throw null;
        }

       // var response = new AllProductResponse(_product.Id, _product.Name.Value);

        return _product;
    }
}