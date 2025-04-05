namespace TaskGear.Core.Model;
public class Comment 
{
    public Guid Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public User CreatedByUser { get; set; }
    
    public Guid TaskId { get; set; }
    public Task Task { get; set; }

    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}