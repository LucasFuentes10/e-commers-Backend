// ECOMERCE/ECommerce.Application/Features/Products/Queries/GetAllProducts/GetAllProductsHandler.cs
using MediatR;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(
        GetAllProductsQuery request, 
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products.Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Description,
            p.Price,
            p.Stock
        ));
    }
}