using MediatR;
using Products.Application.Products.Commands.CreateProduct;
using Products.Application.Products.Commands.DeleteProduct;
using Products.Application.Products.Queries.GetProductById;
using Products.Domain.Entities;
using Products.Persistence.ProductDBContext;

public class DeleteProductCommandHandler :IRequestHandler<DeleteProductCommand, Guid>
{

    private readonly ProductsDBContext _dbContext;
    public DeleteProductCommandHandler(ProductsDBContext dbContext)
    {
        _dbContext = dbContext;
    }
   

    public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {

        var _product = _dbContext.Products.Where(x => x.Id.Equals(request.Id))
            .FirstOrDefault();
        if (_product == null) return request.Id;
        _dbContext.Products.Remove(_product);
        await _dbContext.SaveChangesAsync();

        return _product.Id;

    }
}
