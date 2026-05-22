// ECOMERCE/ECommerce.Application/Features/Auth/commands/Register/RegisterCommand.cs
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Register;

public record RegisterCommand(
    string Email,
    string Name,
    string Password
) : IRequest<AuthResponse>;

public record AuthResponse(
    Guid UserId,
    string Email,
    string Token,
    string Role   // ← Agregar esto
);