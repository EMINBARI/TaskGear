namespace TaskGear.Core.Model;
public class Assignee 
{
    public Guid Id { get; set; }
    
    public Guid TaskId { get; set; }
    public Task Task { get; set; }

    public Guid ProjectMemberId { get; set; }
    public ProjectMember ProjectMember { get; set; }
}