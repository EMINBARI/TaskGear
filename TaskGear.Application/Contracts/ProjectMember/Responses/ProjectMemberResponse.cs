using TaskGear.Core.Models;

namespace TaskGear.Application.Services.Contracts;

public class ProjectMemberResponse 
{
    public Guid Id {get; set;}
    public Project Project {get; set;}
    public User User {get; set;}

    public ProjectMemberResponse(ProjectMember projectMember)
    {
        Id = projectMember.Id;
        Project = projectMember.Project;
        User = projectMember.User;
    }

}