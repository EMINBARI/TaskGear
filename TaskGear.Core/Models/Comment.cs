using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;
public class Comment: IEntity
{
    public Guid Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public ProjectMember CreatedByMember { get; set; }
    
    public Guid TaskId { get; set; }
    public ProjectTask Task { get; set; }

    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public Comment () {}

    public Comment(
        Guid id, 
        Guid createdBy, 
        ProjectMember createdByUser, 
        Guid taskId, 
        ProjectTask task, 
        string content)
    {
        Id = id;
        CreatedBy = createdBy;
        CreatedByMember = createdByUser;
        TaskId = taskId;
        Task = task;
        Content = content;
    }
}