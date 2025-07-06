using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCSTest.DTOs;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _channelService.GetAllChannelAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChannelDto dto)
        {
            try
            {
                var id = await _channelService.AddChannelAsync(dto);
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
                var result = await _channelService.UpdateChannelAsync(id, dto);
                return Ok(result);
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
            var result = await _channelService.DeleteChannelAsync(id);
            return Ok(result);
        }
    }
}
