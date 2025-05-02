namespace TaskGear.Application.Services.Contracts;

public class UpdateProjectMemberRequest 
{
    public Guid UserId {get; set;}
    public Guid ProjectId {get; set;}
}