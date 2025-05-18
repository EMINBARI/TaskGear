namespace TaskGear.Application.Contracts;

public class AddCommentRequest
{
    public Guid CreatedBy { get; set; } // Project Member
    public Guid TaskId { get; set; }
    public string Content { get; set; }

    public AddCommentRequest(Guid createdBy, Guid taskId, string content)
    {
        CreatedBy = createdBy;
        TaskId = taskId;
        Content = content;
    }
}