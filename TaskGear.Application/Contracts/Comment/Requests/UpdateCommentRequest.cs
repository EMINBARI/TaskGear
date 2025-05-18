namespace TaskGear.Application.Contracts;

public class UpdateCommentRequest
{
    public Guid Id { get; set; }
    public string Content { get; set; }

    public UpdateCommentRequest(Guid id, string content)
    {
        Id = id;
        Content = content;
    }
}