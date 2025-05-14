namespace TaskGear.Application.Services.Contracts;

public class UpdateProjectTaskRequest 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid TaskStateId { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}
