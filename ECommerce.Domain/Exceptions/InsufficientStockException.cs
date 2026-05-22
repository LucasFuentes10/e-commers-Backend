//ECOMERCE/ECommerce.Domain/Exceptions/InsufficientStockException.cs
namespace ECommerce.Domain.Exceptions;

public class InsufficientStockException : Exception
{
    public InsufficientStockException(string message) 
        : base(message)
    {
    }

    public InsufficientStockException(string productName, int requestedQuantity, int availableStock)
        : base($"Stock insuficiente para el producto '{productName}'. Solicitado: {requestedQuantity}, Disponible: {availableStock}")
    {
    }
}