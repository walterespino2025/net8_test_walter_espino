using Products.Application.Abstractions.Messaging;
using Products.Domain.Entities;
using Products.Domain.Repositories;
using Products.Domain.Shared;
using Products.Domain.ValueObjects;
using MediatR;

namespace Products.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductsCommandHandler : ICommandHandler<CreateProductsCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductsCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        var nameResult = Name.Create(request.Name);
        

        var member = new Product_(
            Guid.NewGuid(),
            nameResult.Value);

        _productRepository.Add(member);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}