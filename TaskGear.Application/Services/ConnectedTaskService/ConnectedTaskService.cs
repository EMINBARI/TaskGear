using TaskGear.Core.Models;
using TaskGear.Core.Repositories;

namespace TaskGear.Application.Services;

public class ConnectedTaskService : IConnectedTaskService
{
    private readonly IConnectedTaskRepository _connectedTaskRepository;
    private readonly IProjectTaskRepository _projectTaskRepository;

    public ConnectedTaskService
    (
        IConnectedTaskRepository connectedTaskRepository,
        IProjectTaskRepository projectTaskRepository
    )
    {
        _connectedTaskRepository = connectedTaskRepository;
        _projectTaskRepository = projectTaskRepository;
    }

    public async Task<ConnectedTaskResponse> AddConnectedTaskAsync(AddConnectedTaskRequest request)
    {

        var sourceTask = await _projectTaskRepository.GetAsync(request.SourceTask, CancellationToken.None);
        var targetTask = await _projectTaskRepository.GetAsync(request.TargetTask, CancellationToken.None);

        if(sourceTask == null)
            throw new Exception($"Could not find project task with id {request.SourceTask}");
            
        if(targetTask == null)
            throw new Exception($"Could not find project task with id {request.TargetTask}");
        
        var connectedTask = new ConnectedTask
        (
            Guid.NewGuid(),
            request.SourceTask,
            sourceTask,
            request.TargetTask,
            targetTask
        );
        
        await _connectedTaskRepository.AddAsync(connectedTask, CancellationToken.None);

        return new ConnectedTaskResponse(connectedTask);
    }

    public async Task DeleteConnectedTaskAsync(Guid id)
    {
        var connectedTask = await _connectedTaskRepository.GetAsync(id, CancellationToken.None);

        if(connectedTask == null)
            throw new Exception($"Could not find project task with id {id}");

        await _connectedTaskRepository.DeleteAsync(connectedTask, CancellationToken.None);
    }
    
    public async Task<IEnumerable<ConnectedTaskResponse>> GetConnectedTasksAsync(Guid taskId)
    {
        var tasks = await _connectedTaskRepository.GetAsync(
            task => task.SourceTaskId == taskId || task.TargetTaskId == taskId, 
            CancellationToken.None);
        
        return tasks.Select(task => new ConnectedTaskResponse(task));
    }
}