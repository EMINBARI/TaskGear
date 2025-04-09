namespace TaskGear.Application.Services.Contracts;

public class UpdateProjectTaskRequest 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public UpdateProjectRequest Project { get; set; }

    public Guid TaskStateId { get; set; }
    public UpdateTaskStateRequest TaskState { get; set; }

    public Guid CreatedBy { get; set; }
    public UpdateProjectMemberRequest CreatedByMember { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
}
