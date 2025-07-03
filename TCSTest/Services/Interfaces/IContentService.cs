using TCSTest.Models;

namespace TCSTest.Services.Interfaces;

public interface IContentService
{
    Task<List<Content>> GetAllAsync();
    Task<Content?> GetByIdAsync(Guid id);
    Task AddAsync(Content content);
    Task<bool> UpdateAsync(Guid id, Content content);
    Task<bool> DeleteAsync(Guid id);
}