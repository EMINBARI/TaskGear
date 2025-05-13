using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class User: IEntity
{
    private string email;
    private string name;
    private string passwordHash;

    public Guid Id { get; set; }
    public string Name { 
        get => name; 
        set {
            if (string.IsNullOrWhiteSpace(value)){
                throw new Exception("Name should not be null or empty.");
            }
            name = value;
        } 
    }
    public string Email { 
        get => email; 
        set {
            if (string.IsNullOrWhiteSpace(value)){
                throw new Exception("Email should not be null or empty.");
            }
            email = value;
        }
    }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string PasswordHash { 
        get => passwordHash; 
        set {
            if (string.IsNullOrWhiteSpace(value)){
                throw new Exception("Password should not be null or empty.");
            }
            passwordHash = value;
        }
    }
    public string? ImageUrl { get; set; }

    public User() {}

    public User(Guid id, string name, string email, string passwordHash) 
    {
        Id = id;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;

        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}