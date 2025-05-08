using TaskGear.Application.Services.Contracts;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectMemberRepository _projectMemberRepository;

    public ProjectService(
        IProjectRepository projectRepository, 
        IUserRepository userRepository,
        IProjectMemberRepository projectMemberRepository
    )
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
        _projectMemberRepository = projectMemberRepository;
    }

    public async Task<ProjectResponse> AddProjectAsync(AddProjectRequest request)
    {
        var user = await _userRepository.GetAsync(request.CreatedBy, CancellationToken.None);

        if (user == null)
            throw new Exception($"Could not find user with id {request.CreatedBy}");

        var project = new Project(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.CreatedBy,
            createdByUser: user,
            createdAt: DateTimeOffset.Now,
            updatedAt: DateTimeOffset.Now
        );

        await _projectRepository.AddAsync(project, CancellationToken.None);

        return new ProjectResponse(project);
    }

    public async Task<ProjectResponse> EditProjectAsync(UpdateProjectRequest request)
    {
        var project = await _projectRepository.GetAsync(request.Id, CancellationToken.None);

        if (project == null)
            throw new Exception($"Could not find project with id {request.Id}");
        
        var user = await _userRepository.GetAsync(request.CreatedBy, CancellationToken.None);

        if (user == null)
            throw new Exception($"Could not find user with id {request.CreatedBy}");
        
        project.Title = request.Title;
        project.Description = request.Description;
        project.CreatedBy = request.CreatedBy;
        project.CreatedByUser = user;
        project.UpdatedAt = DateTimeOffset.Now;

        await _projectRepository.UpdateAsync(project, CancellationToken.None);
        
        return new ProjectResponse(project);
    }

    public async Task<ProjectResponse> GetProjectAsync(Guid projectId)
    {
        var project = await _projectRepository.GetAsync(projectId, CancellationToken.None);
        
        if (project == null)
            throw new Exception($"Could not find project with id {projectId}");

        return new ProjectResponse(project);
    }

     public async Task<IEnumerable<ProjectResponse>> GetProjectsAsync()
    {
        var projects = await _projectRepository.GetAsync(c => true, CancellationToken.None);
        
        return projects.Select(project => new ProjectResponse(project));
    }

    public async Task DeleteProjectAsync(Guid projectId)
    {   
        var project = await _projectRepository.GetAsync(projectId, CancellationToken.None);

        if (project == null)
            throw new Exception($"Could not find project with id {projectId}");

        await _projectRepository.DeleteAsync(project, CancellationToken.None);
    }
   

}