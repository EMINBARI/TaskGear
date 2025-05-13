using TaskGear.Core.Models;

namespace TaskGear.Application.Services.Contracts;

public class ProjectMemberResponse 
{
    public Guid Id {get; set;}
    public ProjectResponse Project {get; set;}
    public UserResponse User {get; set;}

    public ProjectMemberResponse(ProjectMember projectMember)
    {
        Id = projectMember.Id;
        Project = new ProjectResponse(projectMember.Project);
        User = new UserResponse(projectMember.User);
    }

}