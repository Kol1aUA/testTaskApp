using testTaskApp.Models;

namespace testTaskApp.Data.Repositories;

public interface ISubscriptionRepository
{
  Task<List<Subscription>> GetAllAsync();
  Task<Subscription?> GetByIdAsync(int id);
  Task<Subscription> CreateAsync(Subscription subscription);
}
