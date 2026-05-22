// ECOMERCE/ECommerce.Application/ApplicationServiceExtensions.cs
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Application.Common.Behaviors;
using ECommerce.Application.Services;           

namespace ECommerce.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceExtensions).Assembly));

        services.AddValidatorsFromAssembly(typeof(ApplicationServiceExtensions).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Servicios de Autenticación
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<AuthService>();

        return services;
    }
}