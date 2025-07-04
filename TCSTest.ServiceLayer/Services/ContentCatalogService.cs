using TcsTest.RepositoryLayer.Interfaces;
using TcsTest.Utilities.DTO;
using TcsTest.Utilities.Models;
using TCSTest.ServiceLayer.Interfaces;

namespace TCSTest.ServiceLayer.Services
{
    public class ContentCatalogService : IContentCatalogService
    {
        private readonly IContentCatalogRepo _repository;

        public ContentCatalogService(IContentCatalogRepo repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ContentCatalog>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ContentCatalog?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ContentCatalog> CreateAsync(ContentCatalogDto dtoContent)
        {
            var content = new ContentCatalog
            {
                ContentId = Guid.NewGuid(),
                Title = dtoContent.Title,
                Type = dtoContent.Type,
                Genre = dtoContent.Genre,
                DurationMinutes = dtoContent.DurationMinutes,
                Rating = dtoContent.Rating,
                Year = dtoContent.Year,
                Season = dtoContent.Season,
                Episode = dtoContent.Episode
            };

            await _repository.CreateAsync(content);
            return content;
        }

        public async Task<bool> UpdateAsync(Guid id, ContentCatalogDto dtoContent)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            existing.Title = dtoContent.Title;
            existing.Type = dtoContent.Type;
            existing.Genre = dtoContent.Genre;
            existing.DurationMinutes = dtoContent.DurationMinutes;
            existing.Rating = dtoContent.Rating;
            existing.Year = dtoContent.Year;
            existing.Season = dtoContent.Season;
            existing.Episode = dtoContent.Episode;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
