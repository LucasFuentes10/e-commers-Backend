//ECOMERCE/ECommerce.Application/Services/AuthService.cs
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Application.Services;

public class AuthService
{
    private readonly IJwtService _jwtService;
    private readonly IUserRepository _userRepository;

    public AuthService(
        IJwtService jwtService,
        IUserRepository userRepository)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    public async Task<AuthResponse?> Register(RegisterCommand command)
    {
        var existingUser = await _userRepository.GetByEmailAsync(command.Email);

        if (existingUser != null)
            return null;

        var user = new User(
            command.Email,
            command.Name,
            command.Password,
            "User");

        await _userRepository.AddAsync(user);

        var token = _jwtService.GenerateToken(
            user.Id,
            user.Email,
            user.Role);

        return new AuthResponse(
            user.Id,
            user.Email,
            token,
            user.Role);
    }

    public async Task<AuthResponse?> Login(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
            return null;

        if (user.PasswordHash != password)
            return null;

        var token = _jwtService.GenerateToken(
            user.Id,
            user.Email,
            user.Role);

        return new AuthResponse(
            user.Id,
            user.Email,
            token,
            user.Role);
    }
}