namespace TaskGear.Application.Services.Contracts;

public class AddProjectMemberRequest 
{
    public Guid UserId {get; set;}
    public Guid ProjectId {get; set;}
}