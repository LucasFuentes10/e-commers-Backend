// ECOMERCE/ECommerce.Infrastructure/Persistence/Configurations/ProductConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Description).HasMaxLength(1000);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Stock).IsRequired();

        // SEED DATA
        builder.HasData(
            new Product("Laptop Dell", "Laptop i7 16GB", 899.99m, 15, Guid.NewGuid()),
            new Product("iPhone 15", "128GB Negro", 999.99m, 8, Guid.NewGuid()),
            new Product("Casco Moto", "Protección integral", 89.99m, 25, Guid.NewGuid())
        );
    }
}