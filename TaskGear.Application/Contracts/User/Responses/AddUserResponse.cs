namespace TaskGear.Application.Services.Contracts;

public class AddUserResponse 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }
}