using TaskGear.Application.Services;
using TaskGear.Application.Services.Contracts;
using TaskGear.Core.Models;
using TaskGear.Core.Repositories;

public class ProjectMemberService : IProjectMemberService
{
   private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;

    public ProjectMemberService(
        IProjectMemberRepository projectMemberRepository, 
        IUserRepository userRepository, 
        IProjectRepository projectRepository
    )
    {
        _projectMemberRepository = projectMemberRepository;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
    }

    public async Task<ProjectMemberResponse> AddProjectMemberAsync(AddProjectMemberRequest request)
    {
        var user = await _userRepository.GetAsync(request.UserId, CancellationToken.None);
        var project = await _projectRepository.GetAsync(request.UserId, CancellationToken.None);

        if (user == null)
            throw new Exception($"Could not find user with id {request.UserId}");
        
        if (project == null)
            throw new Exception($"Could not find project with id {request.ProjectId}");
        
        var projectMember = new ProjectMember(
            Guid.NewGuid(),
            request.ProjectId,
            project,
            request.UserId,
            user
        );

        await _projectMemberRepository.AddAsync(projectMember, CancellationToken.None);

        return new ProjectMemberResponse(projectMember);
    }


    public async Task DeleteProjectMemberAsync(Guid projectMemberId)
    {
        var projectMember = await _projectMemberRepository.GetAsync(projectMemberId, CancellationToken.None);

        if (projectMember == null)
            throw new Exception($"Could not find user with id {projectMemberId}");

        await _projectMemberRepository.DeleteAsync(projectMember, CancellationToken.None);
    }

    public async Task<ProjectMemberResponse> EditProjectMemberAsync(UpdateProjectMemberRequest request)
    {
        var projectMember = await _projectMemberRepository.GetAsync(request.Id, CancellationToken.None);

        if (projectMember == null)
            throw new Exception($"Could not find project member with id {request.Id}");

        var project = await _projectRepository.GetAsync(request.ProjectId, CancellationToken.None);
        var user = await _userRepository.GetAsync(request.UserId, CancellationToken.None);
        
        if (project == null)
            throw new Exception($"Could not find project with id {request.ProjectId}");
        
        if (user == null)
            throw new Exception($"Could not find user with id {request.UserId}");

        projectMember.ProjectId = request.ProjectId;
        projectMember.UserId = request.UserId;
        projectMember.Project = project;
        projectMember.User = user;

        await _projectMemberRepository.UpdateAsync(projectMember, CancellationToken.None);

        return new ProjectMemberResponse(projectMember);
    }

    public async Task<ProjectMemberResponse> GetProjectMemberAsync(Guid projectMemberId)
    {
        var projectMember = await _projectMemberRepository.GetAsync(projectMemberId, CancellationToken.None);

        if (projectMember == null)
            throw new Exception($"Could not find project member with id {projectMemberId}");

        return new ProjectMemberResponse(projectMember);
    }

    public async Task<IEnumerable<ProjectMemberResponse>> GetProjectMembersAsync()
    {
        var projectMembers = await _projectMemberRepository.GetAsync(c => true, CancellationToken.None);
        return projectMembers.Select(member => new ProjectMemberResponse(member));
    }
}
   