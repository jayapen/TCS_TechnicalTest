using TCSTest.DTOs;
using TCSTest.Entities;
using TCSTest.Repository.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services.Implementation
{
    public class ContentCatalogService : ICatalogService
    {
        private readonly ICatalogRepository _Catrepository;

        public ContentCatalogService(ICatalogRepository catRepository)
        {
            _Catrepository = catRepository;
        }

        public async Task<IEnumerable<CatalogDto>> GetAllCatalogAsync()
        {
            var catalogContent = await _Catrepository.GetAllCatalogAsync();

            return catalogContent.Select(c => new CatalogDto
            {
                contentId = c.contentId,
                title = c.title,
                type = c.type,
                genre = c.genre,
                durationMinutes = c.durationMinutes,
                rating = c.rating,
                year = c.year,
                season = c.season,
                episode = c.episode
            });
        }

        public async Task<CatalogDto?> GetCatalogByIdAsync(Guid id)
        {
            var catalogContent = await _Catrepository.GetCatalogByIdAsync(id);
            return new CatalogDto
            {
                title = catalogContent.title,
                type = catalogContent.type,
                genre = catalogContent.genre,
                durationMinutes = catalogContent.durationMinutes,
                rating = catalogContent.rating,
                year = catalogContent.year,
                season = catalogContent.season,
                episode = catalogContent.episode
            };
        }

        public async Task<Guid> AddCatalogAsync(CatalogDto catDto)
        {
            var catalogContent = new Catalog
            {
                contentId = new Guid(),
                title = catDto.title,
                type = catDto.type,
                genre = catDto.genre,
                durationMinutes = catDto.durationMinutes,
                rating = catDto.rating,
                year = catDto.year,
                season = catDto.season,
                episode = catDto.episode
            };

            await _Catrepository.AddCatalogAsync(catalogContent);
            return catalogContent.contentId;
        }

        public async Task UpdateCatalogAsync(Guid id, CatalogDto catDto)
        {
            var catalogContent = new Catalog
            {
                contentId = id,
                title = catDto.title,
                type = catDto.type,
                genre = catDto.genre,
                durationMinutes = catDto.durationMinutes,
                rating = catDto.rating,
                year = catDto.year,
                season = catDto.season,
                episode = catDto.episode
            };

            await _Catrepository.UpdateCatalogAsync(catalogContent.contentId, catalogContent);
        }

        public async Task DeleteCatalogAsync(Guid id)
        {
            await _Catrepository.DeleteCatalogAsync(id);
        }
    }
}
