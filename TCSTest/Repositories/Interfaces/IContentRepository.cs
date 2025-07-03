using TCSTest.Models;

namespace TCSTest.Repositories.Interfaces;

public interface IContentRepository
{
    Task<List<Content>> GetAllAsync();
    Task<Content?> GetByIdAsync(Guid id);
    Task AddAsync(Content content);
    Task<bool> UpdateAsync(Guid id, Content content);
    Task<bool> DeleteAsync(Guid id);
}