using ProjectService.Models;

namespace ProjectService.Services;

public interface IUserSettingsService
{
  Task<List<UserSetting>> GetAllAsync();
  Task<UserSetting?> GetByUserIdAsync(int userId);
  Task AddAsync(UserSetting setting);
  Task<bool> UpdateAsync(UserSetting setting);
  Task<bool> DeleteAsync(int userId);
}
