namespace TaskGear.Core.Model;

public class User 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string PasswordHash { get; set; }
    public string? ImageUrl { get; set; }
}