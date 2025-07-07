using ProjectService.Models;
using ProjectService.Repositories;

namespace ProjectService.Services;

public class ProjectService : IProjectService
{
  private readonly IProjectRepository _repository;

  public ProjectService(IProjectRepository repository)
  {
    _repository = repository;
  }

  public Task<List<Project>> GetAllAsync() => _repository.GetAllAsync();

  public Task<Project?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);

  public Task<List<Project>> GetByUserIdAsync(int userId) => _repository.GetByUserIdAsync(userId);

  public Task CreateAsync(Project project) => _repository.CreateAsync(project);

  public Task<bool> UpdateAsync(Project project) => _repository.UpdateAsync(project);

  public Task<bool> DeleteAsync(string id) => _repository.DeleteAsync(id);
}
