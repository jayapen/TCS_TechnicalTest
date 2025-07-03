using TCSTest.Models;

namespace TCSTest.Repositories.Interfaces;

public interface IScheduleRepository
{
    Task<List<Schedule>> GetAllAsync();
    Task<List<Schedule>> GetByChannelIdAsync(Guid channelId);
    Task<List<Schedule>> GetCurrentlyAiringAsync();
    Task AddAsync(Schedule schedule);
    Task<bool> UpdateAsync(Guid channelId, Guid contentId, Schedule schedule);
    Task<bool> DeleteAsync(Guid channelId, Guid contentId);
}