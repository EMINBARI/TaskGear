using Microsoft.AspNetCore.Mvc;
using TaskGear.Application.Contracts;
using TaskGear.Application.Services.CommentService;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommentResponse>> GetComment(Guid id)
    {
        var comment = await _commentService.GetCommentAsync(id);
        return Ok(comment);
    }

    [HttpGet]
    public async Task<ActionResult<List<CommentResponse>>> GetComments()
    {
        var comments = await _commentService.GetCommentsAsync();
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult> CreateComment([FromBody] AddCommentRequest request)
    {
        var comment = await _commentService.AddCommentAsync(request);
        return Ok(comment);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateComment([FromBody] UpdateCommentRequest request)
    {
        var comment = await _commentService.EditCommentAsync(request);
        return Ok(comment);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteComment(Guid id)
    {
        await _commentService.DeleteCommentAsync(id);
        return Ok(
            new { message = $"User  with id {id} successfully deleted" }
        );
    }


}