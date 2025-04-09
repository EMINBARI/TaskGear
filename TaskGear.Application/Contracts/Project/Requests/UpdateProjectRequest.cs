namespace TaskGear.Application.Services.Contracts;

public class UpdateProjectRequest {
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public AddUserRequest CreatedByUser { get; set; }
}