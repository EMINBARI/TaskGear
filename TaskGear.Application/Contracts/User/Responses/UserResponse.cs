using TaskGear.Core.Models;

namespace TaskGear.Application.Services.Contracts;

public class UserResponse 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }

    public UserResponse(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        ImageUrl = user.ImageUrl;
    }
}