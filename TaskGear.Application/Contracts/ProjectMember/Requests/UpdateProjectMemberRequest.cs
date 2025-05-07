namespace TaskGear.Application.Services.Contracts;

public class UpdateProjectMemberRequest 
{
    public Guid Id {get; set;}
    public Guid UserId {get; set;}
    public Guid ProjectId {get; set;}
}