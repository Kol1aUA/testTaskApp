using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProjectService.Models;
using ProjectService.Services;

namespace ProjectService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
  private readonly IProjectService _service;

  public ProjectsController(IProjectService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<Project>>> GetAll() =>
    Ok(await _service.GetAllAsync());

  [HttpGet("{id}")]
  public async Task<ActionResult<Project>> GetById(string id)
  {
    var project = await _service.GetByIdAsync(id);
    return project is null ? NotFound() : Ok(project);
  }

  [HttpGet("by-user/{userId}")]
  public async Task<ActionResult<List<Project>>> GetByUserId(int userId) =>
    Ok(await _service.GetByUserIdAsync(userId));

  [HttpPost]
  public async Task<IActionResult> Create(Project project)
  {
    await _service.CreateAsync(project);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(string id, Project project)
  {
    var objectId = ObjectId.Parse(id); // move this logic to Utils, not on presentation level
    if (objectId != project.Id) return BadRequest("ID mismatch");
    var result = await _service.UpdateAsync(project);
    return result ? NoContent() : NotFound();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(string id)
  {
    var result = await _service.DeleteAsync(id);
    return result ? NoContent() : NotFound();
  }
}
