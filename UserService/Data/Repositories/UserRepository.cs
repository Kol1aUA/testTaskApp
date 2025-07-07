using Microsoft.EntityFrameworkCore;
using testTaskApp.Models;

namespace testTaskApp.Data.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<User>> GetAllAsync()
  {
    return await _context.Users.ToListAsync();
  }

  public async Task<User?> GetByIdAsync(int id)
  {
    return await _context.Users.FindAsync(id);
  }

  public async Task<List<User>> GetBySubscriptionTypeAsync(string type)
  {
    return await _context.Users
      .Include(u => u.Subscription)
      .Where(u => u.Subscription.Type == type)
      .ToListAsync();
  }

  public async Task<User> CreateAsync(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return user;
  }

  public async Task<bool> UpdateAsync(User user)
  {
    _context.Users.Update(user);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    var user = await _context.Users.FindAsync(id);
    if (user == null) return false;
    _context.Users.Remove(user);
    return await _context.SaveChangesAsync() > 0;
  }
}
