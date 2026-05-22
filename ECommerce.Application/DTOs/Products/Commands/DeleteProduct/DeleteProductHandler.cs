// ECOMERCE/ECommerce.Application/Features/Products/Commands/DeleteProduct/DeleteProductHandler.cs
using MediatR;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler 
    : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        var exists = await _repository.ExistsAsync(
            command.Id,
            cancellationToken);

        if (!exists)
            return false;

        await _repository.DeleteAsync(
            command.Id,
            cancellationToken);

        return true;
    }
}