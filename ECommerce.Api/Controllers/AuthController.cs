//ECommerce.Api/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Features.Auth.Commands.Register;
using ECommerce.Application.Services;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
   public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var response = await _authService.Register(command);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
       var response = await _authService.Login(request.Email, request.Password);

        if (response == null)
            return Unauthorized(new { message = "Credenciales inválidas" });

        return Ok(response);
    }
}

public record LoginRequest(string Email, string Password);