using Microsoft.AspNetCore.Mvc;
using TaskGear.Application.Services;
using TaskGear.Application.Services.Contracts;

[ApiController]
[Route("[controller]")]
public class ProjectTaskController : ControllerBase 
{
    private readonly IProjectTaskService _projectTaskService;

    public ProjectTaskController(IProjectTaskService projectTaskService)
    {
        _projectTaskService = projectTaskService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProjectTaskResponse>> GetProjectTask(Guid id)
    {
        var projectTask = await _projectTaskService.GetProjectTaskAsync(id);
        return Ok(projectTask);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectTaskResponse>>> GetProjectTasks()
    {
        var projectTasksList = await _projectTaskService.GetProjectTasksAsync();
        return Ok(projectTasksList);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectTaskResponse>> CreateProjectTask([FromBody] AddProjectTaskRequest request)
    {
        var projectTask = await _projectTaskService.AddProjectTaskAsync(request);
        return Ok(projectTask);
    }

    [HttpPut]
    public async Task<ActionResult<ProjectTaskResponse>> UpdateProjectTask([FromBody] UpdateProjectTaskRequest request)
    {
        var projectTask = await _projectTaskService.EditProjectTaskAsync(request);
        return Ok(projectTask);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProjectTask(Guid id)
    {
        await _projectTaskService.DeleteProjectTaskAsync(id);
        return Ok(
            new { message = $"Project Task with id {id} successfully deleted" }
        );
    }
}