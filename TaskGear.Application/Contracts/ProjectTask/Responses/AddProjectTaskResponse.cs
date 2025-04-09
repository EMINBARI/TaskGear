namespace TaskGear.Application.Services.Contracts;

public class AddProjectTaskResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public AddProjectResponse Project { get; set; }

    public Guid TaskStateId { get; set; }
    public AddTaskStateResponse TaskState { get; set; }

    public Guid CreatedBy { get; set; }
    public AddProjectMemberResponse CreatedByMember { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
}