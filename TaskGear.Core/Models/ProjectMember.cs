using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;

public class ProjectMember: IEntity
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public Guid UserId { get; set; }   

    public ProjectMember() {}
}