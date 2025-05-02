using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class ProjectMember: IEntity
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public Guid UserId { get; set; }   
    public User User { get; set; }   

    public ProjectMember() {}

    public ProjectMember(Guid id, Guid projectId, Project project, Guid userId, User user) {
        Id = id;
        ProjectId = projectId;
        Project = project;
        UserId = userId;
        User = user;
    }
}