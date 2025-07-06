using TCSTest.Entities;

namespace TCSTest.Repository.Interfaces
{
    public interface ICatalogRepository
    {
        Task<List<Catalog>> GetAllCatalogAsync();
        Task<Catalog?> GetCatalogByIdAsync(Guid id);
        Task AddCatalogAsync(Catalog catalog);
        Task UpdateCatalogAsync(Guid id, Catalog catalog);
        Task DeleteCatalogAsync(Guid id);
    }
}
