using testTaskApp.Models;

namespace testTaskApp.Data.Repositories;

public interface IUserRepository
{
  Task<List<User>> GetAllAsync();
  Task<User?> GetByIdAsync(int id);
  Task<List<User>> GetBySubscriptionTypeAsync(string type);
  Task<User> CreateAsync(User user);
  Task<bool> UpdateAsync(User user);
  Task<bool> DeleteAsync(int id);
}
