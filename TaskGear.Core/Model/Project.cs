namespace TaskGear.Core.Model;
public class Project 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public Guid CreatedBy { get; set; }
    public User CreatedByUser { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}