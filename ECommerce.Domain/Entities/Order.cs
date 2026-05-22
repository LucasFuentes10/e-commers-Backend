// ECOMERCE/ECommerce.Domain/Entities/Order.cs
namespace ECommerce.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public decimal Total { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { }

    public Order(Guid userId)
    {
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
        Total = 0;
    }
}