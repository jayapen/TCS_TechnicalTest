using TcsTest.Utilities.Models;

namespace TcsTest.RepositoryLayer.Interfaces
{
    public interface IContentCatalogRepo
    {
        Task<IEnumerable<ContentCatalog>> GetAllAsync();
        Task<ContentCatalog?> GetByIdAsync(Guid id);
        Task CreateAsync(ContentCatalog content);
        Task UpdateAsync(ContentCatalog content);
        Task<bool> DeleteAsync(Guid id);
    }
}
