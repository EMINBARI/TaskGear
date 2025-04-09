namespace TaskGear.Application.Services.Contracts;

public class AddProjectTaskRequest 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public AddProjectRequest Project { get; set; }

    public Guid TaskStateId { get; set; }
    public AddTaskStateRequest TaskState { get; set; }

    public Guid CreatedBy { get; set; }
    public AddProjectMemberRequest CreatedByMember { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
}