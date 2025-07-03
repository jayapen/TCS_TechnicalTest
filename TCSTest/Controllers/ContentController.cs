using Microsoft.AspNetCore.Mvc;
using TCSTest.Models;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly IContentService _service;

    public ContentController(IContentService service)
    {
        _service = service;
    }

    /// <summary>Get all content items.</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    /// <summary>Get content by ID.</summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>Add new content.</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Content content)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AddAsync(content);
        return CreatedAtAction(nameof(GetById), new { id = content.ContentId }, content);
    }

    /// <summary>Update content by ID.</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Content content)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, content);
        return updated ? Ok("Content updated.") : NotFound($"Content with ID {id} not found.");
    }

    /// <summary>Delete content by ID.</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? Ok("Content deleted.") : NotFound($"Content with ID {id} not found.");
    }
}
