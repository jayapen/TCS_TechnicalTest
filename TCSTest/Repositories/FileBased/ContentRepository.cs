using TCSTest.Data;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;

namespace TCSTest.Repositories.FileBased;

public class ContentRepository : IContentRepository
{
    private const string FilePath = "Json Store/content_catalog.json";

    public async Task<List<Content>> GetAllAsync() => await FileDatabase.LoadAsync<Content>(FilePath);

    public async Task<Content?> GetByIdAsync(Guid id)
    {
        var all = await GetAllAsync();
        return all.FirstOrDefault(c => c.ContentId == id);
    }

    public async Task AddAsync(Content content)
    {
        var all = await GetAllAsync();
        all.Add(content);
        await FileDatabase.SaveAsync(FilePath, all);
    }

    public async Task<bool> UpdateAsync(Guid id, Content updated)
    {
        var all = await GetAllAsync();
        var index = all.FindIndex(c => c.ContentId == id);
        if (index == -1) return false;

        updated.ContentId = id; // Ensure ID is preserved
        all[index] = updated;
        await FileDatabase.SaveAsync(FilePath, all);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var contents = await FileDatabase.LoadAsync<Content>(FilePath);
        var content = contents.FirstOrDefault(c => c.ContentId == id);
        if (content == null) return false;

        contents.Remove(content);
        await FileDatabase.SaveAsync(FilePath, contents);
        return true;
    }

}
