// ECOMERCE/ECommerce.Domain/Interfaces/IProductRepository.cs
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> SearchByNameAsync(string term, CancellationToken ct = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
}