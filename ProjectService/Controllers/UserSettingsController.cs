using Microsoft.AspNetCore.Mvc;
using ProjectService.Models;
using ProjectService.Services;

namespace ProjectService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserSettingsController : ControllerBase
{
  private readonly IUserSettingsService _service;

  public UserSettingsController(IUserSettingsService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<UserSetting>>> GetAll()
  {
    var settings = await _service.GetAllAsync();
    return Ok(settings);
  }

  [HttpGet("{userId}")]
  public async Task<ActionResult<UserSetting>> GetByUserId(int userId)
  {
    var setting = await _service.GetByUserIdAsync(userId);
    return setting == null ? NotFound() : Ok(setting);
  }

  [HttpPost]
  public async Task<IActionResult> Create(UserSetting setting)
  {
    await _service.AddAsync(setting);
    return CreatedAtAction(nameof(GetByUserId), new { userId = setting.UserId }, setting);
  }

  [HttpPut("{userId}")]
  public async Task<IActionResult> Update(int userId, UserSetting setting)
  {
    if (userId != setting.UserId)
      return BadRequest("UserId in URL and body must match");

    var success = await _service.UpdateAsync(setting);
    return success ? NoContent() : NotFound();
  }

  [HttpDelete("{userId}")]
  public async Task<IActionResult> Delete(int userId)
  {
    var deleted = await _service.DeleteAsync(userId);
    return deleted ? NoContent() : NotFound();
  }
}
