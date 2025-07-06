using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCSTest.DTOs;
using TCSTest.Services.Interfaces;

namespace TCSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentCatalogController : ControllerBase
    {
        private readonly ICatalogService _service;

        public ContentCatalogController(ICatalogService service)
        {
            _service = service;
        }

        // GET: /api/content
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contents = await _service.GetAllCatalogAsync();
            return Ok(contents);
        }

        // GET: /api/content/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var content = await _service.GetCatalogByIdAsync(id);
            return content == null ? NotFound() : Ok(content);
        }

        // POST: /api/content
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CatalogDto dto)
        {
            var id = await _service.AddCatalogAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = id }, null);
        }

        // PUT: /api/content/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CatalogDto dto)
        {
            await _service.UpdateCatalogAsync(id, dto);
            return NoContent();
        }

        // DELETE: /api/content/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteCatalogAsync(id);
            return NoContent();
        }
    }
}
