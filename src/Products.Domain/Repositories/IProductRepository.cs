using Products.Domain.Entities;
using System.Linq.Expressions;

namespace Products.Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Product?> GetProducts(CancellationToken cancellationToken = default);

    void Add(Product product);
}