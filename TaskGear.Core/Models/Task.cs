using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class Task: IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }

    public Guid TaskStateId { get; set; }
    public TaskState TaskState { get; set; }

    public Guid CreatedBy { get; set; }
    public User CreatedByUser { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public Task() {}
}