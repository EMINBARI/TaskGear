namespace TaskGear.Application.Services;

public interface IConnectedTaskService 
{
    public Task<ConnectedTaskResponse> AddConnectedTaskAsync(AddConnectedTaskRequest request);
    public Task<IEnumerable<ConnectedTaskResponse>> GetConnectedTasksAsync(Guid taskId);
    public Task DeleteConnectedTaskAsync(Guid taskId);
}