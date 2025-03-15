using Products.Application.Abstractions.Messaging;
using Products.Domain.Repositories;
using Products.Domain.Shared;

namespace Products.Application.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler
    : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResponse>> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var _product = await _productRepository.GetByIdAsync(
            request.id,
            cancellationToken);

        if (_product is null)
        {
            return Result.Failure<ProductResponse>(new Error(
                "Product.NotFound",
                $"The member with Id {request.id} was not found"));
        }

        var response = new ProductResponse(_product.Id, _product.Name);

        return response;
    }
}