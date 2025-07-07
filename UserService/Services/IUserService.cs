using testTaskApp.DTOs;
using testTaskApp.Models;

namespace testTaskApp.Services;

public interface IUserService
{
  Task<List<User>> GetAllUsersAsync();
  Task<User?> GetUserByIdAsync(int id);
  Task<List<User>> GetUsersBySubscriptionTypeAsync(string type);
  Task<User> CreateUserAsync(UserDto dto);
  Task<bool> UpdateUserAsync(int id, UserDto dto);
  Task<bool> DeleteUserAsync(int id);
}
