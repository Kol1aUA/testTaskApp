namespace ProjectService.DTOs;

public class UserResponseDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public int SubscriptionId { get; set; }
}
