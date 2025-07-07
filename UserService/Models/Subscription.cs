namespace testTaskApp.Models;

public class Subscription
{
  public int Id { get; set; }
  public string Type { get; set; } // Free / Trial / Super
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }

  public ICollection<User> Users { get; set; }
}