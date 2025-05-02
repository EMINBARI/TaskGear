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


    public Task DeleteProjectMemberAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectMemberResponse> EditProjectMemberAsync(UpdateProjectMemberRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectMemberResponse> GetProjectMemberAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProjectMemberResponse>> GetProjectMembersAsync()
    {
        throw new NotImplementedException();
    }
}
   