using ProjectService.DTOs;

namespace ProjectService.Services;

public interface IUserHttpClient
{
  Task<List<UserResponseDto>> GetUsersBySubscriptionTypeAsync(string type);
}
