// ECOMERCE/ECommerce.Domain/Entities/Product.cs
namespace ECommerce.Domain.Entities;

public class Product : BaseEntity   // ← Agregar : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public Guid CategoryId { get; private set; }

    // Constructor privado para EF Core
    private Product() { }

    public Product(string name, string description, decimal price, int stock, Guid categoryId)
    {
        // validaciones...
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }
}