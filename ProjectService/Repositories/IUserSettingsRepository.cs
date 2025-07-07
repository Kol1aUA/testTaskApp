using ProjectService.Models;

namespace ProjectService.Repositories;

public interface IUserSettingsRepository
{
  Task<UserSetting?> GetByUserIdAsync(int userId);
  Task<List<UserSetting>> GetAllAsync();
  Task AddAsync(UserSetting setting);
  Task<bool> UpdateAsync(UserSetting setting);
  Task<bool> DeleteByUserIdAsync(int userId);
}
