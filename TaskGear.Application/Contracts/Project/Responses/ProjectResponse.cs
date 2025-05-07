using TaskGear.Core.Models;

namespace TaskGear.Application.Services.Contracts;

public class ProjectResponse {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public UserResponse CreatedByUser { get; set; }

    public ProjectResponse(Project project)
    {
        Id = project.Id;
        Title = project.Title;
        Description = project.Description;
        CreatedBy = project.CreatedBy;
        CreatedByUser = new UserResponse(project.CreatedByUser);
        CreatedAt = project.CreatedAt;
        UpdatedAt = project.UpdatedAt;
    }
}