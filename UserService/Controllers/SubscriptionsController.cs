using Microsoft.AspNetCore.Mvc;
using testTaskApp.DTOs;
using testTaskApp.Models;
using testTaskApp.Services;

namespace testTaskApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
  private readonly ISubscriptionService _service;

  public SubscriptionsController(ISubscriptionService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<Subscription>>> GetAll()
  {
    var result = await _service.GetAllAsync();
    return Ok(result);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Subscription>> GetById(int id)
  {
    var subscription = await _service.GetByIdAsync(id);
    return subscription == null ? NotFound() : Ok(subscription);
  }

  [HttpPost]
  public async Task<ActionResult<Subscription>> Create(SubscriptionDto dto)
  {
    var created = await _service.CreateAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
  }
}
