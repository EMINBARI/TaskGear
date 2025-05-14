using TaskGear.Core.Models;

namespace TaskGear.Application.Services.Contracts;

public class AddProjectTaskRequest 
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public Guid TaskStateId { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}