using ProjectService.DTOs;

namespace ProjectService.Services;

using System.Net.Http;
using System.Text.Json;

public class UserHttpClient : IUserHttpClient
{
  private readonly HttpClient _httpClient;

  public UserHttpClient(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<List<UserResponseDto>> GetUsersBySubscriptionTypeAsync(string type)
  {
    var response = await _httpClient.GetAsync($"/api/users/by-subscription/{type}");
    response.EnsureSuccessStatusCode();

    var stream = await response.Content.ReadAsStreamAsync();
    var users = await JsonSerializer.DeserializeAsync<List<UserResponseDto>>(stream, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    });

    return users ?? new List<UserResponseDto>();
  }
}
