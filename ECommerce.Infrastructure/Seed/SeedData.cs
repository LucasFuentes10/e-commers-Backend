// ECOMERCE/ECommerce.Infrastructure/Seed/SeedData.cs
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Seed;

public static class SeedData
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        if (await context.Products.AnyAsync())
            return;

        var products = new List<Product>
        {
            new Product("Laptop Dell XPS 15", "Intel i7 - 16GB RAM - 512GB SSD", 1299.99m, 10, Guid.NewGuid()),
            new Product("iPhone 15 Pro", "128GB - Titanio Natural", 1099.99m, 8, Guid.NewGuid()),
            new Product("Monitor LG 27\" 4K", "Ultra HD IPS", 399.99m, 15, Guid.NewGuid()),
            new Product("Teclado Mecánico Logitech G Pro", "RGB Gaming", 89.99m, 25, Guid.NewGuid()),
            new Product("Auriculares Sony WH-1000XM5", "Cancelación de Ruido", 349.99m, 12, Guid.NewGuid())
        };

        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ Seed Data cargado correctamente");
    }
}