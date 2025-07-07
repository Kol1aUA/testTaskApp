using Microsoft.EntityFrameworkCore;
using testTaskApp.Models;

namespace testTaskApp.Data.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
  private readonly AppDbContext _context;

  public SubscriptionRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<Subscription>> GetAllAsync()
  {
    return await _context.Subscriptions.ToListAsync();
  }

  public async Task<Subscription?> GetByIdAsync(int id)
  {
    return await _context.Subscriptions.FindAsync(id);
  }

  public async Task<Subscription> CreateAsync(Subscription subscription)
  {
    _context.Subscriptions.Add(subscription);
    await _context.SaveChangesAsync();
    return subscription;
  }
}
