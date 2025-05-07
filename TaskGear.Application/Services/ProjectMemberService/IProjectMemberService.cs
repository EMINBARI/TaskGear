using TaskGear.Application.Services.Contracts;
namespace TaskGear.Application.Services;

public interface IProjectMemberService {
    public Task<ProjectMemberResponse> AddProjectMemberAsync(AddProjectMemberRequest request);
    public Task<ProjectMemberResponse> EditProjectMemberAsync(UpdateProjectMemberRequest request);
    public Task<ProjectMemberResponse> GetProjectMemberAsync(Guid memberId);
    public Task<IEnumerable<ProjectMemberResponse>> GetProjectMembersAsync();
    public Task DeleteProjectMemberAsync(Guid memberId);
}
