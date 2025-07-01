using TCSTest.Models.DTO;
using TCSTest.Models.Entities;
using TCSTest.Repository.Interface;
using TCSTest.Services.Interface;

namespace TCSTest.Services.Implementation
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _repository;

        public ContentService(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ContentDto>> GetAllAsync()
        {
            var contents = await _repository.GetAllAsync();
            return contents.Select(c => new ContentDto
            {
                Title = c.Title,
                Type = c.Type,
                Genre = c.Genre,
                DurationMinutes = c.DurationMinutes,
                Rating = c.Rating,
                Year = c.Year,
                Season = c.Season,
                Episode = c.Episode
            });
        }

        public async Task<ContentDto?> GetByIdAsync(Guid id)
        {
            var content = await _repository.GetByIdAsync(id);
            if (content == null) 
                return null;
            return new ContentDto
            {
                Title = content.Title,
                Type = content.Type,
                Genre = content.Genre,
                DurationMinutes = content.DurationMinutes,
                Rating = content.Rating,
                Year = content.Year,
                Season = content.Season,
                Episode = content.Episode
            };
        }

        public async Task<Guid> CreateAsync(ContentDto dto)
        {
            var content = new Content
            {
                ContentId = Guid.NewGuid(),
                Title = dto.Title,
                Type = dto.Type,
                Genre = dto.Genre,
                DurationMinutes = dto.DurationMinutes,
                Rating = dto.Rating,
                Year = dto.Year,
                Season = dto.Season,
                Episode = dto.Episode
            };

            await _repository.AddAsync(content);
            return content.ContentId;
        }

        public async Task UpdateAsync(Guid id, ContentDto dto)
        {
            var content = new Content
            {
                ContentId = id,
                Title = dto.Title,
                Type = dto.Type,
                Genre = dto.Genre,
                DurationMinutes = dto.DurationMinutes,
                Rating = dto.Rating,
                Year = dto.Year,
                Season = dto.Season,
                Episode = dto.Episode
            };

            await _repository.UpdateAsync(content);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
