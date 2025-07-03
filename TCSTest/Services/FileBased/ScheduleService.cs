using System.ComponentModel.DataAnnotations;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services.FileBased;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _repository;
    private readonly ILogger<ScheduleService> _logger;

    public ScheduleService(IScheduleRepository repository, ILogger<ScheduleService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<List<Schedule>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<List<Schedule>> GetByChannelIdAsync(Guid channelId) =>
        await _repository.GetByChannelIdAsync(channelId);

    public async Task<List<Schedule>> GetCurrentlyAiringAsync() =>
        await _repository.GetCurrentlyAiringAsync();

    public async Task AddAsync(Schedule schedule)
    {
        await _repository.AddAsync(schedule);
        _logger.LogInformation("Schedule added: ChannelId={ChannelId}, ContentId={ContentId}", schedule.ChannelId, schedule.ContentId);
    }

    public async Task<bool> UpdateAsync(Guid channelId, Guid contentId, Schedule schedule)
    {
        schedule.ChannelId = channelId;
        schedule.ContentId = contentId;
        var result = await _repository.UpdateAsync(channelId, contentId, schedule);
        if (result)
            _logger.LogInformation("Schedule updated: ChannelId={ChannelId}, ContentId={ContentId}", channelId, contentId);
        return result;
    }

    public async Task<bool> DeleteAsync(Guid channelId, Guid contentId)
    {
        var result = await _repository.DeleteAsync(channelId, contentId);
        if(result)
            _logger.LogInformation("Schedule deleted: ChannelId={ChannelId}, ContentId={ContentId}", channelId, contentId);
        return result;
    }
}
