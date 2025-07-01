using TCSTest.Models.Entities;

namespace TCSTest.Repository.Interface
{
    public interface IScheduleRepository
    {
        Task<List<ScheduleEntry>> GetAllAsync();
        Task SaveAllAsync(List<ScheduleEntry> entries);
    }
}
