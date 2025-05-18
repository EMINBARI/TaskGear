using TaskGear.Core.Models;

namespace TaskGear.Application.Contracts.Comment.Responses;

public class CommentResponse
{
    public Guid Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public ProjectMember CreatedByMember { get; set; }
    
    public Guid TaskId { get; set; }
    public ProjectTask Task { get; set; }

    public string Content { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}