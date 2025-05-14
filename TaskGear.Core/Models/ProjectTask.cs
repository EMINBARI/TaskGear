using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class ProjectTask: IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }

    public Guid TaskStateId { get; set; }
    public TaskState TaskState { get; set; }

    public Guid CreatedBy { get; set; }
    public ProjectMember CreatedByMember { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public ProjectTask() {}

    public ProjectTask(
        Guid id, 
        string title, 
        string description, 
        Guid projectId, 
        Project project, 
        Guid taskStateId, 
        TaskState taskState, 
        Guid createdBy, 
        ProjectMember createdByMember, 
        DateTimeOffset expiresAt, 
        DateTimeOffset createdAt, 
        DateTimeOffset updatedAt
    )
    {
        Id = id;
        Title = title;
        Description = description;
        ProjectId = projectId;
        Project = project;
        TaskStateId = taskStateId;
        TaskState = taskState;
        CreatedBy = createdBy;
        CreatedByMember = createdByMember;
        ExpiresAt = expiresAt;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}