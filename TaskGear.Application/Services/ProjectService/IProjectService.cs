using TaskGear.Application.Services.Contracts;

public interface IProjectService {
    public Task<ProjectResponse> AddProjectAsync(AddProjectRequest request);
    public Task<ProjectResponse> EditProjectAsync(UpdateProjectRequest request);
    public Task<ProjectResponse> GetProjectAsync(Guid projectId);
    public Task<IEnumerable<ProjectResponse>> GetProjectsAsync();
    public Task DeleteProjectAsync(Guid projectId);
}