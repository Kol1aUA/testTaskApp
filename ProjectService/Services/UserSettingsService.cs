using ProjectService.Models;
using ProjectService.Repositories;

namespace ProjectService.Services;

public class UserSettingsService : IUserSettingsService
{
  private readonly IUserSettingsRepository _repository;

  public UserSettingsService(IUserSettingsRepository repository)
  {
    _repository = repository;
  }

  public async Task<List<UserSetting>> GetAllAsync() => await _repository.GetAllAsync();

  public async Task<UserSetting?> GetByUserIdAsync(int userId) => await _repository.GetByUserIdAsync(userId);

  public async Task AddAsync(UserSetting setting) => await _repository.AddAsync(setting);

  public async Task<bool> UpdateAsync(UserSetting setting) => await _repository.UpdateAsync(setting);

  public async Task<bool> DeleteAsync(int userId) => await _repository.DeleteByUserIdAsync(userId);
}
