namespace TaskGear.Application.Services.Contracts;

public class AddProjectRequest {
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
}