// ECOMERCE/ECommerce.Application/Features/Products/Commands/DeleteProduct/DeleteProductCommand.cs
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;