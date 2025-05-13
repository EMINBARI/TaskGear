using TaskGear.Application.Services.Contracts;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;

public class TaskStateService : ITaskStateService
{
    private readonly ITaskStateRepository _taskStateRepository;

    public TaskStateService(ITaskStateRepository taskStateRepository)
    {
        _taskStateRepository = taskStateRepository;
    }

    public async Task<TaskStateResponse> AddTaskStateAsync(AddTaskStateRequest request)
    {
        var taskState = new TaskState(
            Guid.NewGuid(),
            request.Name
        );

        await _taskStateRepository.AddAsync(taskState, CancellationToken.None);

        return new TaskStateResponse(taskState);
    }

    public async Task DeleteTaskStateAsync(Guid taskStateId)
    {
        var taskState = await _taskStateRepository.GetAsync(taskStateId, CancellationToken.None);

        if(taskState == null)
            throw new Exception($"Could not find task state with id {taskStateId}");

        await _taskStateRepository.DeleteAsync(taskState, CancellationToken.None);
    }

    public async Task<TaskStateResponse> EditTaskStateAsync(UpdateTaskStateRequest request)
    {
        var taskState = await _taskStateRepository.GetAsync(request.Id, CancellationToken.None);

        if(taskState == null)
            throw new Exception($"Could not find task state with id {request.Id}");

        taskState.Name = request.Name;

        await _taskStateRepository.UpdateAsync(taskState, CancellationToken.None);

        return new TaskStateResponse(taskState);
    }

    public async Task<TaskStateResponse> GetTaskStateAsync(Guid taskStateId)
    {
        var taskState = await _taskStateRepository.GetAsync(taskStateId, CancellationToken.None);

        if(taskState == null)
            throw new Exception($"Could not find task state with id {taskStateId}");

        return new TaskStateResponse(taskState);
    }

    public async Task<IEnumerable<TaskStateResponse>> GetTaskStatesAsync()
    {
        var taskStates = await _taskStateRepository.GetAsync( c=> true, CancellationToken.None);
        return taskStates.Select(ts => new TaskStateResponse(ts));
    }
}