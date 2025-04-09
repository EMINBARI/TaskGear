namespace TaskGear.Application.Services.Contracts;

public class AddProjectResponse {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public AddUserResponse CreatedByUser { get; set; }
}