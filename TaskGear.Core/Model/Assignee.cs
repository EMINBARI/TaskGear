using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;
public class Assignee: IEntity
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }
    public Task Task { get; set; }

    public Guid ProjectMemberId { get; set; }
    public ProjectMember ProjectMember { get; set; }

    public Assignee() {}

    // public Assignee(Guid id, Guid taskId, Task task, Guid projectMemberId, ProjectMember projectMember){
    //     Id = id;
    //     TaskId = taskId;
    //     Task = task;
    //     ProjectMemberId = projectMemberId;
    //     ProjectMember = projectMember; 
    // }
}