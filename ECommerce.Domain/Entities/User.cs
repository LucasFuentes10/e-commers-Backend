// ECOMERCE/ECommerce.Domain/Entities/User.cs
namespace ECommerce.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "User";

    // Constructor vacío para EF Core
    public User() { }

    // Constructor para crear usuarios
    public User(string email, string name, string password, string role = "User")
    {
        Id = Guid.NewGuid();
        Email = email;
        Name = name;
        PasswordHash = password;
        Role = role;
    }
}