namespace TaskGear.Application.Services.Contracts;

public class UpdateProjectTaskResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public UpdateProjectResponse Project { get; set; }

    public Guid TaskStateId { get; set; }
    public UpdateTaskStateResponse TaskState { get; set; }

    public Guid CreatedBy { get; set; }
    public UpdateProjectMemberResponse CreatedByMember { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
}
