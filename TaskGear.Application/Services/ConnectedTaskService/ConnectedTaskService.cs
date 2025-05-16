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

        var task1 = await _projectTaskRepository.GetAsync(request.TaskId1, CancellationToken.None);
        var task2 = await _projectTaskRepository.GetAsync(request.TaskId2, CancellationToken.None);

        if(task1 == null)
            throw new Exception($"Could not find project task with id {request.TaskId1}");
            
        if(task2 == null)
            throw new Exception($"Could not find project task with id {request.TaskId2}");
        
        var connectedTask = new ConnectedTask
        (
            Guid.NewGuid(),
            request.TaskId1,
            task1,
            request.TaskId2,
            task2
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
            task => task.TaskId1 == taskId || task.TaskId2 == taskId, 
            CancellationToken.None);
        
        return tasks.Select(task => new ConnectedTaskResponse(task));
    }
}