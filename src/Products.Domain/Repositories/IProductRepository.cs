using Products.Domain.Entities;

namespace Products.Domain.Repositories;

public interface IProductRepository
{
    Task<Product_?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Product_ member);
}