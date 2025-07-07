using testTaskApp.Data.Repositories;
using testTaskApp.DTOs;
using testTaskApp.Models;

namespace testTaskApp.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _repo;

  public UserService(IUserRepository repo)
  {
    _repo = repo;
  }

  public async Task<List<User>> GetAllUsersAsync() => await _repo.GetAllAsync();

  public async Task<User?> GetUserByIdAsync(int id) => await _repo.GetByIdAsync(id);

  public async Task<List<User>> GetUsersBySubscriptionTypeAsync(string type) =>
    await _repo.GetBySubscriptionTypeAsync(type);

  public async Task<User> CreateUserAsync(UserDto dto)
  {
    var user = new User
    {
      Name = dto.Name,
      Email = dto.Email,
      SubscriptionId = dto.SubscriptionId
    };
    return await _repo.CreateAsync(user);
  }

  public async Task<bool> UpdateUserAsync(int id, UserDto dto)
  {
    var user = await _repo.GetByIdAsync(id);
    if (user == null) return false;

    user.Name = dto.Name;
    user.Email = dto.Email;
    user.SubscriptionId = dto.SubscriptionId;
    return await _repo.UpdateAsync(user);
  }

  public async Task<bool> DeleteUserAsync(int id) => await _repo.DeleteAsync(id);
}
