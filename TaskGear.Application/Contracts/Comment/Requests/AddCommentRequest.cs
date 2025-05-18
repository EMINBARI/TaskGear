namespace TaskGear.Application.Contracts.Comment.Requests;

public class AddCommentRequest
{
    public Guid CreatedBy {get; set;} // Project Member
    public Guid TaskId {get; set;}
    public string Content { get; set; }
}