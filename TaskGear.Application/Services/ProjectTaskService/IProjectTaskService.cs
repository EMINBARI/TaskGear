using TaskGear.Application.Services.Contracts;
namespace TaskGear.Application.Services;

public interface IProjectTaskService 
{
    public Task<ProjectTaskResponse> AddProjectTaskAsync(AddProjectTaskRequest request);
    public Task<ProjectTaskResponse> EditProjectTaskAsync(UpdateProjectTaskRequest request);
    public Task<ProjectTaskResponse> GetProjectTaskAsync(Guid projectTaskId);
    public Task<IEnumerable<ProjectTaskResponse>> GetProjectTasksAsync();
    public Task DeleteProjectTaskAsync(Guid projectTaskId);
}