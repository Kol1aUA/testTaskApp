using Microsoft.AspNetCore.Mvc;
using testTaskApp.DTOs;
using testTaskApp.Models;
using testTaskApp.Services;

namespace testTaskApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUserService _service;

  public UsersController(IUserService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<User>>> GetAll() =>
    Ok(await _service.GetAllUsersAsync());

  [HttpGet("{id}")]
  public async Task<ActionResult<User>> Get(int id)
  {
    var user = await _service.GetUserByIdAsync(id);
    return user is null ? NotFound() : Ok(user);
  }

  [HttpGet("by-subscription/{type}")]
  public async Task<ActionResult<List<User>>> GetBySubscription(string type) =>
    Ok(await _service.GetUsersBySubscriptionTypeAsync(type));

  [HttpPost]
  public async Task<ActionResult<User>> Create(UserDto dto)
  {
    var user = await _service.CreateUserAsync(dto);
    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UserDto dto)
  {
    return await _service.UpdateUserAsync(id, dto) ? NoContent() : NotFound();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    return await _service.DeleteUserAsync(id) ? NoContent() : NotFound();
  }
}
