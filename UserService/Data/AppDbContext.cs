using Microsoft.EntityFrameworkCore;
using testTaskApp.Models;

namespace testTaskApp.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<Subscription> Subscriptions { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Subscription>()
      .HasMany(s => s.Users)
      .WithOne(u => u.Subscription)
      .HasForeignKey(u => u.SubscriptionId);

    modelBuilder.Entity<Subscription>().HasData(
      new Subscription { Id = 1, Type = "Free", StartDate = DateTime.UtcNow.AddMonths(-2), EndDate = DateTime.UtcNow.AddMonths(1) },
      new Subscription { Id = 2, Type = "Trial", StartDate = DateTime.UtcNow.AddDays(-7), EndDate = DateTime.UtcNow.AddDays(7) },
      new Subscription { Id = 3, Type = "Super", StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(6) }
    );

    modelBuilder.Entity<User>().HasData(
      new User { Id = 1, Name = "Alice", Email = "alice@example.com", SubscriptionId = 1 },
      new User { Id = 2, Name = "Bob", Email = "bob@example.com", SubscriptionId = 3 },
      new User { Id = 3, Name = "Carlos", Email = "carlos@example.com", SubscriptionId = 2 }
    );
  }

}
