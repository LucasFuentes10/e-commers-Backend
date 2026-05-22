// ECOMERCE/ECommerce.Application/Features/Products/Commands/UpdateProduct/UpdateProductHandler.cs
using MediatR;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (existing == null)
            return false;

        // Creamos una nueva instancia con los datos actualizados
        var updatedProduct = new ECommerce.Domain.Entities.Product(
            command.Name,
            command.Description,
            command.Price,
            command.Stock,
            existing.CategoryId
        );

        // Copiamos el mismo ID (usando reflexión porque es protected)
        typeof(ECommerce.Domain.Entities.BaseEntity)
            .GetProperty("Id")!
            .SetValue(updatedProduct, command.Id);

        await _repository.UpdateAsync(updatedProduct, cancellationToken);
        return true;
    }
}