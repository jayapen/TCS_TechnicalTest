using Microsoft.AspNetCore.Mvc;
using TCSTest.Models.DTO;
using TCSTest.Services.Interface;

namespace TCSTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _service;

        public ContentController(IContentService service)
        {
            _service = service;
        }

        // GET: /api/content
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contents = await _service.GetAllAsync();
            return Ok(contents);
        }

        // GET: /api/content/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var content = await _service.GetByIdAsync(id);
            return content == null ? NotFound() : Ok(content);
        }

        // POST: /api/content
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContentDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = id }, null);
        }

        // PUT: /api/content/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ContentDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE: /api/content/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
