using Microsoft.AspNetCore.Mvc;
using TCSTest.Models.DTO;
using TCSTest.Services.Interface;

namespace TCSTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelsController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _channelService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChannelDto dto)
        {
            try
            {
                var id = await _channelService.AddAsync(dto);
                return Ok(new { id = id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ChannelDto dto)
        {
            try
            {
                var success = await _channelService.UpdateAsync(id, dto);
                if (!success) return NotFound($"Channel with ID {id} not found.");

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _channelService.DeleteAsync(id);
            return success ? NoContent() : NotFound($"Channel with ID {id} not found.");
        }
    }
}
