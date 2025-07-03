using Microsoft.AspNetCore.Mvc;
using TCSTest.Models;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _service;

    public ScheduleController(IScheduleService service)
    {
        _service = service;
    }

    /// <summary>Get all schedules.</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    /// <summary>Get schedules by channel ID.</summary>
    [HttpGet("channel/{channelId}")]
    public async Task<IActionResult> GetByChannel(Guid channelId) => Ok(await _service.GetByChannelIdAsync(channelId));

    /// <summary>Get currently airing schedules.</summary>
    [HttpGet("now")]
    public async Task<IActionResult> GetCurrentlyAiring() => Ok(await _service.GetCurrentlyAiringAsync());

    /// <summary>Add a new schedule.</summary>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Schedule schedule)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AddAsync(schedule);
        return Ok();
    }

    /// <summary>Update a schedule.</summary>
    [HttpPut("{channelId}/{contentId}")]
    public async Task<IActionResult> Update(Guid channelId, Guid contentId, [FromBody] Schedule schedule)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(channelId, contentId, schedule);
        return updated ? NoContent() : NotFound();
    }

    /// <summary>Delete a schedule.</summary>
    [HttpDelete("{channelId}/{contentId}")]
    public async Task<IActionResult> Delete(Guid channelId, Guid contentId)
    {
        var success = await _service.DeleteAsync(channelId, contentId);
        return success ? NoContent() : NotFound($"Schedule with Channel ID {channelId} and Content ID {contentId} not found.");
    }
}
