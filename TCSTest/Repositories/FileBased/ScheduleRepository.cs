using TCSTest.Data;
using TCSTest.Models;
using TCSTest.Repositories.Interfaces;

namespace TCSTest.Repositories.FileBased;

public class ScheduleRepository : IScheduleRepository
{
    private const string FilePath = "Json Store/channel_schedule.json";

    public async Task<List<Schedule>> GetAllAsync() => await FileDatabase.LoadAsync<Schedule>(FilePath);

    public async Task<List<Schedule>> GetByChannelIdAsync(Guid channelId)
    {
        var all = await GetAllAsync();
        return all.Where(s => s.ChannelId == channelId).ToList();
    }

    public async Task<List<Schedule>> GetCurrentlyAiringAsync()
    {
        var all = await GetAllAsync();
        var now = DateTime.Now;
        return all.Where(s => s.AirTime <= now && now <= s.EndTime).Select(s => new Schedule
        {
            ChannelId = s.ChannelId,
            ContentId = s.ContentId,
            AirTime = s.AirTime,
            EndTime = s.EndTime
        }).ToList();
    }

    public async Task AddAsync(Schedule schedule)
    {
        var all = await GetAllAsync();
        all.Add(schedule);
        await FileDatabase.SaveAsync(FilePath, all);
    }

    public async Task<bool> UpdateAsync(Guid channelId, Guid contentId, Schedule updated)
    {
        var all = await GetAllAsync();
        var index = all.FindIndex(s => s.ChannelId == channelId && s.ContentId == contentId);
        if (index == -1) return false;

        all[index] = updated;
        await FileDatabase.SaveAsync(FilePath, all);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid channelId, Guid contentId)
    {
        var schedules = await FileDatabase.LoadAsync<Schedule>(FilePath);
        var schedule = schedules.FirstOrDefault(s => s.ChannelId == channelId && s.ContentId == contentId);
        if (schedule == null) return false;

        schedules.Remove(schedule);
        await FileDatabase.SaveAsync(FilePath, schedules);
        return true;
    }
}
