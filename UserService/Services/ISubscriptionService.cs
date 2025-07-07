using testTaskApp.DTOs;
using testTaskApp.Models;

namespace testTaskApp.Services;

public interface ISubscriptionService
{
  Task<List<Subscription>> GetAllAsync();
  Task<Subscription?> GetByIdAsync(int id);
  Task<Subscription> CreateAsync(SubscriptionDto dto);
}
