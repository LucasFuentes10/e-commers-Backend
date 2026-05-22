// ECOMERCE/ECommerce.Application/Services/IJwtService.cs
namespace ECommerce.Application.Services;

public interface IJwtService
{
    string GenerateToken(Guid userId, string email, string role);
}