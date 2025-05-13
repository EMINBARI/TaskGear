using TaskGear.Application.Services.Contracts;

public interface ITaskStateService {
    public Task<TaskStateResponse> AddTaskStateAsync(AddTaskStateRequest request);
    public Task<TaskStateResponse> EditTaskStateAsync(UpdateTaskStateRequest request);
    public Task<TaskStateResponse> GetTaskStateAsync(Guid taskStateId);
    public Task<IEnumerable<TaskStateResponse>> GetTaskStatesAsync();
    public Task DeleteTaskStateAsync(Guid taskStateId);
}