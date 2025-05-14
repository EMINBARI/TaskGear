using TaskGear.Application.Services;
using TaskGear.Application.Services.Contracts;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;

public class ProjectTaskService : IProjectTaskService
{
    private readonly IProjectTaskRepository _projectTaskRepository;
    private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskStateRepository _taskStateRepository;

    public ProjectTaskService
    (
        IProjectTaskRepository projectTaskRepository,
        IProjectMemberRepository projectMemberRepository,
        IProjectRepository projectRepository,
        ITaskStateRepository taskStateRepository
    )
    {
        _projectTaskRepository = projectTaskRepository;
        _projectMemberRepository = projectMemberRepository;
        _projectRepository = projectRepository;
        _taskStateRepository = taskStateRepository;
    }

    public async Task<ProjectTaskResponse> AddProjectTaskAsync(AddProjectTaskRequest request)
    {
        var project = await _projectRepository.GetAsync(request.ProjectId, CancellationToken.None);
        if(project == null)
            throw new Exception($"Could not find project with id {request.ProjectId}");

        var createdBy = await _projectMemberRepository.GetAsync(request.CreatedBy, CancellationToken.None);
        if(createdBy ==null)
            throw new Exception($"Could not find project member with id {request.CreatedBy}");

        var taskState = await _taskStateRepository.GetAsync(request.TaskStateId, CancellationToken.None);
        if(taskState ==null)
            throw new Exception($"Could not find task state with id {request.TaskStateId}");

        var projectTask = new ProjectTask(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.ProjectId,
            project,
            request.TaskStateId,
            taskState,
            request.CreatedBy,
            createdBy,
            request.ExpiresAt,
            createdAt: DateTimeOffset.UtcNow,
            updatedAt: DateTimeOffset.UtcNow
        );

        await _projectTaskRepository.AddAsync(projectTask, CancellationToken.None);

        return new ProjectTaskResponse(projectTask);
    }

    public async Task DeleteProjectTaskAsync(Guid projectTaskId)
    {
        var projectTask = await _projectTaskRepository.GetAsync(projectTaskId, CancellationToken.None);

        if(projectTask == null)
            throw new Exception($"Could not find project task with id {projectTaskId}");

        await _projectTaskRepository.DeleteAsync(projectTask, CancellationToken.None);
    }

    public async Task<ProjectTaskResponse> EditProjectTaskAsync(UpdateProjectTaskRequest request)
    {
        var projectTask = await _projectTaskRepository.GetAsync(request.Id, CancellationToken.None);
        if(projectTask == null)
            throw new Exception($"Could not find project task with id {request.Id}");

        var taskState = await _taskStateRepository.GetAsync(request.TaskStateId, CancellationToken.None);
        if(taskState == null)
            throw new Exception($"Could not find task state with id {request.TaskStateId}");
        
        projectTask.Title = request.Title;
        projectTask.Description = request.Description;
        projectTask.ExpiresAt = request.ExpiresAt;
        projectTask.TaskState = taskState;

        await _projectTaskRepository.UpdateAsync(projectTask, CancellationToken.None);

        return new ProjectTaskResponse(projectTask);
    }

    public async Task<ProjectTaskResponse> GetProjectTaskAsync(Guid projectTaskId)
    {
        var projectTask = await _projectTaskRepository.GetAsync(projectTaskId, CancellationToken.None);
        if(projectTask == null)
            throw new Exception($"Could not find project task with id {projectTaskId}");

        return new ProjectTaskResponse(projectTask);
    }

    public async Task<IEnumerable<ProjectTaskResponse>> GetProjectTasksAsync()
    {
        var projectTasks = await _projectTaskRepository.GetAsync(c => true, CancellationToken.None);
        return projectTasks.Select(pt => new ProjectTaskResponse(pt));
    }
}