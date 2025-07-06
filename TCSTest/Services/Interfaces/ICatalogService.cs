using TCSTest.DTOs;

namespace TCSTest.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogDto>> GetAllCatalogAsync();
        Task<CatalogDto?> GetCatalogByIdAsync(Guid id);
        Task<Guid> AddCatalogAsync(CatalogDto dto);
        Task UpdateCatalogAsync(Guid id, CatalogDto dto);
        Task DeleteCatalogAsync(Guid id);
    }
}
