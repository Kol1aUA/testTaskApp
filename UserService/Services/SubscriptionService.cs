using testTaskApp.Data.Repositories;
using testTaskApp.DTOs;
using testTaskApp.Models;

namespace testTaskApp.Services;

public class SubscriptionService : ISubscriptionService
{
  private readonly ISubscriptionRepository _repository;

  public SubscriptionService(ISubscriptionRepository repository)
  {
    _repository = repository;
  }

  public async Task<List<Subscription>> GetAllAsync()
  {
    return await _repository.GetAllAsync();
  }

  public async Task<Subscription?> GetByIdAsync(int id)
  {
    return await _repository.GetByIdAsync(id);
  }

  public async Task<Subscription> CreateAsync(SubscriptionDto dto)
  {
    var subscription = new Subscription
    {
      Type = dto.Type,
      StartDate = dto.StartDate,
      EndDate = dto.EndDate
    };

    return await _repository.CreateAsync(subscription);
  }
}
