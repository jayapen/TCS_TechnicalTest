using TCSTest.Models;

namespace TCSTest.Services.Interfaces;

public interface IScheduleService
{
    Task<List<Schedule>> GetAllAsync();
    Task<List<Schedule>> GetByChannelIdAsync(Guid channelId);
    Task<List<Schedule>> GetCurrentlyAiringAsync();
    Task AddAsync(Schedule schedule);
    Task<bool> UpdateAsync(Guid channelId, Guid contentId, Schedule schedule);
    Task<bool> DeleteAsync(Guid channelId, Guid contentId);
}