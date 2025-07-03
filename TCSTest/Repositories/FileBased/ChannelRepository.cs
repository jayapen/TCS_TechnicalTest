using TCSTest.Data;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;

namespace TCSTest.Repositories.FileBased;

public class ChannelRepository : IChannelRepository
{
    private const string FilePath = "Json Store/channels.json";

    public async Task<List<Channel>> GetAllAsync() => await FileDatabase.LoadAsync<Channel>(FilePath);

    public async Task<Channel?> GetByIdAsync(Guid id)
    {
        var all = await GetAllAsync();
        return all.FirstOrDefault(c => c.ChannelId == id);
    }

    public async Task AddAsync(Channel channel)
    {
        var all = await GetAllAsync();
        all.Add(channel);
        await FileDatabase.SaveAsync(FilePath, all);
    }

    public async Task<bool> UpdateAsync(Guid id, Channel updated)
    {
        var all = await GetAllAsync();
        var index = all.FindIndex(c => c.ChannelId == id);
        if (index == -1) return false;

        updated.ChannelId = id;
        all[index] = updated;
        await FileDatabase.SaveAsync(FilePath, all);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var channels = await FileDatabase.LoadAsync<Channel>(FilePath);
        var channel = channels.FirstOrDefault(c => c.ChannelId == id);
        if (channel is null) return false;

        channels.Remove(channel);
        await FileDatabase.SaveAsync(FilePath, channels);
        return true;
    }
}
