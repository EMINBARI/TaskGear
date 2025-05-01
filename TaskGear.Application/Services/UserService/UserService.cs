using TaskGear.Core.Models;
using TaskGear.Core.Repositories;
using TaskGear.Application.Services.Contracts;

namespace TaskGear.Application.Services;

public class UserService : IUserService
{
    IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserResponse> AddUserAsync(AddUserRequest request)
    {
        var user = new User(
            Guid.NewGuid(),
            request.Name,
            request.Email,
            request.PasswordHash
        );

        await _userRepository.AddAsync(user, CancellationToken.None);

        return new UserResponse(user);
    }

    public async Task<UserResponse> EditUserAsync(UpdateUserRequest request)
    {
        var user = await _userRepository.GetAsync(request.Id, CancellationToken.None);

        if (user == null)
            throw new Exception($"Could not find user with id {request.Id}");
        
        //Field uniqueness check 
        user.Email = request.Email;
        user.Name = request.Name;
        user.ImageUrl = request.ImageUrl;
        user.UpdatedAt = DateTimeOffset.UtcNow;

        await _userRepository.UpdateAsync(user, CancellationToken.None);

        return new UserResponse(user);
    }

    public async Task<UserResponse> GetUserAsync(Guid userId)
    {
        var user = await _userRepository.GetAsync(userId, CancellationToken.None);

        if (user == null)
            throw new Exception($"Could not find user with id {userId}");

        return new UserResponse(user);
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await _userRepository.GetAsync(userId, CancellationToken.None);

        if (user == null)
            throw new Exception($"Could not find user with id {userId}");

        await _userRepository.DeleteAsync(user, CancellationToken.None);
    }

    public async Task<IEnumerable<UserResponse>> GetUsersAsync()
    {
        var users = await _userRepository.GetAsync(c => true, CancellationToken.None);

        return users.Select(card => new UserResponse(card));
    }
}