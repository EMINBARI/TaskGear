namespace TaskGear.Application.Services.Contracts;

public class ProjectTaskResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public ProjectResponse Project { get; set; }

    public Guid TaskStateId { get; set; }
    public TaskStateResponse TaskState { get; set; }

    public Guid CreatedBy { get; set; }
    public ProjectMemberResponse CreatedByMember { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
}
