using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;
public class Assignee: IEntity
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }
    public ProjectTask Task { get; set; }

    public Guid ProjectMemberId { get; set; }
    public ProjectMember ProjectMember { get; set; }

    public Assignee() {}
}