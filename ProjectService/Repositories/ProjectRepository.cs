using MongoDB.Bson;
using ProjectService.Models;

namespace ProjectService.Repositories;

using MongoDB.Driver;

public class ProjectRepository : IProjectRepository
{
  private readonly IMongoCollection<Project> _collection;

  public ProjectRepository(IMongoDatabase database)
  {
    _collection = database.GetCollection<Project>("projects");
  }

  public async Task<List<Project>> GetAllAsync()
  {
    return await _collection.Find(_ => true).ToListAsync();
  }

  public async Task<Project?> GetByIdAsync(string id)
  {
    var objectId = ObjectId.Parse(id);
    return await _collection.Find(p => p.Id == objectId).FirstOrDefaultAsync();
  }

  public async Task<List<Project>> GetByUserIdAsync(int userId)
  {
    return await _collection.Find(p => p.UserId == userId).ToListAsync();
  }

  public async Task CreateAsync(Project project)
  {
    await _collection.InsertOneAsync(project);
  }

  public async Task<bool> UpdateAsync(Project project)
  {
    var result = await _collection.ReplaceOneAsync(p => p.Id == project.Id, project);
    return result.ModifiedCount > 0;
  }

  public async Task<bool> DeleteAsync(string id)
  {
    var objectId = ObjectId.Parse(id);
    var result = await _collection.DeleteOneAsync(p => p.Id == objectId);
    return result.DeletedCount > 0;
  }
}
