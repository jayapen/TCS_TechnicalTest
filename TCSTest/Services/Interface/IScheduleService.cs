using TCSTest.Models.DTO;

namespace TCSTest.Services.Interface
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDto>> GetAllAsync();
        Task<IEnumerable<ScheduleDto>> GetByChannelAsync(Guid channelId);
        Task<IEnumerable<ScheduleDto>> GetCurrentlyAiringAsync(DateTime now);
        Task<bool> AddAsync(ScheduleDto dto);
        Task<bool> UpdateAsync(Guid channelId, Guid contentId, ScheduleDto dto);
        Task<bool> DeleteAsync(Guid channelId, Guid contentId);
    }
}