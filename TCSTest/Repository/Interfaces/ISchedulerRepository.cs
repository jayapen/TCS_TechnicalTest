using TCSTest.Entities;

namespace TCSTest.Repository.Interfaces
{
    public interface ISchedulerRepository
    {
        Task<List<ChannelScheduler>> GetAllSchedulerAsync();
        Task SaveScheduleAllAsync(ChannelScheduler schedulers);
        Task UpdateScheduleAsync(Guid channelId, Guid contentId, ChannelScheduler scheduler);
        Task DeleteScheduleAsync(Guid channelId, Guid contentId);
    }
}
