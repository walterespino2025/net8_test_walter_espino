using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Repositories;
using System.Linq.Expressions;

namespace Products.Persistence.Repository;

internal sealed class ProductRepository : IProductRepository
{
    
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return null;
    }

    public async Task<Product?> GetProducts(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return null;


    }

    public void Add(Product product)
    {
    }
}