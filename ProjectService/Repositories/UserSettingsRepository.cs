using ProjectService.Models;

namespace ProjectService.Repositories;

using MongoDB.Driver;

public class UserSettingsRepository : IUserSettingsRepository
{
  private readonly IMongoCollection<UserSetting> _collection;

  public UserSettingsRepository(IMongoDatabase database)
  {
    _collection = database.GetCollection<UserSetting>("user.settings");
  }

  public async Task<UserSetting?> GetByUserIdAsync(int userId)
  {
    return await _collection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
  }

  public async Task<List<UserSetting>> GetAllAsync()
  {
    return await _collection.Find(_ => true).ToListAsync();
  }

  public async Task AddAsync(UserSetting setting)
  {
    await _collection.InsertOneAsync(setting);
  }

  public async Task<bool> UpdateAsync(UserSetting setting)
  {
    var result = await _collection.ReplaceOneAsync(x => x.UserId == setting.UserId, setting);
    return result.ModifiedCount > 0;
  }

  public async Task<bool> DeleteByUserIdAsync(int userId)
  {
    var result = await _collection.DeleteOneAsync(x => x.UserId == userId);
    return result.DeletedCount > 0;
  }
}
