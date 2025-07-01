using TCSTest.Models.DTO;

namespace TCSTest.Services.Interface
{
    public interface IContentService
    {
        Task<IEnumerable<ContentDto>> GetAllAsync();
        Task<ContentDto?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(ContentDto dto);
        Task UpdateAsync(Guid id, ContentDto dto);
        Task DeleteAsync(Guid id);
    }
}