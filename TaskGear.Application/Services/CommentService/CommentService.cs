using TaskGear.Application.Contracts;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;

namespace TaskGear.Application.Services.CommentService;

public class CommentService(
    ICommentRepository commentRepository, 
    IProjectTaskRepository projectTaskRepository, 
    IProjectMemberRepository projectMemberRepository) : ICommentService
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IProjectTaskRepository _projectTaskRepository = projectTaskRepository;
    private readonly IProjectMemberRepository _projectMemberRepository = projectMemberRepository;
    
    public async Task<CommentResponse> AddCommentAsync(AddCommentRequest request)
    {
        var task = await _projectTaskRepository.GetAsync(request.TaskId, CancellationToken.None);
        var member = await _projectMemberRepository.GetAsync(request.CreatedBy, CancellationToken.None);
         
        var comment = new Comment(
            Guid.NewGuid(),
            taskId: request.TaskId,
            task: task ?? throw new Exception("Task not found"),
            createdBy: request.CreatedBy,
            createdByUser:member ?? throw new Exception("Member not found"),
            content:request.Content
        );
        
        await _commentRepository.AddAsync(comment, CancellationToken.None);

        return new CommentResponse(comment);
    }

    public async Task<CommentResponse> EditCommentAsync(UpdateCommentRequest request)
    {
        var comment = await _commentRepository.GetAsync(request.Id, CancellationToken.None);

        if (comment == null)
            throw new Exception($"Could not find comment with id {request.Id}");

        comment.Content = request.Content;

        return new CommentResponse(comment);
    }

    public async Task<CommentResponse> GetCommentAsync(Guid commentId)
    {
        var comment = await _commentRepository.GetAsync(commentId, CancellationToken.None);

        if (comment == null)
            throw new Exception($"Could not find comment with id {commentId}");

        return new CommentResponse(comment);
    }

    public async Task<IEnumerable<CommentResponse>> GetCommentsAsync()
    {
        var comments = await _commentRepository.GetAsync(c => true, CancellationToken.None);
        return comments.Select(comment => new CommentResponse(comment));
    }

    public async Task DeleteCommentAsync(Guid commentId)
    {
        var comment = await _commentRepository.GetAsync(commentId, CancellationToken.None);

        if (comment == null)
            throw new Exception($"Could not find comment with id {commentId}");

        await _commentRepository.DeleteAsync(comment, CancellationToken.None);
    }
}