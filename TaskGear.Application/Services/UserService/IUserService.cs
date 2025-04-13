using TaskGear.Application.Services.Contracts;
namespace TaskGear.Application.Services;

public interface IUserService {
    public Task<UserResponse> AddUserAsync(AddUserRequest request);
    public Task<UserResponse> EditUserAsync(UpdateUserRequest request);
    public Task<UserResponse> GetUserAsync(Guid userId);
    public Task<IEnumerable<UserResponse>> GetUsersAsync();
    public Task DeleteUserAsync(Guid userId);
}