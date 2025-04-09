namespace TaskGear.Application.Services.Contracts;

public class UpdateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string? ImageUrl { get; set; }
}