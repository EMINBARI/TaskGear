using TaskGear.Core.Models;

namespace TaskGear.Application.Contracts;

public class CommentResponse
{
    public Guid Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public ProjectMember CreatedByMember { get; set; }
    
    public Guid TaskId { get; set; }
    public ProjectTask Task { get; set; }

    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public CommentResponse(Comment comment)
    {
        Id = comment.Id;
        CreatedBy = comment.CreatedBy;
        CreatedByMember = comment.CreatedByMember;
        TaskId = comment.TaskId;
        Task = comment.Task;
        Content = comment.Content;
        CreatedAt = comment.CreatedAt;
    }
}