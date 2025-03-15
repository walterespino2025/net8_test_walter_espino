using Products.Domain.Entities;
using Products.Domain.Repositories;

namespace Products.Persistence.Repository;

internal sealed class MemberRepository : IProductRepository
{
    public async Task<Product_?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return null;
    }

    public void Add(Product_ member)
    {
    }
}