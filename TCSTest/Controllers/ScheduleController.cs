using Microsoft.AspNetCore.Mvc;
using TCSTest.Models.DTO;
using TCSTest.Services.Interface;

namespace TCSTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;

        public ScheduleController(IScheduleService service)
        {
            _service = service;
        }

        // GET /api/schedule
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _service.GetAllAsync();
            return Ok(schedules);
        }

        // GET /api/schedule/channel/{channelId}
        [HttpGet("channel/{channelId}")]
        public async Task<IActionResult> GetByChannel(Guid channelId)
        {
            var schedules = await _service.GetByChannelAsync(channelId);
            return Ok(schedules);
        }

        // GET /api/schedule/now
        [HttpGet("now")]
        public async Task<IActionResult> GetNow()
        {
            var now = DateTime.UtcNow;
            var airing = await _service.GetCurrentlyAiringAsync(now);
            return Ok(airing);
        }

        // POST /api/schedule
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ScheduleDto dto)
        {
            var success = await _service.AddAsync(dto);
            if (!success)
                return Conflict("Schedule overlaps with an existing airing.");

            return Ok("Schedule added.");
        }

        // PUT /api/schedule/{channelId}/{contentId}
        [HttpPut("{channelId}/{contentId}")]
        public async Task<IActionResult> Update(Guid channelId, Guid contentId, [FromBody] ScheduleDto dto)
        {
            var updated = await _service.UpdateAsync(channelId, contentId, dto);
            if (!updated)
                return NotFound("Schedule not found.");

            return Ok("Schedule updated.");
        }

        // DELETE /api/schedule/{channelId}/{contentId}
        [HttpDelete("{channelId}/{contentId}")]
        public async Task<IActionResult> Delete(Guid channelId, Guid contentId)
        {
            var deleted = await _service.DeleteAsync(channelId, contentId);
            if (!deleted)
                return NotFound("Schedule not found.");

            return Ok("Schedule deleted.");
        }
    }
}
