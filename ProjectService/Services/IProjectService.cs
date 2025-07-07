using ProjectService.Models;

namespace ProjectService.Services;

public interface IProjectService
{
  Task<List<Project>> GetAllAsync();
  Task<Project?> GetByIdAsync(string id);
  Task<List<Project>> GetByUserIdAsync(int userId);
  Task CreateAsync(Project project);
  Task<bool> UpdateAsync(Project project);
  Task<bool> DeleteAsync(string id);
}
