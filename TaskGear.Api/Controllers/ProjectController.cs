using Microsoft.AspNetCore.Mvc;
using TaskGear.Application.Services.Contracts;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase 
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService) 
    {
        _projectService = projectService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProjectResponse>> GetProject(Guid id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return Ok(project);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjects()
    {
        var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> CreateProject([FromBody] AddProjectRequest request)
    {
        var project = await _projectService.AddProjectAsync(request);
        return Ok(project);
    }

    [HttpPut]
    public async Task<ActionResult<ProjectResponse>> UpdateProject([FromBody] UpdateProjectRequest request)
    {
        var project = await _projectService.EditProjectAsync(request);
        return Ok(project);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProjectResponse>> DeleteProject(Guid id)
    {
        await _projectService.DeleteProjectAsync(id);
        return Ok(
            new { message = $"Project with id {id} successfully deleted" }
        );
    }
}