using TaskGear.Core.Abstractions;

namespace TaskGear.Core.Models;
public class Comment: IEntity
{
    public Guid Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public User CreatedByUser { get; set; }
    
    public Guid TaskId { get; set; }
    public ProjectTask Task { get; set; }

    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Comment () {}

    // public Comment (Guid id, Guid createdBy, User createdByUser, Guid taskId, Task task) {

    // }


}