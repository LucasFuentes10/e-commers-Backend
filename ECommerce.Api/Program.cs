// ECOMERCE/ECommerce.Api/Program.cs

using ECommerce.Application;
using ECommerce.Infrastructure;
using ECommerce.Api.Middleware;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ==================== DEPENDENCY INJECTION ====================

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// ==================== CONTROLLERS ====================

builder.Services.AddControllers();

// ==================== SWAGGER ====================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header usando Bearer scheme. Ejemplo: 'Bearer {token}'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
});

// ==================== JWT ====================



var jwtSection = builder.Configuration.GetSection("Jwt");

var jwtKey = jwtSection["Key"];

if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("JWT Key no configurada");
}

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)),

            RoleClaimType = ClaimTypes.Role,
            NameClaimType = ClaimTypes.Email,

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

// ==================== EXCEPTION HANDLER ====================

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// ==================== BUILD ====================

var app = builder.Build();

// ==================== MIDDLEWARE ====================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionHandler();

// ==================== SEED DATA ====================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services
        .GetRequiredService<ECommerce.Infrastructure.Persistence.ApplicationDbContext>();

    await ECommerce.Infrastructure.Seed.SeedData.InitializeAsync(context);
}

// ==================== ENDPOINTS ====================

app.MapControllers();

app.Run();