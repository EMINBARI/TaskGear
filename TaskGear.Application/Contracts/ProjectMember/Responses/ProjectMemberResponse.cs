using TaskGear.Core.Models;

namespace TaskGear.Application.Services.Contracts;

public class ProjectMemberResponse 
{
    Guid Id {get; set;}
    Project Project {get; set;}
    User User {get; set;}

    public ProjectMemberResponse(ProjectMember projectMember)
    {
        Id = projectMember.Id;
        Project = projectMember.Project;
        User = projectMember.User;
    }

}