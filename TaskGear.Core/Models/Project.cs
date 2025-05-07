using System.Data;
using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;
public class Project: IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid CreatedBy { get; set; }
    public User CreatedByUser { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public Project() {}

    public Project(
        Guid id, 
        string title, 
        string description, 
        Guid createdBy, 
        User createdByUser,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt
    )
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedBy = createdBy;
        CreatedByUser = createdByUser;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}