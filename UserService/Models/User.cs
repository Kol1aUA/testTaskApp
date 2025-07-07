using System.ComponentModel.DataAnnotations;

namespace testTaskApp.Models;

public class User
{
  [Key]
  public int Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }

  public int SubscriptionId { get; set; }
  public Subscription Subscription { get; set; }
}