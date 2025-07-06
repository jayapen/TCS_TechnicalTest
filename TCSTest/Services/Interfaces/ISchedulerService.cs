using TCSTest.DTOs;

namespace TCSTest.Services.Interfaces
{
    public interface ISchedulerService
    {
        Task<IEnumerable<ChannelSchedulerDto>> GetAllScheduleAsync();
        Task<IEnumerable<ChannelSchedulerDto>> GetScheduleByChannelAsync(Guid channelId);
        Task<IEnumerable<ChannelSchedulerDto>> GetCurrentlyAiringAsync(DateTime now);
        Task<string> AddScheduleAsync(ChannelSchedulerDto dto);
        Task<string> UpdateScheduleAsync(Guid channelId, Guid contentId, ChannelSchedulerDto dto);
        Task<string> DeleteScheduleAsync(Guid channelId, Guid contentId);
    }
}
