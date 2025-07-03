using Microsoft.AspNetCore.Mvc;
using TCSTest.Models;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    private readonly IChannelService _service;

    public ChannelController(IChannelService service)
    {
        _service = service;
    }

    /// <summary>Get all channels.</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    /// <summary>Get channel by ID.</summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>Add a new channel.</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Channel channel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AddAsync(channel);
        return CreatedAtAction(nameof(GetById), new { id = channel.ChannelId }, channel);
    }

    /// <summary>Update an existing channel.</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Channel channel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, channel);
        return updated ? Ok("Channel updated.") : NotFound($"Channel with ID {id} not found.");
    }

    /// <summary>Delete a channel.</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? Ok("Channel deleted.") : NotFound($"Channel with ID {id} not found.");
    }
}
