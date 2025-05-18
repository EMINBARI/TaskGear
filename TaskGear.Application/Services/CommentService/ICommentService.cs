using TaskGear.Application.Contracts.Comment.Requests;
using TaskGear.Application.Contracts.Comment.Responses;

namespace TaskGear.Application.Services.CommentService;

public interface ICommentService
{
    public Task<CommentResponse> AddCommentAsync(AddCommentRequest request);
    public Task<CommentResponse> EditCommentAsync(UpdateCommentRequest request);
    public Task<CommentResponse> GetCommentAsync(Guid commentId);
    public Task<IEnumerable<CommentResponse>> GetCommentsAsync();
    public Task DeleteCommentAsync(Guid commentId);
}