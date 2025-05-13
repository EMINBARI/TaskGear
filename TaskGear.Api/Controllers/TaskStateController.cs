using Microsoft.AspNetCore.Mvc;
using TaskGear.Application.Services.Contracts;

[ApiController]
[Route("[controller]")]
public class TaskStateController : ControllerBase
{
    private readonly ITaskStateService _taskStateServices;

    public TaskStateController(ITaskStateService taskStateServices)
    {
        _taskStateServices = taskStateServices;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskStateResponse>> GetTaskState(Guid id)
    {
        var taskState = await _taskStateServices.GetTaskStateAsync(id);
        return Ok(taskState);

    }

    [HttpGet]
    public async Task<ActionResult<TaskStateResponse>> GetTaskSates()
    {
        var taskState = await _taskStateServices.GetTaskStatesAsync();
        return Ok(taskState);
    }

    [HttpPost]
    public async Task<ActionResult<TaskStateResponse>> CreateTaskState([FromBody] AddTaskStateRequest request)
    {
        var taskState = await _taskStateServices.AddTaskStateAsync(request);
        return Ok(taskState);
    }

    [HttpPut]
    public async Task<ActionResult<TaskStateResponse>> UpdateTaskState([FromBody] UpdateTaskStateRequest request)
    {
        var taskState = await _taskStateServices.EditTaskStateAsync(request);
        return Ok(taskState);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTaskState(Guid id)
    {
        await _taskStateServices.DeleteTaskStateAsync(id);
        return Ok(
            new { message = $"Task state with id {id} successfully deleted." }
        );
    }


}