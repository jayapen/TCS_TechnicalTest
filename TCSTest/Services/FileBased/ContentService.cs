using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services.FileBased;

public class ContentService : IContentService
{
    private readonly IContentRepository _repository;
    private readonly ILogger<ContentService> _logger;

    public ContentService(IContentRepository repository, ILogger<ContentService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<Content>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Content?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

    public async Task AddAsync(Content content)
    {
        content.ContentId = Guid.NewGuid();
        await _repository.AddAsync(content);
        _logger.LogInformation("Content added: {ContentId}", content.ContentId);
    }

    public async Task<bool> UpdateAsync(Guid id, Content content)
    {
        var result = await _repository.UpdateAsync(id, content);
        if (result)
            _logger.LogInformation("Content updated: {ContentId}", id);
        return result;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        if(result)
            _logger.LogInformation("Content deleted: {ContentId}", id);
        return result;
    }
}
