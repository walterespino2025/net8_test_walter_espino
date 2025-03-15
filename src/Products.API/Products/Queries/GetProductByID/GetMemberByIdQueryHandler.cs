using Products.Application.Abstractions.Messaging;
using Products.Domain.Repositories;
using Products.Domain.Shared;

namespace Products.Application.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler
    : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _memberRepository;

    public GetProductByIdQueryHandler(IProductRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<Result<ProductResponse>> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var _product = await _memberRepository.GetByIdAsync(
            request.ProductID,
            cancellationToken);

        if (_product is null)
        {
            return Result.Failure<ProductResponse>(new Error(
                "Member.NotFound",
                $"The member with Id {request.ProductID} was not found"));
        }

        var response = new ProductResponse(_product.Id, _product.Name.Value);

        return response;
    }
}