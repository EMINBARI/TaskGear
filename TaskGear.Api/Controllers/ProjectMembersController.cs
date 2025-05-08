using Microsoft.AspNetCore.Mvc;
using TaskGear.Application.Services;
using TaskGear.Application.Services.Contracts;

namespace TaskGear.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectMembersController : ControllerBase
{
    private readonly IProjectMemberService _projectMemberService;

    public ProjectMembersController(IProjectMemberService projectMemberService) {
        _projectMemberService = projectMemberService;
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProjectMemberResponse>> GetProjectMember(Guid id)
    {
        var projectMember = await _projectMemberService.GetProjectMemberAsync(id);
        return Ok(projectMember);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectMemberResponse>>> GetProjectMembers()
    {
        var projectMembers = await _projectMemberService.GetProjectMembersAsync();
        return Ok(projectMembers);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectMemberResponse>> CreateProjectMember([FromBody] AddProjectMemberRequest request)
    {
        var projectMember = await _projectMemberService.AddProjectMemberAsync(request);
        return Ok(projectMember);
    }

    [HttpPut]
    public async Task<ActionResult<ProjectMemberResponse>> UpdateProjectMember([FromBody] UpdateProjectMemberRequest request)
    {
        var projectMember = await _projectMemberService.EditProjectMemberAsync(request);
        return Ok(projectMember);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProjectMember(Guid id)
    {
        await _projectMemberService.DeleteProjectMemberAsync(id);
        return Ok(
            new { message = $"Project member with id {id} successfully deleted" }
        );
    }
}