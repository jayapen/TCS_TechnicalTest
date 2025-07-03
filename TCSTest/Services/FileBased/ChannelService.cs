using TCSTest.Models;
using TCSTest.Repositories.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services.FileBased;

public class ChannelService : IChannelService
{
    private readonly IChannelRepository _repository;
    private readonly ILogger<ChannelService> _logger;

    public ChannelService(IChannelRepository repository, ILogger<ChannelService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<Channel>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Channel?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

    public async Task AddAsync(Channel channel)
    {
        channel.ChannelId = Guid.NewGuid();
        await _repository.AddAsync(channel);
        _logger.LogInformation("Channel added: {ChannelId}", channel.ChannelId);
    }

    public async Task<bool> UpdateAsync(Guid id, Channel channel)
    {
        var result = await _repository.UpdateAsync(id, channel);
        if (result)
            _logger.LogInformation("Channel updated: {ChannelId}", id);
        return result;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        if(result)
            _logger.LogInformation("Channel deleted: {ChannelId}", id);

        return result;
    }
}
