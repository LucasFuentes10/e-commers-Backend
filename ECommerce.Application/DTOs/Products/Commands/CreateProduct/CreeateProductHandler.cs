// ECOMERCE/ECommerce.Application/Features/Products/Commands/CreateProduct/CreateProductHandler.cs
using MediatR;
using ECommerce.Domain.Interfaces;        // ← Aquí está la interfaz
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product(
            command.Name, 
            command.Description, 
            command.Price, 
            command.Stock, 
            command.CategoryId);

        await _repository.AddAsync(product, cancellationToken);

        return new CreateProductResponse(product.Id, product.Name, product.Price, product.Stock);
    }
}