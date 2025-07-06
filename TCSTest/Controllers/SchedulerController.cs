using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TCSTest.DTOs;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly ISchedulerService _service;

        public SchedulerController(ISchedulerService service)
        {
            _service = service;
        }

        // GET /api/schedule
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _service.GetAllScheduleAsync();
            return Ok(schedules);
        }

        // GET /api/schedule/channel/{channelId}
        [HttpGet("channel/{channelId}")]
        public async Task<IActionResult> GetByChannel(Guid channelId)
        {
            var schedules = await _service.GetScheduleByChannelAsync(channelId);
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
        public async Task<IActionResult> Add([FromBody] ChannelSchedulerDto dto)
        {
            var result = await _service.AddScheduleAsync(dto);
            return Ok(result);
        }

        // PUT /api/schedule/{channelId}/{contentId}
        [HttpPut("{channelId}/{contentId}")]
        public async Task<IActionResult> Update(Guid channelId, Guid contentId, [FromBody] ChannelSchedulerDto dto)
        {
            var result = await _service.UpdateScheduleAsync(channelId, contentId, dto);
            return Ok(result);
        }

        // DELETE /api/schedule/{channelId}/{contentId}
        [HttpDelete("{channelId}/{contentId}")]
        public async Task<IActionResult> Delete(Guid channelId, Guid contentId)
        {
            var result = await _service.DeleteScheduleAsync(channelId, contentId);
            return Ok(result);
        }
    }
}
