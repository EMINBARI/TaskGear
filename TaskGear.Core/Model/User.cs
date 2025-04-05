using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class User: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string PasswordHash { get; set; }
    public string? ImageUrl { get; set; }

    public User() {}
}